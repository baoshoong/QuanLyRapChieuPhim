using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WinFormsApp1.BLL;
using WinFormsApp1.Model;

namespace WinFormsApp1.UI
{
	public partial class FormVouchers : Form
	{
		private VoucherBLL voucherBLL;
		private Voucher? currentVoucher;

		public FormVouchers()
		{
			InitializeComponent();
			voucherBLL = new VoucherBLL();
		}

		private void FormVouchers_Load(object sender, EventArgs e)
		{
			LoadVouchers();
			// Thi?t l?p giá tr? m?c đ?nh cho ComboBox
			cboDiscountType.Items.AddRange(new string[] { "Fixed", "Percentage" });
			ClearForm();
		}

		private void LoadVouchers()
		{
			ThemeManager.ApplyModernDarkTheme(this);
			dgvVouchers.DataSource = null; 
			dgvVouchers.DataSource = voucherBLL.GetAllVouchers();
			FormatDataGridView();
		}

		private void FormatDataGridView()
		{
			if (dgvVouchers.Columns.Count == 0) return;

			// Đ?i tên các c?t đ? kh?p v?i Model m?i
			dgvVouchers.Columns["Id"].HeaderText = "ID";
			dgvVouchers.Columns["VoucherCode"].HeaderText = "Mã Voucher";
			dgvVouchers.Columns["VoucherName"].HeaderText = "Tên Voucher";
			dgvVouchers.Columns["DiscountType"].HeaderText = "Loại Giảmm Giá";
			dgvVouchers.Columns["DiscountValue"].HeaderText = "Giá Trị Giảm";
			dgvVouchers.Columns["MinOrderAmount"].HeaderText = "Đơn Tối Thiểu";
			dgvVouchers.Columns["ValidFrom"].HeaderText = "Ngày Bắtt Đầu";
			dgvVouchers.Columns["ValidTo"].HeaderText = "Ngày Kết Thúc";
			dgvVouchers.Columns["IsActive"].HeaderText = "Hiệu Lực";

			// Đ?nh d?ng c?t
			dgvVouchers.Columns["DiscountValue"].DefaultCellStyle.Format = "N0";
			dgvVouchers.Columns["MinOrderAmount"].DefaultCellStyle.Format = "N0";
			dgvVouchers.Columns["ValidFrom"].DefaultCellStyle.Format = "dd/MM/yyyy";
			dgvVouchers.Columns["ValidTo"].DefaultCellStyle.Format = "dd/MM/yyyy";

			dgvVouchers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
		}

		private void ClearForm()
		{
			// Làm m?i các control m?i
			txtVoucherId.Text = string.Empty;
			txtVoucherCode.Text = string.Empty;
			txtVoucherName.Text = string.Empty;
			cboDiscountType.SelectedIndex = -1;
			nudDiscountValue.Value = 0;
			nudMinOrderAmount.Value = 0;
			dtpValidFrom.Value = DateTime.Today;
			dtpValidTo.Value = DateTime.Today.AddMonths(1);
			chkIsActive.Checked = true;

			currentVoucher = null;
			btnAdd.Enabled = true;
			btnUpdate.Enabled = false;
			btnDelete.Enabled = false;
			errorProvider.Clear();
		}

		private void dgvVouchers_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0 && dgvVouchers.Rows[e.RowIndex].DataBoundItem is Voucher selectedVoucher)
			{
				currentVoucher = selectedVoucher;
				if (currentVoucher != null)
				{
					// L?y d? li?u t? các thu?c tính m?i
					txtVoucherId.Text = currentVoucher.Id.ToString();
					txtVoucherCode.Text = currentVoucher.VoucherCode;
					txtVoucherName.Text = currentVoucher.VoucherName;
					cboDiscountType.SelectedItem = currentVoucher.DiscountType;
					nudDiscountValue.Value = currentVoucher.DiscountValue;
					nudMinOrderAmount.Value = currentVoucher.MinOrderAmount;
					dtpValidFrom.Value = currentVoucher.ValidFrom;
					dtpValidTo.Value = currentVoucher.ValidTo;
					chkIsActive.Checked = currentVoucher.IsActive;

					btnAdd.Enabled = false;
					btnUpdate.Enabled = true;
					btnDelete.Enabled = true;
				}
			}
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			try
			{
				if (ValidateInputs())
				{
					Voucher voucher = new Voucher
					{
						// Gán giá tr? vào các thu?c tính m?i
						VoucherCode = txtVoucherCode.Text.Trim().ToUpper(),
						VoucherName = txtVoucherName.Text.Trim(),
						DiscountType = cboDiscountType.SelectedItem.ToString(),
						DiscountValue = nudDiscountValue.Value,
						MinOrderAmount = nudMinOrderAmount.Value,
						ValidFrom = dtpValidFrom.Value.Date,
						ValidTo = dtpValidTo.Value.Date,
						IsActive = chkIsActive.Checked
					};

					if (voucherBLL.AddVoucher(voucher))
					{
						MessageBox.Show("Thêm voucher thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
						LoadVouchers();
						ClearForm();
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnUpdate_Click(object sender, EventArgs e)
		{
			if (currentVoucher == null) return;
			try
			{
				if (ValidateInputs())
				{
					// C?p nh?t các thu?c tính m?i
					currentVoucher.VoucherCode = txtVoucherCode.Text.Trim().ToUpper();
					currentVoucher.VoucherName = txtVoucherName.Text.Trim();
					currentVoucher.DiscountType = cboDiscountType.SelectedItem.ToString();
					currentVoucher.DiscountValue = nudDiscountValue.Value;
					currentVoucher.MinOrderAmount = nudMinOrderAmount.Value;
					currentVoucher.ValidFrom = dtpValidFrom.Value.Date;
					currentVoucher.ValidTo = dtpValidTo.Value.Date;
					currentVoucher.IsActive = chkIsActive.Checked;

					if (voucherBLL.UpdateVoucher(currentVoucher))
					{
						MessageBox.Show("Cập nhật voucher thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
						LoadVouchers();
						ClearForm();
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			if (currentVoucher == null) return;

			DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa voucher này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (dr == DialogResult.Yes)
			{
				try
				{
					if (voucherBLL.DeleteVoucher(currentVoucher.Id))
					{
						MessageBox.Show("Xóa voucher thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
						LoadVouchers();
						ClearForm();
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("L?i: " + ex.Message, "L?i", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			ClearForm();
		}

		private bool ValidateInputs()
		{
			errorProvider.Clear();
			bool isValid = true;

			if (string.IsNullOrWhiteSpace(txtVoucherCode.Text))
			{
				errorProvider.SetError(txtVoucherCode, "Vui lòng nhập mã voucher.");
				isValid = false;
			}

			if (string.IsNullOrWhiteSpace(txtVoucherName.Text))
			{
				errorProvider.SetError(txtVoucherName, "Vui lòng nhập tên voucher.");
				isValid = false;
			}

			if (cboDiscountType.SelectedIndex == -1)
			{
				errorProvider.SetError(cboDiscountType, "Vui lòng chọn loại giảm giá.");
				isValid = false;
			}

			if (nudDiscountValue.Value <= 0)
			{
				errorProvider.SetError(nudDiscountValue, "Giá trị giảm giá phải lớn hơn 0.");
				isValid = false;
			}

			if (dtpValidTo.Value < dtpValidFrom.Value)
			{
				errorProvider.SetError(dtpValidTo, "Ngày kết thúc phải sau ngày bắt đầu.");
				isValid = false;
			}

			return isValid;
		}


		private void btnBack_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}