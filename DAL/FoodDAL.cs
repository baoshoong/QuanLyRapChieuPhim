using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.Data;
using WinFormsApp1.Model;

namespace WinFormsApp1.DAL
{
    public class FoodDAL
    {
		private string connectionString = ConfigurationHelper.GetConnectionString();

		public List<Food> GetAllFoods()
        {
            List<Food> foods = new List<Food>();
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT FoodID, FoodName, Description, Price, Category, Image, IsAvailable, CreatedDate FROM Foods";
                
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Food food = new Food
                            {
                                Id = Convert.ToInt32(reader["FoodID"]),
                                Name = reader["FoodName"].ToString() ?? string.Empty,
                                Description = reader["Description"] != DBNull.Value ? reader["Description"].ToString() : null,
                                Price = Convert.ToDecimal(reader["Price"]),
                                Category = reader["Category"] != DBNull.Value ? reader["Category"].ToString() : null,
                                Image = reader["Image"] != DBNull.Value ? reader["Image"].ToString() : null,
                                IsAvailable = Convert.ToBoolean(reader["IsAvailable"])
                            };
                            
                            foods.Add(food);
                        }
                    }
                }
            }
            
            return foods;
        }
        
        public Food? GetFoodById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT FoodID, FoodName, Description, Price, Category, Image, IsAvailable, CreatedDate FROM Foods WHERE FoodID = @FoodID";
                
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FoodID", id);
                    
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Food
                            {
                                Id = Convert.ToInt32(reader["FoodID"]),
                                Name = reader["FoodName"].ToString() ?? string.Empty,
                                Description = reader["Description"] != DBNull.Value ? reader["Description"].ToString() : null,
                                Price = Convert.ToDecimal(reader["Price"]),
                                Category = reader["Category"] != DBNull.Value ? reader["Category"].ToString() : null,
                                Image = reader["Image"] != DBNull.Value ? reader["Image"].ToString() : null,
                                IsAvailable = Convert.ToBoolean(reader["IsAvailable"])
                            };
                        }
                    }
                }
            }
            
            return null;
        }
        
        public bool AddFood(Food food)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"INSERT INTO Foods (FoodName, Description, Price, Category, Image, IsAvailable) 
                                 VALUES (@FoodName, @Description, @Price, @Category, @Image, @IsAvailable);
                                 SELECT SCOPE_IDENTITY();";
                
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FoodName", food.Name);
                    command.Parameters.AddWithValue("@Description", food.Description ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Price", food.Price);
                    command.Parameters.AddWithValue("@Category", food.Category ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Image", food.Image ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@IsAvailable", food.IsAvailable);
                    
                    int newId = Convert.ToInt32(command.ExecuteScalar());
                    food.Id = newId;
                    return true;
                }
            }
        }
        
        public bool UpdateFood(Food food)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"UPDATE Foods 
                                 SET FoodName = @FoodName, 
                                     Description = @Description, 
                                     Price = @Price, 
                                     Category = @Category, 
                                     Image = @Image, 
                                     IsAvailable = @IsAvailable 
                                 WHERE FoodID = @FoodID";
                
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FoodID", food.Id);
                    command.Parameters.AddWithValue("@FoodName", food.Name);
                    command.Parameters.AddWithValue("@Description", food.Description ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Price", food.Price);
                    command.Parameters.AddWithValue("@Category", food.Category ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Image", food.Image ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@IsAvailable", food.IsAvailable);
                    
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
        
        public bool DeleteFood(int foodId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Foods WHERE FoodID = @FoodID";
                
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FoodID", foodId);
                    
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public List<Food> GetFoodsByCategory(string category)
        {
            List<Food> foods = new List<Food>();
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT FoodID, FoodName, Description, Price, Category, Image, IsAvailable, CreatedDate FROM Foods WHERE Category = @Category AND IsAvailable = 1";
                
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Category", category);
                    
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Food food = new Food
                            {
                                Id = Convert.ToInt32(reader["FoodID"]),
                                Name = reader["FoodName"].ToString() ?? string.Empty,
                                Description = reader["Description"] != DBNull.Value ? reader["Description"].ToString() : null,
                                Price = Convert.ToDecimal(reader["Price"]),
                                Category = reader["Category"] != DBNull.Value ? reader["Category"].ToString() : null,
                                Image = reader["Image"] != DBNull.Value ? reader["Image"].ToString() : null,
                                IsAvailable = Convert.ToBoolean(reader["IsAvailable"])
                            };
                            
                            foods.Add(food);
                        }
                    }
                }
            }
            
            return foods;
        }
        
        public List<Food> SearchFoods(string? searchTerm = null, string? category = null, decimal? minPrice = null, decimal? maxPrice = null, bool onlyAvailable = true)
        {
            List<Food> foods = new List<Food>();
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                
                StringBuilder queryBuilder = new StringBuilder();
                queryBuilder.Append("SELECT FoodID, FoodName, Description, Price, Category, Image, IsAvailable, CreatedDate FROM Foods WHERE 1=1");
                
                // Add filter conditions based on parameters
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    queryBuilder.Append(" AND (FoodName LIKE @SearchTerm OR Description LIKE @SearchTerm)");
                }
                
                if (!string.IsNullOrEmpty(category))
                {
                    queryBuilder.Append(" AND Category = @Category");
                }
                
                if (minPrice.HasValue)
                {
                    queryBuilder.Append(" AND Price >= @MinPrice");
                }
                
                if (maxPrice.HasValue)
                {
                    queryBuilder.Append(" AND Price <= @MaxPrice");
                }
                
                if (onlyAvailable)
                {
                    queryBuilder.Append(" AND IsAvailable = 1");
                }
                
                string query = queryBuilder.ToString();
                
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameter values
                    if (!string.IsNullOrEmpty(searchTerm))
                    {
                        command.Parameters.AddWithValue("@SearchTerm", $"%{searchTerm}%");
                    }
                    
                    if (!string.IsNullOrEmpty(category))
                    {
                        command.Parameters.AddWithValue("@Category", category);
                    }
                    
                    if (minPrice.HasValue)
                    {
                        command.Parameters.AddWithValue("@MinPrice", minPrice.Value);
                    }
                    
                    if (maxPrice.HasValue)
                    {
                        command.Parameters.AddWithValue("@MaxPrice", maxPrice.Value);
                    }
                    
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Food food = new Food
                            {
                                Id = Convert.ToInt32(reader["FoodID"]),
                                Name = reader["FoodName"].ToString() ?? string.Empty,
                                Description = reader["Description"] != DBNull.Value ? reader["Description"].ToString() : null,
                                Price = Convert.ToDecimal(reader["Price"]),
                                Category = reader["Category"] != DBNull.Value ? reader["Category"].ToString() : null,
                                Image = reader["Image"] != DBNull.Value ? reader["Image"].ToString() : null,
                                IsAvailable = Convert.ToBoolean(reader["IsAvailable"])
                            };
                            
                            foods.Add(food);
                        }
                    }
                }
            }
            
            return foods;
        }

        public List<string> GetAllCategories()
        {
            List<string> categories = new List<string>();
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT DISTINCT Category FROM Foods WHERE Category IS NOT NULL ORDER BY Category";
                
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string category = reader["Category"].ToString() ?? string.Empty;
                            if (!string.IsNullOrEmpty(category))
                            {
                                categories.Add(category);
                            }
                        }
                    }
                }
            }
            
            return categories;
        }
    }
}