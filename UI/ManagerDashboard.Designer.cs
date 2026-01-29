#pragma warning disable CA1416
namespace WinFormsApp1.UI
{
	partial class ManagerDashboard
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
			this.label1 = new System.Windows.Forms.Label();
			this.lblWelcome = new System.Windows.Forms.Label();
			this.btnManageUsers = new System.Windows.Forms.Button();
			this.btnManageMovies = new System.Windows.Forms.Button();
			this.btnManageScreenings = new System.Windows.Forms.Button();
			this.btnManageRooms = new System.Windows.Forms.Button();
			this.btnManageFoods = new System.Windows.Forms.Button();
			this.btnManageVouchers = new System.Windows.Forms.Button();
			this.btnViewRevenue = new System.Windows.Forms.Button();
			this.btnSettings = new System.Windows.Forms.Button();
			this.btnViewBookings = new System.Windows.Forms.Button();
			this.btnLogout = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
			this.label1.Location = new System.Drawing.Point(373, 29);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(268, 37);
			this.label1.TabIndex = 0;
			this.label1.Text = "BẢNG ĐIỀU KHIỂN";
			// 
			// lblWelcome
			// 
			this.lblWelcome.AutoSize = true;
			this.lblWelcome.Location = new System.Drawing.Point(373, 80);
			this.lblWelcome.Name = "lblWelcome";
			this.lblWelcome.Size = new System.Drawing.Size(75, 20);
			this.lblWelcome.TabIndex = 1;
			this.lblWelcome.Text = "Xin chào, ";
			// 
			// btnManageUsers
			// 
			this.btnManageUsers.Location = new System.Drawing.Point(87, 138);
			this.btnManageUsers.Name = "btnManageUsers";
			this.btnManageUsers.Size = new System.Drawing.Size(200, 80);
			this.btnManageUsers.TabIndex = 2;
			this.btnManageUsers.Text = "Quản lý người dùng";
			this.btnManageUsers.UseVisualStyleBackColor = true;
			this.btnManageUsers.Click += new System.EventHandler(this.btnManageUsers_Click);
			// 
			// btnManageMovies
			// 
			this.btnManageMovies.Location = new System.Drawing.Point(406, 138);
			this.btnManageMovies.Name = "btnManageMovies";
			this.btnManageMovies.Size = new System.Drawing.Size(200, 80);
			this.btnManageMovies.TabIndex = 3;
			this.btnManageMovies.Text = "Quản lý phim";
			this.btnManageMovies.UseVisualStyleBackColor = true;
			this.btnManageMovies.Click += new System.EventHandler(this.btnManageMovies_Click);
			// 
			// btnManageScreenings
			// 
			this.btnManageScreenings.Location = new System.Drawing.Point(727, 138);
			this.btnManageScreenings.Name = "btnManageScreenings";
			this.btnManageScreenings.Size = new System.Drawing.Size(200, 80);
			this.btnManageScreenings.TabIndex = 4;
			this.btnManageScreenings.Text = "Quản lý lịch chiếu";
			this.btnManageScreenings.UseVisualStyleBackColor = true;
			this.btnManageScreenings.Click += new System.EventHandler(this.btnManageScreenings_Click);
			// 
			// btnManageRooms
			// 
			this.btnManageRooms.Location = new System.Drawing.Point(87, 259);
			this.btnManageRooms.Name = "btnManageRooms";
			this.btnManageRooms.Size = new System.Drawing.Size(200, 80);
			this.btnManageRooms.TabIndex = 5;
			this.btnManageRooms.Text = "Quản lý phòng chiếu";
			this.btnManageRooms.UseVisualStyleBackColor = true;
			this.btnManageRooms.Click += new System.EventHandler(this.btnManageRooms_Click);
			// 
			// btnManageFoods
			// 
			this.btnManageFoods.Location = new System.Drawing.Point(406, 259);
			this.btnManageFoods.Name = "btnManageFoods";
			this.btnManageFoods.Size = new System.Drawing.Size(200, 80);
			this.btnManageFoods.TabIndex = 6;
			this.btnManageFoods.Text = "Quản lý đồ ăn";
			this.btnManageFoods.UseVisualStyleBackColor = true;
			this.btnManageFoods.Click += new System.EventHandler(this.btnManageFoods_Click);
			// 
			// btnManageVouchers
			// 
			this.btnManageVouchers.Location = new System.Drawing.Point(727, 259);
			this.btnManageVouchers.Name = "btnManageVouchers";
			this.btnManageVouchers.Size = new System.Drawing.Size(200, 80);
			this.btnManageVouchers.TabIndex = 7;
			this.btnManageVouchers.Text = "Quản lý voucher";
			this.btnManageVouchers.UseVisualStyleBackColor = true;
			this.btnManageVouchers.Click += new System.EventHandler(this.btnManageVouchers_Click);
			// 
			// btnViewRevenue
			// 
			this.btnViewRevenue.Location = new System.Drawing.Point(87, 377);
			this.btnViewRevenue.Name = "btnViewRevenue";
			this.btnViewRevenue.Size = new System.Drawing.Size(200, 80);
			this.btnViewRevenue.TabIndex = 8;
			this.btnViewRevenue.Text = "Xem báo cáo doanh thu";
			this.btnViewRevenue.UseVisualStyleBackColor = true;
			this.btnViewRevenue.Click += new System.EventHandler(this.btnViewRevenue_Click);
			// 
			// btnSettings
			// 
			this.btnSettings.Location = new System.Drawing.Point(406, 377);
			this.btnSettings.Name = "btnSettings";
			this.btnSettings.Size = new System.Drawing.Size(200, 80);
			this.btnSettings.TabIndex = 9;
			this.btnSettings.Text = "Cài đặt hệ thống";
			this.btnSettings.UseVisualStyleBackColor = true;
			this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
			// 
			// btnViewBookings
			// 
			this.btnViewBookings.Location = new System.Drawing.Point(727, 377);
			this.btnViewBookings.Name = "btnViewBookings";
			this.btnViewBookings.Size = new System.Drawing.Size(200, 80);
			this.btnViewBookings.TabIndex = 10;
			this.btnViewBookings.Text = "Xem tất cả đặt vé";
			this.btnViewBookings.UseVisualStyleBackColor = true;
			this.btnViewBookings.Click += new System.EventHandler(this.btnViewBookings_Click);
			// 
			// btnLogout
			// 
			this.btnLogout.Location = new System.Drawing.Point(854, 29);
			this.btnLogout.Name = "btnLogout";
			this.btnLogout.Size = new System.Drawing.Size(134, 37);
			this.btnLogout.TabIndex = 11;
			this.btnLogout.Text = "Đăng xuất";
			this.btnLogout.UseVisualStyleBackColor = true;
			this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
			// 
			// ManagerDashboard
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1014, 502);
			this.Controls.Add(this.btnLogout);
			this.Controls.Add(this.btnViewBookings);
			this.Controls.Add(this.btnSettings);
			this.Controls.Add(this.btnViewRevenue);
			this.Controls.Add(this.btnManageVouchers);
			this.Controls.Add(this.btnManageFoods);
			this.Controls.Add(this.btnManageRooms);
			this.Controls.Add(this.btnManageScreenings);
			this.Controls.Add(this.btnManageMovies);
			this.Controls.Add(this.btnManageUsers);
			this.Controls.Add(this.lblWelcome);
			this.Controls.Add(this.label1);
			this.Name = "ManagerDashboard";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Quản lý rạp chiếu phim - Quản lý";
			this.Load += new System.EventHandler(this.ManagerDashboard_Load);
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		#endregion

		private Label label1;
		private Label lblWelcome;
		private Button btnManageUsers;
		private Button btnManageMovies;
		private Button btnManageScreenings;
		private Button btnManageRooms;
		private Button btnManageFoods;
		private Button btnManageVouchers;
		private Button btnViewRevenue;
		private Button btnSettings;
		private Button btnViewBookings;
		private Button btnLogout;
	}
}