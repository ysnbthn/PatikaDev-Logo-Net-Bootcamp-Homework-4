using Microsoft.AspNetCore.Mvc;
using System;

namespace First.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        public IActionResult Index()
        {
            throw new ArgumentNullException();
        }
    }
}
