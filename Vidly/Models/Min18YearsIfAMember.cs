using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.Models
{
    public class Min18YearsIfAMember:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Customer costumer = (Customer)validationContext.ObjectInstance;

            if (costumer.MembershipTypeId == MembershipType.Unknown || costumer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;

            if (costumer.Birthdate == null)
                return new ValidationResult("Birthdate is requered");

            var age = DateTime.Today.Year - costumer.Birthdate.Value.Year;

            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("Costumer should be at least 18 years old to go on membership");
            
        }
    }
}