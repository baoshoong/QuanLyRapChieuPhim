using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.Data;
using WinFormsApp1.Model;

namespace WinFormsApp1.DAL
{
    public class UserDAL
    {
		private string connectionString = ConfigurationHelper.GetConnectionString();

		// In a real application, we would use a configuration file for the connection string

		public User? Login(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT UserID, Username, FullName, Email, Phone, Role, IsActive, CreatedDate, LastLoginDate FROM Users WHERE Username = @Username AND Password = @Password AND IsActive = 1";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password); // In a real app, use proper password hashing

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                Id = Convert.ToInt32(reader["UserID"]),
                                Username = reader["Username"].ToString() ?? string.Empty,
                                FullName = reader["FullName"].ToString() ?? string.Empty,
                                Email = reader["Email"] != DBNull.Value ? reader["Email"].ToString() : string.Empty,
                                Phone = reader["Phone"] != DBNull.Value ? reader["Phone"].ToString() : string.Empty,
                                Role = reader["Role"].ToString() ?? string.Empty,
                                IsActive = Convert.ToBoolean(reader["IsActive"]),
                                CreatedDate = reader["CreatedDate"] != DBNull.Value ? Convert.ToDateTime(reader["CreatedDate"]) : DateTime.Now,
                                LastLoginDate = reader["LastLoginDate"] != DBNull.Value ? Convert.ToDateTime(reader["LastLoginDate"]) : null
                            };
                        }
                    }
                }
            }

            return null;
        }

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT UserID, Username, FullName, Email, Phone, Role, IsActive, CreatedDate, LastLoginDate FROM Users";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            User user = new User
                            {
                                Id = Convert.ToInt32(reader["UserID"]),
                                Username = reader["Username"].ToString() ?? string.Empty,
                                FullName = reader["FullName"].ToString() ?? string.Empty,
                                Email = reader["Email"] != DBNull.Value ? reader["Email"].ToString() : string.Empty,
                                Phone = reader["Phone"] != DBNull.Value ? reader["Phone"].ToString() : string.Empty,
                                Role = reader["Role"].ToString() ?? string.Empty,
                                IsActive = Convert.ToBoolean(reader["IsActive"]),
                                CreatedDate = reader["CreatedDate"] != DBNull.Value ? Convert.ToDateTime(reader["CreatedDate"]) : DateTime.Now,
                                LastLoginDate = reader["LastLoginDate"] != DBNull.Value ? Convert.ToDateTime(reader["LastLoginDate"]) : null
                            };

                            users.Add(user);
                        }
                    }
                }
            }

            return users;
        }

        // Ki?m tra xem tên ðãng nh?p ð? t?n t?i chýa
        public bool IsUsernameExists(string username)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        // Ki?m tra email ð? t?n t?i chýa (n?u có email)
        public bool IsEmailExists(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false; // Không ki?m tra n?u email tr?ng

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Users WHERE Email = @Email";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        public bool AddUser(User user)
        {
            // Ki?m tra d? li?u ð?u vào ð? tránh vi ph?m ràng bu?c UNIQUE KEY
            if (string.IsNullOrEmpty(user.Username))
            {
                throw new ArgumentException("Tên ðãng nh?p không ðý?c ð? tr?ng");
            }

            if (string.IsNullOrEmpty(user.FullName))
            {
                user.FullName = user.Username; // S? d?ng Username làm giá tr? m?c ð?nh cho FullName n?u b? b? tr?ng
            }

            // Ki?m tra xem tên ðãng nh?p ð? t?n t?i chýa
            if (IsUsernameExists(user.Username))
            {
                throw new InvalidOperationException("Tên ðãng nh?p này ð? t?n t?i, vui l?ng ch?n tên khác");
            }

            // Ki?m tra email n?u có giá tr?
            if (!string.IsNullOrWhiteSpace(user.Email) && IsEmailExists(user.Email))
            {
                throw new InvalidOperationException("Email này ð? ðý?c s? d?ng b?i m?t tài kho?n khác");
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"INSERT INTO Users (Username, Password, FullName, Email, Phone, Role, IsActive, CreatedDate) 
                                 VALUES (@Username, @Password, @FullName, @Email, @Phone, @Role, @IsActive, @CreatedDate);
                                 SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", user.Username);
                    command.Parameters.AddWithValue("@Password", string.IsNullOrEmpty(user.Password) ? "" : user.Password); // Ð?m b?o không có NULL
                    command.Parameters.AddWithValue("@FullName", user.FullName);

                    // X? l? Email và Phone ð? tránh lýu giá tr? NULL
                    if (string.IsNullOrWhiteSpace(user.Email))
                        command.Parameters.AddWithValue("@Email", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@Email", user.Email);

                    if (string.IsNullOrWhiteSpace(user.Phone))
                        command.Parameters.AddWithValue("@Phone", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@Phone", user.Phone);

                    command.Parameters.AddWithValue("@Role", string.IsNullOrEmpty(user.Role) ? "Staff" : user.Role); // Ð?t giá tr? m?c ð?nh n?u Role là NULL
                    command.Parameters.AddWithValue("@IsActive", user.IsActive);
                    command.Parameters.AddWithValue("@CreatedDate", DateTime.Now);

                    try
                    {
                        int newId = Convert.ToInt32(command.ExecuteScalar());
                        user.Id = newId;
                        return true;
                    }
                    catch (SqlException ex)
                    {
                        if (ex.Message.Contains("UNIQUE KEY") || ex.Message.Contains("duplicate key"))
                        {
                            throw new InvalidOperationException("Không th? thêm ngý?i dùng: Vi ph?m ràng bu?c d? li?u duy nh?t", ex);
                        }
                        throw; // Ném l?i ngo?i l? khác
                    }
                }
            }
        }

        public bool UpdateUser(User user)
        {
            // Ki?m tra email n?u ðý?c c?p nh?t
            if (!string.IsNullOrWhiteSpace(user.Email))
            {
                // Ki?m tra email có b? trùng không (ngo?i tr? ngý?i dùng hi?n t?i)
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string emailQuery = "SELECT COUNT(*) FROM Users WHERE Email = @Email AND UserID <> @UserID";
                    using (SqlCommand cmd = new SqlCommand(emailQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@Email", user.Email);
                        cmd.Parameters.AddWithValue("@UserID", user.Id);
                        int count = (int)cmd.ExecuteScalar();
                        if (count > 0)
                        {
                            throw new InvalidOperationException("Email này ð? ðý?c s? d?ng b?i m?t tài kho?n khác");
                        }
                    }
                }
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"UPDATE Users 
                                 SET Username = @Username,
                                     FullName = @FullName,
                                     Email = @Email,
                                     Phone = @Phone,
                                     Role = @Role,
                                     IsActive = @IsActive
                                 WHERE UserID = @UserID";

                // If password is being updated, include it in the query
                if (!string.IsNullOrEmpty(user.Password))
                {
                    query = @"UPDATE Users 
                             SET Username = @Username,
                                 Password = @Password,
                                 FullName = @FullName,
                                 Email = @Email,
                                 Phone = @Phone,
                                 Role = @Role,
                                 IsActive = @IsActive
                             WHERE UserID = @UserID";
                }

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", user.Id);
                    command.Parameters.AddWithValue("@Username", user.Username);
                    if (!string.IsNullOrEmpty(user.Password))
                    {
                        command.Parameters.AddWithValue("@Password", user.Password); // In a real app, use proper password hashing
                    }
                    command.Parameters.AddWithValue("@FullName", string.IsNullOrEmpty(user.FullName) ? user.Username : user.FullName);

                    // X? l? Email và Phone ð? tránh lýu giá tr? NULL
                    if (string.IsNullOrWhiteSpace(user.Email))
                        command.Parameters.AddWithValue("@Email", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@Email", user.Email);

                    if (string.IsNullOrWhiteSpace(user.Phone))
                        command.Parameters.AddWithValue("@Phone", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@Phone", user.Phone);

                    command.Parameters.AddWithValue("@Role", string.IsNullOrEmpty(user.Role) ? "Staff" : user.Role);
                    command.Parameters.AddWithValue("@IsActive", user.IsActive);

                    try
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        if (ex.Message.Contains("UNIQUE KEY") || ex.Message.Contains("duplicate key"))
                        {
                            throw new InvalidOperationException("Không th? c?p nh?t ngý?i dùng: Vi ph?m ràng bu?c d? li?u duy nh?t", ex);
                        }
                        throw; // Ném l?i ngo?i l? khác
                    }
                }
            }
        }

        public bool DeleteUser(int userId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                // In a real application, consider using soft delete (update IsActive to false)
                // instead of hard delete
                string query = "DELETE FROM Users WHERE UserID = @UserID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userId);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        // C?p nh?t th?i gian ðãng nh?p cu?i cùng
        public bool UpdateLastLogin(int userId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Users SET LastLoginDate = @LastLoginDate WHERE UserID = @UserID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userId);
                    command.Parameters.AddWithValue("@LastLoginDate", DateTime.Now);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
    }
}