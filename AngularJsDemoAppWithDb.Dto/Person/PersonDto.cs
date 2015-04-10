using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace AngularJsDemoAppWithDb.Dto.Person
{
    public class PersonDto : IValidatableObject
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (String.IsNullOrEmpty(Name))
            {
                yield return new ValidationResult("Name is not set.");
            }

            int age;
            if (!Int32.TryParse(Age.ToString(CultureInfo.InvariantCulture), out age))
            {
                yield return new ValidationResult("Age is not valid.");
            }
        }
    }
}
