using System;
using System.ComponentModel.DataAnnotations;

namespace LibApp.Domain.Models
{
    public class Min18YearsIfMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.MembershipTypeId == MembershipType.Free)
            {
                return ValidationResult.Success;
            }

            if (customer.Birthdate == null)
            {
                return new ValidationResult("Birthdate is required");
            }

            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;

            return age >= 18 ? ValidationResult.Success : new ValidationResult("Customer should be at least 18 to subscribe");
        }
    }
}
