using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.Data;
using WinFormsApp1.Model;

namespace WinFormsApp1.DAL
{
	public class ScreeningDAL
	{
		private string connectionString = ConfigurationHelper.GetConnectionString();
		private MovieDAL movieDAL;
		private RoomDAL roomDAL;

		public ScreeningDAL()
		{
			movieDAL = new MovieDAL();
			roomDAL = new RoomDAL();
		}

		public List<Screening> GetAllScreenings()
		{
			List<Screening> screenings = new List<Screening>();
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					string query = @"SELECT s.ScheduleID, s.MovieID, s.RoomID, s.ShowDate, s.ShowTime, s.Price, s.IsActive 
                                     FROM Schedules s
                                     ORDER BY s.ShowDate DESC, s.ShowTime DESC";

					using (SqlCommand command = new SqlCommand(query, connection))
					{
						using (SqlDataReader reader = command.ExecuteReader())
						{
							while (reader.Read())
							{
								Screening screening = new Screening
								{
									Id = Convert.ToInt32(reader["ScheduleID"]),
									MovieId = Convert.ToInt32(reader["MovieID"]),
									RoomId = Convert.ToInt32(reader["RoomID"]),
									TicketPrice = Convert.ToDecimal(reader["Price"]),
									IsActive = Convert.ToBoolean(reader["IsActive"])
								};
								DateTime date = (DateTime)reader["ShowDate"];
								TimeSpan time = (TimeSpan)reader["ShowTime"];
								screening.StartTime = date.Add(time);
								screenings.Add(screening);
							}
						}
					}

					foreach (var screening in screenings)
					{
						screening.Movie = movieDAL.GetMovieById(screening.MovieId);
						screening.Room = roomDAL.GetRoomById(screening.RoomId);

						// ---- THÊM ĐOẠN CODE TÍNH TOÁN ENDTIME DƯỚI ĐÂY ----
						if (screening.Movie != null)
						{
							// Tính EndTime bằng cách lấy StartTime cộng với thời lượng phim (tính bằng phút)
							screening.EndTime = screening.StartTime.AddMinutes(screening.Movie.Duration);
						}
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error in GetAllScreenings: {ex.Message}");
				throw;
			}
			return screenings;
		}

		public Screening? GetScreeningById(int id)
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					string query = @"SELECT s.ScheduleID, s.MovieID, s.RoomID, s.ShowDate, s.ShowTime, s.Price, s.IsActive 
                                     FROM Schedules s
                                     WHERE s.ScheduleID = @ScheduleID";

