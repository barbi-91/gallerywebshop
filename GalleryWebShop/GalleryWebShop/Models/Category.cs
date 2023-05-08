using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GalleryWebShop.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(256, MinimumLength = 2)]
        [Column(TypeName = "nvarchar")]
        public string Title { get; set; } = String.Empty;

        [Column(TypeName = "ntext")]
        public string? Description { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string? Image { get; set; }
    }
}
