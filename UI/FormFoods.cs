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
    public partial class FormFoods : Form
    {
        private FoodBLL foodBLL;
        private Food? currentFood;
        
        public FormFoods()
        {
            InitializeComponent();
            foodBLL = new FoodBLL();
        }
        
        private void FormFoods_Load(object sender, EventArgs e)
        {
			ThemeManager.ApplyModernDarkTheme(this);
			LoadFoods();
            LoadCategories();
            ClearForm();
        }
        
        private void LoadFoods()
        {
            dgvFoods.DataSource = foodBLL.GetAllFoods();
            FormatDataGridView();
        }
        
        private void LoadCategories()
        {
            // Use the new GetAllCategories method
            List<string> categories = foodBLL.GetAllCategories();
            
            cboCategory.Items.Clear();
            cboCategory.Items.Add(""); // Empty option
            
            foreach (string category in categories)
            {
                cboCategory.Items.Add(category);
            }
            
            // Add default categories if not present
            string[] defaultCategories = { "Popcorn", "Drinks", "Snacks", "Combos" };
            foreach (string category in defaultCategories)
            {
                if (!cboCategory.Items.Contains(category))
                {
                    cboCategory.Items.Add(category);
                }
            }
        }
        
        private void FormatDataGridView()
        {
            dgvFoods.Columns["Id"].HeaderText = "ID";
            dgvFoods.Columns["Name"].HeaderText = "Tên đồ ăn";
            dgvFoods.Columns["Description"].HeaderText = "Mô tả";
            dgvFoods.Columns["Price"].HeaderText = "Giá (VNĐ)";
            dgvFoods.Columns["Category"].HeaderText = "Danh mục";
            dgvFoods.Columns["IsAvailable"].HeaderText = "Còn hàng";
            
            // Hide Image column as it's just a URL/path
            if (dgvFoods.Columns.Contains("Image"))
            {
                dgvFoods.Columns["Image"].Visible = false;
            }
            
            dgvFoods.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
            // Format price column to show as currency
            dgvFoods.Columns["Price"].DefaultCellStyle.Format = "N0";
        }
        
        private void ClearForm()
        {
            txtFoodId.Text = string.Empty;
            txtFoodName.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtPrice.Text = string.Empty;
            cboCategory.SelectedIndex = -1;
            chkIsAvailable.Checked = true;
            txtImagePath.Text = string.Empty;
            
            currentFood = null;
            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }
        
        private void dgvFoods_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int foodId = Convert.ToInt32(dgvFoods.Rows[e.RowIndex].Cells["Id"].Value);
                currentFood = foodBLL.GetFoodById(foodId);
                
                if (currentFood != null)
                {
                    txtFoodId.Text = currentFood.Id.ToString();
                    txtFoodName.Text = currentFood.Name;
                    txtDescription.Text = currentFood.Description;
                    txtPrice.Text = currentFood.Price.ToString("N0");
                    cboCategory.Text = currentFood.Category;
                    chkIsAvailable.Checked = currentFood.IsAvailable;
                    txtImagePath.Text = currentFood.Image;
                    
                    btnAdd.Enabled = false;
                    btnUpdate.Enabled = true;
                    btnDelete.Enabled = true;
                }
            }
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Food food = new Food
                {
                    Name = txtFoodName.Text.Trim(),
                    Description = txtDescription.Text.Trim(),
                    Price = decimal.Parse(txtPrice.Text.Replace(",", "")),
                    Category = cboCategory.Text,
                    IsAvailable = chkIsAvailable.Checked,
                    Image = txtImagePath.Text.Trim()
                };
                
                bool result = foodBLL.AddFood(food);
                
                if (result)
                {
                    MessageBox.Show("Thêm đồ ăn thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadFoods();
                    LoadCategories();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Thêm đồ ăn thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (currentFood == null)
            {
                MessageBox.Show("Vui lòng chọn đồ ăn để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            try
            {
                currentFood.Name = txtFoodName.Text.Trim();
                currentFood.Description = txtDescription.Text.Trim();
                currentFood.Price = decimal.Parse(txtPrice.Text.Replace(",", ""));
                currentFood.Category = cboCategory.Text;
                currentFood.IsAvailable = chkIsAvailable.Checked;
                currentFood.Image = txtImagePath.Text.Trim();
                
                bool result = foodBLL.UpdateFood(currentFood);
                
                if (result)
                {
                    MessageBox.Show("Cập nhật đồ ăn thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadFoods();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Cập nhật đồ ăn thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (currentFood == null)
            {
                MessageBox.Show("Vui lòng chọn đồ ăn để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa đồ ăn này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (dr == DialogResult.Yes)
            {
                try
                {
                    bool result = foodBLL.DeleteFood(currentFood.Id);
                    
                    if (result)
                    {
                        MessageBox.Show("Xóa đồ ăn thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadFoods();
                        LoadCategories();
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Xóa đồ ăn thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
        
        private void btnBrowseImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.gif)|*.jpg; *.jpeg; *.png; *.gif";
                openFileDialog.Title = "Chọn hình ảnh";
                
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtImagePath.Text = openFileDialog.FileName;
                }
            }
        }
        
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}