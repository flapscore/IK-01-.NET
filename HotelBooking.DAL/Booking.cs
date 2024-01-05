using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DAL
{
    public class Booking
    {
        public int BookingId { get; set; } // Идентификатор бронирования
        public int RoomId { get; set; } // Идентификатор команты, которая забронирована
        public DateTime DateFrom { get; set; } // Датана начала бронирования
        public DateTime DateTo { get; set; } // Дата окончания бронирования
        
    }
}
