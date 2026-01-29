namespace WinFormsApp1.UI
{
    partial class FormViewFoods
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
			dgvFoods = new DataGridView();
			label2 = new Label();
			cboCategory = new ComboBox();
			btnBack = new Button();
			((System.ComponentModel.ISupportInitialize)dgvFoods).BeginInit();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
			label1.Location = new Point(318, 19);
			label1.Name = "label1";
			label1.Size = new Size(219, 30);
			label1.TabIndex = 0;
			label1.Text = "DANH SÁCH ĐỒ ĂN";
			// 
			// dgvFoods
			// 
			dgvFoods.AllowUserToAddRows = false;
			dgvFoods.AllowUserToDeleteRows = false;
			dgvFoods.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvFoods.Location = new Point(24, 101);
			dgvFoods.Margin = new Padding(3, 2, 3, 2);
			dgvFoods.Name = "dgvFoods";
			dgvFoods.ReadOnly = true;
			dgvFoods.RowHeadersWidth = 51;
			dgvFoods.RowTemplate.Height = 29;
			dgvFoods.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvFoods.Size = new Size(811, 290);
			dgvFoods.TabIndex = 1;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(24, 69);
			label2.Name = "label2";
			label2.Size = new Size(65, 15);
			label2.TabIndex = 2;
			label2.Text = "Danh mục:";
			// 
			// cboCategory
			// 
			cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
			cboCategory.FormattingEnabled = true;
			cboCategory.Location = new Point(99, 67);
			cboCategory.Margin = new Padding(3, 2, 3, 2);
			cboCategory.Name = "cboCategory";
			cboCategory.Size = new Size(288, 23);
			cboCategory.TabIndex = 3;
			cboCategory.SelectedIndexChanged += cboCategory_SelectedIndexChanged;
			// 
			// btnBack
			// 
			btnBack.Location = new Point(24, 19);
			btnBack.Margin = new Padding(3, 2, 3, 2);
			btnBack.Name = "btnBack";
			btnBack.Size = new Size(82, 22);
			btnBack.TabIndex = 4;
			btnBack.Text = "Quay lại";
			btnBack.UseVisualStyleBackColor = true;
			btnBack.Click += btnBack_Click;
			// 
			// FormViewFoods
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(857, 408);
			Controls.Add(btnBack);
			Controls.Add(cboCategory);
			Controls.Add(label2);
			Controls.Add(dgvFoods);
			Controls.Add(label1);
			Margin = new Padding(3, 2, 3, 2);
			Name = "FormViewFoods";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Xem danh sách đồ ăn";
			Load += FormViewFoods_Load;
			((System.ComponentModel.ISupportInitialize)dgvFoods).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
        private DataGridView dgvFoods;
        private Label label2;
        private ComboBox cboCategory;
        private Button btnBack;
    }
}