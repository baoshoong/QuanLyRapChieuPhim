#pragma warning disable CA1416 // T?t c?nh báo tương thích n?n t?ng
namespace WinFormsApp1.UI
{
	partial class FormVouchers
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			label1 = new Label();
			dgvVouchers = new DataGridView();
			groupBox1 = new GroupBox();
			label10 = new Label();
			nudMinOrderAmount = new NumericUpDown();
			label11 = new Label();
			nudDiscountValue = new NumericUpDown();
			cboDiscountType = new ComboBox();
			label12 = new Label();
			txtVoucherName = new TextBox();
			label13 = new Label();
			chkIsActive = new CheckBox();
			dtpValidTo = new DateTimePicker();
			dtpValidFrom = new DateTimePicker();
			txtVoucherCode = new TextBox();
			txtVoucherId = new TextBox();
			label7 = new Label();
			label6 = new Label();
			label3 = new Label();
			label2 = new Label();
			btnAdd = new Button();
			btnUpdate = new Button();
			btnDelete = new Button();
			btnClear = new Button();
			btnBack = new Button();
			label9 = new Label();
			errorProvider = new ErrorProvider(components);
			((System.ComponentModel.ISupportInitialize)dgvVouchers).BeginInit();
			groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudMinOrderAmount).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudDiscountValue).BeginInit();
			((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
			label1.Location = new Point(398, 7);
			label1.Name = "label1";
			label1.Size = new Size(258, 30);
			label1.TabIndex = 0;
			label1.Text = "QUẢN LÝ MÃ GIẢM GIÁ";
			// 
			// dgvVouchers
			// 
			dgvVouchers.AllowUserToAddRows = false;
			dgvVouchers.AllowUserToDeleteRows = false;
			dgvVouchers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvVouchers.Location = new Point(10, 281);
			dgvVouchers.Margin = new Padding(3, 2, 3, 2);
			dgvVouchers.Name = "dgvVouchers";
			dgvVouchers.ReadOnly = true;
			dgvVouchers.RowHeadersWidth = 51;
			dgvVouchers.RowTemplate.Height = 29;
			dgvVouchers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvVouchers.Size = new Size(1029, 238);
			dgvVouchers.TabIndex = 1;
			dgvVouchers.CellClick += dgvVouchers_CellClick;
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(label10);
			groupBox1.Controls.Add(nudMinOrderAmount);
			groupBox1.Controls.Add(label11);
			groupBox1.Controls.Add(nudDiscountValue);
			groupBox1.Controls.Add(cboDiscountType);
			groupBox1.Controls.Add(label12);
			groupBox1.Controls.Add(txtVoucherName);
			groupBox1.Controls.Add(label13);
			groupBox1.Controls.Add(chkIsActive);
			groupBox1.Controls.Add(dtpValidTo);
			groupBox1.Controls.Add(dtpValidFrom);
			groupBox1.Controls.Add(txtVoucherCode);
			groupBox1.Controls.Add(txtVoucherId);
			groupBox1.Controls.Add(label7);
			groupBox1.Controls.Add(label6);
			groupBox1.Controls.Add(label3);
			groupBox1.Controls.Add(label2);
			groupBox1.Location = new Point(10, 46);
			groupBox1.Margin = new Padding(3, 2, 3, 2);
			groupBox1.Name = "groupBox1";
			groupBox1.Padding = new Padding(3, 2, 3, 2);
			groupBox1.Size = new Size(679, 212);
			groupBox1.TabIndex = 2;
			groupBox1.TabStop = false;
			groupBox1.Text = "Thông tin voucher";
			// 
			// label10
			// 
			label10.AutoSize = true;
			label10.Location = new Point(14, 87);
			label10.Name = "label10";
			label10.Size = new Size(72, 15);
			label10.TabIndex = 26;
			label10.Text = "Tên Voucher";
			// 
			// nudMinOrderAmount
			// 
			nudMinOrderAmount.Increment = new decimal(new int[] { 10000, 0, 0, 0 });
			nudMinOrderAmount.Location = new Point(509, 86);
			nudMinOrderAmount.Margin = new Padding(3, 2, 3, 2);
			nudMinOrderAmount.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
			nudMinOrderAmount.Name = "nudMinOrderAmount";
			nudMinOrderAmount.Size = new Size(146, 23);
			nudMinOrderAmount.TabIndex = 25;
			nudMinOrderAmount.ThousandsSeparator = true;
			// 
			// label11
			// 
			label11.AutoSize = true;
			label11.Location = new Point(405, 87);
			label11.Name = "label11";
			label11.Size = new Size(76, 15);
			label11.TabIndex = 24;
			label11.Text = "Đơn tối thiểu";
			// 
			// nudDiscountValue
			// 
			nudDiscountValue.Increment = new decimal(new int[] { 10000, 0, 0, 0 });
			nudDiscountValue.Location = new Point(509, 59);
			nudDiscountValue.Margin = new Padding(3, 2, 3, 2);
			nudDiscountValue.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
			nudDiscountValue.Name = "nudDiscountValue";
			nudDiscountValue.Size = new Size(146, 23);
			nudDiscountValue.TabIndex = 23;
			nudDiscountValue.ThousandsSeparator = true;
			// 
			// cboDiscountType
			// 
			cboDiscountType.DropDownStyle = ComboBoxStyle.DropDownList;
			cboDiscountType.FormattingEnabled = true;
			cboDiscountType.Location = new Point(509, 32);
			cboDiscountType.Margin = new Padding(3, 2, 3, 2);
			cboDiscountType.Name = "cboDiscountType";
			cboDiscountType.Size = new Size(147, 23);
			cboDiscountType.TabIndex = 22;
			// 
			// label12
			// 
			label12.AutoSize = true;
			label12.Location = new Point(405, 34);
			label12.Name = "label12";
			label12.Size = new Size(78, 15);
			label12.TabIndex = 21;
			label12.Text = "Loại giảm giá";
			// 
			// txtVoucherName
			// 
			txtVoucherName.Location = new Point(111, 85);
			txtVoucherName.Margin = new Padding(3, 2, 3, 2);
			txtVoucherName.Name = "txtVoucherName";
			txtVoucherName.Size = new Size(261, 23);
			txtVoucherName.TabIndex = 20;
			// 
			// label13
			// 
			label13.AutoSize = true;
			label13.Location = new Point(405, 61);
			label13.Name = "label13";
			label13.Size = new Size(38, 15);
			label13.TabIndex = 19;
			label13.Text = "Giá trị";
			// 
			// chkIsActive
			// 
			chkIsActive.AutoSize = true;
			chkIsActive.Checked = true;
			chkIsActive.CheckState = CheckState.Checked;
			chkIsActive.Location = new Point(509, 112);
			chkIsActive.Margin = new Padding(3, 2, 3, 2);
			chkIsActive.Name = "chkIsActive";
			chkIsActive.Size = new Size(76, 19);
			chkIsActive.TabIndex = 13;
			chkIsActive.Text = "Kích hoạt";
			chkIsActive.UseVisualStyleBackColor = true;
			// 
			// dtpValidTo
			// 
			dtpValidTo.Format = DateTimePickerFormat.Short;
			dtpValidTo.Location = new Point(301, 112);
			dtpValidTo.Margin = new Padding(3, 2, 3, 2);
			dtpValidTo.Name = "dtpValidTo";
			dtpValidTo.Size = new Size(125, 23);
			dtpValidTo.TabIndex = 12;
			// 
			// dtpValidFrom
			// 
			dtpValidFrom.Format = DateTimePickerFormat.Short;
			dtpValidFrom.Location = new Point(111, 112);
			dtpValidFrom.Margin = new Padding(3, 2, 3, 2);
			dtpValidFrom.Name = "dtpValidFrom";
			dtpValidFrom.Size = new Size(125, 23);
			dtpValidFrom.TabIndex = 11;
			// 
			// txtVoucherCode
			// 
			txtVoucherCode.CharacterCasing = CharacterCasing.Upper;
			txtVoucherCode.Location = new Point(111, 58);
			txtVoucherCode.Margin = new Padding(3, 2, 3, 2);
			txtVoucherCode.Name = "txtVoucherCode";
			txtVoucherCode.Size = new Size(261, 23);
			txtVoucherCode.TabIndex = 8;
			// 
			// txtVoucherId
			// 
			txtVoucherId.Enabled = false;
			txtVoucherId.Location = new Point(111, 32);
			txtVoucherId.Margin = new Padding(3, 2, 3, 2);
			txtVoucherId.Name = "txtVoucherId";
			txtVoucherId.Size = new Size(261, 23);
			txtVoucherId.TabIndex = 7;
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Location = new Point(14, 115);
			label7.Name = "label7";
			label7.Size = new Size(50, 15);
			label7.TabIndex = 6;
			label7.Text = "Từ ngày";
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Location = new Point(241, 115);
			label6.Name = "label6";
			label6.Size = new Size(57, 15);
			label6.TabIndex = 5;
			label6.Text = "Đến ngày";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(14, 61);
			label3.Name = "label3";
			label3.Size = new Size(70, 15);
			label3.TabIndex = 2;
			label3.Text = "Mã Voucher";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(14, 34);
			label2.Name = "label2";
			label2.Size = new Size(18, 15);
			label2.TabIndex = 1;
			label2.Text = "ID";
			// 
			// btnAdd
			// 
			btnAdd.BackColor = Color.LightGreen;
			btnAdd.Location = new Point(712, 68);
			btnAdd.Margin = new Padding(3, 2, 3, 2);
			btnAdd.Name = "btnAdd";
			btnAdd.Size = new Size(140, 30);
			btnAdd.TabIndex = 3;
			btnAdd.Text = "Thêm";
			btnAdd.UseVisualStyleBackColor = false;
			btnAdd.Click += btnAdd_Click;
			// 
			// btnUpdate
			// 
			btnUpdate.BackColor = Color.LightSkyBlue;
			btnUpdate.Enabled = false;
			btnUpdate.Location = new Point(712, 110);
			btnUpdate.Margin = new Padding(3, 2, 3, 2);
			btnUpdate.Name = "btnUpdate";
			btnUpdate.Size = new Size(140, 30);
			btnUpdate.TabIndex = 4;
			btnUpdate.Text = "Cập nhật";
			btnUpdate.UseVisualStyleBackColor = false;
			btnUpdate.Click += btnUpdate_Click;
			// 
			// btnDelete
			// 
			btnDelete.BackColor = Color.LightCoral;
			btnDelete.Enabled = false;
			btnDelete.Location = new Point(712, 151);
			btnDelete.Margin = new Padding(3, 2, 3, 2);
			btnDelete.Name = "btnDelete";
			btnDelete.Size = new Size(140, 30);
			btnDelete.TabIndex = 5;
			btnDelete.Text = "Xóa";
			btnDelete.UseVisualStyleBackColor = false;
			btnDelete.Click += btnDelete_Click;
			// 
			// btnClear
			// 
			btnClear.Location = new Point(712, 192);
			btnClear.Margin = new Padding(3, 2, 3, 2);
			btnClear.Name = "btnClear";
			btnClear.Size = new Size(140, 30);
			btnClear.TabIndex = 6;
			btnClear.Text = "Nhập mới";
			btnClear.UseVisualStyleBackColor = true;
			btnClear.Click += btnClear_Click;
			// 
			// btnBack
			// 
			btnBack.Location = new Point(957, 10);
			btnBack.Margin = new Padding(3, 2, 3, 2);
			btnBack.Name = "btnBack";
			btnBack.Size = new Size(82, 22);
			btnBack.TabIndex = 7;
			btnBack.Text = "Quay lại";
			btnBack.UseVisualStyleBackColor = true;
			btnBack.Click += btnBack_Click;
			// 
			// label9
			// 
			label9.AutoSize = true;
			label9.Location = new Point(10, 264);
			label9.Name = "label9";
			label9.Size = new Size(134, 15);
			label9.TabIndex = 8;
			label9.Text = "Danh sách mã giảm giá:";
			// 
			// errorProvider
			// 
			errorProvider.ContainerControl = this;
			// 
			// FormVouchers
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1050, 528);
			Controls.Add(label9);
			Controls.Add(btnBack);
			Controls.Add(btnClear);
			Controls.Add(btnDelete);
			Controls.Add(btnUpdate);
			Controls.Add(btnAdd);
			Controls.Add(groupBox1);
			Controls.Add(dgvVouchers);
			Controls.Add(label1);
			Margin = new Padding(3, 2, 3, 2);
			Name = "FormVouchers";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Quản lý voucher";
			Load += FormVouchers_Load;
			((System.ComponentModel.ISupportInitialize)dgvVouchers).EndInit();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudMinOrderAmount).EndInit();
			((System.ComponentModel.ISupportInitialize)nudDiscountValue).EndInit();
			((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private DataGridView dgvVouchers;
		private GroupBox groupBox1;
		private Label label7;
		private Label label6;
		private Label label3;
		private Label label2;
		private DateTimePicker dtpValidTo;
		private DateTimePicker dtpValidFrom;
		private TextBox txtVoucherId;
		private CheckBox chkIsActive;
		private Button btnAdd;
		private Button btnUpdate;
		private Button btnDelete;
		private Button btnClear;
		private Button btnBack;
		private Label label9;
		private ErrorProvider errorProvider;
		private Label label10;
		private NumericUpDown nudMinOrderAmount;
		private Label label11;
		private NumericUpDown nudDiscountValue;
		private ComboBox cboDiscountType;
		private Label label12;
		private TextBox txtVoucherName;
		private Label label13;
		private TextBox txtVoucherCode;
	}
}