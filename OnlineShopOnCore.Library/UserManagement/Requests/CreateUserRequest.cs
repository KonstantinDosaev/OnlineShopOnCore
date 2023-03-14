using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShopOnCore.Library.UserManagement.Models;

namespace OnlineShopOnCore.Library.UserManagement.Requests
{
    public class CreateUserRequest
    {
        public ApplicationUser User { get; set; } = null!;
        public string? Password { get; set; }
    }
}
