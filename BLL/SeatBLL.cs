using System;
using System.Collections.Generic;
using WinFormsApp1.DAL;
using WinFormsApp1.Model;

namespace WinFormsApp1.BLL
{
	public class SeatBLL
	{
		private SeatDAL seatDAL;

		public SeatBLL()
		{
			seatDAL = new SeatDAL();
		}

		public List<Seat> GetSeatsByRoomId(int roomId)
		{
			return seatDAL.GetSeatsByRoomId(roomId);
		 }

		/// <summary>
		/// Tự động tạo ghế cho phòng mới, dựa trên capacity
		/// </summary>
		public bool CreateSeatsForRoom(int roomId, int capacity)
		{
			// Tính toán số hàng và số ghế mỗi hàng dựa trên capacity
			// Cố gắng tạo layout hợp lý, gần vuông (số hàng gần bằng số cột)
			int rows = (int)Math.Ceiling(Math.Sqrt(capacity));
			int seatsPerRow = (int)Math.Ceiling((double)capacity / rows);
			
			// Đảm bảo tổng số ghế tạo ra bằng hoặc gần bằng capacity
			// Nếu capacity = 150, có thể tạo layout 10x15 = 150 ghế
			return seatDAL.CreateSeatsForRoom(roomId, rows, seatsPerRow);
		}
		
		/// <summary>
		/// Tạo ghế cho phòng với layout cụ thể
		/// </summary>
		public bool CreateSeatsForRoom(int roomId, int rows, int seatsPerRow)
		{
			return seatDAL.CreateSeatsForRoom(roomId, rows, seatsPerRow);
		}
		
		public bool DeleteSeatsByRoomId(int roomId)
		{
			return seatDAL.DeleteSeatsByRoomId(roomId);
		}
	}
}
