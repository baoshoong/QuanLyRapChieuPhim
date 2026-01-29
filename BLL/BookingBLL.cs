using System;
using System.Collections.Generic;
using WinFormsApp1.DAL;
using WinFormsApp1.Model;

namespace WinFormsApp1.BLL
{
	public class BookingBLL
	{
		private BookingDAL bookingDAL;

		public BookingBLL()
		{
			bookingDAL = new BookingDAL();
		}

		public List<string> GetBookedSeats(int scheduleId)
		{
			return bookingDAL.GetBookedSeats(scheduleId);
		}

		public int CreateBooking(Booking booking)
		{
			// Validate booking data
			if (booking.Screening == null || booking.Screening.Id <= 0)
				throw new ArgumentException("Phải chọn một suất chiếu hợp lệ.");

			if (booking.BookingDetails == null || booking.BookingDetails.Count == 0)
				throw new ArgumentException("Phải chọn ít nhất một ghế.");

			if (string.IsNullOrWhiteSpace(booking.CustomerName))
				booking.CustomerName = "Khách lẻ";

			// Calculate total amount before saving
			decimal total = 0;
			foreach (var detail in booking.BookingDetails)
			{
				total += detail.Price;
			}
			foreach (var foodOrder in booking.FoodOrders)
			{
				total += foodOrder.Price * foodOrder.Quantity;
			}
			booking.TotalAmount = total;

			return bookingDAL.CreateBooking(booking);
		}
	}
}
