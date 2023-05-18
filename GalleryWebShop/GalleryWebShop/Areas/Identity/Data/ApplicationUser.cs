using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GalleryWebShop.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ApplicationUser class

//ExpandUserTable
public class ApplicationUser : IdentityUser
{
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

