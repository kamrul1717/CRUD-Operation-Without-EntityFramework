using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CustomerMvcApp.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage="Please enter name"),MaxLength(30), MinLength(4)]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Code { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Address { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(50, ErrorMessage="Do not enter more than 50 characters")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name="Phone Number")]
        public string Contact { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public int Age { get; set; }

        [DataType(DataType.Text)]
        public int LoyalityPoint { get; set; }
    }
}