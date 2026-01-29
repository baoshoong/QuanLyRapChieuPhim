using Microsoft.Extensions.Configuration;
using System.IO;

namespace WinFormsApp1.Data
{
	// Lớp tĩnh này sẽ đọc file appsettings.json và lấy ra chuỗi kết nối
	public static class ConfigurationHelper
	{
		private static IConfiguration _configuration;

		static ConfigurationHelper()
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory()) // Thiết lập đường dẫn cơ sở là thư mục chạy ứng dụng
				.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

			_configuration = builder.Build();
		}

		// Phương thức tĩnh để lấy chuỗi kết nối từ tên đã định nghĩa trong file JSON
		public static string GetConnectionString()
		{
			// "DefaultConnection" là tên bạn đã đặt trong appsettings.json
			return _configuration.GetConnectionString("DefaultConnection");
		}
	}
}