namespace WinFormsApp1.UI
{
    partial class FormMovies
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
			dgvMovies = new DataGridView();
			label2 = new Label();
			label3 = new Label();
			label4 = new Label();
			label5 = new Label();
			label6 = new Label();
			label7 = new Label();
			label8 = new Label();
			label9 = new Label();
			txtMovieId = new TextBox();
			txtTitle = new TextBox();
			txtDirector = new TextBox();
			txtGenre = new TextBox();
			txtDuration = new TextBox();
			txtDescription = new TextBox();
			txtPosterUrl = new TextBox();
			dtpReleaseDate = new DateTimePicker();
			chkIsActive = new CheckBox();
			btnBrowseImage = new Button();
			btnAdd = new Button();
			btnUpdate = new Button();
			btnDelete = new Button();
			btnClear = new Button();
			btnBack = new Button();
			picPoster = new PictureBox();
			label10 = new Label();
			((System.ComponentModel.ISupportInitialize)dgvMovies).BeginInit();
			((System.ComponentModel.ISupportInitialize)picPoster).BeginInit();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
			label1.Location = new Point(522, 9);
			label1.Name = "label1";
			label1.Size = new Size(213, 37);
			label1.TabIndex = 0;
			label1.Text = "QUẢN LÝ PHIM";
			// 
			// dgvMovies
			// 
			dgvMovies.AllowUserToAddRows = false;
			dgvMovies.AllowUserToDeleteRows = false;
			dgvMovies.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvMovies.Location = new Point(11, 373);
			dgvMovies.Name = "dgvMovies";
			dgvMovies.ReadOnly = true;
			dgvMovies.RowHeadersWidth = 51;
			dgvMovies.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvMovies.Size = new Size(1162, 300);
			dgvMovies.TabIndex = 1;
			dgvMovies.CellClick += dgvMovies_CellClick;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(40, 67);
			label2.Name = "label2";
			label2.Size = new Size(24, 20);
			label2.TabIndex = 2;
			label2.Text = "ID";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(40, 108);
			label3.Name = "label3";
			label3.Size = new Size(70, 20);
			label3.TabIndex = 3;
			label3.Text = "Tên phim";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(40, 147);
			label4.Name = "label4";
			label4.Size = new Size(70, 20);
			label4.TabIndex = 4;
			label4.Text = "Đạo diễn";
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new Point(40, 187);
			label5.Name = "label5";
			label5.Size = new Size(62, 20);
			label5.TabIndex = 5;
			label5.Text = "Thể loại";
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Location = new Point(40, 227);
			label6.Name = "label6";
			label6.Size = new Size(125, 20);
			label6.TabIndex = 6;
			label6.Text = "Thời lượng (phút)";
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Location = new Point(40, 267);
			label7.Name = "label7";
			label7.Size = new Size(48, 20);
			label7.TabIndex = 7;
			label7.Text = "Mô tả";
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.Location = new Point(421, 67);
			label8.Name = "label8";
			label8.Size = new Size(115, 20);
			label8.TabIndex = 8;
			label8.Text = "Ngày khởi chiếu";
			// 
			// label9
			// 
			label9.AutoSize = true;
			label9.Location = new Point(421, 108);
			label9.Name = "label9";
			label9.Size = new Size(79, 20);
			label9.TabIndex = 9;
			label9.Text = "Poster URL";
			// 
			// txtMovieId
			// 
			txtMovieId.Enabled = false;
			txtMovieId.Location = new Point(173, 67);
			txtMovieId.Name = "txtMovieId";
			txtMovieId.Size = new Size(199, 27);
			txtMovieId.TabIndex = 10;
			// 
			// txtTitle
			// 
			txtTitle.Location = new Point(173, 105);
			txtTitle.Name = "txtTitle";
			txtTitle.Size = new Size(199, 27);
			txtTitle.TabIndex = 11;
			// 
			// txtDirector
			// 
			txtDirector.Location = new Point(173, 144);
			txtDirector.Name = "txtDirector";
			txtDirector.Size = new Size(199, 27);
			txtDirector.TabIndex = 12;
			// 
			// txtGenre
			// 
			txtGenre.Location = new Point(173, 183);
			txtGenre.Name = "txtGenre";
			txtGenre.Size = new Size(199, 27);
			txtGenre.TabIndex = 13;
			// 
			// txtDuration
			// 
			txtDuration.Location = new Point(173, 224);
			txtDuration.Name = "txtDuration";
			txtDuration.Size = new Size(199, 27);
			txtDuration.TabIndex = 14;
			// 
			// txtDescription
			// 
			txtDescription.Location = new Point(173, 264);
			txtDescription.Multiline = true;
			txtDescription.Name = "txtDescription";
			txtDescription.ScrollBars = ScrollBars.Vertical;
			txtDescription.Size = new Size(199, 87);
			txtDescription.TabIndex = 15;
			// 
			// txtPosterUrl
			// 
			txtPosterUrl.Location = new Point(539, 105);
			txtPosterUrl.Name = "txtPosterUrl";
			txtPosterUrl.Size = new Size(350, 27);
			txtPosterUrl.TabIndex = 16;
			// 
			// dtpReleaseDate
			// 
			dtpReleaseDate.Format = DateTimePickerFormat.Short;
			dtpReleaseDate.Location = new Point(539, 67);
			dtpReleaseDate.Name = "dtpReleaseDate";
			dtpReleaseDate.Size = new Size(201, 27);
			dtpReleaseDate.TabIndex = 17;
			// 
			// chkIsActive
			// 
			chkIsActive.AutoSize = true;
			chkIsActive.Location = new Point(421, 147);
			chkIsActive.Name = "chkIsActive";
			chkIsActive.Size = new Size(106, 24);
			chkIsActive.TabIndex = 18;
			chkIsActive.Text = "Đang chiếu";
			chkIsActive.UseVisualStyleBackColor = true;
			// 
			// btnBrowseImage
			// 
			btnBrowseImage.Location = new Point(895, 104);
			btnBrowseImage.Name = "btnBrowseImage";
			btnBrowseImage.Size = new Size(94, 29);
			btnBrowseImage.TabIndex = 19;
			btnBrowseImage.Text = "Chọn ảnh";
			btnBrowseImage.UseVisualStyleBackColor = true;
			btnBrowseImage.Click += btnBrowseImage_Click;
			// 
			// btnAdd
			// 
			btnAdd.BackColor = Color.LightGreen;
			btnAdd.Location = new Point(421, 183);
			btnAdd.Name = "btnAdd";
			btnAdd.Size = new Size(94, 40);
			btnAdd.TabIndex = 20;
			btnAdd.Text = "Thêm";
			btnAdd.UseVisualStyleBackColor = false;
			btnAdd.Click += btnAdd_Click;
			// 
			// btnUpdate
			// 
			btnUpdate.BackColor = Color.LightSkyBlue;
			btnUpdate.Enabled = false;
			btnUpdate.Location = new Point(520, 183);
			btnUpdate.Name = "btnUpdate";
			btnUpdate.Size = new Size(94, 40);
			btnUpdate.TabIndex = 21;
			btnUpdate.Text = "Chỉnh";
			btnUpdate.UseVisualStyleBackColor = false;
			btnUpdate.Click += btnUpdate_Click;
			// 
			// btnDelete
			// 
			btnDelete.BackColor = Color.LightCoral;
			btnDelete.Enabled = false;
			btnDelete.Location = new Point(421, 229);
			btnDelete.Name = "btnDelete";
			btnDelete.Size = new Size(94, 40);
			btnDelete.TabIndex = 22;
			btnDelete.Text = "Xóa";
			btnDelete.UseVisualStyleBackColor = false;
			btnDelete.Click += btnDelete_Click;
			// 
			// btnClear
			// 
			btnClear.Location = new Point(520, 229);
			btnClear.Name = "btnClear";
			btnClear.Size = new Size(94, 40);
			btnClear.TabIndex = 23;
			btnClear.Text = "Nhập";
			btnClear.UseVisualStyleBackColor = true;
			btnClear.Click += btnClear_Click;
			// 
			// btnBack
			// 
			btnBack.Location = new Point(1080, 9);
			btnBack.Name = "btnBack";
			btnBack.Size = new Size(94, 40);
			btnBack.TabIndex = 24;
			btnBack.Text = "Quay lại";
			btnBack.UseVisualStyleBackColor = true;
			btnBack.Click += btnBack_Click;
			// 
			// picPoster
			// 
			picPoster.BorderStyle = BorderStyle.FixedSingle;
			picPoster.Location = new Point(995, 67);
			picPoster.Name = "picPoster";
			picPoster.Size = new Size(179, 283);
			picPoster.SizeMode = PictureBoxSizeMode.Zoom;
			picPoster.TabIndex = 25;
			picPoster.TabStop = false;
			// 
			// label10
			// 
			label10.AutoSize = true;
			label10.Location = new Point(14, 349);
			label10.Name = "label10";
			label10.Size = new Size(141, 20);
			label10.TabIndex = 26;
			label10.Text = "Danh sách các phim";
			// 
			// FormMovies
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1186, 685);
			Controls.Add(label10);
			Controls.Add(picPoster);
			Controls.Add(btnBack);
			Controls.Add(btnClear);
			Controls.Add(btnDelete);
			Controls.Add(btnUpdate);
			Controls.Add(btnAdd);
			Controls.Add(btnBrowseImage);
			Controls.Add(chkIsActive);
			Controls.Add(dtpReleaseDate);
			Controls.Add(txtPosterUrl);
			Controls.Add(txtDescription);
			Controls.Add(txtDuration);
			Controls.Add(txtGenre);
			Controls.Add(txtDirector);
			Controls.Add(txtTitle);
			Controls.Add(txtMovieId);
			Controls.Add(label9);
			Controls.Add(label8);
			Controls.Add(label7);
			Controls.Add(label6);
			Controls.Add(label5);
			Controls.Add(label4);
			Controls.Add(label3);
			Controls.Add(label2);
			Controls.Add(dgvMovies);
			Controls.Add(label1);
			Name = "FormMovies";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Quản lý phim";
			Load += FormMovies_Load;
			((System.ComponentModel.ISupportInitialize)dgvMovies).EndInit();
			((System.ComponentModel.ISupportInitialize)picPoster).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
        private DataGridView dgvMovies;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private TextBox txtMovieId;
        private TextBox txtTitle;
        private TextBox txtDirector;
        private TextBox txtGenre;
        private TextBox txtDuration;
        private TextBox txtDescription;
        private TextBox txtPosterUrl;
        private DateTimePicker dtpReleaseDate;
        private CheckBox chkIsActive;
        private Button btnBrowseImage;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private Button btnBack;
        private PictureBox picPoster;
        private Label label10;
    }
}