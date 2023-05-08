using GalleryWebShop.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GalleryWebShop.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime DateCreated { get; set; } = DateTime.Now;

        [Required]
        [Column(TypeName = "decimal(9,2)")]
        public decimal Subtotal { get; set; }

        [Required]
        [Column(TypeName = "decimal(9,2)")]
        public decimal Tax { get; set; }

        [Required]
        [Column(TypeName = "decimal(9,2)")]
        public decimal Total { get; set; }

        //Application User class (for registred customer)
        [ForeignKey(nameof(UserId))]
        public ApplicationUser? User { get; set; }


        [Column(TypeName = "nvarchar(450)")]
        public string? UserId { get; set; }
    }
}
