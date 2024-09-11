using System.ComponentModel.DataAnnotations;

namespace BackendAPI_Assignment.Models
{
    public class AddProductDB
    {
        [Key]
        public int ProductID { get; set; } // Auto-increment primary key

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } // Required name with max length 100

        [MaxLength(500)]
        public string Description { get; set; } // Optional description with max length 500

        [Required]
        public decimal Price { get; set; } // Required price (precision: 18, scale: 2)

        [Required]
        public int Quantity { get; set; } // Required quantity
    }
}
