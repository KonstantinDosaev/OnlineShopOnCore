using Microsoft.AspNetCore.Identity;
using OnlineShopOnCore.Library.Common.Models;

namespace OnlineShopOnCore.Library.UserManagement.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public Address? DefaultAddress { get; set; }

        public Address? DeliveryAddress { get; set; }
    }
}
