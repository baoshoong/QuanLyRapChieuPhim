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
    public class MovieDAL
    {
		private string connectionString = ConfigurationHelper.GetConnectionString();

		public List<Movie> GetAllMovies()
        {
            List<Movie> movies = new List<Movie>();
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT MovieID, Title, Director, Genre, Duration, Description, ReleaseDate, Poster, IsActive FROM Movies";
                
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Movie movie = new Movie
                            {
                                Id = Convert.ToInt32(reader["MovieID"]),
                                Title = reader["Title"].ToString() ?? string.Empty,
                                Director = reader["Director"].ToString() ?? string.Empty,
                                Genre = reader["Genre"].ToString() ?? string.Empty,
                                Duration = Convert.ToInt32(reader["Duration"]),
                                Description = reader["Description"].ToString() ?? string.Empty,
                                ReleaseDate = reader["ReleaseDate"] != DBNull.Value ? Convert.ToDateTime(reader["ReleaseDate"]) : DateTime.MinValue,
                                Poster = reader["Poster"] != DBNull.Value ? reader["Poster"].ToString() : null,
                                IsActive = Convert.ToBoolean(reader["IsActive"])
                            };
                            
                            movies.Add(movie);
                        }
                    }
                }
            }
            
            return movies;
        }
        
        public Movie? GetMovieById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT MovieID, Title, Director, Genre, Duration, Description, ReleaseDate, Poster, IsActive FROM Movies WHERE MovieID = @MovieID";
                
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MovieID", id);
                    
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Movie
                            {
                                Id = Convert.ToInt32(reader["MovieID"]),
                                Title = reader["Title"].ToString() ?? string.Empty,
                                Director = reader["Director"].ToString() ?? string.Empty,
                                Genre = reader["Genre"].ToString() ?? string.Empty,
                                Duration = Convert.ToInt32(reader["Duration"]),
                                Description = reader["Description"].ToString() ?? string.Empty,
                                ReleaseDate = reader["ReleaseDate"] != DBNull.Value ? Convert.ToDateTime(reader["ReleaseDate"]) : DateTime.MinValue,
                                Poster = reader["Poster"] != DBNull.Value ? reader["Poster"].ToString() : null,
                                IsActive = Convert.ToBoolean(reader["IsActive"])
                            };
                        }
                    }
                }
            }
            
            return null;
        }
        
        public bool AddMovie(Movie movie)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"INSERT INTO Movies (Title, Director, Genre, Duration, Description, ReleaseDate, Poster, IsActive) 
                                 VALUES (@Title, @Director, @Genre, @Duration, @Description, @ReleaseDate, @PosterUrl, @IsActive);
                                 SELECT SCOPE_IDENTITY();";
                
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Title", movie.Title);
                    command.Parameters.AddWithValue("@Director", movie.Director);
                    command.Parameters.AddWithValue("@Genre", movie.Genre);
                    command.Parameters.AddWithValue("@Duration", movie.Duration);
                    command.Parameters.AddWithValue("@Description", movie.Description);
                    command.Parameters.AddWithValue("@ReleaseDate", movie.ReleaseDate);
                    command.Parameters.AddWithValue("@PosterUrl", movie.Poster ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@IsActive", movie.IsActive);
                    
                    int newId = Convert.ToInt32(command.ExecuteScalar());
                    movie.Id = newId;
                    return true;
                }
            }
        }
        
        public bool UpdateMovie(Movie movie)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"UPDATE Movies 
                                 SET Title = @Title, 
                                     Director = @Director, 
                                     Genre = @Genre, 
                                     Duration = @Duration, 
                                     Description = @Description, 
                                     ReleaseDate = @ReleaseDate, 
                                     Poster = @Poster, 
                                     IsActive = @IsActive 
                                 WHERE MovieID = @MovieID";
                
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MovieID", movie.Id);
                    command.Parameters.AddWithValue("@Title", movie.Title);
                    command.Parameters.AddWithValue("@Director", movie.Director);
                    command.Parameters.AddWithValue("@Genre", movie.Genre);
                    command.Parameters.AddWithValue("@Duration", movie.Duration);
                    command.Parameters.AddWithValue("@Description", movie.Description);
                    command.Parameters.AddWithValue("@ReleaseDate", movie.ReleaseDate);
                    command.Parameters.AddWithValue("@Poster", movie.Poster ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@IsActive", movie.IsActive);
                    
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
        
        public bool DeleteMovie(int movieId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Movies WHERE MovieID = @MovieID";
                
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MovieID", movieId);
                    
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
        
        public List<Movie> GetActiveMovies()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                List<Movie> movies = new List<Movie>();
                
                connection.Open();
                string query = "SELECT MovieID, Title, Director, Genre, Duration, Description, ReleaseDate, PosterUrl, IsActive FROM Movies WHERE IsActive = 1";
                
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Movie movie = new Movie
                            {
                                Id = Convert.ToInt32(reader["MovieID"]),
                                Title = reader["Title"].ToString() ?? string.Empty,
                                Director = reader["Director"].ToString() ?? string.Empty,
                                Genre = reader["Genre"].ToString() ?? string.Empty,
                                Duration = Convert.ToInt32(reader["Duration"]),
                                Description = reader["Description"].ToString() ?? string.Empty,
                                ReleaseDate = reader["ReleaseDate"] != DBNull.Value ? Convert.ToDateTime(reader["ReleaseDate"]) : DateTime.MinValue,
                                Poster = reader["Poster"] != DBNull.Value ? reader["Poster"].ToString() : null,
                                IsActive = Convert.ToBoolean(reader["IsActive"])
                            };
                            
                            movies.Add(movie);
                        }
                    }
                }
                
                return movies;
            }
        }

		public List<Movie> GetMoviesWithScreeningsToday()
		{
			List<Movie> movies = new List<Movie>();
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					// Truy vấn để lấy các phim (không trùng lặp) có suất chiếu vào ngày hôm nay
					string query = @"SELECT DISTINCT m.* FROM Movies m
                                     JOIN Schedules s ON m.MovieID = s.MovieID
                                     WHERE s.ShowDate = CAST(GETDATE() AS DATE) AND m.IsActive = 1
                                     ORDER BY m.Title";

					using (SqlCommand command = new SqlCommand(query, connection))
					{
						using (SqlDataReader reader = command.ExecuteReader())
						{
							while (reader.Read())
							{
								Movie movie = new Movie
								{
									Id = Convert.ToInt32(reader["MovieID"]),
									Title = reader["Title"].ToString() ?? string.Empty,
									Director = reader["Director"].ToString() ?? string.Empty,
									Genre = reader["Genre"].ToString() ?? string.Empty,
									Duration = Convert.ToInt32(reader["Duration"]),
									Description = reader["Description"].ToString() ?? string.Empty,
									ReleaseDate = reader["ReleaseDate"] != DBNull.Value ? Convert.ToDateTime(reader["ReleaseDate"]) : DateTime.MinValue,
									Poster = reader["Poster"] != DBNull.Value ? reader["Poster"].ToString() : string.Empty,
									IsActive = Convert.ToBoolean(reader["IsActive"])
								};
								movies.Add(movie);
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error in GetMoviesWithScreeningsToday: {ex.Message}");
				throw;
			}
			return movies;
		}

	}
}