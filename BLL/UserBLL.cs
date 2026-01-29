using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WinFormsApp1.DAL;
using WinFormsApp1.Model;

namespace WinFormsApp1.BLL
{
    public class UserBLL
    {
        private UserDAL userDAL;
        
        public UserBLL()
        {
            userDAL = new UserDAL();
        }
        
        public User Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Tên ðãng nh?p và m?t kh?u không ðý?c ð? tr?ng");
            }
            
            User user = userDAL.Login(username, password);
            if (user != null)
            {
                // C?p nh?t th?i gian ðãng nh?p
                userDAL.UpdateLastLogin(user.Id);
            }
            return user;
        }
        
        public List<User> GetAllUsers()
        {
            return userDAL.GetAllUsers();
        }
        
        // Xác th?c ð?nh d?ng email
        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return true; // Email r?ng ðý?c ch?p nh?n
                
            try
            {
                // S? d?ng Regex ð? ki?m tra ð?nh d?ng email
                var regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
                return regex.IsMatch(email);
            }
            catch
            {
                return false;
            }
        }
        
        // Xác th?c ð?nh d?ng s? ði?n tho?i
        private bool IsValidPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return true; // S? ði?n tho?i r?ng ðý?c ch?p nh?n
                
            // Ki?m tra s? ði?n tho?i ch? ch?a s? và có ð? dài t? 10-11 s?
            return Regex.IsMatch(phone, @"^\d{10,11}$");
        }
        
        public bool AddUser(User user)
        {
            // Validate user data
            if (string.IsNullOrEmpty(user.Username))
            {
                throw new ArgumentException("Tên ðãng nh?p không ðý?c ð? tr?ng");
            }
            
            if (string.IsNullOrEmpty(user.Password))
            {
                throw new ArgumentException("M?t kh?u không ðý?c ð? tr?ng");
            }
            
            if (string.IsNullOrEmpty(user.FullName))
            {
                // S? d?ng username làm fullname n?u không có
                user.FullName = user.Username;
            }
            
            if (string.IsNullOrEmpty(user.Role))
            {
                // M?c ð?nh là Staff n?u không ch?n Role
                user.Role = "Staff";
            }
            
            // Validate email (n?u có)
            if (!string.IsNullOrWhiteSpace(user.Email) && !IsValidEmail(user.Email))
            {
                throw new ArgumentException("Email không ðúng ð?nh d?ng");
            }
            
            // Validate phone (n?u có)
            if (!string.IsNullOrWhiteSpace(user.Phone) && !IsValidPhone(user.Phone))
            {
                throw new ArgumentException("S? ði?n tho?i không ðúng ð?nh d?ng, c?n nh?p 10-11 s?");
            }
            
            // Ki?m tra xem username ð? t?n t?i chýa
            if (userDAL.IsUsernameExists(user.Username))
            {
                throw new InvalidOperationException($"Tên ðãng nh?p '{user.Username}' ð? t?n t?i, vui l?ng ch?n tên khác");
            }
            
            // Ki?m tra email có b? trùng không
            if (!string.IsNullOrWhiteSpace(user.Email) && userDAL.IsEmailExists(user.Email))
            {
                throw new InvalidOperationException($"Email '{user.Email}' ð? ðý?c s? d?ng b?i m?t tài kho?n khác");
            }
            
            // Set default values
            user.CreatedDate = DateTime.Now;
            user.IsActive = true;
            
            return userDAL.AddUser(user);
        }
        
        public bool UpdateUser(User user)
        {
            // Validation
            if (user.Id <= 0)
            {
                throw new ArgumentException("ID ngý?i dùng không h?p l?");
            }
            
            if (string.IsNullOrEmpty(user.Username))
            {
                throw new ArgumentException("Tên ðãng nh?p không ðý?c ð? tr?ng");
            }
            
            // Validate email (n?u có)
            if (!string.IsNullOrWhiteSpace(user.Email) && !IsValidEmail(user.Email))
            {
                throw new ArgumentException("Email không ðúng ð?nh d?ng");
            }
            
            // Validate phone (n?u có)
            if (!string.IsNullOrWhiteSpace(user.Phone) && !IsValidPhone(user.Phone))
            {
                throw new ArgumentException("S? ði?n tho?i không ðúng ð?nh d?ng, c?n nh?p 10-11 s?");
            }
            
            // Ki?m tra xem username ð? t?n t?i cho ngý?i dùng khác chýa
            var allUsers = userDAL.GetAllUsers();
            if (allUsers.Any(u => u.Username == user.Username && u.Id != user.Id))
            {
                throw new InvalidOperationException($"Tên ðãng nh?p '{user.Username}' ð? ðý?c s? d?ng b?i ngý?i dùng khác");
            }
            
            return userDAL.UpdateUser(user);
        }
        
        public bool DeleteUser(int userId)
        {
            if (userId <= 0)
            {
                throw new ArgumentException("ID ngý?i dùng không h?p l?");
            }
            
            return userDAL.DeleteUser(userId);
        }
    }
}