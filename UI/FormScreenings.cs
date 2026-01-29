#pragma warning disable CA1416
using System;
using System.Drawing;
using System.Windows.Forms;
using WinFormsApp1.BLL;
using WinFormsApp1.Model;

namespace WinFormsApp1.UI
{
	public partial class FormScreenings : Form
	{
		private ScreeningBLL screeningBLL;
		private MovieBLL movieBLL;
		private RoomBLL roomBLL;
		private Screening? currentScreening;

		

		public FormScreenings()
		{
			InitializeComponent();
			screeningBLL = new ScreeningBLL();
			movieBLL = new MovieBLL();
			roomBLL = new RoomBLL();

			// Gán sự kiện cho các control để tự động cập nhật
			this.cboMovie.SelectedIndexChanged += new System.EventHandler(this.cboMovie_SelectedIndexChanged);
			this.dtpStartDate.ValueChanged += new System.EventHandler(this.dtpStartDate_ValueChanged);
			this.dtpStartTime.ValueChanged += new System.EventHandler(this.dtpStartTime_ValueChanged);
		}

		private void FormScreenings_Load(object? sender, EventArgs e)
		 {
			ThemeManager.ApplyModernDarkTheme(this);
			LoadMovies();
			LoadRooms();
			LoadScreenings();
			SetupDateTimeDefaults();
			ClearForm();
		
		}


		private void LoadMovies()
		{
			cboMovie.DataSource = movieBLL.GetActiveMovies();
			cboMovie.DisplayMember = "Title";
			cboMovie.ValueMember = "Id";
			cboMovie.SelectedIndex = -1;
		}

		private void LoadRooms()
		{
			cboRoom.DataSource = roomBLL.GetActiveRooms();
			cboRoom.DisplayMember = "Name";
			cboRoom.ValueMember = "Id";
			cboRoom.SelectedIndex = -1;
		}

		private void LoadScreenings()
		{
			dgvScreenings.DataSource = screeningBLL.GetAllScreenings();
			FormatDataGridView();
		}

		private void SetupDateTimeDefaults()
		{
			dtpStartDate.Value = DateTime.Today;
			dtpStartTime.Value = DateTime.Today.AddHours(8);
			nudTicketPrice.Value = 80000;
			dtpStartDate.MinDate = DateTime.Today;
		}

