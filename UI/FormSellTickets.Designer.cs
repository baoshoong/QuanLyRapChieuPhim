#pragma warning disable CA1416
namespace WinFormsApp1.UI
{
	partial class FormSellTickets
	{
		private System.ComponentModel.IContainer components = null;

		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code
		private void InitializeComponent()
		{
			label1 = new Label();
			groupBox1 = new GroupBox();
			dgvMovies = new DataGridView();
			groupBox2 = new GroupBox();
			dgvScreenings = new DataGridView();
			pnlSeats = new Panel();
			groupBox3 = new GroupBox();
			dgvOrder = new DataGridView();
			label2 = new Label();
			lblTotal = new Label();
			btnConfirm = new Button();
			btnAddFood = new Button();
			label3 = new Label();
			txtCustomerName = new TextBox();
			txtVoucherCode = new TextBox();
			btnApplyVoucher = new Button();
			lblDiscount = new Label();
			groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dgvMovies).BeginInit();
			groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dgvScreenings).BeginInit();
			groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dgvOrder).BeginInit();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
			label1.Location = new Point(467, 7);
			label1.Name = "label1";
			label1.Size = new Size(212, 30);
			label1.TabIndex = 0;
			label1.Text = "BÁN VÉ / ĐẶT CHỖ";
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(dgvMovies);
			groupBox1.Location = new Point(10, 45);
			groupBox1.Margin = new Padding(3, 2, 3, 2);
			groupBox1.Name = "groupBox1";
			groupBox1.Padding = new Padding(3, 2, 3, 2);
			groupBox1.Size = new Size(262, 188);
			groupBox1.TabIndex = 1;
			groupBox1.TabStop = false;
			groupBox1.Text = "1. Chọn phim";
			// 
			// dgvMovies
			// 
			dgvMovies.AllowUserToAddRows = false;
			dgvMovies.AllowUserToDeleteRows = false;
			dgvMovies.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvMovies.Dock = DockStyle.Fill;
			dgvMovies.Location = new Point(3, 18);
			dgvMovies.Margin = new Padding(3, 2, 3, 2);
			dgvMovies.Name = "dgvMovies";
			dgvMovies.ReadOnly = true;
			dgvMovies.RowHeadersWidth = 51;
			dgvMovies.RowTemplate.Height = 29;
			dgvMovies.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvMovies.Size = new Size(256, 168);
			dgvMovies.TabIndex = 0;
			dgvMovies.SelectionChanged += dgvMovies_SelectionChanged;
			// 
			// groupBox2
			// 
			groupBox2.Controls.Add(dgvScreenings);
			groupBox2.Location = new Point(10, 237);
			groupBox2.Margin = new Padding(3, 2, 3, 2);
			groupBox2.Name = "groupBox2";
			groupBox2.Padding = new Padding(3, 2, 3, 2);
			groupBox2.Size = new Size(262, 279);
			groupBox2.TabIndex = 2;
			groupBox2.TabStop = false;
			groupBox2.Text = "2. Chọn suất chiếu";
			// 
			// dgvScreenings
			// 
			dgvScreenings.AllowUserToAddRows = false;
			dgvScreenings.AllowUserToDeleteRows = false;
			dgvScreenings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvScreenings.Dock = DockStyle.Fill;
			dgvScreenings.Location = new Point(3, 18);
			dgvScreenings.Margin = new Padding(3, 2, 3, 2);
			dgvScreenings.Name = "dgvScreenings";
			dgvScreenings.ReadOnly = true;
			dgvScreenings.RowHeadersWidth = 51;
			dgvScreenings.RowTemplate.Height = 29;
			dgvScreenings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvScreenings.Size = new Size(256, 259);
			dgvScreenings.TabIndex = 0;
			dgvScreenings.SelectionChanged += dgvScreenings_SelectionChanged;
			// 
			// pnlSeats
			// 
			pnlSeats.BorderStyle = BorderStyle.FixedSingle;
			pnlSeats.Location = new Point(289, 45);
			pnlSeats.Margin = new Padding(3, 2, 3, 2);
			pnlSeats.Name = "pnlSeats";
			pnlSeats.Size = new Size(482, 472);
			pnlSeats.TabIndex = 3;
			// 
			// groupBox3
			// 
			groupBox3.Controls.Add(dgvOrder);
			groupBox3.Location = new Point(788, 120);
			groupBox3.Margin = new Padding(3, 2, 3, 2);
			groupBox3.Name = "groupBox3";
			groupBox3.Padding = new Padding(3, 2, 3, 2);
			groupBox3.Size = new Size(350, 225);
			groupBox3.TabIndex = 4;
			groupBox3.TabStop = false;
			groupBox3.Text = "Hóa đơn tạm tính";
			// 
			// dgvOrder
			// 
			dgvOrder.AllowUserToAddRows = false;
			dgvOrder.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvOrder.Dock = DockStyle.Fill;
			dgvOrder.Location = new Point(3, 18);
			dgvOrder.Margin = new Padding(3, 2, 3, 2);
			dgvOrder.Name = "dgvOrder";
			dgvOrder.ReadOnly = true;
			dgvOrder.RowHeadersWidth = 51;
			dgvOrder.RowTemplate.Height = 29;
			dgvOrder.Size = new Size(344, 205);
			dgvOrder.TabIndex = 0;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
			label2.Location = new Point(788, 352);
			label2.Name = "label2";
			label2.Size = new Size(103, 25);
			label2.TabIndex = 5;
			label2.Text = "Tổng tiền:";
			// 
			// lblTotal
			// 
			lblTotal.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
			lblTotal.ForeColor = Color.Red;
			lblTotal.Location = new Point(900, 352);
			lblTotal.Name = "lblTotal";
			lblTotal.Size = new Size(236, 23);
			lblTotal.TabIndex = 6;
			lblTotal.Text = "0 VNĐ";
			lblTotal.TextAlign = ContentAlignment.MiddleRight;
			// 
			// btnConfirm
			// 
			btnConfirm.BackColor = Color.Green;
			btnConfirm.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
			btnConfirm.ForeColor = Color.White;
			btnConfirm.Location = new Point(788, 465);
			btnConfirm.Margin = new Padding(3, 2, 3, 2);
			btnConfirm.Name = "btnConfirm";
			btnConfirm.Size = new Size(350, 51);
			btnConfirm.TabIndex = 7;
			btnConfirm.Text = "XÁC NHẬN THANH TOÁN";
			btnConfirm.UseVisualStyleBackColor = false;
			btnConfirm.Click += btnConfirm_Click;
			// 
			// btnAddFood
			// 
			btnAddFood.Location = new Point(788, 420);
			btnAddFood.Margin = new Padding(3, 2, 3, 2);
			btnAddFood.Name = "btnAddFood";
			btnAddFood.Size = new Size(350, 34);
			btnAddFood.TabIndex = 8;
			btnAddFood.Text = "+ Thêm đồ ăn / bắp nước";
			btnAddFood.UseVisualStyleBackColor = true;
			btnAddFood.Click += btnAddFood_Click;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(788, 68);
			label3.Name = "label3";
			label3.Size = new Size(94, 15);
			label3.TabIndex = 9;
			label3.Text = "Tên khách hàng:";
			// 
			// txtCustomerName
			// 
			txtCustomerName.Location = new Point(788, 86);
			txtCustomerName.Margin = new Padding(3, 2, 3, 2);
			txtCustomerName.Name = "txtCustomerName";
			txtCustomerName.Size = new Size(350, 23);
			txtCustomerName.TabIndex = 10;
			// 
			// txtVoucherCode
			// 
			txtVoucherCode.CharacterCasing = CharacterCasing.Upper;
			txtVoucherCode.Location = new Point(788, 382);
			txtVoucherCode.Margin = new Padding(3, 2, 3, 2);
			txtVoucherCode.Name = "txtVoucherCode";
			txtVoucherCode.PlaceholderText = "Nhập mã giảm giá";
			txtVoucherCode.Size = new Size(176, 23);
			txtVoucherCode.TabIndex = 11;
			// 
			// btnApplyVoucher
			// 
			btnApplyVoucher.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
			btnApplyVoucher.Location = new Point(972, 377);
			btnApplyVoucher.Margin = new Padding(3, 2, 3, 2);
			btnApplyVoucher.Name = "btnApplyVoucher";
			btnApplyVoucher.Size = new Size(166, 20);
			btnApplyVoucher.TabIndex = 12;
			btnApplyVoucher.Text = "Áp dụng";
			btnApplyVoucher.UseVisualStyleBackColor = true;
			btnApplyVoucher.Click += btnApplyVoucher_Click;
			// 
			// lblDiscount
			// 
			lblDiscount.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
			lblDiscount.ForeColor = Color.ForestGreen;
			lblDiscount.Location = new Point(788, 405);
			lblDiscount.Name = "lblDiscount";
			lblDiscount.Size = new Size(350, 15);
			lblDiscount.TabIndex = 13;
			lblDiscount.TextAlign = ContentAlignment.MiddleRight;
			// 
			// FormSellTickets
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1158, 525);
			Controls.Add(lblDiscount);
			Controls.Add(btnApplyVoucher);
			Controls.Add(txtVoucherCode);
			Controls.Add(txtCustomerName);
			Controls.Add(label3);
			Controls.Add(btnAddFood);
			Controls.Add(btnConfirm);
			Controls.Add(lblTotal);
			Controls.Add(label2);
			Controls.Add(groupBox3);
			Controls.Add(pnlSeats);
			Controls.Add(groupBox2);
			Controls.Add(groupBox1);
			Controls.Add(label1);
			Margin = new Padding(3, 2, 3, 2);
			Name = "FormSellTickets";
			Text = "Bán vé";
			Load += FormSellTickets_Load;
			groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)dgvMovies).EndInit();
			groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)dgvScreenings).EndInit();
			groupBox3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)dgvOrder).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
		#endregion

		private Label label1;
		private GroupBox groupBox1;
		private DataGridView dgvMovies;
		private GroupBox groupBox2;
		private DataGridView dgvScreenings;
		private Panel pnlSeats;
		private GroupBox groupBox3;
		private DataGridView dgvOrder;
		private Label label2;
		private Label lblTotal;
		private Button btnConfirm;
		private Button btnAddFood;
		private Label label3;
		private TextBox txtCustomerName;
		private System.Windows.Forms.TextBox txtVoucherCode;
		private System.Windows.Forms.Button btnApplyVoucher;
		private System.Windows.Forms.Label lblDiscount;
	}
}
