using HotelBooking.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq; // Для работы с LINQ

namespace HotelBooking.Controllers
{
    public class RoomsController : Controller
    {
        private static List<Room> _rooms = new List<Room>();

        // GET: Rooms
        public IActionResult Index()
        {
            return View(_rooms);
        }

        // GET: Rooms/Create
        public IActionResult Create()
        {
            return View(new Room()); // Если у тебя есть конструктор по умолчанию и начальные значения не требуются, просто используй `return View();`
        }

        // POST: Rooms/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Room room)
        {
            if (ModelState.IsValid)
            {
                // Здесь добавь логику для добавления комнаты в базу данных или список
                _rooms.Add(room); // Это просто пример, в реальном приложении ты добавишь комнату в базу данных
                return RedirectToAction(nameof(Index));
            }
            return View(room);
        }

        // GET: Rooms/Edit/5
        public IActionResult Edit(int id)// Метод Get который отображает форму для редактирования бронирования. При переходе на страницу /Bookings/Edit вызывается метод Edit(Get) и отображается форма для редактирования бронирования.
        {
            var room = _rooms.FirstOrDefault(r => r.Id == id);// Поиск бронирования по id
            if (room == null)// Если бронирование не найдено
            {
                return NotFound();// Возврат ошибки 404
            }
            return View(room);// Возврат представления с бронированием
        }

        // POST: Rooms/Edit/5
        [HttpPost]
        public IActionResult Edit(int id, Room room)// Метод post , который обрабатывает отправку формы редактирования бронирования. Когда форма отправляется, данные бронирования обновляются в списке _bookings и происходит перенаправление на страницу /Bookings.
        {
            var existingRoom = _rooms.FirstOrDefault(r => r.Id == id);// Поиск бронирования по id
            if (existingRoom != null && ModelState.IsValid)// Если бронирование найдено
            {
                existingRoom.Category = room.Category;// Обновление данных бронирования
                existingRoom.Price = room.Price;// Обновление данных бронирования
                existingRoom.IsAvailable = room.IsAvailable;// Обновление данных бронирования
                return RedirectToAction(nameof(Index));// Перенаправление на страницу Index
            }
            return View(room);
        }

        // GET: Rooms/Delete/5
        public IActionResult Delete(int id)// Метод Get который отображает форму для удаления бронирования. При переходе на страницу /Bookings/Delete вызывается метод Delete(Get) и отображается форма для удаления бронирования.
        {
            var room = _rooms.FirstOrDefault(r => r.Id == id);// Поиск бронирования по id
            if (room == null)// Если бронирование не найдено
            {
                return NotFound();// Возврат ошибки 404
            }
            return View(room);// Возврат представления с бронированием
        }

        // POST: Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]// Метод post , который обрабатывает отправку формы удаления бронирования. Когда форма отправляется, данные бронирования удаляются из списка _bookings и происходит перенаправление на страницу /Bookings.
        public IActionResult DeleteConfirmed(int id)// Метод post , который обрабатывает отправку формы удаления бронирования. Когда форма отправляется, данные бронирования удаляются из списка _bookings и происходит перенаправление на страницу /Bookings.
        {
            var room = _rooms.FirstOrDefault(r => r.Id == id);// Поиск бронирования по id
            if (room != null)// Если бронирование найдено
            {
                _rooms.Remove(room);// Удаление бронирования из списка
                return RedirectToAction(nameof(Index));// Перенаправление на страницу Index
            }
            return NotFound();// Возврат ошибки 404
        }

        // GET: Rooms/Details/5
        public IActionResult Details(int id)// Метод Get который отображает форму для просмотра бронирования. При переходе на страницу /Bookings/Details вызывается метод Details(Get) и отображается форма для просмотра бронирования.
        {
            var room = _rooms.FirstOrDefault(r => r.Id == id);// Поиск бронирования по id
            if (room == null)// Если бронирование не найдено
            {
                return NotFound();// Возврат ошибки 404
            }
            return View(room);// Возврат представления с бронированием
        }

        
    }
}




/*RoomController - данный контроллер управляет номерами в отеле. В нем есть методы для просмотра и создания номеров:
 * Index - метод Get который отображает список всех номеров. Он вызывается при переходе на страницу /Rooms. Он использует переменную _rooms, которая является статическим списком для хранения данных о номерах. Данный список используется как временное хранилище данных в памяти.
 * Create(GET) метод Get который отображает форму для создания нового номера. При переходе на страницу /Rooms/Create вызывается метод Create(GET) и отображается форма для создания нового номера.
 * Create (POST): Метод POST, который обрабатывает отправку формы добавления нового номера. При успешном добавлении номера в список _rooms происходит перенаправление на метод Index, чтобы показать обновленный список номеров.
 * В обоих контроллерах используется паттерн "Post/Redirect/Get", который предотвращает повторную отправку формы при обновлении страницы пользователем после создания бронирования или номера
*/