using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using WinFormsApp1.Data;
using WinFormsApp1.Model;

namespace WinFormsApp1.DAL
{
	public class VoucherDAL
	{
		private string connectionString = ConfigurationHelper.GetConnectionString();

		public List<Voucher> GetAllVouchers()
		{
			List<Voucher> vouchers = new List<Voucher>();
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					string query = @"SELECT VoucherID, VoucherCode, VoucherName, DiscountType, DiscountValue, 
                                            MinOrderAmount, ValidFrom, ValidTo, IsActive 
                                     FROM Vouchers";

					using (SqlCommand command = new SqlCommand(query, connection))
					{
						using (SqlDataReader reader = command.ExecuteReader())
						{
							while (reader.Read())
							{
								Voucher voucher = new Voucher
								{
									Id = Convert.ToInt32(reader["VoucherID"]),
									VoucherCode = reader["VoucherCode"].ToString() ?? string.Empty,
									VoucherName = reader["VoucherName"].ToString() ?? string.Empty,
									DiscountType = reader["DiscountType"].ToString() ?? string.Empty,
									DiscountValue = Convert.ToDecimal(reader["DiscountValue"]),
									MinOrderAmount = Convert.ToDecimal(reader["MinOrderAmount"]),
									ValidFrom = Convert.ToDateTime(reader["ValidFrom"]),
									ValidTo = Convert.ToDateTime(reader["ValidTo"]),
									IsActive = Convert.ToBoolean(reader["IsActive"])
								};
								vouchers.Add(voucher);
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error in GetAllVouchers: {ex.Message}");
				throw;
			}
			return vouchers;
		}

		public Voucher? GetVoucherById(int id)
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					string query = @"SELECT VoucherID, VoucherCode, VoucherName, DiscountType, DiscountValue, 
                                            MinOrderAmount, ValidFrom, ValidTo, IsActive 
                                     FROM Vouchers WHERE VoucherID = @VoucherID";

					using (SqlCommand command = new SqlCommand(query, connection))
					{
						command.Parameters.AddWithValue("@VoucherID", id);
						using (SqlDataReader reader = command.ExecuteReader())
						{
							if (reader.Read())
							{
								return new Voucher
								{
									Id = Convert.ToInt32(reader["VoucherID"]),
									VoucherCode = reader["VoucherCode"].ToString() ?? string.Empty,
									VoucherName = reader["VoucherName"].ToString() ?? string.Empty,
									DiscountType = reader["DiscountType"].ToString() ?? string.Empty,
									DiscountValue = Convert.ToDecimal(reader["DiscountValue"]),
									MinOrderAmount = Convert.ToDecimal(reader["MinOrderAmount"]),
									ValidFrom = Convert.ToDateTime(reader["ValidFrom"]),
									ValidTo = Convert.ToDateTime(reader["ValidTo"]),
									IsActive = Convert.ToBoolean(reader["IsActive"])
								};
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error in GetVoucherById: {ex.Message}");
				throw;
			}
			return null;
		}

		public Voucher? GetVoucherByCode(string code)
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					string query = @"SELECT VoucherID, VoucherCode, VoucherName, DiscountType, DiscountValue, 
                                            MinOrderAmount, ValidFrom, ValidTo, IsActive 
                                     FROM Vouchers WHERE VoucherCode = @VoucherCode";

					using (SqlCommand command = new SqlCommand(query, connection))
					{
						command.Parameters.AddWithValue("@VoucherCode", code);
						using (SqlDataReader reader = command.ExecuteReader())
						{
							if (reader.Read())
							{
								return new Voucher
								{
									Id = Convert.ToInt32(reader["VoucherID"]),
									VoucherCode = reader["VoucherCode"].ToString() ?? string.Empty,
									VoucherName = reader["VoucherName"].ToString() ?? string.Empty,
									DiscountType = reader["DiscountType"].ToString() ?? string.Empty,
									DiscountValue = Convert.ToDecimal(reader["DiscountValue"]),
									MinOrderAmount = Convert.ToDecimal(reader["MinOrderAmount"]),
									ValidFrom = Convert.ToDateTime(reader["ValidFrom"]),
									ValidTo = Convert.ToDateTime(reader["ValidTo"]),
									IsActive = Convert.ToBoolean(reader["IsActive"])
								};
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error in GetVoucherByCode: {ex.Message}");
				throw;
			}
			return null;
		}

		public bool AddVoucher(Voucher voucher)
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					string query = @"INSERT INTO Vouchers (VoucherCode, VoucherName, DiscountType, DiscountValue, MinOrderAmount, ValidFrom, ValidTo, IsActive) 
                                     VALUES (@VoucherCode, @VoucherName, @DiscountType, @DiscountValue, @MinOrderAmount, @ValidFrom, @ValidTo, @IsActive);
                                     SELECT SCOPE_IDENTITY();";

					using (SqlCommand command = new SqlCommand(query, connection))
					{
						command.Parameters.AddWithValue("@VoucherCode", voucher.VoucherCode);
						command.Parameters.AddWithValue("@VoucherName", voucher.VoucherName);
						command.Parameters.AddWithValue("@DiscountType", voucher.DiscountType);
						command.Parameters.AddWithValue("@DiscountValue", voucher.DiscountValue);
						command.Parameters.AddWithValue("@MinOrderAmount", voucher.MinOrderAmount);
						command.Parameters.AddWithValue("@ValidFrom", voucher.ValidFrom);
						command.Parameters.AddWithValue("@ValidTo", voucher.ValidTo);
						command.Parameters.AddWithValue("@IsActive", voucher.IsActive);

						int newId = Convert.ToInt32(command.ExecuteScalar());
						voucher.Id = newId;
						return true;
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error in AddVoucher: {ex.Message}");
				throw;
			}
		}

		public bool UpdateVoucher(Voucher voucher)
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					string query = @"UPDATE Vouchers 
                                     SET VoucherCode = @VoucherCode, 
                                         VoucherName = @VoucherName, 
                                         DiscountType = @DiscountType, 
                                         DiscountValue = @DiscountValue,
                                         MinOrderAmount = @MinOrderAmount,
                                         ValidFrom = @ValidFrom, 
                                         ValidTo = @ValidTo, 
                                         IsActive = @IsActive
                                     WHERE VoucherID = @VoucherID";

					using (SqlCommand command = new SqlCommand(query, connection))
					{
						command.Parameters.AddWithValue("@VoucherID", voucher.Id);
						command.Parameters.AddWithValue("@VoucherCode", voucher.VoucherCode);
						command.Parameters.AddWithValue("@VoucherName", voucher.VoucherName);
						command.Parameters.AddWithValue("@DiscountType", voucher.DiscountType);
						command.Parameters.AddWithValue("@DiscountValue", voucher.DiscountValue);
						command.Parameters.AddWithValue("@MinOrderAmount", voucher.MinOrderAmount);
						command.Parameters.AddWithValue("@ValidFrom", voucher.ValidFrom);
						command.Parameters.AddWithValue("@ValidTo", voucher.ValidTo);
						command.Parameters.AddWithValue("@IsActive", voucher.IsActive);

						int rowsAffected = command.ExecuteNonQuery();
						return rowsAffected > 0;
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error in UpdateVoucher: {ex.Message}");
				throw;
			}
		}

		public bool DeleteVoucher(int voucherId)
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					string query = "DELETE FROM Vouchers WHERE VoucherID = @VoucherID";

					using (SqlCommand command = new SqlCommand(query, connection))
					{
						command.Parameters.AddWithValue("@VoucherID", voucherId);
						int rowsAffected = command.ExecuteNonQuery();
						return rowsAffected > 0;
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error in DeleteVoucher: {ex.Message}");
				throw;
			}
		}

		public decimal CalculateDiscount(Voucher? voucher, decimal orderAmount)
		{
			if (voucher == null)
			{
				return 0;
			}

			if (!voucher.IsActive || DateTime.Now < voucher.ValidFrom || DateTime.Now > voucher.ValidTo)
			{
				return 0;
			}

			if (orderAmount < voucher.MinOrderAmount)
			{
				return 0;
			}

			decimal discount = 0;

			if (voucher.DiscountType.Equals("Percentage", StringComparison.OrdinalIgnoreCase))
			{
				discount = orderAmount * (voucher.DiscountValue / 100);
			}
			else if (voucher.DiscountType.Equals("Fixed", StringComparison.OrdinalIgnoreCase))
			{
				discount = voucher.DiscountValue;
			}

			return Math.Min(discount, orderAmount);
		}
	}
}