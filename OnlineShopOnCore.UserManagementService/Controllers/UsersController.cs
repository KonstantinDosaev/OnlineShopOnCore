using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShopOnCore.Library.UserManagement.Models;
using OnlineShopOnCore.Library.UserManagement.Requests;

namespace OnlineShopOnCore.UserManagementService.Controllers
{
    [Route("[controller]")]
    [ApiController]
   [Authorize(AuthenticationSchemes = "Bearer")]
    public class UsersController : ControllerBase
   {
       private readonly UserManager<ApplicationUser> _userManager;

       public UsersController(UserManager<ApplicationUser> userManager)
       {
           _userManager = userManager;
       }

       [HttpPost("add")]
       public Task<IdentityResult> Add(CreateUserRequest request) =>
           _userManager.CreateAsync(request.User, request.Password);
   }
}
