using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Model
{
	public class Room
	{
		public int Id { get; set; }
		// Thêm giá trị khởi tạo để khắc phục lỗi
		public string Name { get; set; } = string.Empty;
		public int Capacity { get; set; }
		public string Type { get; set; } = string.Empty;
		public bool IsActive { get; set; }

		// Các thuộc tính này không còn trong CSDL nhưng để tránh lỗi, ta vẫn khởi tạo
		public int Rows { get; set; }
		public int SeatsPerRow { get; set; }
		public string ScreenSize { get; set; } = string.Empty;
		public bool Has3D { get; set; }
		public bool HasDolbySurround { get; set; }
		public string SeatingLayout { get; set; } = string.Empty;
		public decimal CleaningTime { get; set; }

		public override string ToString()
		{
			return Name;
		}

		public int GetCalculatedCapacity()
		{
			return Rows * SeatsPerRow;
		}
	}
}
