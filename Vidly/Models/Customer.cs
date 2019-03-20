using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength:255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        [Display(Name = "Membership Type")]

        public MembershipType MembershipType { get; set; } // navigation property, it allows us to navigate from one type to another 

        [Required(ErrorMessage = "Membership Type is required")]
        public byte MembershipTypeId { get; set; }

        [Display(Name = "Date of Birthday")]
        [Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }
    }
}