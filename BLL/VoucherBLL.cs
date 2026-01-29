using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using WinFormsApp1.DAL;
using WinFormsApp1.Model;

namespace WinFormsApp1.BLL
{
	public class VoucherBLL
	{
		private VoucherDAL voucherDAL;

		public VoucherBLL()
		{
			voucherDAL = new VoucherDAL();
		}

		public List<Voucher> GetAllVouchers()
		{
			return voucherDAL.GetAllVouchers();
		}

		public Voucher GetVoucherByCode(string code)
		{
			if (string.IsNullOrWhiteSpace(code))
			{
				throw new ArgumentException("M? voucher không ðý?c ð? tr?ng");
			}
			return voucherDAL.GetVoucherByCode(code);
		}

		public bool AddVoucher(Voucher voucher)
		{
			ValidateVoucher(voucher);

			var existingVoucher = voucherDAL.GetVoucherByCode(voucher.VoucherCode);
			if (existingVoucher != null)
			{
				throw new InvalidOperationException($"M? voucher {voucher.VoucherCode} ð? t?n t?i");
			}

			return voucherDAL.AddVoucher(voucher);
		}

		public bool UpdateVoucher(Voucher voucher)
		{
			if (voucher.Id <= 0)
			{
				throw new ArgumentException("ID voucher không h?p l?");
			}
			ValidateVoucher(voucher);

			var existingVoucher = voucherDAL.GetVoucherByCode(voucher.VoucherCode);
			if (existingVoucher != null && existingVoucher.Id != voucher.Id)
			{
				throw new InvalidOperationException($"M? voucher {voucher.VoucherCode} ð? t?n t?i");
			}

			return voucherDAL.UpdateVoucher(voucher);
		}

		public bool DeleteVoucher(int voucherId)
		{
			if (voucherId <= 0)
			{
				throw new ArgumentException("ID voucher không h?p l?");
			}
			return voucherDAL.DeleteVoucher(voucherId);
		}

		public decimal CalculateDiscountAmount(Voucher voucher, decimal orderAmount)
		{
			if (voucher == null || !voucher.IsActive || voucher.ValidFrom > DateTime.Now || voucher.ValidTo < DateTime.Now)
			{
				return 0;
			}

			if (orderAmount < voucher.MinOrderAmount)
			{
				return 0; // Chýa ð? giá tr? ðõn hàng t?i thi?u
			}

			decimal discountAmount = 0;
			if (voucher.DiscountType.Equals("Percentage", StringComparison.OrdinalIgnoreCase))
			{
				discountAmount = orderAmount * (voucher.DiscountValue / 100);
			}
			else // 'Fixed'
			{
				discountAmount = voucher.DiscountValue;
			}

			return Math.Min(discountAmount, orderAmount); // Gi?m giá không th? l?n hõn giá tr? ðõn hàng
		}

		private void ValidateVoucher(Voucher voucher)
		{
			if (string.IsNullOrWhiteSpace(voucher.VoucherCode))
			{
				throw new ArgumentException("M? voucher không ðý?c ð? tr?ng");
			}

			if (!Regex.IsMatch(voucher.VoucherCode, @"^[a-zA-Z0-9]+$"))
			{
				throw new ArgumentException("M? voucher ch? ðý?c ch?a ch? cái và s?, không có kho?ng tr?ng");
			}

			if (string.IsNullOrWhiteSpace(voucher.VoucherName))
			{
				throw new ArgumentException("Tên voucher không ðý?c ð? tr?ng");
			}

			if (voucher.DiscountValue <= 0)
			{
				throw new ArgumentException("Giá tr? gi?m giá ph?i l?n hõn 0");
			}

			if (voucher.DiscountType != "Percentage" && voucher.DiscountType != "Fixed")
			{
				throw new ArgumentException("Lo?i gi?m giá không h?p l?. Ph?i là 'Percentage' ho?c 'Fixed'.");
			}

			if (voucher.ValidTo < voucher.ValidFrom)
			{
				throw new ArgumentException("Ngày k?t thúc ph?i sau ngày b?t ð?u");
			}
		}
	}
}