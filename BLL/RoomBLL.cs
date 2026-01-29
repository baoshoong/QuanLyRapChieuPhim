using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.DAL;
using WinFormsApp1.Model;

namespace WinFormsApp1.BLL
{
    public class RoomBLL
    {
        private RoomDAL roomDAL;
        
        public RoomBLL()
        {
            roomDAL = new RoomDAL();
        }
        
        public List<Room> GetAllRooms()
        {
            return roomDAL.GetAllRooms();
        }
        
        public List<Room> GetActiveRooms()
        {
            return roomDAL.GetAllRooms().Where(r => r.IsActive).ToList();
        }
        
        public Room GetRoomById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID phòng chiếu không hợp lệ");
            }
            
            return roomDAL.GetRoomById(id);
        }
        
        public bool AddRoom(Room room)
        {
            // Validation
            if (string.IsNullOrEmpty(room.Name))
            {
                throw new ArgumentException("Tên phòng chiếu không được để trống");
            }
            
            if (room.Capacity <= 0)
            {
                throw new ArgumentException("Sức chứa phải lớn hơn 0");
            }
            
            // Thêm điều kiện kiểm tra sức chứa tối đa
            if (room.Capacity > 120)
            {
                throw new ArgumentException("Sức chứa tối đa của phòng chiếu là 120 chỗ ngồi");
            }
            
            // Thêm phòng mới vào CSDL
            bool result = roomDAL.AddRoom(room);
            
            if (result)
            {
                // Tự động tạo ghế cho phòng mới
                SeatBLL seatBLL = new SeatBLL();
                seatBLL.CreateSeatsForRoom(room.Id, room.Capacity);
            }
            
            return result;
        }
        
        public bool UpdateRoom(Room room)
        {
            // Validation
            if (room.Id <= 0)
            {
                throw new ArgumentException("ID phòng chiếu không hợp lệ");
            }
            
            if (string.IsNullOrEmpty(room.Name))
            {
                throw new ArgumentException("Tên phòng chiếu không được để trống");
            }
            
            if (room.Capacity <= 0)
            {
                throw new ArgumentException("Sức chứa phải lớn hơn 0");
            }
            
           
            if (room.Capacity > 120)
            {
                throw new ArgumentException("Sức chứa tối đa của phòng chiếu là 120 chỗ ngồi");
            }
            
            // Lấy thông tin phòng cũ để so sánh capacity
            Room oldRoom = roomDAL.GetRoomById(room.Id);
            bool result = roomDAL.UpdateRoom(room);
            
            // Nếu capacity thay đổi, cập nhật lại ghế
            if (result && oldRoom != null && room.Capacity != oldRoom.Capacity)
            {
                SeatBLL seatBLL = new SeatBLL();
                // Xóa ghế cũ
                seatBLL.DeleteSeatsByRoomId(room.Id);
                // Tạo ghế mới với capacity mới
                seatBLL.CreateSeatsForRoom(room.Id, room.Capacity);
            }
            
            return result;
        }
        
        public bool DeleteRoom(int roomId)
        {
            if (roomId <= 0)
            {
                throw new ArgumentException("ID phòng chiếu không hợp lệ");
            }
            
            // Xóa ghế trước khi xóa phòng
            SeatBLL seatBLL = new SeatBLL();
            seatBLL.DeleteSeatsByRoomId(roomId);
            
            return roomDAL.DeleteRoom(roomId);
        }
    }
}