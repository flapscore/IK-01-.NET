using HotelBooking.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq; // Для работы с LINQ

namespace HotelBooking.Controllers
{
    public class BookingsController : Controller // Это объявление контроллера с именем BookingsController, который наследует функциональность базового контроллера Controller.
    {
        private static List<Booking> _bookings = new List<Booking>(); //  Эта строка объявляет статическое поле _bookings, которое представляет собой список бронирований (Booking). Этот список будет использоваться в качестве хранилища бронирований.

        // GET: Bookings
        public IActionResult Index() // тот метод действия (action) обрабатывает HTTP GET-запрос и возвращает представление Index, передавая ему список бронирований _bookings.
        {
            return View(_bookings);  // Возвращает представление Index
        }

        // GET: Bookings/Create
        public IActionResult Create() // Метод Get который отображает форму для создания нового бронирования . При переходе на страницу /Bookings/Create вызывается метод Create(Get) и отображается форма для создания нового бронирования.
        {
            // Передать список комнат в ViewBag или ViewData для DropDownList в представлении, если необходимо
            // Например: ViewBag.Rooms = new SelectList(_rooms, "Id", "Name");
            return View();
        }

        // POST: Bookings/Create
        [HttpPost]
        public IActionResult Create(Booking booking) // Метод post , который обрабатывает отправку формы создания нового бронирования. Когда форма отправляется, данные бронирования добавляются в список _bookings и происходит перенаправление на страницу /Bookings.
        {
            if (ModelState.IsValid) // Проверка на валидность модели
            {
                _bookings.Add(booking);// Добавление бронирования в список
                return RedirectToAction("Index");// Перенаправление на страницу Index
            }
            return View(booking);// Возврат представления с ошибкой
        }

        // GET: Bookings/Edit/5
        public IActionResult Edit(int id)// Метод Get который отображает форму для редактирования бронирования. При переходе на страницу /Bookings/Edit вызывается метод Edit(Get) и отображается форма для редактирования бронирования.
        {
            var booking = _bookings.FirstOrDefault(b => b.Id == id);// Поиск бронирования по id
            if (booking == null)// Если бронирование не найдено
            {
                return NotFound();// Возврат ошибки 404
            }
            return View(booking);// Возврат представления с бронированием
        }

        // POST: Bookings/Edit/5
        [HttpPost]
        public IActionResult Edit(int id, Booking booking)// Метод post , который обрабатывает отправку формы редактирования бронирования. Когда форма отправляется, данные бронирования обновляются в списке _bookings и происходит перенаправление на страницу /Bookings.
        {
            var existingBooking = _bookings.FirstOrDefault(b => b.Id == id);// Поиск бронирования по id
            if (existingBooking != null)// Если бронирование найдено
            {
                existingBooking.RoomId = booking.RoomId;// Обновление данных бронирования
                existingBooking.StartDate = booking.StartDate;// Обновление данных бронирования
                existingBooking.EndDate = booking.EndDate;// Обновление данных бронирования
                return RedirectToAction("Index");// Перенаправление на страницу Index
            }
            return View(booking);// Возврат представления с ошибкой
        }

        // GET: Bookings/Delete/5
        public IActionResult Delete(int id)// Метод Get который отображает форму для удаления бронирования. При переходе на страницу /Bookings/Delete вызывается метод Delete(Get) и отображается форма для удаления бронирования.
        {
            var booking = _bookings.FirstOrDefault(b => b.Id == id);// Поиск бронирования по id
            if (booking == null)
            {
                return NotFound();// Возврат ошибки 404
            }
            return View(booking);// Возврат представления с бронированием
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]// Метод post , который обрабатывает отправку формы удаления бронирования. Когда форма отправляется, данные бронирования удаляются из списка _bookings и происходит перенаправление на страницу /Bookings.
        public IActionResult DeleteConfirmed(int id) // Метод post , который обрабатывает отправку формы удаления бронирования. Когда форма отправляется, данные бронирования удаляются из списка _bookings и происходит перенаправление на страницу /Bookings.
        {
            var booking = _bookings.FirstOrDefault(b => b.Id == id);// Поиск бронирования по id
            if (booking != null)// Если бронирование найдено
            {
                _bookings.Remove(booking);// Удаление бронирования из списка
            }
            return RedirectToAction("Index");// Перенаправление на страницу Index
        }

        
    }
}





// Этот контроллер отвечает за управления бронированиями. В нем определены такие методы:
// Index - Метод Get который отображает список всех броннированийй. Он вызывается при переходе на страницу /Bookings.ОН использует переменную _bookings, которая ялвяется статическком списком для хранения данных о бронированиях.
// Данный список используется как временное хранлище данных в памяти.

//Create(Get): метод Get который отображает форму для создания нового бронирования . При переходе на страницу /Bookings/Create вызывается метод Create(Get) и отображается форма для создания нового бронирования.

// Create (Post) Метод post , который обрабатывает отправку формы создания нового бронирования. Когда форма отправляется, данные бронирования добавляются в список _bookings и происходит перенаправление на страницу /Bookings.

