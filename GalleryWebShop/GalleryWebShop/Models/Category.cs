using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GalleryWebShop.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(256, MinimumLength = 2)]
        [Column(TypeName = "nvarchar")]
        [DisplayName("Technique")]
        public string Title { get; set; }

        [Column(TypeName = "ntext")]
        [DisplayName("Technique description")]
        public string? Description { get; set; }
    }
}
