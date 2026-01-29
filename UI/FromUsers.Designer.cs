#pragma warning disable CA1416
namespace WinFormsApp1.UI
{
	partial class FormUsers
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
			this.dgvUsers = new System.Windows.Forms.DataGridView();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtPhone = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.txtEmail = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.cboRole = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtFullName = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.chkIsActive = new System.Windows.Forms.CheckBox();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.txtUsername = new System.Windows.Forms.TextBox();
			this.txtUserId = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnUpdate = new System.Windows.Forms.Button();
			this.btnDelete = new System.Windows.Forms.Button();
			this.btnClear = new System.Windows.Forms.Button();
			this.btnBack = new System.Windows.Forms.Button();
			this.label9 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
			this.label1.Location = new System.Drawing.Point(455, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(320, 37);
			this.label1.TabIndex = 0;
			this.label1.Text = "QUẢN LÝ NGƯỜI DÙNG";
			// 
			// dgvUsers
			// 
			this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvUsers.Location = new System.Drawing.Point(12, 330);
			this.dgvUsers.Name = "dgvUsers";
			this.dgvUsers.RowHeadersWidth = 51;
			this.dgvUsers.Size = new System.Drawing.Size(1176, 362);
			this.dgvUsers.TabIndex = 1;
			this.dgvUsers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsers_CellClick);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtPhone);
			this.groupBox1.Controls.Add(this.label10);
			this.groupBox1.Controls.Add(this.txtEmail);
			this.groupBox1.Controls.Add(this.label11);
			this.groupBox1.Controls.Add(this.cboRole);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.txtFullName);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.chkIsActive);
			this.groupBox1.Controls.Add(this.txtPassword);
			this.groupBox1.Controls.Add(this.txtUsername);
			this.groupBox1.Controls.Add(this.txtUserId);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Location = new System.Drawing.Point(12, 61);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(776, 230);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Thông tin người dùng";
			// 
			 // txtPhone
			// 
			this.txtPhone.Location = new System.Drawing.Point(533, 150);
			this.txtPhone.Name = "txtPhone";
			this.txtPhone.Size = new System.Drawing.Size(216, 27);
			this.txtPhone.TabIndex = 12;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(448, 153);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(35, 20);
			this.label10.TabIndex = 11;
			this.label10.Text = "SĐT";
			// 
			// txtEmail
			// 
			this.txtEmail.Location = new System.Drawing.Point(533, 113);
			this.txtEmail.Name = "txtEmail";
			this.txtEmail.Size = new System.Drawing.Size(216, 27);
			this.txtEmail.TabIndex = 10;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(448, 116);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(46, 20);
			this.label11.TabIndex = 9;
			this.label11.Text = "Email";
			// 
			// cboRole
			// 
			this.cboRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboRole.FormattingEnabled = true;
			this.cboRole.Location = new System.Drawing.Point(533, 43);
			this.cboRole.Name = "cboRole";
			this.cboRole.Size = new System.Drawing.Size(216, 28);
			this.cboRole.TabIndex = 8;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(448, 46);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(61, 20);
			this.label6.TabIndex = 7;
			this.label6.Text = "Vai trò";
			// 
			// txtFullName
			// 
			this.txtFullName.Location = new System.Drawing.Point(127, 150);
			this.txtFullName.Name = "txtFullName";
			this.txtFullName.Size = new System.Drawing.Size(298, 27);
			this.txtFullName.TabIndex = 6;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(16, 153);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(82, 20);
			this.label5.TabIndex = 5;
			this.label5.Text = "Họ và tên";
			// 
			// chkIsActive
			// 
			this.chkIsActive.AutoSize = true;
			this.chkIsActive.Location = new System.Drawing.Point(533, 81);
			this.chkIsActive.Name = "chkIsActive";
			this.chkIsActive.Size = new System.Drawing.Size(95, 24);
			this.chkIsActive.TabIndex = 4;
			this.chkIsActive.Text = "Kích hoạt";
			this.chkIsActive.UseVisualStyleBackColor = true;
			// 
			// txtPassword
			// 
			this.txtPassword.Location = new System.Drawing.Point(127, 113);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.PasswordChar = '*';
			this.txtPassword.Size = new System.Drawing.Size(298, 27);
			this.txtPassword.TabIndex = 3;
			// 
			// txtUsername
			// 
			this.txtUsername.Location = new System.Drawing.Point(127, 78);
			this.txtUsername.Name = "txtUsername";
			this.txtUsername.Size = new System.Drawing.Size(298, 27);
			this.txtUsername.TabIndex = 2;
			// 
			// txtUserId
			// 
			this.txtUserId.Enabled = false;
			this.txtUserId.Location = new System.Drawing.Point(127, 43);
			this.txtUserId.Name = "txtUserId";
			this.txtUserId.Size = new System.Drawing.Size(298, 27);
			this.txtUserId.TabIndex = 1;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(16, 116);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(75, 20);
			this.label4.TabIndex = 0;
			this.label4.Text = "Mật khẩu";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(16, 81);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(112, 20);
			this.label3.TabIndex = 0;
			this.label3.Text = "Tên đăng nhập";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(16, 46);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(24, 20);
			this.label2.TabIndex = 0;
			this.label2.Text = "ID";
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(814, 91);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(160, 40);
			this.btnAdd.TabIndex = 3;
			this.btnAdd.Text = "Thêm";
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnUpdate
			// 
			this.btnUpdate.Location = new System.Drawing.Point(814, 146);
			this.btnUpdate.Name = "btnUpdate";
			this.btnUpdate.Size = new System.Drawing.Size(160, 40);
			this.btnUpdate.TabIndex = 4;
			this.btnUpdate.Text = "Cập nhật";
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.Location = new System.Drawing.Point(814, 201);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(160, 40);
			this.btnDelete.TabIndex = 5;
			this.btnDelete.Text = "Xóa";
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnClear
			// 
			this.btnClear.Location = new System.Drawing.Point(814, 256);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(160, 40);
			this.btnClear.TabIndex = 6;
			this.btnClear.Text = "Làm mới";
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// btnBack
			// 
			this.btnBack.Location = new System.Drawing.Point(1094, 13);
			this.btnBack.Name = "btnBack";
			this.btnBack.Size = new System.Drawing.Size(94, 29);
			this.btnBack.TabIndex = 7;
			this.btnBack.Text = "Quay lại";
			this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(12, 307);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(163, 20);
			this.label9.TabIndex = 8;
			this.label9.Text = "Danh sách người dùng:";
			// 
			// FormUsers
			// 
			this.ClientSize = new System.Drawing.Size(1200, 704);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.btnBack);
			this.Controls.Add(this.btnClear);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.btnUpdate);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.dgvUsers);
			this.Controls.Add(this.label1);
			this.Name = "FormUsers";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Quản lý Người dùng";
			this.Load += new System.EventHandler(this.FormUsers_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		#endregion

		private Label label1;
		private DataGridView dgvUsers;
		private GroupBox groupBox1;
		private Button btnAdd;
		private Button btnUpdate;
		private Button btnDelete;
		private Button btnClear;
		private Button btnBack;
		private Label label9;
		private TextBox txtPassword;
		private TextBox txtUsername;
		private TextBox txtUserId;
		private Label label4;
		private Label label3;
		private Label label2;
		private CheckBox chkIsActive;
		private ComboBox cboRole;
		private Label label6;
		private TextBox txtFullName;
		private Label label5;
		private TextBox txtEmail;
		private Label label11;
		private TextBox txtPhone;
		private Label label10;
	}
}
