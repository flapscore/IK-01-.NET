namespace lab6.Models
{
    public class Booking
    {
        public int Id { get; set; } // Идентификатор бронирования
        public int RoomId { get; set; } // Идентификатор номера
    
        public DateTime BookingDate { get; set; } // Дата бронирования

    }
}
