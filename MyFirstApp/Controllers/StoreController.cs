using Microsoft.AspNetCore.Mvc;

namespace MyFirstApp.Controllers
{
    public class StoreController : Controller
    {
        [Route("Store/book")]
        public IActionResult Index()
        {
            return Content("welcome to book store");
        }
    }
}
