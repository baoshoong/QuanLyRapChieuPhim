using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.DAL;
using WinFormsApp1.Model;

namespace WinFormsApp1.BLL
{
    public class FoodBLL
    {
        private FoodDAL foodDAL;
        
        public FoodBLL()
        {
            foodDAL = new FoodDAL();
        }
        
        public List<Food> GetAllFoods()
        {
            return foodDAL.GetAllFoods();
        }
        
        public List<Food> GetAvailableFoods()
        {
            // Use the SearchFoods method with onlyAvailable=true
            return foodDAL.SearchFoods(null, null, null, null, true);
        }
        
        public Food? GetFoodById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID ð? ãn không h?p l?");
            }
            
            return foodDAL.GetFoodById(id);
        }
        
        public List<Food> GetFoodsByCategory(string category)
        {
            if (string.IsNullOrEmpty(category))
            {
                throw new ArgumentException("Danh m?c không ðý?c ð? tr?ng");
            }
            
            // Use the dedicated method for getting foods by category
            return foodDAL.GetFoodsByCategory(category);
        }
        
        public List<string> GetAllCategories()
        {
            return foodDAL.GetAllCategories();
        }
        
        public List<Food> SearchFoods(string? searchTerm = null, string? category = null, decimal? minPrice = null, decimal? maxPrice = null, bool onlyAvailable = true)
        {
            return foodDAL.SearchFoods(searchTerm, category, minPrice, maxPrice, onlyAvailable);
        }
        
        public bool AddFood(Food food)
        {
            ValidateFood(food);
            return foodDAL.AddFood(food);
        }
        
        public bool UpdateFood(Food food)
        {
            if (food.Id <= 0)
            {
                throw new ArgumentException("ID ð? ãn không h?p l?");
            }
            
            ValidateFood(food);
            return foodDAL.UpdateFood(food);
        }
        
        public bool DeleteFood(int foodId)
        {
            if (foodId <= 0)
            {
                throw new ArgumentException("ID ð? ãn không h?p l?");
            }
            
            return foodDAL.DeleteFood(foodId);
        }
        
        private void ValidateFood(Food food)
        {
            if (string.IsNullOrEmpty(food.Name))
            {
                throw new ArgumentException("Tên ð? ãn không ðý?c ð? tr?ng");
            }
            
            if (food.Price <= 0)
            {
                throw new ArgumentException("Giá ð? ãn ph?i l?n hõn 0");
            }
            
            if (string.IsNullOrEmpty(food.Category))
            {
                throw new ArgumentException("Danh m?c không ðý?c ð? tr?ng");
            }
        }
    }
}