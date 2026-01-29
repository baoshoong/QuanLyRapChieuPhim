using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using WinFormsApp1.Data;
using WinFormsApp1.Model;

namespace WinFormsApp1.DAL
{
	public class RoomDAL
	{
		private string connectionString = ConfigurationHelper.GetConnectionString();

		public List<Room> GetAllRooms()
		{
			List<Room> rooms = new List<Room>();
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					// Chỉ SELECT các cột thực sự tồn tại trong CSDL
					string query = @"SELECT RoomID, RoomName, Capacity, RoomType, IsActive FROM Rooms";

					using (SqlCommand command = new SqlCommand(query, connection))
					{
						using (SqlDataReader reader = command.ExecuteReader())
						{
							while (reader.Read())
							{
								Room room = new Room
								{
									Id = Convert.ToInt32(reader["RoomID"]),
									// Đọc từ các cột có tên đúng: RoomName, RoomType
									Name = reader["RoomName"].ToString() ?? string.Empty,
									Capacity = Convert.ToInt32(reader["Capacity"]),
									Type = reader["RoomType"].ToString() ?? string.Empty,
									IsActive = Convert.ToBoolean(reader["IsActive"])
									// Các thuộc tính chi tiết khác sẽ không được gán vì không có trong CSDL
								};
								rooms.Add(room);
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error in GetAllRooms: {ex.Message}");
				throw;
			}
			return rooms;
		}

		public Room? GetRoomById(int id)
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					// Sửa lại câu lệnh SELECT
					string query = @"SELECT RoomID, RoomName, Capacity, RoomType, IsActive FROM Rooms WHERE RoomID = @RoomID";

					using (SqlCommand command = new SqlCommand(query, connection))
					{
						command.Parameters.AddWithValue("@RoomID", id);
						using (SqlDataReader reader = command.ExecuteReader())
						{
							if (reader.Read())
							{
								return new Room
								{
									Id = Convert.ToInt32(reader["RoomID"]),
									Name = reader["RoomName"].ToString() ?? string.Empty,
									Capacity = Convert.ToInt32(reader["Capacity"]),
									Type = reader["RoomType"].ToString() ?? string.Empty,
									IsActive = Convert.ToBoolean(reader["IsActive"])
								};
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error in GetRoomById: {ex.Message}");
				throw;
			}
			return null;
		}

		public bool AddRoom(Room room)
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					// Chỉ INSERT vào các cột tồn tại
					string query = @"INSERT INTO Rooms (RoomName, Capacity, RoomType, IsActive) 
                                     VALUES (@RoomName, @Capacity, @RoomType, @IsActive);
                                     SELECT SCOPE_IDENTITY();";

					using (SqlCommand command = new SqlCommand(query, connection))
					{
						// Thêm các tham số tương ứng
						command.Parameters.AddWithValue("@RoomName", room.Name);
						command.Parameters.AddWithValue("@Capacity", room.Capacity);
						command.Parameters.AddWithValue("@RoomType", room.Type);
						command.Parameters.AddWithValue("@IsActive", room.IsActive);

						int newId = Convert.ToInt32(command.ExecuteScalar());
						room.Id = newId;
						return true;
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error in AddRoom: {ex.Message}");
				throw;
			}
		}

		public bool UpdateRoom(Room room)
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					// Chỉ UPDATE các cột tồn tại
					string query = @"UPDATE Rooms 
                                     SET RoomName = @RoomName, 
                                         Capacity = @Capacity, 
                                         RoomType = @RoomType, 
                                         IsActive = @IsActive 
                                     WHERE RoomID = @RoomID";

					using (SqlCommand command = new SqlCommand(query, connection))
					{
						command.Parameters.AddWithValue("@RoomID", room.Id);
						command.Parameters.AddWithValue("@RoomName", room.Name);
						command.Parameters.AddWithValue("@Capacity", room.Capacity);
						command.Parameters.AddWithValue("@RoomType", room.Type);
						command.Parameters.AddWithValue("@IsActive", room.IsActive);

						int rowsAffected = command.ExecuteNonQuery();
						return rowsAffected > 0;
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error in UpdateRoom: {ex.Message}");
				throw;
			}
		}

		public bool DeleteRoom(int roomId)
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					string query = "DELETE FROM Rooms WHERE RoomID = @RoomID";

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
				Console.WriteLine($"Error in DeleteRoom: {ex.Message}");
				throw;
			}
		}
	}
}