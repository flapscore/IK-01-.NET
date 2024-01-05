using System;
using System.Collections.Generic;
using System.Linq;
using HotelBooking.DAL;

namespace HotelBooking.BLL
{
    public class RoomService : IRoomService
    {
        private readonly HotelBookingContext _context;

        public RoomService(HotelBookingContext context) 
        {
            _context = context;
        }

        public Room GetRoomById(int roomId) 
        {
            return _context.Rooms.FirstOrDefault(room => room.RoomId == roomId);
        }

        public IEnumerable<Room> GetAllRooms() 
        {
            return _context.Rooms;
        }

        public IEnumerable<Room> GetAvailableRooms(DateTime startDate, DateTime endDate) 
        {
            return _context.Rooms.Where(room => room.Bookings == null || room.Bookings.All(booking =>
                booking.DateTo <= startDate || booking.DateFrom >= endDate));
        }

        public void AddRoom(Room room) 
        {
            _context.Rooms.Add(room);
        }

        public void UpdateRoom(Room room) 
        {
            var existingRoom = GetRoomById(room.RoomId);
            if (existingRoom != null)
            {
                existingRoom.Number = room.Number;
                existingRoom.CategoryId = room.CategoryId;
                
            }
        }

        public void DeleteRoom(int roomId) 
        {
            var room = GetRoomById(roomId);
            if (room != null)
            {
                _context.Rooms.Remove(room);
            }
        }

        public IEnumerable<Room> GetRoomsByCategory(int categoryId) 
        {
            return _context.Rooms.Where(room => room.CategoryId == categoryId);
        }
    }
}
