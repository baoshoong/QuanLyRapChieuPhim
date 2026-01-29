#pragma warning disable CA1416
using System;
using System.Windows.Forms;
using WinFormsApp1.Model;

namespace WinFormsApp1.UI
{
	public partial class StaffDashboard : Form
	{
		private User currentUser;

		public StaffDashboard(User user)
		{
			InitializeComponent();
			currentUser = user;
		}

		private void StaffDashboard_Load(object? sender, EventArgs e)
		{
			ThemeManager.ApplyModernDarkTheme(this);
			lblWelcome.Text = $"Xin chào, {currentUser.FullName} ({currentUser.Role})";
		}

		private void btnSellTickets_Click(object? sender, EventArgs e)
		{
			// Sửa lỗi CS1729: Gọi constructor không có tham số
			FormSellTickets sellTicketsForm = new FormSellTickets(currentUser);
			sellTicketsForm.ShowDialog();
		}

		private void btnViewScreenings_Click(object? sender, EventArgs e)
		{
			FormViewScreenings viewScreeningsForm = new FormViewScreenings();
			viewScreeningsForm.ShowDialog();
		}

		private void btnViewFoods_Click(object? sender, EventArgs e)
		{
			FormViewFoods viewFoodsForm = new FormViewFoods();
			viewFoodsForm.ShowDialog();
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
