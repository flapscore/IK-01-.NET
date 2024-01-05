using lab6.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace lab6.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index() // Действие для отображения домашней страницы
        {
            return View();
        }

        public IActionResult Privacy() // Действие для отображения страницы конфиденциальности
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

//  контроллер для управления домашней страницей  проекта.
// Он включает действия для отображения домашней страницы, страницы конфиденциальности и страницы ошибки. Контроллер также обрабатывает логирование ошибок.