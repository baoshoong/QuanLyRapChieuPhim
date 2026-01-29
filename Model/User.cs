using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty; // Thêm trý?ng Email
        public string Phone { get; set; } = string.Empty; // Thêm trý?ng Phone
        public string Role { get; set; } = "Staff"; // "Manager" or "Staff", m?c ð?nh là Staff
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? LastLoginDate { get; set; } // Thêm trý?ng LastLoginDate
    }
}