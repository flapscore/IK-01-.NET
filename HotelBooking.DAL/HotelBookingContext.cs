using System.Collections.Generic;

namespace HotelBooking.DAL
{
    public class HotelBookingContext
    {
        public List<Room> Rooms { get; set; } = new List<Room>(); // Коллекция комнат, используется для хранения информации о комнатах в отеле
        public List<Category> Categories { get; set; } = new List<Category>(); // Коллекция категорий комнат, используется для классфикации комнат по категориям.
        public List<Booking> Bookings { get; set; } = new List<Booking>(); // Коллекция бронирований, используется для хранения информации о бронированиях комнат.

        
    }
}

// Этот класс представляет собой контейнет, который может использоваться для хранения и управления данными, связанными с вашей системой отелей
