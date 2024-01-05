namespace laba5.Models
{
    public class Room// Класс для работы с номерами
    {
        public int Id { get; set; }// ID номера
        public string Category { get; set; }// Категория номера
        public decimal Price { get; set; }// Цена за ночь
        public bool IsAvailable { get; set; } // Доступен ли номер для бронирования
        public double Size { get; set; } // Площадь номера в квадратных метрах
        public int NumberOfBeds { get; set; } // Количество кроватей
        public string Amenities { get; set; } // Дополнительные удобства
        public string PhotoUrl { get; set; } // URL фотографии номера
    }
}
