#pragma warning disable CA1416
using System;
using System.Windows.Forms;
using WinFormsApp1.BLL;
using WinFormsApp1.Model;

namespace WinFormsApp1.UI
{
	public partial class FormUsers : Form
	{
		private UserBLL userBLL;
		private User? currentUser;

		public FormUsers()
		{
			InitializeComponent();
			userBLL = new UserBLL();
		}

		private void FormUsers_Load(object? sender, EventArgs e)
		{
			ThemeManager.ApplyModernDarkTheme(this);
			LoadUsers();
			cboRole.Items.AddRange(new string[] { "Manager", "Staff" });
			cboRole.SelectedIndex = 1; // Mặc định chọn "Staff"
			ClearForm();
		}

		private void LoadUsers()
		{
			dgvUsers.DataSource = userBLL.GetAllUsers();
			FormatDataGridView();
		}

		private void FormatDataGridView()
		{
			if (dgvUsers.Columns.Count > 0)
			{
				dgvUsers.Columns["Id"].HeaderText = "ID";
				dgvUsers.Columns["Username"].HeaderText = "Tên đăng nhập";
				dgvUsers.Columns["FullName"].HeaderText = "Họ và tên";
				dgvUsers.Columns["Email"].HeaderText = "Email";
				dgvUsers.Columns["Phone"].HeaderText = "SĐT";
				dgvUsers.Columns["Role"].HeaderText = "Vai trò";
				dgvUsers.Columns["IsActive"].HeaderText = "Hoạt động";
				dgvUsers.Columns["Password"].Visible = false; // Luôn ẩn cột mật khẩu
				dgvUsers.Columns["CreatedDate"].Visible = false;
				dgvUsers.Columns["LastLoginDate"].HeaderText = "Đăng nhập cuối";
				dgvUsers.Columns["LastLoginDate"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
				dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			}
		}

		private void ClearForm()
		{
			txtUserId.Text = string.Empty;
			txtUsername.Text = string.Empty;
			txtPassword.Text = string.Empty;
			txtFullName.Text = string.Empty;
			txtEmail.Text = string.Empty;
			txtPhone.Text = string.Empty;
			if (cboRole.Items.Count > 0 && cboRole.SelectedIndex < 0)
			{
				cboRole.SelectedIndex = 1; // Mặc định là Staff
			}
			chkIsActive.Checked = true;
			currentUser = null;
			btnAdd.Enabled = true;
			btnUpdate.Enabled = false;
			btnDelete.Enabled = false;
		}

		private void dgvUsers_CellClick(object? sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0 && dgvUsers.Rows[e.RowIndex].DataBoundItem is User selectedUser)
			{
				currentUser = selectedUser;
				txtUserId.Text = currentUser.Id.ToString();
				txtUsername.Text = currentUser.Username;
				txtFullName.Text = currentUser.FullName;
				txtEmail.Text = currentUser.Email;
				txtPhone.Text = currentUser.Phone;
				cboRole.SelectedItem = currentUser.Role;
				chkIsActive.Checked = currentUser.IsActive;
				txtPassword.Text = ""; // Để trống mật khẩu, chỉ cập nhật nếu người dùng nhập mới

				btnAdd.Enabled = false;
				btnUpdate.Enabled = true;
				btnDelete.Enabled = true;
			}
		}

		private bool ValidateUserInput(bool isUpdate = false)
		{
			// Kiểm tra tên đăng nhập
			if (string.IsNullOrWhiteSpace(txtUsername.Text))
			{
				MessageBox.Show("Vui lòng nhập tên đăng nhập", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				txtUsername.Focus();
				return false;
			}
			
			// Kiểm tra mật khẩu khi thêm mới
			if (!isUpdate && string.IsNullOrWhiteSpace(txtPassword.Text))
			{
				MessageBox.Show("Vui lòng nhập mật khẩu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				txtPassword.Focus();
				return false;
			}
			
			// Kiểm tra vai trò
			if (cboRole.SelectedIndex < 0)
			{
				MessageBox.Show("Vui lòng chọn vai trò", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				cboRole.Focus();
				return false;
			}
			
			// Kiểm tra định dạng email (nếu có nhập)
			if (!string.IsNullOrWhiteSpace(txtEmail.Text))
			{
				// Kiểm tra định dạng email đơn giản
				if (!txtEmail.Text.Contains('@') || !txtEmail.Text.Contains('.'))
				{
					MessageBox.Show("Định dạng email không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
					txtEmail.Focus();
					return false;
				}
			}
			
			// Kiểm tra định dạng số điện thoại (nếu có nhập)
			if (!string.IsNullOrWhiteSpace(txtPhone.Text))
			{
				if (!System.Text.RegularExpressions.Regex.IsMatch(txtPhone.Text, @"^\d{10,11}$"))
				{
					MessageBox.Show("Số điện thoại phải có 10-11 chữ số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
					txtPhone.Focus();
					return false;
				}
			}
			
			return true;
		}

		private void btnAdd_Click(object? sender, EventArgs e)
		{
			if (!ValidateUserInput())
			{
				return;
			}
			
			try
			{
				User newUser = new User
				{
					Username = txtUsername.Text.Trim(),
					Password = txtPassword.Text, // BLL sẽ kiểm tra
					FullName = txtFullName.Text.Trim(),
					Email = txtEmail.Text.Trim(),
					Phone = txtPhone.Text.Trim(),
					Role = cboRole.SelectedItem?.ToString() ?? "Staff",
					IsActive = chkIsActive.Checked
				};
				userBLL.AddUser(newUser);
				MessageBox.Show("Thêm người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				LoadUsers();
				ClearForm();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi: " + ex.Message, "Thêm thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnUpdate_Click(object? sender, EventArgs e)
		{
			if (currentUser == null) return;
			if (!ValidateUserInput(true))
			{
				return;
			}
			
			try
			{
				currentUser.Username = txtUsername.Text.Trim();
				currentUser.FullName = txtFullName.Text.Trim();
				currentUser.Email = txtEmail.Text.Trim();
				currentUser.Phone = txtPhone.Text.Trim();
				currentUser.Role = cboRole.SelectedItem?.ToString() ?? "Staff";
				currentUser.IsActive = chkIsActive.Checked;

				// Chỉ cập nhật mật khẩu nếu người dùng nhập mật khẩu mới
				if (!string.IsNullOrWhiteSpace(txtPassword.Text))
				{
					currentUser.Password = txtPassword.Text;
				}
				else
				{
					currentUser.Password = null; // Gửi null để DAL biết không cần cập nhật mật khẩu
				}

				userBLL.UpdateUser(currentUser);
				MessageBox.Show("Cập nhật người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				LoadUsers();
				ClearForm();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi: " + ex.Message, "Cập nhật thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnDelete_Click(object? sender, EventArgs e)
		{
			if (currentUser == null) return;
			DialogResult dr = MessageBox.Show($"Bạn có chắc chắn muốn xóa người dùng '{currentUser.Username}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
			if (dr == DialogResult.Yes)
			{
				try
				{
					userBLL.DeleteUser(currentUser.Id);
					MessageBox.Show("Xóa người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					LoadUsers();
					ClearForm();
				}
				catch (Exception ex)
				{
					MessageBox.Show("Lỗi: " + ex.Message, "Xóa thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
	}
}
