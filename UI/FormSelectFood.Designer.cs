#pragma warning disable CA1416
namespace WinFormsApp1.UI
{
	partial class FormSelectFood
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
			this.dgvAvailableFoods = new System.Windows.Forms.DataGridView();
			this.dgvSelectedFoods = new System.Windows.Forms.DataGridView();
			this.btnConfirm = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lblTotalAmount = new System.Windows.Forms.Label();
			this.btnCancel = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.lblTotalPrice = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dgvAvailableFoods)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvSelectedFoods)).BeginInit();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// dgvAvailableFoods
			// 
			this.dgvAvailableFoods.AllowUserToAddRows = false;
			this.dgvAvailableFoods.AllowUserToDeleteRows = false;
			this.dgvAvailableFoods.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.dgvAvailableFoods.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvAvailableFoods.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvAvailableFoods.Location = new System.Drawing.Point(10, 10);
			this.dgvAvailableFoods.MultiSelect = false;
			this.dgvAvailableFoods.Name = "dgvAvailableFoods";
			this.dgvAvailableFoods.ReadOnly = true;
			this.dgvAvailableFoods.RowHeadersWidth = 51;
			this.dgvAvailableFoods.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvAvailableFoods.Size = new System.Drawing.Size(480, 380);
			this.dgvAvailableFoods.TabIndex = 0;
			// 
			// dgvSelectedFoods
			// 
			this.dgvSelectedFoods.AllowUserToAddRows = false;
			this.dgvSelectedFoods.AllowUserToDeleteRows = false;
			this.dgvSelectedFoods.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.dgvSelectedFoods.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvSelectedFoods.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvSelectedFoods.Location = new System.Drawing.Point(10, 10);
			this.dgvSelectedFoods.MultiSelect = false;
			this.dgvSelectedFoods.Name = "dgvSelectedFoods";
			this.dgvSelectedFoods.ReadOnly = true;
			this.dgvSelectedFoods.RowHeadersWidth = 51;
			this.dgvSelectedFoods.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvSelectedFoods.Size = new System.Drawing.Size(480, 380);
			this.dgvSelectedFoods.TabIndex = 1;
			// 
			// btnConfirm
			// 
			this.btnConfirm.BackColor = System.Drawing.Color.ForestGreen;
			this.btnConfirm.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnConfirm.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.btnConfirm.ForeColor = System.Drawing.Color.White;
			this.btnConfirm.Location = new System.Drawing.Point(800, 475);
			this.btnConfirm.Name = "btnConfirm";
			this.btnConfirm.Size = new System.Drawing.Size(197, 40);
			this.btnConfirm.TabIndex = 4;
			this.btnConfirm.Text = "XÁC NHẬN";
			this.btnConfirm.UseVisualStyleBackColor = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label1.Location = new System.Drawing.Point(12, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(196, 28);
			this.label1.TabIndex = 5;
			this.label1.Text = "SẢN PHẨM CÓ SẴN";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label2.Location = new System.Drawing.Point(520, 19);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(201, 28);
			this.label2.TabIndex = 6;
			this.label2.Text = "SẢN PHẨM ĐÃ CHỌN";
			// 
			// lblTotalAmount
			// 
			this.lblTotalAmount.AutoSize = true;
			this.lblTotalAmount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lblTotalAmount.Location = new System.Drawing.Point(520, 455);
			this.lblTotalAmount.Name = "lblTotalAmount";
			this.lblTotalAmount.Size = new System.Drawing.Size(123, 28);
			this.lblTotalAmount.TabIndex = 8;
			this.lblTotalAmount.Text = "TỔNG TIỀN:";
			// 
			// btnCancel
			// 
			this.btnCancel.BackColor = System.Drawing.Color.Firebrick;
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.btnCancel.ForeColor = System.Drawing.Color.White;
			this.btnCancel.Location = new System.Drawing.Point(590, 475);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(197, 40);
			this.btnCancel.TabIndex = 10;
			this.btnCancel.Text = "HỦY";
			this.btnCancel.UseVisualStyleBackColor = false;
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.dgvAvailableFoods);
			this.panel1.Location = new System.Drawing.Point(12, 50);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(500, 400);
			this.panel1.TabIndex = 11;
			// 
			// panel2
			// 
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.dgvSelectedFoods);
			this.panel2.Location = new System.Drawing.Point(520, 50);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(500, 400);
			this.panel2.TabIndex = 12;
			// 
			// lblTotalPrice
			// 
			this.lblTotalPrice.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lblTotalPrice.ForeColor = System.Drawing.Color.Red;
			this.lblTotalPrice.Location = new System.Drawing.Point(650, 455);
			this.lblTotalPrice.Name = "lblTotalPrice";
			this.lblTotalPrice.Size = new System.Drawing.Size(347, 28);
			this.lblTotalPrice.TabIndex = 13;
			this.lblTotalPrice.Text = "0 VNĐ";
			this.lblTotalPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// FormSelectFood
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1032, 527);
			this.Controls.Add(this.lblTotalPrice);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.lblTotalAmount);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnConfirm);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormSelectFood";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Chọn Đồ Ăn";
			this.Load += new System.EventHandler(this.FormSelectFood_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvAvailableFoods)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvSelectedFoods)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion

		private System.Windows.Forms.DataGridView dgvAvailableFoods;
		private System.Windows.Forms.DataGridView dgvSelectedFoods;
		private System.Windows.Forms.Button btnConfirm;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblTotalAmount;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label lblTotalPrice;
	}
}
