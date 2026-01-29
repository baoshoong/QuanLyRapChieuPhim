#pragma warning disable CA1416
namespace WinFormsApp1.UI
{
	partial class StaffDashboard
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
			this.label1 = new System.Windows.Forms.Label();
			this.lblWelcome = new System.Windows.Forms.Label();
			this.btnSellTickets = new System.Windows.Forms.Button();
			this.btnViewScreenings = new System.Windows.Forms.Button();
			this.btnViewFoods = new System.Windows.Forms.Button();
			this.btnLogout = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
			this.label1.Location = new System.Drawing.Point(230, 29);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(354, 37);
			this.label1.TabIndex = 0;
			this.label1.Text = "BẢNG ĐIỀU KHIỂN - BÁN VÉ";
			// 
			// lblWelcome
			// 
			this.lblWelcome.AutoSize = true;
			this.lblWelcome.Location = new System.Drawing.Point(230, 80);
			this.lblWelcome.Name = "lblWelcome";
			this.lblWelcome.Size = new System.Drawing.Size(75, 20);
			this.lblWelcome.TabIndex = 1;
			this.lblWelcome.Text = "Xin chào, ";
			// 
			// btnSellTickets
			// 
			this.btnSellTickets.BackColor = System.Drawing.Color.LightGreen;
			this.btnSellTickets.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
			this.btnSellTickets.Location = new System.Drawing.Point(87, 138);
			this.btnSellTickets.Name = "btnSellTickets";
			this.btnSellTickets.Size = new System.Drawing.Size(280, 120);
			this.btnSellTickets.TabIndex = 2;
			this.btnSellTickets.Text = "Bán Vé / Đặt Chỗ";
			this.btnSellTickets.UseVisualStyleBackColor = false;
			this.btnSellTickets.Click += new System.EventHandler(this.btnSellTickets_Click);
			// 
			// btnViewScreenings
			// 
			this.btnViewScreenings.Location = new System.Drawing.Point(434, 138);
			this.btnViewScreenings.Name = "btnViewScreenings";
			this.btnViewScreenings.Size = new System.Drawing.Size(280, 55);
			this.btnViewScreenings.TabIndex = 3;
			this.btnViewScreenings.Text = "Xem Lịch Chiếu";
			this.btnViewScreenings.UseVisualStyleBackColor = true;
			this.btnViewScreenings.Click += new System.EventHandler(this.btnViewScreenings_Click);
			// 
			// btnViewFoods
			// 
			this.btnViewFoods.Location = new System.Drawing.Point(434, 203);
			this.btnViewFoods.Name = "btnViewFoods";
			this.btnViewFoods.Size = new System.Drawing.Size(280, 55);
			this.btnViewFoods.TabIndex = 4;
			this.btnViewFoods.Text = "Xem Danh Sách Đồ Ăn";
			this.btnViewFoods.UseVisualStyleBackColor = true;
			this.btnViewFoods.Click += new System.EventHandler(this.btnViewFoods_Click);
			// 
			// btnLogout
			// 
			this.btnLogout.Location = new System.Drawing.Point(670, 29);
			this.btnLogout.Name = "btnLogout";
			this.btnLogout.Size = new System.Drawing.Size(134, 37);
			this.btnLogout.TabIndex = 11;
			this.btnLogout.Text = "Đăng xuất";
			this.btnLogout.UseVisualStyleBackColor = true;
			this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
			// 
			// StaffDashboard
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(829, 313);
			this.Controls.Add(this.btnLogout);
			this.Controls.Add(this.btnViewFoods);
			this.Controls.Add(this.btnViewScreenings);
			this.Controls.Add(this.btnSellTickets);
			this.Controls.Add(this.lblWelcome);
			this.Controls.Add(this.label1);
			this.Name = "StaffDashboard";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Quản lý rạp chiếu phim - Nhân viên";
			this.Load += new System.EventHandler(this.StaffDashboard_Load);
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		#endregion

		private Label label1;
		private Label lblWelcome;
		private Button btnSellTickets;
		private Button btnViewScreenings;
		private Button btnViewFoods;
		private Button btnLogout;
	}
}
