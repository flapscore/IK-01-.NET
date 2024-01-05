using Microsoft.AspNetCore.Mvc;
using laba5.Models;
using System.Collections.Generic;
using System.Linq;

namespace laba5.Controllers
{
    [ApiController]
    [Route("[controller]")]//
    public class RoomsController : ControllerBase// Контроллер для работы с номерами
    {
        private static List<Room> rooms;// Список номеров

        static RoomsController()// Инициализация начальных данных с новыми свойствами
        {
            // Инициализация начальных данных с новыми свойствами
            rooms = new List<Room>
            {
                new Room { Id = 1, Category = "Economy", Price = 50.00m, IsAvailable = true, Size = 20, NumberOfBeds = 2, Amenities = "WiFi, TV", PhotoUrl = "url_to_photo1.jpg" },
                new Room { Id = 2, Category = "Economy", Price = 50.00m, IsAvailable = false, Size = 20, NumberOfBeds = 2, Amenities = "WiFi", PhotoUrl = "url_to_photo2.jpg" },
                new Room { Id = 3, Category = "Deluxe", Price = 120.00m, IsAvailable = true, Size = 35, NumberOfBeds = 1, Amenities = "WiFi, TV, Minibar", PhotoUrl = "url_to_photo3.jpg" },
                new Room { Id = 4, Category = "Deluxe", Price = 120.00m, IsAvailable = false, Size = 35, NumberOfBeds = 1, Amenities = "WiFi, TV, Minibar", PhotoUrl = "url_to_photo4.jpg" },
                // Добавьте дополнительные комнаты при необходимости
            };
        }

        [HttpGet]
        public IActionResult GetAllRooms()// Получение всех номеров
        {
            return Ok(rooms);// Возвращает список номеров
        }

        [HttpGet("available")]// Получение доступных номеров
        public IActionResult GetAvailableRooms()// Получение доступных номеров
        {
            var availableRooms = rooms.Where(r => r.IsAvailable).ToList();// Получение доступных номеров
            return Ok(availableRooms);// Возвращает список доступных номеров
        }

        [HttpGet("{id}")]// Получение номера по ID
        public IActionResult GetRoomById(int id)// Получение номера по ID
        {
            var room = rooms.FirstOrDefault(r => r.Id == id);// Получение номера по ID
            if (room == null)// Если номер не найден
            {
                return NotFound();// Возвращает ошибку 404
            }
            return Ok(room);// Возвращает номер
        }

        [HttpPost]
        public IActionResult CreateRoom([FromBody] Room room)// Создание нового номера
        {
            room.Id = rooms.Any() ? rooms.Max(r => r.Id) + 1 : 1;// Генерация ID для нового номера
            rooms.Add(room);
            return CreatedAtAction(nameof(GetRoomById), new { id = room.Id }, room);// Возвращает созданный номер
        }

        [HttpPut("{id}")]// Обновление данных комнаты
        public IActionResult UpdateRoom(int id, [FromBody] Room updatedRoom)// Обновление данных комнаты
        {
            var roomIndex = rooms.FindIndex(r => r.Id == id);// Получение номера по ID
            if (roomIndex == -1)// Если номер не найден
            {
                return NotFound();// Возвращает ошибку 404
            }

            rooms[roomIndex] = updatedRoom; // Обновление данных комнаты
            rooms[roomIndex].Id = id; // Убедитесь, что ID не изменяется
            return NoContent();// Возвращает пустой ответ
        }

        [HttpDelete("{id}")]// Удаление номера
        public IActionResult DeleteRoom(int id)// Удаление номера
        {
            var roomIndex = rooms.FindIndex(r => r.Id == id);// Получение номера по ID
            if (roomIndex == -1)// Если номер не найден
            {
                return NotFound();// Возвращает ошибку 404
            }

            rooms.RemoveAt(roomIndex);// Удаление номера
            return NoContent();// Возвращает пустой ответ
        }
    }
}
