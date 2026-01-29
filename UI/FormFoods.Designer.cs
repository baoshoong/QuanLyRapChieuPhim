namespace WinFormsApp1.UI
{
    partial class FormFoods
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed.</param>
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
			btnBrowseImage = new Button();
			txtImagePath = new TextBox();
			label7 = new Label();
			chkIsAvailable = new CheckBox();
			cboCategory = new ComboBox();
			txtPrice = new TextBox();
			txtDescription = new TextBox();
			txtFoodName = new TextBox();
			txtFoodId = new TextBox();
			label6 = new Label();
			label5 = new Label();
			label4 = new Label();
			label3 = new Label();
			label2 = new Label();
			groupBox2 = new GroupBox();
			btnClear = new Button();
			btnDelete = new Button();
			btnUpdate = new Button();
			btnAdd = new Button();
			dgvFoods = new DataGridView();
			btnBack = new Button();
			groupBox1.SuspendLayout();
			groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dgvFoods).BeginInit();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
			label1.Location = new Point(351, 16);
			label1.Name = "label1";
			label1.Size = new Size(184, 30);
			label1.TabIndex = 0;
			label1.Text = "QUẢN LÝ ĐỒ ĂN";
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(btnBrowseImage);
			groupBox1.Controls.Add(txtImagePath);
			groupBox1.Controls.Add(label7);
			groupBox1.Controls.Add(chkIsAvailable);
			groupBox1.Controls.Add(cboCategory);
			groupBox1.Controls.Add(txtPrice);
			groupBox1.Controls.Add(txtDescription);
			groupBox1.Controls.Add(txtFoodName);
			groupBox1.Controls.Add(txtFoodId);
			groupBox1.Controls.Add(label6);
			groupBox1.Controls.Add(label5);
			groupBox1.Controls.Add(label4);
			groupBox1.Controls.Add(label3);
			groupBox1.Controls.Add(label2);
			groupBox1.Location = new Point(20, 58);
			groupBox1.Margin = new Padding(3, 2, 3, 2);
			groupBox1.Name = "groupBox1";
			groupBox1.Padding = new Padding(3, 2, 3, 2);
			groupBox1.Size = new Size(522, 206);
			groupBox1.TabIndex = 1;
			groupBox1.TabStop = false;
			groupBox1.Text = "Thông tin đồ ăn";
			// 
			// btnBrowseImage
			// 
			btnBrowseImage.Location = new Point(430, 160);
			btnBrowseImage.Margin = new Padding(3, 2, 3, 2);
			btnBrowseImage.Name = "btnBrowseImage";
			btnBrowseImage.Size = new Size(71, 22);
			btnBrowseImage.TabIndex = 13;
			btnBrowseImage.Text = "Chọn";
			btnBrowseImage.UseVisualStyleBackColor = true;
			btnBrowseImage.Click += btnBrowseImage_Click;
			// 
			// txtImagePath
			// 
			txtImagePath.Location = new Point(100, 161);
			txtImagePath.Margin = new Padding(3, 2, 3, 2);
			txtImagePath.Name = "txtImagePath";
			txtImagePath.Size = new Size(326, 23);
			txtImagePath.TabIndex = 12;
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Location = new Point(18, 164);
			label7.Name = "label7";
			label7.Size = new Size(59, 15);
			label7.TabIndex = 11;
			label7.Text = "Hình ảnh:";
			// 
			// chkIsAvailable
			// 
			chkIsAvailable.AutoSize = true;
			chkIsAvailable.Location = new Point(100, 137);
			chkIsAvailable.Margin = new Padding(3, 2, 3, 2);
			chkIsAvailable.Name = "chkIsAvailable";
			chkIsAvailable.Size = new Size(78, 19);
			chkIsAvailable.TabIndex = 10;
			chkIsAvailable.Text = "Còn hàng";
			chkIsAvailable.UseVisualStyleBackColor = true;
			// 
			// cboCategory
			// 
			cboCategory.FormattingEnabled = true;
			cboCategory.Location = new Point(100, 110);
			cboCategory.Margin = new Padding(3, 2, 3, 2);
			cboCategory.Name = "cboCategory";
			cboCategory.Size = new Size(402, 23);
			cboCategory.TabIndex = 9;
			// 
			// txtPrice
			// 
			txtPrice.Location = new Point(100, 83);
			txtPrice.Margin = new Padding(3, 2, 3, 2);
			txtPrice.Name = "txtPrice";
			txtPrice.Size = new Size(402, 23);
			txtPrice.TabIndex = 8;
			// 
			// txtDescription
			// 
			txtDescription.Location = new Point(100, 58);
			txtDescription.Margin = new Padding(3, 2, 3, 2);
			txtDescription.Name = "txtDescription";
			txtDescription.Size = new Size(402, 23);
			txtDescription.TabIndex = 7;
			// 
			// txtFoodName
			// 
			txtFoodName.Location = new Point(314, 32);
			txtFoodName.Margin = new Padding(3, 2, 3, 2);
			txtFoodName.Name = "txtFoodName";
			txtFoodName.Size = new Size(188, 23);
			txtFoodName.TabIndex = 6;
			// 
			// txtFoodId
			// 
			txtFoodId.Location = new Point(100, 32);
			txtFoodId.Margin = new Padding(3, 2, 3, 2);
			txtFoodId.Name = "txtFoodId";
			txtFoodId.ReadOnly = true;
			txtFoodId.Size = new Size(110, 23);
			txtFoodId.TabIndex = 5;
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Location = new Point(228, 34);
			label6.Name = "label6";
			label6.Size = new Size(73, 15);
			label6.TabIndex = 4;
			label6.Text = "Tên món ăn:";
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new Point(18, 112);
			label5.Name = "label5";
			label5.Size = new Size(65, 15);
			label5.TabIndex = 3;
			label5.Text = "Danh mục:";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(18, 86);
			label4.Name = "label4";
			label4.Size = new Size(27, 15);
			label4.TabIndex = 2;
			label4.Text = "Giá:";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(18, 60);
			label3.Name = "label3";
			label3.Size = new Size(41, 15);
			label3.TabIndex = 1;
			label3.Text = "Mô tả:";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(18, 34);
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
			groupBox2.Location = new Point(562, 58);
			groupBox2.Margin = new Padding(3, 2, 3, 2);
			groupBox2.Name = "groupBox2";
			groupBox2.Padding = new Padding(3, 2, 3, 2);
			groupBox2.Size = new Size(290, 206);
			groupBox2.TabIndex = 2;
			groupBox2.TabStop = false;
			groupBox2.Text = "Chức năng";
			// 
			// btnClear
			// 
			btnClear.Location = new Point(163, 119);
			btnClear.Margin = new Padding(3, 2, 3, 2);
			btnClear.Name = "btnClear";
			btnClear.Size = new Size(105, 36);
			btnClear.TabIndex = 3;
			btnClear.Text = "Làm mới";
			btnClear.UseVisualStyleBackColor = true;
			btnClear.Click += btnClear_Click;
			// 
			// btnDelete
			// 
			btnDelete.Location = new Point(27, 119);
			btnDelete.Margin = new Padding(3, 2, 3, 2);
			btnDelete.Name = "btnDelete";
			btnDelete.Size = new Size(105, 36);
			btnDelete.TabIndex = 2;
			btnDelete.Text = "Xóa";
			btnDelete.UseVisualStyleBackColor = true;
			btnDelete.Click += btnDelete_Click;
			// 
			// btnUpdate
			// 
			btnUpdate.Location = new Point(163, 58);
			btnUpdate.Margin = new Padding(3, 2, 3, 2);
			btnUpdate.Name = "btnUpdate";
			btnUpdate.Size = new Size(105, 36);
			btnUpdate.TabIndex = 1;
			btnUpdate.Text = "Cập nhật";
			btnUpdate.UseVisualStyleBackColor = true;
			btnUpdate.Click += btnUpdate_Click;
			// 
			// btnAdd
			// 
			btnAdd.Location = new Point(27, 58);
			btnAdd.Margin = new Padding(3, 2, 3, 2);
			btnAdd.Name = "btnAdd";
			btnAdd.Size = new Size(105, 36);
			btnAdd.TabIndex = 0;
			btnAdd.Text = "Thêm";
			btnAdd.UseVisualStyleBackColor = true;
			btnAdd.Click += btnAdd_Click;
			// 
			// dgvFoods
			// 
			dgvFoods.AllowUserToAddRows = false;
			dgvFoods.AllowUserToDeleteRows = false;
			dgvFoods.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvFoods.Location = new Point(20, 280);
			dgvFoods.Margin = new Padding(3, 2, 3, 2);
			dgvFoods.Name = "dgvFoods";
			dgvFoods.ReadOnly = true;
			dgvFoods.RowHeadersWidth = 51;
			dgvFoods.RowTemplate.Height = 29;
			dgvFoods.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvFoods.Size = new Size(831, 178);
			dgvFoods.TabIndex = 3;
			dgvFoods.CellClick += dgvFoods_CellClick;
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
			// FormFoods
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(872, 475);
			Controls.Add(btnBack);
			Controls.Add(dgvFoods);
			Controls.Add(groupBox2);
			Controls.Add(groupBox1);
			Controls.Add(label1);
			Margin = new Padding(3, 2, 3, 2);
			Name = "FormFoods";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Quản lý đồ ăn";
			Load += FormFoods_Load;
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)dgvFoods).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
        private GroupBox groupBox1;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private GroupBox groupBox2;
        private Button btnClear;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnAdd;
        private DataGridView dgvFoods;
        private Button btnBack;
        private TextBox txtPrice;
        private TextBox txtDescription;
        private TextBox txtFoodName;
        private TextBox txtFoodId;
        private Label label6;
        private ComboBox cboCategory;
        private CheckBox chkIsAvailable;
        private Button btnBrowseImage;
        private TextBox txtImagePath;
        private Label label7;
    }
}