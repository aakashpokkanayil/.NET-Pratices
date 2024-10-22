using Microsoft.AspNetCore.Mvc;
using MyFirstApp.Models;

namespace MyFirstApp.Controllers
{
    public class AutherController : Controller
    {
        [Route("Auther/{id}")]    
        public IActionResult Index([FromQuery] Auther auther)
        {
            return Content(auther.ToString());
        }
    }
}
