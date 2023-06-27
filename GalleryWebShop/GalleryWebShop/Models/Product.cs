using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GalleryWebShop.Models
{
    public class Product
    {

        [Key]
        public int Id { get; set; }

        //stock keeping unit
        [Required]
        [StringLength(10, MinimumLength = 1)]
        [Column(TypeName = "nvarchar(10)")]
        [DisplayName("Stock keeping unit")]
        public string Sku { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 1)]
        [Column(TypeName = "nvarchar(10)")]
        public string Size { get; set; }


        [Required]
        [StringLength(256, MinimumLength = 2)]
        [Column(TypeName = "nvarchar")]
        [DisplayName("Painting title")]
        public string Title { get; set; }

        [Column(TypeName = "ntext")]
        [DisplayName("Painting description")]
        public string? Description { get; set; }

        [Required]
        [Display(Name = "In Stock")]
        [Column(TypeName = "decimal(9,2)")]
        public decimal InStock { get; set; } = 0;

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        [Column(TypeName = "decimal(9,2)")]
        public decimal Price { get; set; } = 0.00M;

        [Column(TypeName = "nvarchar(200)")]
        public string? Image { get; set; }
    }
}
