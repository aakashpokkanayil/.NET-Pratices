using Microsoft.AspNetCore.Mvc;

namespace MyFirstApp.Models
{
    public class Auther
    {
        [FromRoute]
        public int Id { get; set; }
        public string? Name { get; set; }

        public override string ToString()
        {
            return $"Auther Id:{Id} and Auther Name:{Name}";
        }
    }
}
