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
	public partial class FormSellTickets : Form
	{
		private MovieBLL movieBLL;
		private ScreeningBLL screeningBLL;
		private SeatBLL seatBLL;
		private BookingBLL bookingBLL;
		private VoucherBLL voucherBLL;
		private User currentUser;

		private Screening? selectedScreening;
		private List<string> selectedSeats = new List<string>();
		private List<FoodOrder> selectedFoodOrders = new List<FoodOrder>();
		private Voucher? appliedVoucher;
		private decimal subTotal = 0;
		private decimal discountAmount = 0;

		public FormSellTickets(User user)
		{
			InitializeComponent();
			currentUser = user;
			movieBLL = new MovieBLL();
			screeningBLL = new ScreeningBLL();
			seatBLL = new SeatBLL();
			bookingBLL = new BookingBLL();
			voucherBLL = new VoucherBLL();
		}

		private void FormSellTickets_Load(object? sender, EventArgs e)
		{
			ThemeManager.ApplyModernDarkTheme(this);
			LoadMoviesForToday();
			dgvOrder.DataSource = new BindingList<object>();
			UpdateOrderDisplay();
		}

		private void LoadMoviesForToday()
		{
			try
			{
				dgvMovies.DataSource = movieBLL.GetMoviesWithScreeningsToday();
				if (dgvMovies.Columns.Contains("Title"))
				{
					dgvMovies.Columns["Title"].HeaderText = "Phim Chiếu Trong Ngày";
					dgvMovies.Columns["Title"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
				}
				foreach (DataGridViewColumn col in dgvMovies.Columns)
				{
					if (col.Name != "Title") col.Visible = false;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi khi tải danh sách phim: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void dgvMovies_SelectionChanged(object? sender, EventArgs e)
		{
			// Clear các lựa chọn cũ
			dgvScreenings.DataSource = null;
			pnlSeats.Controls.Clear();

			// Reset voucher khi chọn phim mới
			ResetVoucher();

			if (dgvMovies.CurrentRow?.DataBoundItem is Movie selectedMovie)
			{
				// Gọi phương thức mới để chỉ lấy suất chiếu trong ngày
				dgvScreenings.DataSource = screeningBLL.GetScreeningsByMovieIdForToday(selectedMovie.Id);
				if (dgvScreenings.Columns.Contains("StartTime"))
				{
					dgvScreenings.Columns["StartTime"].HeaderText = "Suất chiếu";
					dgvScreenings.Columns["StartTime"].DefaultCellStyle.Format = "HH:mm";
					dgvScreenings.Columns["StartTime"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
				}
				foreach (DataGridViewColumn col in dgvScreenings.Columns)
				{
					if (col.Name != "StartTime") col.Visible = false;
				}
			}
		}

		private void dgvScreenings_SelectionChanged(object? sender, EventArgs e)
		{
			if (dgvScreenings.CurrentRow?.DataBoundItem is Screening screening)
			{
				selectedScreening = screening;
				LoadSeats();
				UpdateOrderDisplay();
			}
		}

		private void LoadSeats()
		{
			pnlSeats.Controls.Clear();
			selectedSeats.Clear();
			if (selectedScreening?.Room == null) return;

			List<string> bookedSeats = bookingBLL.GetBookedSeats(selectedScreening.Id);
			List<Seat> roomSeats = seatBLL.GetSeatsByRoomId(selectedScreening.RoomId);

			if (!roomSeats.Any()) return;

			// Lấy số hàng và cột tối đa từ danh sách ghế
			int maxCol = roomSeats.Max(s => s.ColumnNumber);
			// Giả sử các hàng được đặt tên từ 'A' trở đi
			int rowCount = roomSeats.Select(s => s.RowNumber[0]).Distinct().Count();

			if (maxCol == 0 || rowCount == 0) return;

			// Định nghĩa khoảng cách giữa các ghế
			int horizontalSpacing = 5;
			int verticalSpacing = 5;

			// Tính toán kích thước tối ưu cho mỗi nút ghế
			// Trừ đi tổng khoảng cách để có không gian cho các nút
			int totalHorizontalPadding = (maxCol + 1) * horizontalSpacing;
			int totalVerticalPadding = (rowCount + 1) * verticalSpacing;
			
			int buttonWidth = (pnlSeats.Width - totalHorizontalPadding) / maxCol;
			int buttonHeight = (pnlSeats.Height - totalVerticalPadding) / rowCount;

			// Đảm bảo kích thước nút không quá nhỏ
			buttonWidth = Math.Max(25, buttonWidth);
			buttonHeight = Math.Max(25, buttonHeight);

			// Tạo các nút ghế
			foreach (var seat in roomSeats)
			{
				Button seatButton = new Button
				{
					Text = seat.SeatNumber,
					Tag = seat.SeatNumber,
					Size = new Size(buttonWidth, buttonHeight),
					// Tính toán vị trí dựa trên kích thước và khoảng cách
					Location = new Point(
						horizontalSpacing + (seat.ColumnNumber - 1) * (buttonWidth + horizontalSpacing),
						verticalSpacing + (seat.RowNumber[0] - 'A') * (buttonHeight + verticalSpacing)
					),
					Font = new Font("Segoe UI", 7F), // Giảm kích thước font để vừa với nút nhỏ
                    Margin = new Padding(0),
                    FlatStyle = FlatStyle.Flat,
				};
                seatButton.FlatAppearance.BorderSize = 1;


				if (bookedSeats.Contains(seat.SeatNumber))
				{
					seatButton.BackColor = Color.FromArgb(200, 50, 50); // Màu đỏ đậm cho ghế đã đặt
					seatButton.Enabled = false;
				}
				else
				{
					seatButton.BackColor = Color.FromArgb(80, 80, 80); // Màu xám tối
                    seatButton.ForeColor = Color.White;
					seatButton.Click += SeatButton_Click;
				}
				pnlSeats.Controls.Add(seatButton);
			}
		}

		private void SeatButton_Click(object? sender, EventArgs e)
		{
			if (sender is Button seatButton && seatButton.Tag is string seatNumber)
			{
				if (selectedSeats.Contains(seatNumber))
				{
					selectedSeats.Remove(seatNumber);
					seatButton.BackColor = Color.LightGray;
				}
				else
				{
					selectedSeats.Add(seatNumber);
					seatButton.BackColor = Color.CornflowerBlue;
				}
				UpdateOrderDisplay();
			}
		}

		private void btnAddFood_Click(object? sender, EventArgs e)
		{
			using (FormSelectFood selectFoodForm = new FormSelectFood())
			{
				if (selectFoodForm.ShowDialog() == DialogResult.OK)
				{
					selectedFoodOrders = selectFoodForm.SelectedFoodOrders;
					UpdateOrderDisplay();
				}
			}
		}

		private void UpdateOrderDisplay()
		{
			var orderItems = new List<object>();
			subTotal = 0;

			if (selectedScreening != null)
			{
				foreach (var seat in selectedSeats)
				{
					orderItems.Add(new { Item = $"Vé: {selectedScreening.Movie?.Title} - Ghế {seat}", Quantity = 1, Price = selectedScreening.TicketPrice });
					subTotal += selectedScreening.TicketPrice;
				}
			}

			foreach (var foodOrder in selectedFoodOrders)
			{
				if (foodOrder.Food != null)
				{
					orderItems.Add(new { Item = $"Đồ ăn: {foodOrder.Food.Name}", Quantity = foodOrder.Quantity, Price = foodOrder.Price });
					subTotal += foodOrder.Quantity * foodOrder.Price;
				}
			}

			dgvOrder.DataSource = new BindingList<object>(orderItems);
			if (dgvOrder.Columns.Count > 0)
			{
				dgvOrder.Columns["Item"].HeaderText = "Sản phẩm";
				dgvOrder.Columns["Quantity"].HeaderText = "SL";
				dgvOrder.Columns["Price"].HeaderText = "Đơn giá";
				dgvOrder.Columns["Price"].DefaultCellStyle.Format = "N0";
				dgvOrder.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			}

			// Tính lại giảm giá nếu có voucher
			CalculateDiscount();

			// Hiển thị tổng tiền
			decimal total = subTotal - discountAmount;
			lblTotal.Text = $"{total:N0} VNĐ";
		}

		private void btnApplyVoucher_Click(object? sender, EventArgs e)
		{
			string voucherCode = txtVoucherCode.Text.Trim();

			if (string.IsNullOrWhiteSpace(voucherCode))
			{
				MessageBox.Show("Vui lòng nhập mã giảm giá!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			try
			{
				// Tìm kiếm voucher theo mã
				var voucher = voucherBLL.GetVoucherByCode(voucherCode);

				if (voucher == null)
				{
					MessageBox.Show("Mã giảm giá không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				// Kiểm tra nếu voucher còn hiệu lực
				if (!voucher.IsActive || DateTime.Now < voucher.ValidFrom || DateTime.Now > voucher.ValidTo)
				{
					MessageBox.Show("Mã giảm giá đã hết hạn hoặc chưa có hiệu lực!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				// Kiểm tra giá trị đơn hàng tối thiểu
				if (subTotal < voucher.MinOrderAmount)
				{
					MessageBox.Show($"Đơn hàng cần tối thiểu {voucher.MinOrderAmount:N0} VNĐ để áp dụng mã này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}

				// Áp dụng voucher
				appliedVoucher = voucher;
				CalculateDiscount();

				// Hiển thị thông tin giảm giá
				string discountInfo = voucher.DiscountType.Equals("Percentage", StringComparison.OrdinalIgnoreCase)
					? $"Giảm {voucher.DiscountValue}%"
					: $"Giảm {voucher.DiscountValue:N0} VNĐ";

				lblDiscount.Text = $"Đã áp dụng: {discountInfo} (- {discountAmount:N0} VNĐ)";

				MessageBox.Show("Đã áp dụng mã giảm giá thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi khi áp dụng mã giảm giá: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void ResetVoucher()
		{
			appliedVoucher = null;
			discountAmount = 0;
			txtVoucherCode.Clear();
			lblDiscount.Text = string.Empty;
		}

		private void CalculateDiscount()
		{
			discountAmount = 0;

			if (appliedVoucher != null && subTotal > 0)
			{
				discountAmount = voucherBLL.CalculateDiscountAmount(appliedVoucher, subTotal);
			}
		}

		private void btnConfirm_Click(object? sender, EventArgs e)
		{
			if (selectedScreening == null || selectedSeats.Count == 0)
			{
				MessageBox.Show("Vui lòng chọn suất chiếu và ghế ngồi.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			try
			{
				var bookingDetails = selectedSeats.Select(seatNum => new BookingDetail
				{
					SeatNumber = seatNum,
					Price = selectedScreening.TicketPrice
				}).ToList();

				decimal finalTotal = subTotal - discountAmount;

				Booking finalBooking = new Booking
				{
					UserId = currentUser.Id,
					ScheduleId = selectedScreening.Id,
					Screening = selectedScreening,
					CustomerName = txtCustomerName.Text,
					TotalAmount = finalTotal,
					BookingDetails = bookingDetails,
					FoodOrders = selectedFoodOrders,
					VoucherId = appliedVoucher?.Id
				};

				int bookingId = bookingBLL.CreateBooking(finalBooking);
				MessageBox.Show($"Tạo hóa đơn thành công! ID Hóa đơn: {bookingId}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

				// Reset form sau khi đặt vé thành công
				selectedSeats.Clear();
				selectedFoodOrders.Clear();
				ResetVoucher();
				LoadSeats();
				UpdateOrderDisplay();
				txtCustomerName.Clear();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Đã xảy ra lỗi khi tạo hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
