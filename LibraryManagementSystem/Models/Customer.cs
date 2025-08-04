using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Customer name is required.")]
        [MinLength(5, ErrorMessage = "Customer mustn't be less than 5 characters.")]
        [MaxLength(50, ErrorMessage = "Customer mustn't exceed 50 characters. ")]
        [DisplayName("Customer")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        [MinLength(11, ErrorMessage = "Invalid Phone Number.")]
        [MaxLength(13, ErrorMessage = "Invalid Phone Number.")]
        public string PhoneNumber { get; set; }

        [StringLength(200, ErrorMessage = "Address cannot exceed 200 characters.")]
        public string Address { get; set; }


        [DataType(DataType.Date)]
        public DateTime RegistrationDate { get; set; }

        public bool IsActive { get; set; }
    }
}