using HotelBooking.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HotelBooking.Controllers // Это объявление контроллера с именем HomeController, который наследует функциональность базового контроллера Controller.
{
    public class HomeController : Controller // Добавлено для использования List
    {
        private readonly ILogger<HomeController> _logger;///

        // GET: Home
        public HomeController(ILogger<HomeController> logger) // Это конструктор, который принимает ILogger в качестве параметра. Это позволяет использовать логгер внутри контроллера.
        {
            _logger = logger; // 
        }

        public IActionResult Index()// Этот метод действия (action) обрабатывает HTTP GET-запрос и возвращает представление Index.
        {
            return View();// Возвращает представление Index
        }

        // GET: Home/Privacy
        public IActionResult Privacy() 
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]// Этот метод действия (action) обрабатывает HTTP GET-запрос и возвращает представление Privacy.
        public IActionResult Error()// Этот метод действия (action) обрабатывает HTTP GET-запрос и возвращает представление Error.
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });// Возвращает представление Error
        }
    }
}