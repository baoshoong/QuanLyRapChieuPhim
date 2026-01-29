using System;
using System.Collections.Generic;

namespace WinFormsApp1.Model
{
	public class Booking
	{
		public int Id { get; set; }
		// Sửa tên thuộc tính từ ScreeningId thành ScheduleId để khớp với CSDL và các lớp khác
		public int ScheduleId { get; set; }
		public int? UserId { get; set; } // User who created the booking
		public DateTime BookingTime { get; set; }
		public decimal TotalAmount { get; set; }
		public string CustomerName { get; set; } = string.Empty;
		public string? CustomerPhone { get; set; }
		public string Status { get; set; } = string.Empty; // Reserved, Paid, Cancelled
		public int? VoucherId { get; set; }

		// Navigation properties
		public Screening? Screening { get; set; }
		public User? User { get; set; }
		public Voucher? Voucher { get; set; }
		// Khởi tạo List để tránh lỗi null reference
		public List<BookingDetail> BookingDetails { get; set; } = new List<BookingDetail>();
		public List<FoodOrder> FoodOrders { get; set; } = new List<FoodOrder>();
	}

	public class BookingDetail
	{
		public int Id { get; set; }
		public int BookingId { get; set; }
		public string SeatNumber { get; set; } = string.Empty;
		public decimal Price { get; set; }

		public Booking? Booking { get; set; }
	}

	public class FoodOrder
	{
		public int Id { get; set; }
		public int BookingId { get; set; }
		public int FoodId { get; set; }
		public int Quantity { get; set; }
		public decimal Price { get; set; }

		public Booking? Booking { get; set; }
		public Food? Food { get; set; }
	}
}
