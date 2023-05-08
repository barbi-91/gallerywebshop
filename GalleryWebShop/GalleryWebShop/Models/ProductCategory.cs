using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GalleryWebShop.Models
{
    public class ProductCategory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        //optional- object to use
        public Category? Category { get; set; }

        [Required]  
        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        //optional- object to use
        public Product? Product { get; set; }
    }
}
