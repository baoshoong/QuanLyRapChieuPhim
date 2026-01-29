using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.DAL;
using WinFormsApp1.Model;

namespace WinFormsApp1.BLL
{
    public class ScreeningBLL
    {
        private ScreeningDAL screeningDAL;
        private MovieBLL movieBLL;
        private RoomBLL roomBLL;
        
        public ScreeningBLL()
        {
            screeningDAL = new ScreeningDAL();
            movieBLL = new MovieBLL();
            roomBLL = new RoomBLL();
        }
        
        public List<Screening> GetAllScreenings()
        {
            var screenings = screeningDAL.GetAllScreenings();
            
            // Check for screenings that have ended but are still marked as active
            List<Screening> needsUpdate = new List<Screening>();
            foreach (var screening in screenings)
            {
                if (screening.EndTime < DateTime.Now && screening.IsActive)
                {
                    screening.IsActive = false;
                    needsUpdate.Add(screening);
                }
            }
            
            // Update any screenings that need updating
            foreach (var screening in needsUpdate)
            {
                screeningDAL.UpdateScreening(screening);
            }
            
            return screenings;
        }
        
        public List<Screening> GetUpcomingScreenings()
        {
            return screeningDAL.GetUpcomingScreenings();
        }
        
        public Screening GetScreeningById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID l?ch chi?u không h?p l?");
            }
            
            return screeningDAL.GetScreeningById(id);
        }
        
        public List<Screening> GetScreeningsByMovieId(int movieId)
        {
            if (movieId <= 0)
            {
                throw new ArgumentException("ID phim không h?p l?");
            }
            
            return screeningDAL.GetScreeningsByMovieId(movieId);
        }
        
        public bool AddScreening(Screening screening)
        {
            ValidateScreening(screening);
            
            // Calculate end time if not already set
            if (screening.EndTime == DateTime.MinValue || screening.EndTime <= screening.StartTime)
            {
                Movie movie = movieBLL.GetMovieById(screening.MovieId);
                screening.EndTime = screening.StartTime.AddMinutes(movie.Duration);
            }
            
            // Check if the room is available during the selected time
            if (!screeningDAL.IsRoomAvailable(screening.RoomId, screening.StartTime, screening.EndTime))
            {
                throw new InvalidOperationException("Ph?ng đ? đư?c đ?t cho m?t l?ch chi?u khác trong kho?ng th?i gian này");
            }
            
            return screeningDAL.AddScreening(screening);
        }
        
        public bool UpdateScreening(Screening screening)
        {
            if (screening.Id <= 0)
            {
                throw new ArgumentException("ID l?ch chi?u không h?p l?");
            }
            
            ValidateScreening(screening);
            
            // Calculate end time if not already set
            if (screening.EndTime == DateTime.MinValue || screening.EndTime <= screening.StartTime)
            {
                Movie movie = movieBLL.GetMovieById(screening.MovieId);
                screening.EndTime = screening.StartTime.AddMinutes(movie.Duration);
            }
            
            // Check if the room is available during the selected time, excluding the current screening
            if (!screeningDAL.IsRoomAvailable(screening.RoomId, screening.StartTime, screening.EndTime, screening.Id))
            {
                throw new InvalidOperationException("Ph?ng đ? đư?c đ?t cho m?t l?ch chi?u khác trong kho?ng th?i gian này");
            }
            
            return screeningDAL.UpdateScreening(screening);
        }
        
        public bool DeleteScreening(int screeningId)
        {
            if (screeningId <= 0)
            {
                throw new ArgumentException("ID l?ch chi?u không h?p l?");
            }
            
            // In a real application, you might want to check if there are any bookings for this screening
            // and prevent deletion or handle it differently
            
            return screeningDAL.DeleteScreening(screeningId);
        }

		public List<Screening> GetScreeningsByMovieIdForToday(int movieId)
		{
			if (movieId <= 0)
			{
				throw new ArgumentException("ID phim không hợp lệ.");
			}
			return screeningDAL.GetScreeningsByMovieIdForToday(movieId);
		 }

        public bool UpdateScreeningStatus(int screeningId, bool isActive)
        {
            if (screeningId <= 0)
            {
                throw new ArgumentException("ID lịch chiếu không hợp lệ");
            }
            
            Screening screening = GetScreeningById(screeningId);
            if (screening == null)
            {
                throw new ArgumentException("Không tìm thấy lịch chiếu");
            }
            
            // If the screening has ended, force it to be inactive
            if (screening.EndTime < DateTime.Now)
            {
                screening.IsActive = false;
            }
            else
            {
                screening.IsActive = isActive;
            }
            
            return screeningDAL.UpdateScreening(screening);
        }
        
		public List<Screening> GetScreeningsForToday()
		{
			return screeningDAL.GetScreeningsForToday();
		}

		private void ValidateScreening(Screening screening)
        {
            // Validate movie
            if (screening.MovieId <= 0)
            {
                throw new ArgumentException("Vui l?ng ch?n phim");
            }
            
            Movie movie = movieBLL.GetMovieById(screening.MovieId);
            if (movie == null)
            {
                throw new ArgumentException("Phim không t?n t?i");
            }
            
            if (!movie.IsActive)
            {
                throw new ArgumentException("Phim đ? b? vô hi?u hóa và không th? lên l?ch chi?u");
            }
            
            // Validate room
            if (screening.RoomId <= 0)
            {
                throw new ArgumentException("Vui l?ng ch?n ph?ng");
            }
            
            Room room = roomBLL.GetRoomById(screening.RoomId);
            if (room == null)
            {
                throw new ArgumentException("Ph?ng không t?n t?i");
            }
            
            if (!room.IsActive)
            {
                throw new ArgumentException("Ph?ng đ? b? vô hi?u hóa và không th? s? d?ng");
            }
            
            // Validate start time
            if (screening.StartTime == DateTime.MinValue)
            {
                throw new ArgumentException("Vui l?ng ch?n th?i gian b?t đ?u");
            }
            
            // Can't schedule screenings in the past
            if (screening.StartTime < DateTime.Now)
            {
                throw new ArgumentException("Không th? lên l?ch chi?u trong quá kh?");
            }
            
            // Validate ticket price
            if (screening.TicketPrice <= 0)
            {
                throw new ArgumentException("Giá vé ph?i l?n hơn 0");
            }
        }
    }
}