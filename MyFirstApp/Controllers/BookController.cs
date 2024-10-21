using Microsoft.AspNetCore.Mvc;

namespace MyFirstApp.Controllers
{
    public class BookController : Controller
    {
        [Route("Bookstore")]
        public IActionResult Book()
        {
            return RedirectPermanent("Store/book"); //301 permenet redirection only url is required, even url outside of url will redirect.
            return Redirect("Store/book"); //302 temp redirection only url is required, even url outside of url will redirect.
            return LocalRedirectPermanent("Store/book");//301 permenet redirection only url is required
            return LocalRedirect("Store/book"); //302 temp redirection only url is required
            return RedirectToActionPermanent("Index", "Store", new { });//301 permenet redirection
            return RedirectToAction("Index", "Store", new { }); //302 temp redirection
        }
    }
}
