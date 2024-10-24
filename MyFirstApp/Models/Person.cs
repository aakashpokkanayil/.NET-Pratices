using MyFirstApp.CustomAttribute;
using System.ComponentModel.DataAnnotations;

namespace MyFirstApp.Models
{
    public class Person
    {
        #region Properties
        public Guid Id { get; set; }

        [Required(ErrorMessage ="{0} can't be null or empty.")]
        [MinLength(3,ErrorMessage ="{0} must be min 3 char.")]
        [Display(Name="Name of Person")]
        [RegularExpression("^[A-Za-z .]+$",ErrorMessage ="{0} only contain aphabets, space and dot(.)")]
        public string? Name { get; set; }  //As an example for model validation we are defining [Required] attribute here,
                                           //so if name got null , error dedail will be stored in model state object, so we can check model state
                                           //and do need ful
        [Required(ErrorMessage = "{0} is required.")]
        [EmailAddress(ErrorMessage = "{0} format is invalid.")]
        [StringLength(50,MinimumLength = 5, ErrorMessage = "{0} cannot be longer than {1} characters and less than {2} characters.")] 
        // {0} using string formatting i can show display message even in custom message.
        // {1} this will 50 and {2} this will be 5
        [Display(Name ="Email Address")]  // display name desides how this field should show in error message
        public string? EmailAddress { get; set; }

        [Required(ErrorMessage = "{0} is required.")]    
        public string? Password { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        [Compare("Password",ErrorMessage ="{0} and {1} must be same.")] // this compaires ConfromPassword with Password.
        public string? ConfromPassword { get; set; }    

        public string? Address { get; set; }
        [Range(0,120,ErrorMessage ="{0} Must be between {1} and {2}")]
        public int Age { get; set; }

        [DobValidator(2002,ErrorMessage ="Your Age must be less than {0}")]  // here first parameter and ErrorMessage prop of ValidationAttribute base class is optional,
                                                                             // due to we habdles in DobValidator
        public DateTime DateOfBirth { get; set; }


        public DateTime? FromDate { get; set; }

        [DateRangeValidator("FromDate",ErrorMessage ="'FromDate' must be older than or equal to 'ToDate'")]
        public DateTime? ToDate { get; set; }
        #endregion

        public override string ToString()
        {
            return $"Hi {Name}, I hope this is your address: {Address} and your age is {Age}";
        }
    }
}