		private void FormatDataGridView()
		{
			if (dgvScreenings.Columns.Count == 0) return;

			dgvScreenings.Columns["Id"].HeaderText = "ID";
			dgvScreenings.Columns["MovieId"].Visible = false;
			dgvScreenings.Columns["RoomId"].Visible = false;

			if (dgvScreenings.Columns.Contains("Movie"))
			{
				dgvScreenings.Columns["Movie"].HeaderText = "Phim";
				dgvScreenings.Columns["Movie"].DisplayIndex = 1;
			}

			if (dgvScreenings.Columns.Contains("Room"))
			{
				dgvScreenings.Columns["Room"].HeaderText = "Phòng";
				dgvScreenings.Columns["Room"].DisplayIndex = 2;
			}

			dgvScreenings.Columns["StartTime"].HeaderText = "Thời gian bắt đầu";
			dgvScreenings.Columns["StartTime"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

			dgvScreenings.Columns["EndTime"].HeaderText = "Thời gian kết thúc";
			dgvScreenings.Columns["EndTime"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

			dgvScreenings.Columns["TicketPrice"].HeaderText = "Giá vé";
			dgvScreenings.Columns["TicketPrice"].DefaultCellStyle.Format = "N0";

			dgvScreenings.Columns["IsActive"].HeaderText = "Còn hoạt động";
			dgvScreenings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

			// Định dạng màu cho các trạng thái
			dgvScreenings.CellFormatting += (s, e) =>
			{
				if (e.ColumnIndex == dgvScreenings.Columns["IsActive"].Index && e.Value != null)
				{
					if (Convert.ToBoolean(e.Value))
					{
						e.CellStyle.ForeColor = ThemeManager.ActiveColor;
						e.CellStyle.Font = new Font(dgvScreenings.Font, FontStyle.Bold);
					}
					else
					{
						e.CellStyle.ForeColor = ThemeManager.DangerColor;
					}
				}

				// Định dạng màu cho các suất chiếu đã qua
				if (e.ColumnIndex == dgvScreenings.Columns["StartTime"].Index && e.Value != null)
				{
					DateTime startTime = Convert.ToDateTime(e.Value);
					if (startTime < DateTime.Now)
					{
						e.CellStyle.ForeColor = Color.Gray;
						e.CellStyle.Font = new Font(dgvScreenings.Font, FontStyle.Italic);
					}
				}
			};
		}

		private void ClearForm()
		{
			txtScreeningId.Text = string.Empty;
			cboMovie.SelectedIndex = -1;
			cboRoom.SelectedIndex = -1;
			SetupDateTimeDefaults();
			chkIsActive.Checked = true;
			currentScreening = null;
			btnAdd.Enabled = true;
			btnUpdate.Enabled = false;
			btnDelete.Enabled = false;
			errorProvider.Clear();
			UpdateCalculatedEndTime();
		}

		private void dgvScreenings_CellClick(object? sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0 && dgvScreenings.Rows[e.RowIndex].DataBoundItem is Screening selectedScreening)
			{
				currentScreening = selectedScreening;
				txtScreeningId.Text = currentScreening.Id.ToString();
				cboMovie.SelectedValue = currentScreening.MovieId;
				cboRoom.SelectedValue = currentScreening.RoomId;
				dtpStartDate.MinDate = new DateTime(1753, 1, 1);
				dtpStartDate.Value = currentScreening.StartTime.Date;
				dtpStartTime.Value = DateTime.Today.Add(currentScreening.StartTime.TimeOfDay);
				nudTicketPrice.Value = currentScreening.TicketPrice;
				chkIsActive.Checked = currentScreening.IsActive;
				btnAdd.Enabled = false;
				btnUpdate.Enabled = true;
				btnDelete.Enabled = true;
				UpdateCalculatedEndTime();

				bool isPast = currentScreening.StartTime <= DateTime.Now;
				if (isPast)
				{
					MessageBox.Show("Lịch chiếu này đã diễn ra. Bạn chỉ có thể xem thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				cboMovie.Enabled = !isPast;
				cboRoom.Enabled = !isPast;
				dtpStartDate.Enabled = !isPast;
				dtpStartTime.Enabled = !isPast;
				btnUpdate.Enabled = !isPast;
				if (!isPast)
				{
					dtpStartDate.MinDate = DateTime.Today;
				}
			}
		}

		private void UpdateCalculatedEndTime()
		{
			if (cboMovie.SelectedItem is Movie selectedMovie)
			{
				DateTime startDateTime = CombineDateAndTime(dtpStartDate.Value, dtpStartTime.Value);
				DateTime endDateTime = startDateTime.AddMinutes(selectedMovie.Duration);
				lblEndTime.Text = $"Kết thúc lúc: {endDateTime:HH:mm} ngày {endDateTime:dd/MM/yyyy}";
			}
			else
			{
				lblEndTime.Text = "Kết thúc lúc: --";
			}
		}

		private void cboMovie_SelectedIndexChanged(object? sender, EventArgs e)
		{
			UpdateCalculatedEndTime();
		}

		private void dtpStartDate_ValueChanged(object? sender, EventArgs e)
		{
			UpdateCalculatedEndTime();
		}

		private void dtpStartTime_ValueChanged(object? sender, EventArgs e)
		{
			UpdateCalculatedEndTime();
		}

		private void btnAdd_Click(object? sender, EventArgs e)
		{
			try
			{
				if (ValidateInputs())
				{
					Screening screening = new Screening
					{
						MovieId = Convert.ToInt32(cboMovie.SelectedValue),
						RoomId = Convert.ToInt32(cboRoom.SelectedValue),
						StartTime = CombineDateAndTime(dtpStartDate.Value, dtpStartTime.Value),
						TicketPrice = nudTicketPrice.Value,
						IsActive = chkIsActive.Checked
					};
					if (screeningBLL.AddScreening(screening))
					{
						MessageBox.Show("Thêm lịch chiếu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
						LoadScreenings();
						ClearForm();
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnUpdate_Click(object? sender, EventArgs e)
		{
			if (currentScreening == null) return;
			try
			{
				if (ValidateInputs())
				{
					currentScreening.MovieId = Convert.ToInt32(cboMovie.SelectedValue);
					currentScreening.RoomId = Convert.ToInt32(cboRoom.SelectedValue);
					currentScreening.StartTime = CombineDateAndTime(dtpStartDate.Value, dtpStartTime.Value);
					currentScreening.TicketPrice = nudTicketPrice.Value;
					currentScreening.IsActive = chkIsActive.Checked;
					if (screeningBLL.UpdateScreening(currentScreening))
					{
						MessageBox.Show("Cập nhật lịch chiếu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
						LoadScreenings();
						ClearForm();
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnDelete_Click(object? sender, EventArgs e)
		{
			if (currentScreening == null) return;
			if (currentScreening.StartTime <= DateTime.Now)
			{
				MessageBox.Show("Không thể xóa lịch chiếu đã hoặc đang diễn ra.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa lịch chiếu này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (dr == DialogResult.Yes)
			{
				try
				{
					if (screeningBLL.DeleteScreening(currentScreening.Id))
					{
						MessageBox.Show("Xóa lịch chiếu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
						LoadScreenings();
						ClearForm();
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void btnClear_Click(object? sender, EventArgs e)
		{
			ClearForm();
		}

		private void btnBack_Click(object? sender, EventArgs e)
		{
			this.Close();
		}

		private bool ValidateInputs()
		{
			errorProvider.Clear();
			bool isValid = true;

			if (cboMovie.SelectedIndex == -1)
			{
				errorProvider.SetError(cboMovie, "Vui lòng chọn phim");
				isValid = false;
			}

			if (cboRoom.SelectedIndex == -1)
			{
				errorProvider.SetError(cboRoom, "Vui lòng chọn phòng");
				isValid = false;
			}

			if (nudTicketPrice.Value <= 0)
			{
				errorProvider.SetError(nudTicketPrice, "Giá vé phải lớn hơn 0");
				isValid = false;
			}

			DateTime selectedDateTime = CombineDateAndTime(dtpStartDate.Value, dtpStartTime.Value);
			if (selectedDateTime <= DateTime.Now)
			{
				errorProvider.SetError(dtpStartTime, "Thời gian bắt đầu phải ở trong tương lai.");
				errorProvider.SetError(dtpStartDate, "Ngày chiếu phải là hôm nay hoặc trong tương lai.");
				isValid = false;
			}
			return isValid;
		}

		private DateTime CombineDateAndTime(DateTime date, DateTime time)
		{
			return date.Date.Add(time.TimeOfDay);
		}
	}
}
