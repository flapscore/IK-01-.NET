using Microsoft.AspNetCore.Mvc;
using laba5.Models;
using System.Collections.Generic;
using System.Linq;

namespace laba5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservationsController : ControllerBase// Контроллер для работы с бронированиями
    {
        private static List<Reservation> reservations = new List<Reservation>();// Список бронирований

        // Получение всех бронирований
        [HttpGet]
        public IActionResult GetAll()// Получение всех бронирований
        {
            return Ok(reservations);// Возвращает список бронирований
        }

        // Получение бронирования по ID
        [HttpGet("{id}")]// Получение бронирования по ID
        public IActionResult GetById(int id)// Получение бронирования по ID
        {
            var reservation = reservations.FirstOrDefault(r => r.Id == id);// Получение бронирования по ID
            if (reservation == null)// Если бронирование не найдено
            {
                return NotFound();// Возвращает ошибку 404
            }
            return Ok(reservation);// Возвращает бронирование
        }

        // Создание нового бронирования
        [HttpPost]
        public IActionResult Create([FromBody] Reservation reservation)// Создание нового бронирования
        {
            // Генерация ID для нового бронирования
            reservation.Id = reservations.Any() ? reservations.Max(r => r.Id) + 1 : 1;// Генерация ID для нового бронирования
            // Здесь можно добавить логику расчета общей стоимости бронирования, если необходимо
            reservations.Add(reservation);// Добавление бронирования в список
            return CreatedAtAction(nameof(GetById), new { id = reservation.Id }, reservation);// Возвращает созданное бронирование
        }

        // Обновление бронирования
        [HttpPut("{id}")]// Обновление бронирования
        public IActionResult Update(int id, [FromBody] Reservation reservationUpdate)//
        {
            var reservation = reservations.FirstOrDefault(r => r.Id == id);// Получение бронирования по ID
            if (reservation == null)// Если бронирование не найдено
            {
                return NotFound();// Возвращает ошибку 404
            }

            // Обновление свойств бронирования
            reservation.RoomId = reservationUpdate.RoomId;// Обновление свойств бронирования
            reservation.CustomerId = reservationUpdate.CustomerId;// Обновление свойств бронирования
            reservation.CheckInDate = reservationUpdate.CheckInDate;// Обновление свойств бронирования
            reservation.CheckOutDate = reservationUpdate.CheckOutDate;// Обновление свойств бронирования
            reservation.Status = reservationUpdate.Status;// Обновление свойств бронирования
            reservation.TotalPrice = reservationUpdate.TotalPrice;// Обновление свойств бронирования
            reservation.NumberOfGuests = reservationUpdate.NumberOfGuests;// Обновление свойств бронирования
            reservation.SpecialRequests = reservationUpdate.SpecialRequests;// Обновление свойств бронирования

            return NoContent();// Возвращает пустой ответ
        }

        // Удаление бронирования
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var reservation = reservations.FirstOrDefault(r => r.Id == id);
            if (reservation == null)
            {
                return NotFound();
            }
            reservations.Remove(reservation);
            return NoContent();
        }
    }
}

