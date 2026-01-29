using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using WinFormsApp1.Data;
using WinFormsApp1.Model;

namespace WinFormsApp1.DAL
{
	public class SeatDAL
	{
		private string connectionString = ConfigurationHelper.GetConnectionString();

		public List<Seat> GetSeatsByRoomId(int roomId)
		{
			List<Seat> seats = new List<Seat>();
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					string query = "SELECT SeatID, RoomID, SeatNumber, RowNumber, ColumnNumber, SeatType FROM Seats WHERE RoomID = @RoomID ORDER BY RowNumber, ColumnNumber";
					using (SqlCommand command = new SqlCommand(query, connection))
					{
						command.Parameters.AddWithValue("@RoomID", roomId);
						using (SqlDataReader reader = command.ExecuteReader())
						{
							while (reader.Read())
							{
								seats.Add(new Seat
								{
									Id = Convert.ToInt32(reader["SeatID"]),
									RoomId = Convert.ToInt32(reader["RoomID"]),
									SeatNumber = reader["SeatNumber"].ToString() ?? "",
									RowNumber = reader["RowNumber"].ToString() ?? "",
									ColumnNumber = Convert.ToInt32(reader["ColumnNumber"]),
									SeatType = reader["SeatType"].ToString() ?? "Standard"
								});
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error in GetSeatsByRoomId: {ex.Message}");
				throw;
			}
			return seats;
		}

		/// <summary>
		/// Tạo ghế cho phòng mới dựa trên số hàng và số ghế mỗi hàng
		/// </summary>
		public bool CreateSeatsForRoom(int roomId, int rows, int seatsPerRow, string seatType = "Standard")
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					SqlTransaction transaction = connection.BeginTransaction();
					
					try
					{
						for (int rowIndex = 0; rowIndex < rows; rowIndex++)
						{
							char rowChar = (char)('A' + rowIndex);
							string rowNumber = rowChar.ToString();
							
							for (int colIndex = 1; colIndex <= seatsPerRow; colIndex++)
							{
								string seatNumber = rowNumber + colIndex.ToString();
								
								string query = @"INSERT INTO Seats (RoomID, SeatNumber, RowNumber, ColumnNumber, SeatType) 
                                               VALUES (@RoomID, @SeatNumber, @RowNumber, @ColumnNumber, @SeatType)";
								
								using (SqlCommand command = new SqlCommand(query, connection, transaction))
								{
									command.Parameters.AddWithValue("@RoomID", roomId);
									command.Parameters.AddWithValue("@SeatNumber", seatNumber);
									command.Parameters.AddWithValue("@RowNumber", rowNumber);
									command.Parameters.AddWithValue("@ColumnNumber", colIndex);
									command.Parameters.AddWithValue("@SeatType", seatType);
									command.ExecuteNonQuery();
								}
							}
						}
						
						transaction.Commit();
						return true;
					}
					catch (Exception)
					{
						transaction.Rollback();
						throw;
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error in CreateSeatsForRoom: {ex.Message}");
				throw;
			}
		}

		/// <summary>
		/// Xóa tất cả ghế của một phòng
		/// </summary>
		public bool DeleteSeatsByRoomId(int roomId)
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					string query = "DELETE FROM Seats WHERE RoomID = @RoomID";
					
					using (SqlCommand command = new SqlCommand(query, connection))
					{
						command.Parameters.AddWithValue("@RoomID", roomId);
						int rowsAffected = command.ExecuteNonQuery();
						return rowsAffected > 0;
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error in DeleteSeatsByRoomId: {ex.Message}");
				throw;
			}
		}

		/// <summary>
		/// Tạo ghế cho tất cả các phòng
		/// </summary>
		public void CreateSeatsForAllRooms()
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					// Lấy tất cả phòng
					string query = "SELECT RoomID, Capacity FROM Rooms";
					using (SqlCommand command = new SqlCommand(query, connection))
					{
						using (SqlDataReader reader = command.ExecuteReader())
						{
							while (reader.Read())
							{
								int roomId = Convert.ToInt32(reader["RoomID"]);
								int capacity = Convert.ToInt32(reader["Capacity"]);
								
								// Tính số hàng và cột dựa trên capacity
								int rows = 10; // Có thể điều chỉnh theo nhu cầu
								int seatsPerRow = (int)Math.Ceiling((double)capacity / rows);
								
								// Đóng reader trước khi thực hiện hành động khác
								reader.Close();
								
								// Xóa ghế cũ (nếu có)
								DeleteSeatsByRoomId(roomId);
								
								// Tạo ghế mới
								CreateSeatsForRoom(roomId, rows, seatsPerRow);
								
								
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error in CreateSeatsForAllRooms: {ex.Message}");
				throw;
			}
		}

		/// <summary>
		/// Xóa phòng và các phụ thuộc của nó
		/// </summary>
		public bool DeleteRoomWithDependencies(int roomId)
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					using (SqlTransaction transaction = connection.BeginTransaction())
					{
						try
						{
							// First check if there are any bookings for schedules in this room
							string checkBookingsQuery = @"
								SELECT COUNT(*) FROM Bookings b 
								JOIN Schedules s ON b.ScheduleID = s.ScheduleID 
								WHERE s.RoomID = @RoomID";
							
							using (SqlCommand checkCmd = new SqlCommand(checkBookingsQuery, connection, transaction))
							{
								checkCmd.Parameters.AddWithValue("@RoomID", roomId);
								int bookingsCount = (int)checkCmd.ExecuteScalar();
								
								if (bookingsCount > 0)
								{
									throw new InvalidOperationException("Không thể xóa phòng này vì đã có đặt vé cho lịch chiếu trong phòng này.");
								}
							}
							
							// Delete related schedules
							string deleteSchedulesQuery = "DELETE FROM Schedules WHERE RoomID = @RoomID";
							using (SqlCommand scheduleCmd = new SqlCommand(deleteSchedulesQuery, connection, transaction))
							{
								scheduleCmd.Parameters.AddWithValue("@RoomID", roomId);
								scheduleCmd.ExecuteNonQuery();
							}
							
							// Delete related seats
							string deleteSeatsQuery = "DELETE FROM Seats WHERE RoomID = @RoomID";
							using (SqlCommand seatCmd = new SqlCommand(deleteSeatsQuery, connection, transaction))
							{
								seatCmd.Parameters.AddWithValue("@RoomID", roomId);
								seatCmd.ExecuteNonQuery();
							}
							
							// Finally delete the room
							string deleteRoomQuery = "DELETE FROM Rooms WHERE RoomID = @RoomID";
							using (SqlCommand roomCmd = new SqlCommand(deleteRoomQuery, connection, transaction))
							{
								roomCmd.Parameters.AddWithValue("@RoomID", roomId);
								int rowsAffected = roomCmd.ExecuteNonQuery();
								
								transaction.Commit();
								return rowsAffected > 0;
							}
						}
						catch
						{
							transaction.Rollback();
							throw;
						}
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error in DeleteRoomWithDependencies: {ex.Message}");
				throw;
			}
		}
	}
}