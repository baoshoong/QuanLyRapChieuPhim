using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.BLL;
using WinFormsApp1.Model;
using WinFormsApp1.UI;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private UserBLL userBLL;

        public Form1()
        {
            InitializeComponent();
            userBLL = new UserBLL();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ThemeManager.ApplyModernDarkTheme(this);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            try
            {
                User user = userBLL.Login(username, password);
                
                if (user != null)
                {
                    // Login successful
                    MessageBox.Show($"Đăng nhập thành công với quyền {user.Role}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    
                    if (user.Role == "Manager")
                    {
                        // Open manager dashboard
                        ManagerDashboard managerForm = new ManagerDashboard(user);
                        managerForm.ShowDialog();
                    }
                    else if (user.Role == "Staff")
                    {
                        // Open staff dashboard
                        StaffDashboard staffForm = new StaffDashboard(user);
                        staffForm.ShowDialog();
                    }

                    // When dashboard is closed, show login form again
                    this.Show();
                    txtPassword.Clear();
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
