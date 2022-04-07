using First.App.Filters;
using First.App.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace First.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Sample()
        {           
            return View();
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public IActionResult Sample(CustomerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            return View(model);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult BadReq()
        {
            return BadRequest("Hata Yetkisiz Giriş");
        }

        public IActionResult Success()
        {
            return Ok(new SuccessViewModel { Message = "İşlem Başarılı", StatusCode = 200 });
        }

        public IActionResult PageNotFound()
        {
            return NotFound();
        }

        public IActionResult ForbiddenPage()
        {
            return StatusCode(StatusCodes.Status403Forbidden);
        }

        public IActionResult ServerError()
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
