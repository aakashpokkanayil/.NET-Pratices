using System.ComponentModel.DataAnnotations;

namespace MyFirstApp.CustomAttribute
{
    public class DobValidator:ValidationAttribute
    {
        private readonly int dateYear=2000;// default value is set here it self.
        private readonly string defaultYear="year must less than {0}";

        public DobValidator() { } // dateYear is optional thats why we need parameterless ctor.

        public DobValidator(int dateYear)
        {
            this.dateYear = dateYear;

        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var year=Convert.ToDateTime(value).Year;
                if (year >= dateYear)
                {
                    return new ValidationResult(String.Format(ErrorMessage ?? defaultYear,dateYear));// ?? means if ErrorMessage is null defaultYear will be print
                }
                else
                {
                    return  ValidationResult.Success; // static prop
                }
            }
            return null;
        }
    }
}
