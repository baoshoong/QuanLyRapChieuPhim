using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Model
{
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? Category { get; set; } // Popcorn, Drinks, Snacks, etc.
        public string? Image { get; set; }  // Path or URL to the food image
        public bool IsAvailable { get; set; }
    }
}