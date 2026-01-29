#pragma warning disable CA1416 // Tắt cảnh báo tương thích nền tảng

namespace WinFormsApp1.UI
{
	partial class FormViewScreenings
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
			this.dgvScreenings = new System.Windows.Forms.DataGridView();
			this.btnBack = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgvScreenings)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label1.Location = new System.Drawing.Point(480, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(262, 38);
			this.label1.TabIndex = 0;
			this.label1.Text = "XEM LỊCH CHIẾU";
			// 
			// dgvScreenings
			// 
			this.dgvScreenings.AllowUserToAddRows = false;
			this.dgvScreenings.AllowUserToDeleteRows = false;
			this.dgvScreenings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvScreenings.Location = new System.Drawing.Point(12, 80);
			this.dgvScreenings.Name = "dgvScreenings";
			this.dgvScreenings.ReadOnly = true;
			this.dgvScreenings.RowHeadersWidth = 51;
			this.dgvScreenings.RowTemplate.Height = 29;
			this.dgvScreenings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvScreenings.Size = new System.Drawing.Size(1176, 612);
			this.dgvScreenings.TabIndex = 1;
			// 
			// btnBack
			// 
			this.btnBack.Location = new System.Drawing.Point(12, 20);
			this.btnBack.Name = "btnBack";
			this.btnBack.Size = new System.Drawing.Size(110, 40);
			this.btnBack.TabIndex = 2;
			this.btnBack.Text = "Quay lại";
			this.btnBack.UseVisualStyleBackColor = true;
			this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
			// 
			// FormViewScreenings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1200, 704);
			this.Controls.Add(this.btnBack);
			this.Controls.Add(this.dgvScreenings);
			this.Controls.Add(this.label1);
			this.Name = "FormViewScreenings";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Xem Lịch Chiếu";
			this.Load += new System.EventHandler(this.FormViewScreenings_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvScreenings)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGridView dgvScreenings;
		private System.Windows.Forms.Button btnBack;
	}
}
