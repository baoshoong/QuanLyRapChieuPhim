#pragma warning disable CA1416
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WinFormsApp1.BLL;
using WinFormsApp1.Model;

namespace WinFormsApp1.UI
{
	public partial class FormSelectFood : Form
	{
		private FoodBLL foodBLL;
		public List<FoodOrder> SelectedFoodOrders { get; private set; }
		private ContextMenuStrip? menuStrip;

		public FormSelectFood()
		{
			InitializeComponent();
			foodBLL = new FoodBLL();
			SelectedFoodOrders = new List<FoodOrder>();
		}

		private void FormSelectFood_Load(object? sender, EventArgs e)
		{
			ThemeManager.ApplyModernDarkTheme(this);
			LoadAvailableFoods();
			InitializeSelectedFoodsGrid();
			SetupEventHandlers();
			UpdateTotalAmount();
		}

		private void LoadAvailableFoods()
		{
			try
			{
				var foods = foodBLL.GetAvailableFoods();
				dgvAvailableFoods.DataSource = foods;
				
				if (dgvAvailableFoods.Columns.Count > 0)
				{
					dgvAvailableFoods.Columns["Name"].HeaderText = "Tên";
					dgvAvailableFoods.Columns["Price"].HeaderText = "Giá";
					dgvAvailableFoods.Columns["Price"].DefaultCellStyle.Format = "N0";

					// Định dạng màu nền cho các hàng
					dgvAvailableFoods.RowsDefaultCellStyle.BackColor = Color.White;
					dgvAvailableFoods.AlternatingRowsDefaultCellStyle.BackColor = Color.LightCyan;

					string[] hideColsAvailable = { "Id", "Description", "Category", "Image", "IsAvailable" };
					foreach (var colName in hideColsAvailable)
					{
						if (dgvAvailableFoods.Columns.Contains(colName))
							dgvAvailableFoods.Columns[colName].Visible = false;
					}
					dgvAvailableFoods.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
				}
				
				if (foods.Any())
				{
					dgvAvailableFoods.Rows[0].Selected = true;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Lỗi khi tải danh sách đồ ăn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		// Tạo DataTable cho selected foods để tránh lỗi binding
		private void InitializeSelectedFoodsGrid()
		{
			// Clear và thiết lập cấu trúc
			dgvSelectedFoods.DataSource = null;
			dgvSelectedFoods.Columns.Clear();
			
			// Tạo cột tên sản phẩm
			var nameColumn = new DataGridViewTextBoxColumn
			{
				Name = "FoodName",
				HeaderText = "Tên",
				ReadOnly = true
			};
			
			// Tạo cột số lượng
			var quantityColumn = new DataGridViewTextBoxColumn
			{
				Name = "Quantity",
				HeaderText = "SL",
				ReadOnly = false
			};
			
			// Tạo cột đơn giá
			var priceColumn = new DataGridViewTextBoxColumn
			{
				Name = "Price",
				HeaderText = "Đơn Giá",
				ReadOnly = true,
				DefaultCellStyle = { Format = "N0" }
			};
			
			// Tạo cột thành tiền
			var subtotalColumn = new DataGridViewTextBoxColumn
			{
				Name = "Subtotal",
				HeaderText = "Thành Tiền",
				ReadOnly = true,
				DefaultCellStyle = { Format = "N0" }
			};
			
			// Thêm các cột vào grid
			dgvSelectedFoods.Columns.AddRange(nameColumn, quantityColumn, priceColumn, subtotalColumn);
			
			// Định dạng Grid
			dgvSelectedFoods.RowsDefaultCellStyle.BackColor = Color.White;
			dgvSelectedFoods.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGreen;
			dgvSelectedFoods.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			
			 // Refresh grid với dữ liệu hiện tại
			RefreshSelectedFoodsGrid();
		}
		
		private void RefreshSelectedFoodsGrid()
		{
			dgvSelectedFoods.Rows.Clear();
			
			foreach (var order in SelectedFoodOrders)
			{
				string foodName = order.Food?.Name ?? "Không xác định";
				int quantity = order.Quantity;
				decimal price = order.Price;
				decimal subtotal = price * quantity;
				
				dgvSelectedFoods.Rows.Add(foodName, quantity, price, subtotal);
			}
			
			UpdateTotalAmount();
		}

		private void SetupEventHandlers()
		{
			// Thiết lập double-click để thêm đồ ăn
			dgvAvailableFoods.CellDoubleClick += DgvAvailableFoods_CellDoubleClick;
			
			// Xử lý sự kiện khi người dùng thay đổi số lượng trực tiếp trong DataGridView
			dgvSelectedFoods.CellEndEdit += DgvSelectedFoods_CellEndEdit;
			
			// Tạo và thiết lập context menu cho dgvSelectedFoods
			SetupContextMenu();
		}

		private void DgvAvailableFoods_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0 && dgvAvailableFoods.Rows[e.RowIndex].DataBoundItem is Food selectedFood)
			{
				AddFoodToOrder(selectedFood, 1);
			}
		}

		private void DgvSelectedFoods_CellEndEdit(object? sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == dgvSelectedFoods.Columns["Quantity"].Index && e.RowIndex >= 0)
			{
				string cellValue = dgvSelectedFoods.Rows[e.RowIndex].Cells["Quantity"].Value?.ToString() ?? "";
				
				if (int.TryParse(cellValue, out int newValue))
				{
					if (newValue <= 0)
					{
						// Nếu giá trị mới <= 0, xóa món ăn
						if (e.RowIndex < SelectedFoodOrders.Count)
						{
							var order = SelectedFoodOrders[e.RowIndex];
							string foodName = order.Food?.Name ?? "Sản phẩm";
							SelectedFoodOrders.RemoveAt(e.RowIndex);
							RefreshSelectedFoodsGrid();
							MessageBox.Show($"Đã xóa {foodName} khỏi giỏ hàng vì số lượng <= 0.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
						}
					}
					else
					{
						// Cập nhật số lượng và subtotal
						if (e.RowIndex < SelectedFoodOrders.Count)
						{
							SelectedFoodOrders[e.RowIndex].Quantity = newValue;
							decimal price = SelectedFoodOrders[e.RowIndex].Price;
							dgvSelectedFoods.Rows[e.RowIndex].Cells["Subtotal"].Value = price * newValue;
							UpdateTotalAmount();
						}
					}
				}
				else
				{
					// Khôi phục giá trị cũ nếu người dùng nhập không đúng định dạng
					if (e.RowIndex < SelectedFoodOrders.Count)
					{
						dgvSelectedFoods.Rows[e.RowIndex].Cells["Quantity"].Value = SelectedFoodOrders[e.RowIndex].Quantity;
					}
					MessageBox.Show("Vui lòng nhập một số nguyên dương.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}
		}

		private void SetupContextMenu()
		{
			menuStrip = new ContextMenuStrip();
			
			menuStrip.Items.Add("Tăng số lượng (+1)", null, (s, e) => {
				if (dgvSelectedFoods.CurrentRow != null && dgvSelectedFoods.CurrentRow.Index >= 0 && 
					dgvSelectedFoods.CurrentRow.Index < SelectedFoodOrders.Count)
				{
					var order = SelectedFoodOrders[dgvSelectedFoods.CurrentRow.Index];
					order.Quantity += 1;
					RefreshSelectedFoodsGrid();
				}
			});
			
			menuStrip.Items.Add("Giảm số lượng (-1)", null, (s, e) => {
				if (dgvSelectedFoods.CurrentRow != null && dgvSelectedFoods.CurrentRow.Index >= 0 && 
					dgvSelectedFoods.CurrentRow.Index < SelectedFoodOrders.Count)
				{
					var order = SelectedFoodOrders[dgvSelectedFoods.CurrentRow.Index];
					if (order.Quantity > 1)
					{
						order.Quantity -= 1;
						RefreshSelectedFoodsGrid();
					}
					else
					{
						string foodName = order.Food?.Name ?? "Sản phẩm";
						SelectedFoodOrders.RemoveAt(dgvSelectedFoods.CurrentRow.Index);
						RefreshSelectedFoodsGrid();
						MessageBox.Show($"Đã xóa {foodName} khỏi giỏ hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
				}
			});
			
			menuStrip.Items.Add(new ToolStripSeparator());
			
			menuStrip.Items.Add("Xóa khỏi giỏ hàng", null, (s, e) => {
				if (dgvSelectedFoods.CurrentRow != null && dgvSelectedFoods.CurrentRow.Index >= 0 && 
					dgvSelectedFoods.CurrentRow.Index < SelectedFoodOrders.Count)
				{
					var order = SelectedFoodOrders[dgvSelectedFoods.CurrentRow.Index];
					string foodName = order.Food?.Name ?? "Sản phẩm";
					SelectedFoodOrders.RemoveAt(dgvSelectedFoods.CurrentRow.Index);
					RefreshSelectedFoodsGrid();
					MessageBox.Show($"Đã xóa {foodName} khỏi giỏ hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					MessageBox.Show("Vui lòng chọn một sản phẩm để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			});
			
			dgvSelectedFoods.ContextMenuStrip = menuStrip;
		}

		private void AddFoodToOrder(Food selectedFood, int quantity)
		{
			// Kiểm tra xem món ăn đã có trong danh sách chọn chưa
			var existingOrder = SelectedFoodOrders.FirstOrDefault(fo => fo.FoodId == selectedFood.Id);
			if (existingOrder != null)
			{
				// Nếu có rồi thì tăng số lượng
				existingOrder.Quantity += quantity;
			}
			else
			{
				// Nếu chưa có thì thêm mới
				SelectedFoodOrders.Add(new FoodOrder
				{
					FoodId = selectedFood.Id,
					Food = selectedFood,
					Quantity = quantity,
					Price = selectedFood.Price
				});
			}
			
			// Cập nhật lại DataGridView
			RefreshSelectedFoodsGrid();
			
			// Thông báo nhỏ khi thêm thành công
			MessageBox.Show($"Đã thêm {quantity} {selectedFood.Name} vào giỏ hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void UpdateTotalAmount()
		{
			decimal total = SelectedFoodOrders.Sum(item => item.Price * item.Quantity);
			lblTotalPrice.Text = $"{total:N0} VNĐ";
		}
	}
}
