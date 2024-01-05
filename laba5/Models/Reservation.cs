namespace laba5.Models
{
    public class Reservation// Класс для работы с бронированиями
    {
        public int Id { get; set; }// ID бронирования
        public int RoomId { get; set; }// ID номера
        public int CustomerId { get; set; }// ID клиента
        public DateTime CheckInDate { get; set; }// Дата заселения
        public DateTime CheckOutDate { get; set; } // Дата выселения
        public string Status { get; set; } // Например: "New", "Confirmed", "Cancelled"
        public decimal TotalPrice { get; set; } // Общая стоимость бронирования
        public int NumberOfGuests { get; set; } // Количество гостей
        public string SpecialRequests { get; set; } // Специальные запросы или предпочтения
    }
}
