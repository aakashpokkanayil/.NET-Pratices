using System.ComponentModel.DataAnnotations;

namespace MyFirstApp.CustomAttribute
{
    public class DateRangeValidatorAttribute:ValidationAttribute
    {
        private readonly string otherPropertyName;
        private  DateTime fromDate;
        private DateTime toDate;

        public DateRangeValidatorAttribute(string otherPropertyName)
        {
            this.otherPropertyName = otherPropertyName;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                toDate = Convert.ToDateTime(value);
            }

            var otherProperty = validationContext.ObjectType.GetProperty(otherPropertyName); 
            //here we use reflection, ObjectType will contain details of the class where the attribute is used.
            // GetProperty will return the propertyInfo object contains details of the class property mentioned in otherPropertyName

            if (otherProperty!=null)
            {
                fromDate = Convert.ToDateTime(otherProperty.GetValue(validationContext.ObjectInstance));
                // validationContext.ObjectInstance contains all values of current class at this time.
                // otherProperty.GetValue returns value of otherProperty only from the collection of all values of class.
            }

            if (fromDate > toDate) return new ValidationResult(ErrorMessage);

            return null;
        }

    }
}
