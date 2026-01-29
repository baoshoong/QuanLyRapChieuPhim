#pragma warning disable CA1416 // Tắt cảnh báo tương thích nền tảng

using System;
using System.Windows.Forms;
using WinFormsApp1.Model;

namespace WinFormsApp1.UI
{
	public partial class ManagerDashboard : Form
	{
		private User currentUser;

		public ManagerDashboard(User user)
		{
			InitializeComponent();
			currentUser = user;
		}

		private void ManagerDashboard_Load(object? sender, EventArgs e)
		{
			ThemeManager.ApplyModernDarkTheme(this);
			lblWelcome.Text = $"Xin chào, {currentUser.FullName} ({currentUser.Role})";
		}

		// Mở Form Quản lý Người dùng (Form mới sẽ được cung cấp ở dưới)
		private void btnManageUsers_Click(object? sender, EventArgs e)
		{
			FormUsers usersForm = new FormUsers();
			usersForm.ShowDialog();
		}

		private void btnManageMovies_Click(object? sender, EventArgs e)
		{
			FormMovies moviesForm = new FormMovies();
			moviesForm.ShowDialog();
		}

		private void btnManageScreenings_Click(object? sender, EventArgs e)
		{
			FormScreenings screeningsForm = new FormScreenings();
			screeningsForm.ShowDialog();
		}

		private void btnManageRooms_Click(object? sender, EventArgs e)
		{
			FormRooms roomsForm = new FormRooms();
			roomsForm.ShowDialog();
		}

		private void btnManageFoods_Click(object? sender, EventArgs e)
		{
			FormFoods foodsForm = new FormFoods();
			foodsForm.ShowDialog();
		}

		// Mở Form Quản lý Vouchers
		private void btnManageVouchers_Click(object? sender, EventArgs e)
		{
			FormVouchers vouchersForm = new FormVouchers();
			vouchersForm.ShowDialog();
		}

		private void btnViewRevenue_Click(object? sender, EventArgs e)
		{
			MessageBox.Show("Chức năng Xem báo cáo doanh thu sẽ được triển khai trong phiên bản sau.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void btnSettings_Click(object? sender, EventArgs e)
		{
			MessageBox.Show("Chức năng Cài đặt hệ thống sẽ được triển khai trong phiên bản sau.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void btnViewBookings_Click(object? sender, EventArgs e)
		{
			MessageBox.Show("Chức năng Xem tất cả đặt vé sẽ được triển khai trong phiên bản sau.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void btnLogout_Click(object? sender, EventArgs e)
		{
			DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			if (dr == DialogResult.Yes)
			{
				this.Close();
			}
		}
	}
}
