using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OnlineShopOnCore.Library.Common.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopOnCore.Library.UserManagement.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [Column(TypeName = "nvarchar(128)")]
        public string? FirstName { get; set; }

        [Column(TypeName = "nvarchar(128)")]
        public string? LastName { get; set; }

        public Address? DefaultAddress { get; set; }

        public Address? DeliveryAddress { get; set; }
    }
}
