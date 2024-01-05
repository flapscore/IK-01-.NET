using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DAL
{
    public class Room
    {
        public int RoomId { get; set; }
        public string Number { get; set; } // Номер комнаты
        public int CategoryId { get; set; }
        

        // Список бронирований для комнаты
        public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
