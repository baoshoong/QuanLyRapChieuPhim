using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.DAL;
using WinFormsApp1.Model;

namespace WinFormsApp1.BLL
{
    public class MovieBLL
    {
        private MovieDAL movieDAL;
        
        public MovieBLL()
        {
            movieDAL = new MovieDAL();
        }
        
        public List<Movie> GetAllMovies()
        {
            return movieDAL.GetAllMovies();
        }
        
        public List<Movie> GetActiveMovies()
        {
            return movieDAL.GetAllMovies().Where(m => m.IsActive).ToList();
        }
        
        public Movie GetMovieById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID phim không h?p l?");
            }
            
            return movieDAL.GetMovieById(id);
        }
        
        public bool AddMovie(Movie movie)
        {
            // Validation
            if (string.IsNullOrEmpty(movie.Title))
            {
                throw new ArgumentException("Tên phim không ðý?c ð? tr?ng");
            }
            
            if (movie.Duration <= 0)
            {
                throw new ArgumentException("Th?i lý?ng phim ph?i l?n hõn 0");
            }
            
            return movieDAL.AddMovie(movie);
        }
        
        public bool UpdateMovie(Movie movie)
        {
            // Validation
            if (movie.Id <= 0)
            {
                throw new ArgumentException("ID phim không h?p l?");
            }
            
            if (string.IsNullOrEmpty(movie.Title))
            {
                throw new ArgumentException("Tên phim không ðý?c ð? tr?ng");
            }
            
            if (movie.Duration <= 0)
            {
                throw new ArgumentException("Th?i lý?ng phim ph?i l?n hõn 0");
            }
            
            return movieDAL.UpdateMovie(movie);
        }
        
        public bool DeleteMovie(int movieId)
        {
            if (movieId <= 0)
            {
                throw new ArgumentException("ID phim không h?p l?");
            }
            
            return movieDAL.DeleteMovie(movieId);
        }
		public List<Movie> GetMoviesWithScreeningsToday()
		{
			return movieDAL.GetMoviesWithScreeningsToday();
		}

	}
}