using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementSystem.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "You have to provide a valid Title")]
        [MinLength(5, ErrorMessage = "Title mustn't be less than 5 characters.")]
        [MaxLength(50, ErrorMessage = "Title mustn't exceed 50 characters. ")]
        [DisplayName("Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "You have to provide a valid Author")]
        [MinLength(8, ErrorMessage = "Author mustn't be less than 8 characters.")]
        [MaxLength(50, ErrorMessage = "Author mustn't exceed 50 characters. ")]
        [DisplayName("Author")]
        public string Author { get; set; }

        [Required(ErrorMessage = "You have to provide a valid Category")]
        [MinLength(4, ErrorMessage = "Category mustn't be less than 4 characters.")]
        [MaxLength(50, ErrorMessage = "Category mustn't exceed 50 characters. ")]
        [DisplayName("Category")]
        public string Category { get; set; }
        [Required]
        [DisplayName("Published Year")]
        [Range(1000, 9999, ErrorMessage = "Please enter a valid year between 1000 and 9999.")]
        public int PublishedYear { get; set; }

        [Required]
        [DisplayName("Quantity")]
        [Range(1, 9999, ErrorMessage = "Please enter a valid Quantity between 1 and 9999.")]
        public int Quantity { get; set; }
        [Required]
        [DisplayName("Price")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [StringLength(1000)]
        public string? Description { get; set; }


    }
}
