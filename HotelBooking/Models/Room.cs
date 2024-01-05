using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Models
{
    public class Room
    {
        public int Id { get; set; } // Уникальный идентификатор номера

        [Required]
        [StringLength(50)]
        public string Category { get; set; } // Категория номера

        [Required]
        [Range(0, 10000, ErrorMessage = "Price must be a positive value")]
        public double Price { get; set; } // Цена за ночь

        public bool IsAvailable { get; set; } // Доступность номера

        // Дополнительные свойства
        [StringLength(500)]
        public string Description { get; set; } // Описание номера

        public int Beds { get; set; } // Количество кроватей

        // Связи с другими моделями
        public ICollection<Booking> Bookings { get; set; } // Связь с бронированиями

        
    }
}

