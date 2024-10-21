using Microsoft.AspNetCore.Mvc;
using MyFirstApp.Models;

namespace MyFirstApp.Controllers
{
    [Route("Home")]
    public class HomeController : Controller
    {
        [Route("sayhi")]  // we can call this action method as http://localhost:5282/home/sayhi
        public string Hello()
        {
            return "HI dude";
        }

        [Route("about-us")]
        public string About()
        {
            return "Hi this is from about us page";
        }
        [Route("Categories")]
        public ContentResult Categories() // we can call this action method as http://localhost:5282/home/Categories
        {
            return new ContentResult()
            {
                ContentType = "text/html",
                Content = "<h1>Hi welcome to Categories</h1>"
            };
        }

        [Route("products")]
        public ContentResult Products() // we can call this action method as http://localhost:5282/home/products
        {
            return Content("<h1>Hi welcome to Products</h1>", "text/html");
        }

        [Route("person")]
        public JsonResult Person() // we can call this action method as http://localhost:5282/home/person
        {
            var person = new Person()
            {
                Id=Guid.NewGuid(),
                Name="Aakash",
                Address="Test Address",
                Age=32

            };
            //return new JsonResult(person);  // similar to ContentResult we can use this method, but
            return Json(person); //this method is more convinient and this method is from abstract class Controller.
        }

        [Route("download1")]
        public VirtualFileResult download1() // we can call this action method as http://localhost:5282/home/download1
        {
           return File("Aakash_P.pdf", "application/pdf");
        }

        [Route("physicaldownload")]
        public PhysicalFileResult download2() // we can call this action method as http://localhost:5282/home/physicaldownload
        {
            return PhysicalFile("C:\\Users\\aakas\\OneDrive\\Web Development\\WebApps\\MyFirstApp\\MyFirstApp\\webroot\\Aakash_P.pdf", "application/pdf");
        }

        [Route("Fileasbytes")]
        public FileContentResult download3() //http://localhost:5282/home/Fileasbytes
        {
            var bytes = System.IO.File.ReadAllBytes("C:\\Users\\aakas\\OneDrive\\Web Development\\WebApps\\MyFirstApp\\MyFirstApp\\webroot\\Aakash_P.pdf");
            return File(bytes,"application/pdf");
        }

        [Route("Book")]
        public IActionResult Book(int id,bool autherize) //http://localhost:5282/home/Book?id=10&autherize=1
        {
            if (id == 0)
            {
                return BadRequest("Book id cannot be null or string.");
            }
            else if (!(id > 0 && id < 1000))
            {
                return NotFound("Book Not found, we only have 1000 book in stock.");
            }
            else if (!autherize)
            {
                return Unauthorized("You are not loggedIn");
            }
            else
            {
                return File("Aakash_P.pdf","application/pdf");
            }
           
            
        }
        
    }
}
