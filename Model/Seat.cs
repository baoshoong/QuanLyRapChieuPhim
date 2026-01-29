namespace WinFormsApp1.Model
{
	public class Seat
	{
		public int Id { get; set; }
		public int RoomId { get; set; }
		public string SeatNumber { get; set; } = string.Empty;
		public string RowNumber { get; set; } = string.Empty;
		public int ColumnNumber { get; set; }
		public string SeatType { get; set; } = "Standard";
	}
}
