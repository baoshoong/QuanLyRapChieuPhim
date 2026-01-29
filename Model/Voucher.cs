using System;

namespace WinFormsApp1.Model
{
	public class Voucher
	{
		public int Id { get; set; }
		public string VoucherCode { get; set; } = string.Empty;
		public string VoucherName { get; set; } = string.Empty;
		public string DiscountType { get; set; } = string.Empty; // 'Percentage' ho?c 'Fixed'
		public decimal DiscountValue { get; set; }
		public decimal MinOrderAmount { get; set; }
		public DateTime ValidFrom { get; set; }
		public DateTime ValidTo { get; set; }
		public bool IsActive { get; set; }

		// Các thu?c tính c? ð? ðý?c thay th?.
		// Các thu?c tính khác nhý UsageLimit, UsedCount có th? ðý?c thêm vào n?u c?n.
	}
}