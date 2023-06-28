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
        [Display(Name = "Date Created")]
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

        //Application User class (for registeed customer)
        [ForeignKey(nameof(UserId))]
        public ApplicationUser? User { get; set; }


        [Column(TypeName = "nvarchar(450)")]
        public string? UserId { get; set; }



        //Dodatak za osobne informacie korsinika (dodano u istu klasu radi jednostavnosti)
        //-evidencija dali je prijavljen
        [Required(ErrorMessage = "First name is required")]
        [StringLength(50, ErrorMessage = "Max. 50 characters")]
        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(50, ErrorMessage = "Max. 50 characters")]
        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [StringLength(50, ErrorMessage = "Max. 100 characters")]
        [EmailAddress]
        [Column(TypeName = "nvarchar(100)")]
        public string EmailAddress { get; set; }


        [Required(ErrorMessage = "Phone number is required")]
        [Column(TypeName = "nvarchar(10)")]
        public string PhoneNumber { get; set; }



        [Required(ErrorMessage = "Country is required")]
        [Column(TypeName = "nvarchar(150)")]
        public string Country { get; set; }

        [Required(ErrorMessage = "City is required")]
        [Column(TypeName = "nvarchar(150)")]
        public string City { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [Column(TypeName = "nvarchar(150)")]
        public string Address { get; set; }

        [Required(ErrorMessage = "PostalCode is required")]
        [Column(TypeName = "nvarchar(10)")]
        public string PostalCode { get; set; }

        [Column(TypeName = "nvarchar(3000)")]
        public string? Message { get; set; }

    }

}