					using (SqlCommand command = new SqlCommand(query, connection))
					{
						command.Parameters.AddWithValue("@ScheduleID", id);
						using (SqlDataReader reader = command.ExecuteReader())
						{
							if (reader.Read())
							{
								Screening screening = new Screening
								{
									Id = Convert.ToInt32(reader["ScheduleID"]),
									MovieId = Convert.ToInt32(reader["MovieID"]),
									RoomId = Convert.ToInt32(reader["RoomID"]),
									TicketPrice = Convert.ToDecimal(reader["Price"]),
									IsActive = Convert.ToBoolean(reader["IsActive"])
								};
								DateTime date = (DateTime)reader["ShowDate"];
								TimeSpan time = (TimeSpan)reader["ShowTime"];
								screening.StartTime = date.Add(time);
								screening.Movie = movieDAL.GetMovieById(screening.MovieId);
								screening.Room = roomDAL.GetRoomById(screening.RoomId);
								return screening;
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error in GetScreeningById: {ex.Message}");
				throw;
			}
			return null;
		}

		public List<Screening> GetScreeningsByMovieId(int movieId)
		{
			List<Screening> screenings = new List<Screening>();
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					string query = @"SELECT s.ScheduleID, s.MovieID, s.RoomID, s.ShowDate, s.ShowTime, s.Price, s.IsActive 
                                     FROM Schedules s
                                     WHERE s.MovieID = @MovieID AND s.IsActive = 1
                                     ORDER BY s.ShowDate, s.ShowTime";

					using (SqlCommand command = new SqlCommand(query, connection))
					{
						command.Parameters.AddWithValue("@MovieID", movieId);
						using (SqlDataReader reader = command.ExecuteReader())
						{
							while (reader.Read())
							{
								Screening screening = new Screening
								{
									Id = Convert.ToInt32(reader["ScheduleID"]),
									MovieId = movieId,
									RoomId = Convert.ToInt32(reader["RoomID"]),
									TicketPrice = Convert.ToDecimal(reader["Price"]),
									IsActive = Convert.ToBoolean(reader["IsActive"])
								};
								DateTime date = (DateTime)reader["ShowDate"];
								TimeSpan time = (TimeSpan)reader["ShowTime"];
								screening.StartTime = date.Add(time);
								screenings.Add(screening);
							}
						}
					}

					Movie movie = movieDAL.GetMovieById(movieId);
					foreach (var screening in screenings)
					{
						screening.Movie = movie;
						screening.Room = roomDAL.GetRoomById(screening.RoomId);
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error in GetScreeningsByMovieId: {ex.Message}");
				throw;
			}
			return screenings;
		}

		public List<Screening> GetUpcomingScreenings()
		{
			List<Screening> screenings = new List<Screening>();
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					// Sửa lại câu lệnh WHERE để kết hợp ShowDate và ShowTime
					string query = @"SELECT s.ScheduleID, s.MovieID, s.RoomID, s.ShowDate, s.ShowTime, s.Price, s.IsActive 
                                     FROM Schedules s
                                     WHERE CAST(s.ShowDate AS DATETIME) + CAST(s.ShowTime AS DATETIME) > @CurrentTime AND s.IsActive = 1
                                     ORDER BY s.ShowDate, s.ShowTime";

					using (SqlCommand command = new SqlCommand(query, connection))
					{
						command.Parameters.AddWithValue("@CurrentTime", DateTime.Now);
						using (SqlDataReader reader = command.ExecuteReader())
						{
							while (reader.Read())
							{
								Screening screening = new Screening
								{
									Id = Convert.ToInt32(reader["ScheduleID"]),
									MovieId = Convert.ToInt32(reader["MovieID"]),
									RoomId = Convert.ToInt32(reader["RoomID"]),
									TicketPrice = Convert.ToDecimal(reader["Price"]),
									IsActive = Convert.ToBoolean(reader["IsActive"])
								};
								DateTime date = (DateTime)reader["ShowDate"];
								TimeSpan time = (TimeSpan)reader["ShowTime"];
								screening.StartTime = date.Add(time);
								screenings.Add(screening);
							}
						}
					}

					foreach (var screening in screenings)
					{
						screening.Movie = movieDAL.GetMovieById(screening.MovieId);
						screening.Room = roomDAL.GetRoomById(screening.RoomId);
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error in GetUpcomingScreenings: {ex.Message}");
				throw;
			}
			return screenings;
		}

		public bool AddScreening(Screening screening)
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					string query = @"INSERT INTO Schedules (MovieID, RoomID, ShowDate, ShowTime, Price, IsActive) 
                                     VALUES (@MovieID, @RoomID, @ShowDate, @ShowTime, @Price, @IsActive);
                                     SELECT SCOPE_IDENTITY();";

					using (SqlCommand command = new SqlCommand(query, connection))
					{
						command.Parameters.AddWithValue("@MovieID", screening.MovieId);
						command.Parameters.AddWithValue("@RoomID", screening.RoomId);
						command.Parameters.AddWithValue("@ShowDate", screening.StartTime.Date);
						command.Parameters.AddWithValue("@ShowTime", screening.StartTime.TimeOfDay);
						command.Parameters.AddWithValue("@Price", screening.TicketPrice);
						command.Parameters.AddWithValue("@IsActive", screening.IsActive);
						int newId = Convert.ToInt32(command.ExecuteScalar());
						screening.Id = newId;
						return true;
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error in AddScreening: {ex.Message}");
				throw;
			}
		}

		public bool UpdateScreening(Screening screening)
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					string query = @"UPDATE Schedules 
                                     SET MovieID = @MovieID, 
                                         RoomID = @RoomID, 
                                         ShowDate = @ShowDate, 
                                         ShowTime = @ShowTime, 
                                         Price = @Price, 
                                         IsActive = @IsActive 
                                     WHERE ScheduleID = @ScheduleID";

					using (SqlCommand command = new SqlCommand(query, connection))
					{
						command.Parameters.AddWithValue("@ScheduleID", screening.Id);
						command.Parameters.AddWithValue("@MovieID", screening.MovieId);
						command.Parameters.AddWithValue("@RoomID", screening.RoomId);
						command.Parameters.AddWithValue("@ShowDate", screening.StartTime.Date);
						command.Parameters.AddWithValue("@ShowTime", screening.StartTime.TimeOfDay);
						command.Parameters.AddWithValue("@Price", screening.TicketPrice);
						command.Parameters.AddWithValue("@IsActive", screening.IsActive);
						int rowsAffected = command.ExecuteNonQuery();
						return rowsAffected > 0;
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error in UpdateScreening: {ex.Message}");
				throw;
			}
		}

		public bool DeleteScreening(int screeningId)
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					string query = "DELETE FROM Schedules WHERE ScheduleID = @ScheduleID";

