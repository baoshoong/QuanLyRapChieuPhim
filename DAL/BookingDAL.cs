using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using WinFormsApp1.Data;
using WinFormsApp1.Model;

namespace WinFormsApp1.DAL
{
	// Đảm bảo namespace là DAL, không phải BLL
	public class BookingDAL
	{
		private string connectionString = ConfigurationHelper.GetConnectionString();
		/// <summary>
		/// Lấy danh sách các số ghế đã được đặt cho một suất chiếu cụ thể.
		/// </summary>
		public List<string> GetBookedSeats(int scheduleId)
		{
			List<string> bookedSeats = new List<string>();
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					string query = @"SELECT s.SeatNumber FROM Seats s
                                     JOIN BookingDetails bd ON s.SeatID = bd.SeatID
                                     JOIN Bookings b ON bd.BookingID = b.BookingID
                                     WHERE b.ScheduleID = @ScheduleID AND b.Status IN ('Completed', 'Paid')";

					using (SqlCommand command = new SqlCommand(query, connection))
					{
						command.Parameters.AddWithValue("@ScheduleID", scheduleId);
						using (SqlDataReader reader = command.ExecuteReader())
						{
							while (reader.Read())
							{
								bookedSeats.Add(reader["SeatNumber"]?.ToString() ?? "");
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error in GetBookedSeats: {ex.Message}");
				throw;
			}
			return bookedSeats;
		}

		/// <summary>
		/// Lưu toàn bộ thông tin đặt vé (vé, đồ ăn) vào CSDL trong một giao dịch.
		/// </summary>
		public int CreateBooking(Booking booking)
		{
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();
				SqlTransaction transaction = connection.BeginTransaction();

				try
				{
					// Bước 1: Insert vào bảng Bookings và lấy BookingID vừa tạo
					string bookingQuery = @"INSERT INTO Bookings (UserID, ScheduleID, BookingDate, TotalAmount, Status, PaymentStatus, CustomerName, CreatedBy)
                                            VALUES (@UserID, @ScheduleID, GETDATE(), @TotalAmount, 'Completed', 'Paid', @CustomerName, @CreatedBy);
                                            SELECT SCOPE_IDENTITY();";

					int bookingId;
					using (SqlCommand bookingCommand = new SqlCommand(bookingQuery, connection, transaction))
					{
						bookingCommand.Parameters.AddWithValue("@UserID", (object)booking.UserId ?? DBNull.Value);
						bookingCommand.Parameters.AddWithValue("@ScheduleID", booking.ScheduleId);
						bookingCommand.Parameters.AddWithValue("@TotalAmount", booking.TotalAmount);
						bookingCommand.Parameters.AddWithValue("@CustomerName", (object)booking.CustomerName ?? "Khách lẻ"); 
						bookingCommand.Parameters.AddWithValue("@CreatedBy", (object)booking.UserId ?? DBNull.Value);
						bookingId = Convert.ToInt32(bookingCommand.ExecuteScalar());
					}

					// Bước 2: Insert vào bảng BookingDetails cho mỗi ghế được chọn
					foreach (var detail in booking.BookingDetails)
					{
						string detailQuery = @"INSERT INTO BookingDetails (BookingID, SeatID, Price) 
                                               VALUES (@BookingID, (SELECT SeatID FROM Seats WHERE SeatNumber = @SeatNumber AND RoomID = @RoomID), @Price)";
						using (SqlCommand detailCommand = new SqlCommand(detailQuery, connection, transaction))
						{
							detailCommand.Parameters.AddWithValue("@BookingID", bookingId);
							detailCommand.Parameters.AddWithValue("@SeatNumber", detail.SeatNumber);
							detailCommand.Parameters.AddWithValue("@RoomID", booking.Screening.RoomId);
							detailCommand.Parameters.AddWithValue("@Price", detail.Price);
							detailCommand.ExecuteNonQuery();
						}
					}

					// Bước 3: Insert vào bảng FoodOrders cho mỗi món ăn được chọn
					if (booking.FoodOrders != null)
					{
						foreach (var foodOrder in booking.FoodOrders)
						{
							string foodQuery = @"INSERT INTO FoodOrders (BookingID, FoodID, Quantity, UnitPrice, TotalPrice)
                                                 VALUES (@BookingID, @FoodID, @Quantity, @UnitPrice, @TotalPrice)";
							using (SqlCommand foodCommand = new SqlCommand(foodQuery, connection, transaction))
							{
								foodCommand.Parameters.AddWithValue("@BookingID", bookingId);
								foodCommand.Parameters.AddWithValue("@FoodID", foodOrder.FoodId);
								foodCommand.Parameters.AddWithValue("@Quantity", foodOrder.Quantity);
								foodCommand.Parameters.AddWithValue("@UnitPrice", foodOrder.Price);
								foodCommand.Parameters.AddWithValue("@TotalPrice", foodOrder.Price * foodOrder.Quantity);
								foodCommand.ExecuteNonQuery();
							}
						}
					}

					// Nếu tất cả thành công, commit giao dịch
					transaction.Commit();
					return bookingId;
				}
				catch (Exception)
				{
					// Nếu có lỗi, rollback toàn bộ thay đổi
					transaction.Rollback();
					throw; // Ném lại lỗi để tầng trên xử lý
				}
			}
		}
	}
}
