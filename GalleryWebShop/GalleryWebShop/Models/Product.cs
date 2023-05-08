using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GalleryWebShop.Models
{
    public class Product
    {

        [Key]
        public int Id { get; set; }

        //stock keeping unit
        [Required]
        [Column(TypeName = "nvarchar(10)")]
        public string Sku { get; set; } = String.Empty;

        [Required]
        [StringLength(256, MinimumLength = 2)]
        [Column(TypeName = "nvarchar")]
        public string Title { get; set; } = String.Empty;

        [Column(TypeName = "ntext")]
        public string? Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(9,2)")]
        public decimal InStock { get; set; } = 0;

        [Required]
        [Column(TypeName = "decimal(9,2)")]
        public decimal Price { get; set; } = 0.00M;

        [Column(TypeName = "nvarchar(200)")]
        public string? Image { get; set; }
    }
}
