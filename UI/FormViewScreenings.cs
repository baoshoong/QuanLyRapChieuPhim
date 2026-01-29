using System;
using System.Windows.Forms;
using WinFormsApp1.BLL;

namespace WinFormsApp1.UI
{
	public partial class FormViewScreenings : Form
	{
		private ScreeningBLL screeningBLL;

		public FormViewScreenings()
		{
			InitializeComponent();
			screeningBLL = new ScreeningBLL();
		}

		private void FormViewScreenings_Load(object? sender, EventArgs e)
		{
			ThemeManager.ApplyModernDarkTheme(this);
			LoadScreenings();
		}

		private void LoadScreenings()
		{
			try
			{
				
				//dgvScreenings.DataSource = screeningBLL.GetScreeningsByMovieIdForToday;
				dgvScreenings.DataSource = screeningBLL.GetScreeningsForToday(); // Lấy tất cả lịch chiếu trong ngày hôm nay
				FormatDataGridView();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi khi tải lịch chiếu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void FormatDataGridView()
		{
			if (dgvScreenings.Columns.Count == 0) return;

			string[] columnsToHide = { "Id", "MovieId", "RoomId", "IsActive" };
			foreach (var colName in columnsToHide)
			{
				if (dgvScreenings.Columns.Contains(colName))
				{
					dgvScreenings.Columns[colName].Visible = false;
				}
			}

			if (dgvScreenings.Columns.Contains("Movie"))
				dgvScreenings.Columns["Movie"].HeaderText = "Phim";

			if (dgvScreenings.Columns.Contains("Room"))
				dgvScreenings.Columns["Room"].HeaderText = "Phòng";

			if (dgvScreenings.Columns.Contains("StartTime"))
			{
				dgvScreenings.Columns["StartTime"].HeaderText = "Thời gian bắt đầu";
				dgvScreenings.Columns["StartTime"].DefaultCellStyle.Format = "HH:mm"; // Chỉ hiển thị giờ
			}

			if (dgvScreenings.Columns.Contains("EndTime"))
			{
				dgvScreenings.Columns["EndTime"].HeaderText = "Thời gian kết thúc";
				dgvScreenings.Columns["EndTime"].DefaultCellStyle.Format = "HH:mm"; // Chỉ hiển thị giờ
			}

			if (dgvScreenings.Columns.Contains("TicketPrice"))
			{
				dgvScreenings.Columns["TicketPrice"].HeaderText = "Giá vé";
				dgvScreenings.Columns["TicketPrice"].DefaultCellStyle.Format = "N0";
			}

			dgvScreenings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
		}

		private void btnBack_Click(object? sender, EventArgs e)
		{
			this.Close();
		}
	}
}
