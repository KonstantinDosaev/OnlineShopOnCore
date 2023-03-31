using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShopOnCore.Library.Common.Interfaces;
using OnlineShopOnCore.Library.Common.Repos;
using OnlineShopOnCore.Library.OrdersService.Models;

namespace OnlineShopOnCore.OrderService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = "Bearer")]
    public class OrdersController : RepoControllerBase<Order>
    {
        public OrdersController(IRepo<Order> entitiesRepo) : base(entitiesRepo)
        {
        }

        protected override void UpdateProperties(Order entity, Order entityToBeUpdate)
        {
            entityToBeUpdate.AddressId = entity.AddressId;
            entityToBeUpdate.Articles = entity.Articles;
            entityToBeUpdate.Modified = DateTime.UtcNow;
            entityToBeUpdate.UserId = entity.UserId;
        }
    }
}
