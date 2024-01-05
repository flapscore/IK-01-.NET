using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Models
{
    public class Booking : IValidatableObject // IValidatableObject - интерфейс, который позволяет проверять модель на валидность
    {
        public int Id { get; set; } // Уникальный идентификатор бронирования
        [Required]
        public int RoomId { get; set; } // Номер комнаты, связь с моделью Room
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; } // Дата начала бронирования
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; } // Дата окончания бронирования

        // Навигационное свойство (если есть модель Room)
        public Room Room { get; set; } // Детали комнаты

        // Дополнительные свойства
        [Display(Name = "Booking Status")]
        public string Status { get; set; } // Статус бронирования (Optional)

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)// Метод, который проверяет модель на валидность
        {
            if (EndDate <= StartDate)// Если дата окончания бронирования меньше или равна дате начала бронирования
            {
                yield return new ValidationResult("End date must be after start date", new[] { "EndDate" });// Вернуть ошибку
            }
        }
    }
}
