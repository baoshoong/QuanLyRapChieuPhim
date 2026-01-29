namespace WinFormsApp1.UI
{
	partial class FormScreenings
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormScreenings));
			this.label1 = new System.Windows.Forms.Label();
			this.dgvScreenings = new System.Windows.Forms.DataGridView();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lblEndTime = new System.Windows.Forms.Label();
			this.nudTicketPrice = new System.Windows.Forms.NumericUpDown();
			this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
			this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
			this.cboRoom = new System.Windows.Forms.ComboBox();
			this.cboMovie = new System.Windows.Forms.ComboBox();
			this.chkIsActive = new System.Windows.Forms.CheckBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtScreeningId = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnUpdate = new System.Windows.Forms.Button();
			this.btnDelete = new System.Windows.Forms.Button();
			this.btnClear = new System.Windows.Forms.Button();
			this.btnBack = new System.Windows.Forms.Button();
			this.label8 = new System.Windows.Forms.Label();
			this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			((System.ComponentModel.ISupportInitialize)(this.dgvScreenings)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudTicketPrice)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
			this.label1.Location = new System.Drawing.Point(470, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(292, 37);
			this.label1.TabIndex = 0;
			this.label1.Text = "QUẢN LÝ LỊCH CHIẾU";
			// 
			// dgvScreenings
			// 
			this.dgvScreenings.AllowUserToAddRows = false;
			this.dgvScreenings.AllowUserToDeleteRows = false;
			this.dgvScreenings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
			| System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.dgvScreenings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvScreenings.Location = new System.Drawing.Point(12, 375);
			this.dgvScreenings.Name = "dgvScreenings";
			this.dgvScreenings.ReadOnly = true;
			this.dgvScreenings.RowHeadersWidth = 51;
			this.dgvScreenings.RowTemplate.Height = 29;
			this.dgvScreenings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvScreenings.Size = new System.Drawing.Size(1176, 317);
			this.dgvScreenings.TabIndex = 1;
			this.dgvScreenings.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvScreenings_CellClick);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left))));
			this.groupBox1.Controls.Add(this.lblEndTime);
			this.groupBox1.Controls.Add(this.nudTicketPrice);
			this.groupBox1.Controls.Add(this.dtpStartTime);
			this.groupBox1.Controls.Add(this.dtpStartDate);
			this.groupBox1.Controls.Add(this.cboRoom);
			this.groupBox1.Controls.Add(this.cboMovie);
			this.groupBox1.Controls.Add(this.chkIsActive);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.txtScreeningId);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Location = new System.Drawing.Point(12, 61);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(780, 253);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Thông tin lịch chiếu";
			// 
			// lblEndTime
			// 
			this.lblEndTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblEndTime.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
			this.lblEndTime.Location = new System.Drawing.Point(370, 150);
			this.lblEndTime.Name = "lblEndTime";
			this.lblEndTime.Size = new System.Drawing.Size(350, 32);
			this.lblEndTime.TabIndex = 14;
			this.lblEndTime.Text = "Kết thúc lúc: --";
			this.lblEndTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// nudTicketPrice
			// 
			this.nudTicketPrice.Increment = new decimal(new int[] {
	10000,
	0,
	0,
	0});
			this.nudTicketPrice.Location = new System.Drawing.Point(127, 113);
			this.nudTicketPrice.Maximum = new decimal(new int[] {
	1000000,
	0,
	0,
	0});
			this.nudTicketPrice.Name = "nudTicketPrice";
			this.nudTicketPrice.Size = new System.Drawing.Size(215, 27);
			this.nudTicketPrice.TabIndex = 12;
			this.nudTicketPrice.ThousandsSeparator = true;
			this.nudTicketPrice.Value = new decimal(new int[] {
	80000,
	0,
	0,
	0});
			// 
			// dtpStartTime
			// 
			this.dtpStartTime.CustomFormat = "HH:mm";
			this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpStartTime.Location = new System.Drawing.Point(570, 78);
			this.dtpStartTime.Name = "dtpStartTime";
			this.dtpStartTime.ShowUpDown = true;
			this.dtpStartTime.Size = new System.Drawing.Size(150, 27);
			this.dtpStartTime.TabIndex = 11;
			// 
			// dtpStartDate
			// 
			this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpStartDate.Location = new System.Drawing.Point(570, 43);
			this.dtpStartDate.Name = "dtpStartDate";
			this.dtpStartDate.Size = new System.Drawing.Size(150, 27);
			this.dtpStartDate.TabIndex = 10;
			// 
			// cboRoom
			// 
			this.cboRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboRoom.FormattingEnabled = true;
			this.cboRoom.Location = new System.Drawing.Point(127, 189);
			this.cboRoom.Name = "cboRoom";
			this.cboRoom.Size = new System.Drawing.Size(215, 28);
			this.cboRoom.TabIndex = 9;
			// 
			// cboMovie
			// 
			this.cboMovie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboMovie.FormattingEnabled = true;
			this.cboMovie.Location = new System.Drawing.Point(127, 150);
			this.cboMovie.Name = "cboMovie";
			this.cboMovie.Size = new System.Drawing.Size(215, 28);
			this.cboMovie.TabIndex = 8;
			// 
			// chkIsActive
			// 
			this.chkIsActive.AutoSize = true;
			this.chkIsActive.Location = new System.Drawing.Point(570, 115);
			this.chkIsActive.Name = "chkIsActive";
			this.chkIsActive.Size = new System.Drawing.Size(126, 24);
			this.chkIsActive.TabIndex = 7;
			this.chkIsActive.Text = "Còn hoạt động";
			this.chkIsActive.UseVisualStyleBackColor = true;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(16, 115);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(54, 20);
			this.label7.TabIndex = 6;
			this.label7.Text = "Giá vé";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(463, 81);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(94, 20);
			this.label6.TabIndex = 5;
			this.label6.Text = "Giờ bắt đầu";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(463, 46);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(107, 20);
			this.label5.TabIndex = 4;
			this.label5.Text = "Ngày bắt đầu";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(16, 192);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(52, 20);
			this.label4.TabIndex = 3;
			this.label4.Text = "Phòng";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(16, 153);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(43, 20);
			this.label3.TabIndex = 2;
			this.label3.Text = "Phim";
			// 
			// txtScreeningId
			// 
			this.txtScreeningId.Enabled = false;
			this.txtScreeningId.Location = new System.Drawing.Point(127, 43);
			this.txtScreeningId.Name = "txtScreeningId";
			this.txtScreeningId.Size = new System.Drawing.Size(215, 27);
			this.txtScreeningId.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(16, 46);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(95, 20);
			this.label2.TabIndex = 0;
			this.label2.Text = "ID lịch chiếu";
			// 
			// btnAdd
			// 
			this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
			this.btnAdd.BackColor = System.Drawing.Color.LightGreen;
			this.btnAdd.Location = new System.Drawing.Point(815, 70);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(150, 45);
			this.btnAdd.TabIndex = 3;
			this.btnAdd.Text = "Thêm";
			this.btnAdd.UseVisualStyleBackColor = false;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnUpdate
			// 
			this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
			this.btnUpdate.BackColor = System.Drawing.Color.LightSkyBlue;
			this.btnUpdate.Enabled = false;
			this.btnUpdate.Location = new System.Drawing.Point(815, 125);
			this.btnUpdate.Name = "btnUpdate";
			this.btnUpdate.Size = new System.Drawing.Size(150, 45);
			this.btnUpdate.TabIndex = 4;
			this.btnUpdate.Text = "Cập nhật";
			this.btnUpdate.UseVisualStyleBackColor = false;
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
			this.btnDelete.BackColor = System.Drawing.Color.LightCoral;
			this.btnDelete.Enabled = false;
			this.btnDelete.Location = new System.Drawing.Point(815, 180);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(150, 45);
			this.btnDelete.TabIndex = 5;
			this.btnDelete.Text = "Xóa";
			this.btnDelete.UseVisualStyleBackColor = false;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnClear
			// 
			this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
			this.btnClear.Location = new System.Drawing.Point(815, 235);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(150, 45);
			this.btnClear.TabIndex = 6;
			this.btnClear.Text = "Nhập mới";
			this.btnClear.UseVisualStyleBackColor = true;
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// btnBack
			// 
			this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnBack.Location = new System.Drawing.Point(1094, 15);
			this.btnBack.Name = "btnBack";
			this.btnBack.Size = new System.Drawing.Size(94, 35);
			this.btnBack.TabIndex = 7;
			this.btnBack.Text = "Quay lại";
			this.btnBack.UseVisualStyleBackColor = true;
			this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label8.Location = new System.Drawing.Point(12, 336);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(171, 23);
			this.label8.TabIndex = 8;
			this.label8.Text = "Danh sách lịch chiếu:";
			// 
			// errorProvider
			// 
			this.errorProvider.ContainerControl = this;
			// 
			// FormScreenings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1200, 704);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.btnBack);
			this.Controls.Add(this.btnClear);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.btnUpdate);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.dgvScreenings);
			this.Controls.Add(this.label1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(1000, 600);
			this.Name = "FormScreenings";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Quản lý lịch chiếu";
			this.Load += new System.EventHandler(this.FormScreenings_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvScreenings)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudTicketPrice)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGridView dgvScreenings;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtScreeningId;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.CheckBox chkIsActive;
		private System.Windows.Forms.ComboBox cboRoom;
		private System.Windows.Forms.ComboBox cboMovie;
		private System.Windows.Forms.DateTimePicker dtpStartTime;
		private System.Windows.Forms.DateTimePicker dtpStartDate;
		private System.Windows.Forms.NumericUpDown nudTicketPrice;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnUpdate;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.Button btnBack;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ErrorProvider errorProvider;
		private System.Windows.Forms.Label lblEndTime;
	}
}