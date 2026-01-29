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

namespace WinFormsApp1.UI
{
    public partial class FormViewFoods : Form
    {
        private FoodBLL foodBLL;
        
        public FormViewFoods()
        {
            InitializeComponent();
            foodBLL = new FoodBLL();
        }
        
        private void FormViewFoods_Load(object sender, EventArgs e)
        {
			ThemeManager.ApplyModernDarkTheme(this);
			LoadCategories();
            LoadFoods();
        }
        
        private void LoadFoods()
        {
            // Load all available foods by default
            dgvFoods.DataSource = foodBLL.GetAvailableFoods();
            FormatDataGridView();
        }
        
        private void LoadCategories()
        {
            // Use the new GetAllCategories method
            List<string> categories = foodBLL.GetAllCategories();
            
            cboCategory.Items.Clear();
            cboCategory.Items.Add("T?t c?"); // All option
            
            foreach (string category in categories)
            {
                cboCategory.Items.Add(category);
            }
            
            cboCategory.SelectedIndex = 0; // Select "All" by default
        }
        
        private void FormatDataGridView()
        {
            dgvFoods.Columns["Id"].HeaderText = "ID";
            dgvFoods.Columns["Name"].HeaderText = "Tên ð? ãn";
            dgvFoods.Columns["Description"].HeaderText = "Mô t?";
            dgvFoods.Columns["Price"].HeaderText = "Giá (VNÐ)";
            dgvFoods.Columns["Category"].HeaderText = "Danh m?c";
            
            // Hide columns that staff doesn't need to see
            if (dgvFoods.Columns.Contains("Image"))
            {
                dgvFoods.Columns["Image"].Visible = false;
            }
            
            if (dgvFoods.Columns.Contains("IsAvailable"))
            {
                dgvFoods.Columns["IsAvailable"].Visible = false;
            }
            
            dgvFoods.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
            // Format price column to show as currency
            dgvFoods.Columns["Price"].DefaultCellStyle.Format = "N0";
        }
        
        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCategory.SelectedIndex == 0) // "All" option
            {
                dgvFoods.DataSource = foodBLL.GetAvailableFoods();
            }
            else
            {
                string selectedCategory = cboCategory.SelectedItem?.ToString() ?? string.Empty;
                if (!string.IsNullOrEmpty(selectedCategory))
                {
                    dgvFoods.DataSource = foodBLL.GetFoodsByCategory(selectedCategory);
                }
            }
            
            FormatDataGridView();
        }
        
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}