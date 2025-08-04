using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class MakeSale
    {
        public int MakeSaleId { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "At least one quantity is required.")]
        public List<int> QuantityOfSale { get; set; } = new();

        [Required]
        [Range(0.01, 999999.99, ErrorMessage = "Total price must be greater than 0.")]
        public decimal TotalPriceOfSale { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime SaleDate { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "At least one book is required.")]
        public List<int> BookId { get; set; } = new();

        public int CustomerId { get; set; }

        // Foreign key property for Entity Framework
        public int BooksId { get; set; }

        //Navigation properties
        [ValidateNever]
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public Customer Customer { get; set; }

        [ValidateNever]
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public Book Books { get; set; }
    }
}
