using First.API.Models;
using First.App.Core.Abrastract;
using Microsoft.AspNetCore.Mvc;

namespace First.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        private readonly IEmail _email;
        public HomeController(IEmail mail)
        {
            _email =  mail;
        }

        [HttpGet]
        public IActionResult Index()
        {
            _email.Send();
            return Ok();
        }
        [HttpPost]
        [Route("Tester")]
        public IActionResult Test([FromForm] TesterModel model)
        {
            var tester = new TesterModel
            {
                FirstName = model.FirstName.ToUpper(),
                LastName = model.LastName,
                BirthDate = model.BirthDate,
                Image = model.Image
            };
            return Ok(tester);
        }
        [HttpDelete]
        public IActionResult Delete()
        {
            return Json(new { success = true, data = "Hello World" });
        }
        [HttpPut]
        public IActionResult Put()
        {
            return Ok();
        }
    }
}
