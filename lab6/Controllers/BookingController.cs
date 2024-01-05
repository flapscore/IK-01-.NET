using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using lab6.Models;

namespace lab6.Controllers
{
    public class BookingController : Controller
    {
        // Список доступных номеров для бронирования
        private static List<Room> availableRooms = new List<Room>
        {
            new Room { Id = 1, Number = "101", Type = "Single", Price = 50.00 },
            new Room { Id = 2, Number = "102", Type = "Double", Price = 75.00 },
            new Room { Id = 3, Number = "103", Type = "Single", Price = 55.00 },
            new Room { Id = 4, Number = "104", Type = "Double", Price = 80.00 },
            new Room { Id = 5, Number = "105", Type = "Suite", Price = 100.00 }, // Добавлен новый тип номера
        };

        // Список бронирований и переменная для отслеживания следующего ID бронирования
        private static List<Booking> bookings = new List<Booking>();
        private static int nextBookingId = 1;

        private readonly ILogger<BookingController> _logger;

        public BookingController(ILogger<BookingController> logger)
        {
            _logger = logger;
        }

        // Действие для отображения списка доступных номеров
        public IActionResult Index()
        {
            return View(availableRooms);
        }

        [HttpGet]
        public IActionResult GetAvailableRooms(string type, double? minPrice, double? maxPrice) // Действие для получения доступных номеров с учетом фильтрации
        {
            var filteredRooms = availableRooms.AsQueryable();

            if (!string.IsNullOrWhiteSpace(type)) // Фильтрация по типу номера, минимальной и максимальной цене
            {
                filteredRooms = filteredRooms.Where(r => r.Type == type);
            }
            if (minPrice.HasValue)
            {
                filteredRooms = filteredRooms.Where(r => r.Price >= minPrice.Value);
            }
            if (maxPrice.HasValue)
            {
                filteredRooms = filteredRooms.Where(r => r.Price <= maxPrice.Value);
            }
            _logger.LogInformation("Filtered rooms: {@FilteredRooms}", filteredRooms.ToList());

            return Json(filteredRooms.ToList());
        }

        [HttpPost]
        public IActionResult BookRoom(int roomId) // Действие для бронирования номера
        {
            var room = availableRooms.FirstOrDefault(r => r.Id == roomId);
            if (room == null)
            {
                _logger.LogError("Room not found. RoomId: {RoomId}", roomId);
                return NotFound("Room not found.");
            }

            if (bookings.Any(b => b.RoomId == roomId)) // Проверка, что номер не забронирован ранее
            {
                _logger.LogError("Room is already booked. RoomId: {RoomId}", roomId);
                return BadRequest("Room is already booked.");
            }

            var booking = new Booking { Id = nextBookingId++, RoomId = roomId, BookingDate = DateTime.Now }; // Добавлено сохранение даты бронирования
            bookings.Add(booking);

            _logger.LogInformation("Room booked successfully. RoomId: {RoomId}, BookingId: {BookingId}", roomId, booking.Id);

            return Ok(new { Message = "Room booked successfully.", BookingId = booking.Id });
        }

        [HttpPost]
        public IActionResult CancelBooking(int bookingId) // Действие для отмены бронирования
        {
            var booking = bookings.FirstOrDefault(b => b.Id == bookingId);
            if (booking == null)
            {
                _logger.LogError("Booking not found. BookingId: {BookingId}", bookingId);
                return NotFound("Booking not found.");
            }

            bookings.Remove(booking);// Удаление записи о бронировании

            _logger.LogInformation("Booking cancelled successfully. BookingId: {BookingId}", bookingId);

            return Ok("Booking cancelled successfully.");
        }
    }
}

/*
 * Этот файл содержит контроллер для управления бронированием номеров. 
 * В нем есть методы для отображения доступных номеров, фильтрации, бронирования и отмены бронирования. 
 * Также он хранит списки доступных номеров и бронирований в памяти.