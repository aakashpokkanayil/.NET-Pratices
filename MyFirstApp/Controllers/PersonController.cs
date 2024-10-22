using Microsoft.AspNetCore.Mvc;
using MyFirstApp.Models;

namespace MyFirstApp.Controllers
{
    public class PersonController : Controller
    {
        [Route("person")]    
        public IActionResult Index(Person person)
        {
            if (!ModelState.IsValid)
            {
                var obj = ModelState.Values.SelectMany(x => x.Errors).Select(x=>x.ErrorMessage).ToList();
                // here ModelState.Values contain collection of errors for each properties of model(each model prop can have multiple errors)
                //so error is a collection so we use selectmany to loop over colection of collection (here values over errors)
                //and it return flattened Ienumerable collection of ModelError, flattened means it collect all errors of each prop to a single collection
                // from this collection of error using select we select errormsg as a Ienumerable collection of string
                // to list to convert to string.
                var errors = string.Join(",\n", obj);
                return BadRequest(errors);
            }
            return Content(person.ToString());
        }
    }
}
