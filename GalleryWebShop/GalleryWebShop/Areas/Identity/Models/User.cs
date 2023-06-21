using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GalleryWebShop.Areas.Identity.Models
{
    
    public class User
    {
        
        [Key]
        [Column(TypeName = "nvarchar(256)")]
        public string? UserId { get; set; }

        [Display(Name = "Type")]
        [Required]
        [Column(TypeName = "nvarchar(256)")]
        public string UserType { get; set; }

        [Display(Name = "User Name")]
        [Required]
        [Column(TypeName = "nvarchar(256)")]
        public string UserName { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [Required]
        [PasswordPropertyText]
        public string Password { get; set; }

        [Display(Name = "Password Confirmation")]
        [Required]
        [PasswordPropertyText]
        [Compare("Password")]
        public string PasswordConfirmation { get; set; }

        [Display(Name = "Email Confirmed")]
        public bool EmailConfirmed { get; set; }

        [Display(Name = "First Name")]
        [Required]
        [Column(TypeName = "nvarchar(256)")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        [Column(TypeName = "nvarchar(256)")]
        public string LastName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(256)")]
        public string Address { get; set; }


       
    }
}
