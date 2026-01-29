using System;

namespace WinFormsApp1.Model
{
	public class Movie
	{
		public int Id { get; set; }
		// Thêm giá trị khởi tạo để khắc phục lỗi non-nullable
		public string Title { get; set; } = string.Empty;
		public string Director { get; set; } = string.Empty;
		public string Genre { get; set; } = string.Empty;
		public int Duration { get; set; } // in minutes
		public string Description { get; set; } = string.Empty;
		public string Poster { get; set; } = string.Empty;
		public DateTime ReleaseDate { get; set; }
		public bool IsActive { get; set; }

		public override string ToString()
		{
			return Title;
		}
	}
}
