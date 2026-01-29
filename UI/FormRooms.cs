#pragma warning disable CA1416 // Tắt cảnh báo tương thích nền tảng

using System;
using System.Windows.Forms;
using WinFormsApp1.BLL;
using WinFormsApp1.Model;

namespace WinFormsApp1.UI
{
	public partial class FormRooms : Form
	{
		private RoomBLL roomBLL;
		private Room? currentRoom;
		private ErrorProvider errorProvider;

		public FormRooms()
		{
			InitializeComponent();
			roomBLL = new RoomBLL();
			
			// Set appropriate range for numCapacity
			numCapacity.Minimum = 50;  // Rooms must have at least 1 seat
			numCapacity.Maximum = 120; // Maximum capacity from business logic
		}


		private void FormRooms_Load(object? sender, EventArgs e)
		{
			ThemeManager.ApplyModernDarkTheme(this);
			LoadRooms();
			ClearForm();
		}

		private void LoadRooms()
		{
			dgvRooms.DataSource = roomBLL.GetAllRooms();
			FormatDataGridView();
		}

		private void FormatDataGridView()
		{
			if (dgvRooms.Columns.Count == 0) return;

			dgvRooms.Columns["Id"].HeaderText = "ID";
			dgvRooms.Columns["Name"].HeaderText = "Tên phòng";
			dgvRooms.Columns["Capacity"].HeaderText = "Sức chứa";
			dgvRooms.Columns["Type"].HeaderText = "Loại phòng";
			dgvRooms.Columns["IsActive"].HeaderText = "Đang hoạt động";


			string[] columnsToHide = { "Rows", "SeatsPerRow", "ScreenSize", "Has3D", "HasDolbySurround", "SeatingLayout", "CleaningTime" };
			foreach (var colName in columnsToHide)
			{
				if (dgvRooms.Columns.Contains(colName))
				{
					dgvRooms.Columns[colName].Visible = false;
				}
			}

			dgvRooms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
		}

		private void ClearForm()
		{
			txtRoomId.Text = string.Empty;
			txtRoomName.Text = string.Empty;
			numCapacity.Value = 50;
			cboType.SelectedIndex = -1;
			chkIsActive.Checked = true;

			currentRoom = null;
			btnAdd.Enabled = true;
			btnUpdate.Enabled = false;
			btnDelete.Enabled = false;
		}

		private void dgvRooms_CellClick(object? sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0 && dgvRooms.Rows[e.RowIndex].DataBoundItem is Room selectedRoom)
			{
				currentRoom = selectedRoom;

				txtRoomId.Text = currentRoom.Id.ToString();
				txtRoomName.Text = currentRoom.Name;
				numCapacity.Value = currentRoom.Capacity;
				cboType.Text = currentRoom.Type;
				chkIsActive.Checked = currentRoom.IsActive;

				btnAdd.Enabled = false;
				btnUpdate.Enabled = true;
				btnDelete.Enabled = true;
			}
		}

		private void btnAdd_Click(object? sender, EventArgs e)
		{
			try
			{
				Room room = new Room
				{
					Name = txtRoomName.Text.Trim(),
					Capacity = (int)numCapacity.Value,
					Type = cboType.Text,
					IsActive = chkIsActive.Checked
				};

				if (roomBLL.AddRoom(room))
				{
					MessageBox.Show("Thêm phòng chiếu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					LoadRooms();
					ClearForm();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnUpdate_Click(object? sender, EventArgs e)
		{
			if (currentRoom == null)
			{
				MessageBox.Show("Vui lòng chọn phòng chiếu để cập nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			try
			{
				currentRoom.Name = txtRoomName.Text.Trim();
				currentRoom.Capacity = (int)numCapacity.Value;
				currentRoom.Type = cboType.Text;
				currentRoom.IsActive = chkIsActive.Checked;

				if (roomBLL.UpdateRoom(currentRoom))
				{
					MessageBox.Show("Cập nhật phòng chiếu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					LoadRooms();
					ClearForm();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnDelete_Click(object? sender, EventArgs e)
		{
			if (currentRoom == null) return;

			DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa phòng chiếu này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (dr == DialogResult.Yes)
			{
				try
				{
					if (roomBLL.DeleteRoom(currentRoom.Id))
					{
						MessageBox.Show("Xóa phòng chiếu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
						LoadRooms();
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

		private void label1_Click(object sender, EventArgs e)
		{

		}
	}
}
