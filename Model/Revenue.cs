using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Model
{
    public class Revenue
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal TicketRevenue { get; set; }
        public decimal FoodRevenue { get; set; }
        public decimal TotalRevenue { get; set; }
        public int TotalBookings { get; set; }
        public int TotalCustomers { get; set; }
    }
}