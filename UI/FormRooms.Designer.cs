namespace WinFormsApp1.UI
{
    partial class FormRooms
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
			label1 = new Label();
			groupBox1 = new GroupBox();
			chkIsActive = new CheckBox();
			cboType = new ComboBox();
			numCapacity = new NumericUpDown();
			txtRoomName = new TextBox();
			txtRoomId = new TextBox();
			label5 = new Label();
			label4 = new Label();
			label3 = new Label();
			label2 = new Label();
			groupBox2 = new GroupBox();
			btnClear = new Button();
			btnDelete = new Button();
			btnUpdate = new Button();
			btnAdd = new Button();
			dgvRooms = new DataGridView();
			btnBack = new Button();
			groupBox1.SuspendLayout();
			groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dgvRooms).BeginInit();
			((System.ComponentModel.ISupportInitialize)numCapacity).BeginInit();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
			label1.Location = new Point(246, 16);
			label1.Name = "label1";
			label1.Size = new Size(266, 30);
			label1.TabIndex = 0;
			label1.Text = "QUẢN LÝ PHÒNG CHIẾU";
			label1.Click += label1_Click;
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(chkIsActive);
			groupBox1.Controls.Add(cboType);
			groupBox1.Controls.Add(numCapacity);
			groupBox1.Controls.Add(txtRoomName);
			groupBox1.Controls.Add(txtRoomId);
			groupBox1.Controls.Add(label5);
			groupBox1.Controls.Add(label4);
			groupBox1.Controls.Add(label3);
			groupBox1.Controls.Add(label2);
			groupBox1.Location = new Point(20, 58);
			groupBox1.Margin = new Padding(3, 2, 3, 2);
			groupBox1.Name = "groupBox1";
			groupBox1.Padding = new Padding(3, 2, 3, 2);
			groupBox1.Size = new Size(395, 170);
			groupBox1.TabIndex = 1;
			groupBox1.TabStop = false;
			groupBox1.Text = "Thông tin phòng chiếu";
			// 
			// chkIsActive
			// 
			chkIsActive.AutoSize = true;
			chkIsActive.Location = new Point(115, 137);
			chkIsActive.Margin = new Padding(3, 2, 3, 2);
			chkIsActive.Name = "chkIsActive";
			chkIsActive.Size = new Size(112, 19);
			chkIsActive.TabIndex = 8;
			chkIsActive.Text = "Đang hoạt động";
			chkIsActive.UseVisualStyleBackColor = true;
			// 
			// cboType
			// 
			cboType.FormattingEnabled = true;
			cboType.Items.AddRange(new object[] { "Regular", "VIP", "IMAX", "4DX" });
			cboType.Location = new Point(115, 110);
			cboType.Margin = new Padding(3, 2, 3, 2);
			cboType.Name = "cboType";
			cboType.Size = new Size(258, 23);
			cboType.TabIndex = 7;
			// 
			 // numCapacity
			// 
			numCapacity.Increment = new decimal(new int[] { 10, 0, 0, 0 });
			numCapacity.Location = new Point(115, 83);
			numCapacity.Margin = new Padding(3, 2, 3, 2);
			numCapacity.Maximum = new decimal(new int[] { 120, 0, 0, 0 });
			numCapacity.Minimum = new decimal(new int[] { 50, 0, 0, 0 });
			numCapacity.Name = "numCapacity";
			numCapacity.Size = new Size(258, 23);
			numCapacity.TabIndex = 6;
			numCapacity.Value = new decimal(new int[] { 50, 0, 0, 0 });
			// 
			// txtRoomName
			// 
			txtRoomName.Location = new Point(115, 58);
			txtRoomName.Margin = new Padding(3, 2, 3, 2);
			txtRoomName.Name = "txtRoomName";
			txtRoomName.Size = new Size(258, 23);
			txtRoomName.TabIndex = 5;
			// 
			// txtRoomId
			// 
			txtRoomId.Location = new Point(115, 32);
			txtRoomId.Margin = new Padding(3, 2, 3, 2);
			txtRoomId.Name = "txtRoomId";
			txtRoomId.ReadOnly = true;
			txtRoomId.Size = new Size(258, 23);
			txtRoomId.TabIndex = 4;
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new Point(21, 112);
			label5.Name = "label5";
			label5.Size = new Size(70, 15);
			label5.TabIndex = 3;
			label5.Text = "Loại phòng:";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(21, 86);
			label4.Name = "label4";
			label4.Size = new Size(58, 15);
			label4.TabIndex = 2;
			label4.Text = "Sức chứa:";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(21, 60);
			label3.Name = "label3";
			label3.Size = new Size(67, 15);
			label3.TabIndex = 1;
			label3.Text = "Tên phòng:";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(21, 34);
			label2.Name = "label2";
			label2.Size = new Size(21, 15);
			label2.TabIndex = 0;
			label2.Text = "ID:";
			// 
			// groupBox2
			// 
			groupBox2.Controls.Add(btnClear);
			groupBox2.Controls.Add(btnDelete);
			groupBox2.Controls.Add(btnUpdate);
			groupBox2.Controls.Add(btnAdd);
			groupBox2.Location = new Point(430, 58);
			groupBox2.Margin = new Padding(3, 2, 3, 2);
			groupBox2.Name = "groupBox2";
			groupBox2.Padding = new Padding(3, 2, 3, 2);
			groupBox2.Size = new Size(339, 170);
			groupBox2.TabIndex = 2;
			groupBox2.TabStop = false;
			groupBox2.Text = "Chức năng";
			// 
			// btnClear
			// 
			btnClear.Location = new Point(187, 95);
			btnClear.Margin = new Padding(3, 2, 3, 2);
			btnClear.Name = "btnClear";
			btnClear.Size = new Size(130, 36);
			btnClear.TabIndex = 3;
			btnClear.Text = "Làm mớii";
			btnClear.UseVisualStyleBackColor = true;
			btnClear.Click += btnClear_Click;
			// 
			// btnDelete
			// 
			btnDelete.Location = new Point(32, 95);
			btnDelete.Margin = new Padding(3, 2, 3, 2);
			btnDelete.Name = "btnDelete";
			btnDelete.Size = new Size(130, 36);
			btnDelete.TabIndex = 2;
			btnDelete.Text = "Xóa";
			btnDelete.UseVisualStyleBackColor = true;
			btnDelete.Click += btnDelete_Click;
			// 
			// btnUpdate
			// 
			btnUpdate.Location = new Point(187, 45);
			btnUpdate.Margin = new Padding(3, 2, 3, 2);
			btnUpdate.Name = "btnUpdate";
			btnUpdate.Size = new Size(130, 36);
			btnUpdate.TabIndex = 1;
			btnUpdate.Text = "Cập nhật";
			btnUpdate.UseVisualStyleBackColor = true;
			btnUpdate.Click += btnUpdate_Click;
			// 
			// btnAdd
			// 
			btnAdd.Location = new Point(32, 45);
			btnAdd.Margin = new Padding(3, 2, 3, 2);
			btnAdd.Name = "btnAdd";
			btnAdd.Size = new Size(130, 36);
			btnAdd.TabIndex = 0;
			btnAdd.Text = "Thêm";
			btnAdd.UseVisualStyleBackColor = true;
			btnAdd.Click += btnAdd_Click;
			// 
			// dgvRooms
			// 
			dgvRooms.AllowUserToAddRows = false;
			dgvRooms.AllowUserToDeleteRows = false;
			dgvRooms.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvRooms.Location = new Point(20, 240);
			dgvRooms.Margin = new Padding(3, 2, 3, 2);
			dgvRooms.Name = "dgvRooms";
			dgvRooms.ReadOnly = true;
			dgvRooms.RowHeadersWidth = 51;
			dgvRooms.RowTemplate.Height = 29;
			dgvRooms.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvRooms.Size = new Size(749, 178);
			dgvRooms.TabIndex = 3;
			dgvRooms.CellClick += dgvRooms_CellClick;
			// 
			// btnBack
			// 
			btnBack.Location = new Point(20, 16);
			btnBack.Margin = new Padding(3, 2, 3, 2);
			btnBack.Name = "btnBack";
			btnBack.Size = new Size(82, 22);
			btnBack.TabIndex = 4;
			btnBack.Text = "Quay lại";
			btnBack.UseVisualStyleBackColor = true;
			btnBack.Click += btnBack_Click;
			// 
			// FormRooms
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(790, 434);
			Controls.Add(btnBack);
			Controls.Add(dgvRooms);
			Controls.Add(groupBox2);
			Controls.Add(groupBox1);
			Controls.Add(label1);
			Margin = new Padding(3, 2, 3, 2);
			Name = "FormRooms";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Quảnn lý phònng chiếu";
			Load += FormRooms_Load;
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)dgvRooms).EndInit();
			((System.ComponentModel.ISupportInitialize)numCapacity).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
        private GroupBox groupBox1;
        private CheckBox chkIsActive;
        private ComboBox cboType;
        private NumericUpDown numCapacity;
        private TextBox txtRoomName;
        private TextBox txtRoomId;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private GroupBox groupBox2;
        private Button btnClear;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnAdd;
        private DataGridView dgvRooms;
        private Button btnBack;
    }
}