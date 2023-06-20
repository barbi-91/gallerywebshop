using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace GalleryWebShop.Areas.Identity.Models
{
    public class EditUser
    {

        [Column(TypeName = "nvarchar(256)")]
        public string? UserId { get; set; }

        //[Required]
        //[Column(TypeName = "nvarchar(256)")]
        //public string UserType { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(256)")]
        public string UserName { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(256)")]
        public string FirstName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(256)")]
        public string LastName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(256)")]
        public string Address { get; set; }

    }
}