					using (SqlCommand command = new SqlCommand(query, connection))
					{
						command.Parameters.AddWithValue("@ScheduleID", screeningId);
						int rowsAffected = command.ExecuteNonQuery();
						return rowsAffected > 0;
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error in DeleteScreening: {ex.Message}");
				throw;
			}
		}

		public bool IsRoomAvailable(int roomId, DateTime startTime, DateTime endTime, int? excludeScreeningId = null)
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					// Câu lệnh này phức tạp vì cần JOIN với bảng Movies để lấy Duration và tính toán thời gian kết thúc của các suất chiếu đã có
					string query = @"SELECT COUNT(*) 
                                     FROM Schedules s
                                     JOIN Movies m ON s.MovieID = m.MovieID
                                     WHERE s.RoomID = @RoomID AND s.IsActive = 1
                                     AND (
                                        -- @startTime và @endTime là thời gian của suất chiếu MỚI
                                        -- existingStartTime và existingEndTime là thời gian của suất chiếu ĐÃ CÓ trong CSDL
                                        -- Một xung đột xảy ra nếu: (StartTimeMới < EndTimeCũ) AND (EndTimeMới > StartTimeCũ)
                                        @startTime < DATEADD(minute, m.Duration, CAST(s.ShowDate AS DATETIME) + CAST(s.ShowTime AS DATETIME))
                                        AND
                                        @endTime > (CAST(s.ShowDate AS DATETIME) + CAST(s.ShowTime AS DATETIME))
                                     )";

					if (excludeScreeningId.HasValue)
					{
						query += " AND s.ScheduleID <> @ExcludeScheduleID";
					}

					using (SqlCommand command = new SqlCommand(query, connection))
					{
						command.Parameters.AddWithValue("@RoomID", roomId);
						command.Parameters.AddWithValue("@startTime", startTime);
						command.Parameters.AddWithValue("@endTime", endTime);

						if (excludeScreeningId.HasValue)
						{
							command.Parameters.AddWithValue("@ExcludeScheduleID", excludeScreeningId.Value);
						}

						int conflictCount = Convert.ToInt32(command.ExecuteScalar());
						return conflictCount == 0;
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error in IsRoomAvailable: {ex.Message}");
				throw;
			}
		}

		public List<Screening> GetScreeningsByMovieIdForToday(int movieId)
		{
			List<Screening> screenings = new List<Screening>();
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					// Thêm điều kiện WHERE s.ShowDate = CAST(GETDATE() AS DATE)
					string query = @"SELECT s.ScheduleID, s.MovieID, s.RoomID, s.ShowDate, s.ShowTime, s.Price, s.IsActive 
                             FROM Schedules s
                             WHERE s.MovieID = @MovieID 
                               AND s.ShowDate = CAST(GETDATE() AS DATE) 
                               AND s.IsActive = 1
                             ORDER BY s.ShowTime";

					using (SqlCommand command = new SqlCommand(query, connection))
					{
						command.Parameters.AddWithValue("@MovieID", movieId);
						using (SqlDataReader reader = command.ExecuteReader())
						{
							while (reader.Read())
							{
								Screening screening = new Screening
								{
									Id = Convert.ToInt32(reader["ScheduleID"]),
									MovieId = Convert.ToInt32(reader["MovieID"]),
									RoomId = Convert.ToInt32(reader["RoomID"]),
									TicketPrice = Convert.ToDecimal(reader["Price"]),
									IsActive = Convert.ToBoolean(reader["IsActive"])
								};
								DateTime date = (DateTime)reader["ShowDate"];
								TimeSpan time = (TimeSpan)reader["ShowTime"];
								screening.StartTime = date.Add(time);
								screenings.Add(screening);
							}
						}
					}

					// Tải thông tin Movie và Room liên quan
					foreach (var screening in screenings)
					{
						screening.Movie = movieDAL.GetMovieById(screening.MovieId);
						screening.Room = roomDAL.GetRoomById(screening.RoomId);
						if (screening.Movie != null)
						{
							screening.EndTime = screening.StartTime.AddMinutes(screening.Movie.Duration);
						}
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error in GetScreeningsByMovieIdForToday: {ex.Message}");
				throw;
			}
			return screenings;
		}

		public List<Screening> GetScreeningsForToday()
		{
			List<Screening> screenings = new List<Screening>();
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					string query = @"SELECT s.ScheduleID, s.MovieID, s.RoomID, s.ShowDate, s.ShowTime, s.Price, s.IsActive 
                                     FROM Schedules s
                                     WHERE s.ShowDate = CAST(GETDATE() AS DATE) AND s.IsActive = 1
                                     ORDER BY s.ShowTime";

					using (SqlCommand command = new SqlCommand(query, connection))
					{
						using (SqlDataReader reader = command.ExecuteReader())
						{
							while (reader.Read())
							{
								Screening screening = new Screening
								{
									Id = Convert.ToInt32(reader["ScheduleID"]),
									MovieId = Convert.ToInt32(reader["MovieID"]),
									RoomId = Convert.ToInt32(reader["RoomID"]),
									TicketPrice = Convert.ToDecimal(reader["Price"]),
									IsActive = Convert.ToBoolean(reader["IsActive"])
								};
								DateTime date = (DateTime)reader["ShowDate"];
								TimeSpan time = (TimeSpan)reader["ShowTime"];
								screening.StartTime = date.Add(time);
								screenings.Add(screening);
							}
						}
					}

					foreach (var screening in screenings)
					{
						screening.Movie = movieDAL.GetMovieById(screening.MovieId);
						screening.Room = roomDAL.GetRoomById(screening.RoomId);
						if (screening.Movie != null)
						{
							screening.EndTime = screening.StartTime.AddMinutes(screening.Movie.Duration);
						}
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error in GetScreeningsForToday: {ex.Message}");
				throw;
			}
			return screenings;
		}
	}
}