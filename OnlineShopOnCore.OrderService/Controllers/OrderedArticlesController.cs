using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShopOnCore.Library.ArticleService.Models;
using OnlineShopOnCore.Library.Common.Interfaces;
using OnlineShopOnCore.Library.Common.Repos;

namespace OnlineShopOnCore.OrderService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = "Bearer")]
    public class OrderedArticlesController : RepoControllerBase<OrderedArticle>
    {
        public OrderedArticlesController(IRepo<OrderedArticle> entitiesRepo) : base(entitiesRepo)
        {
        }

        protected override void UpdateProperties(OrderedArticle entity, OrderedArticle entityToBeUpdate)
        {
            entityToBeUpdate.Name = entity.Name;
            entityToBeUpdate.Description = entity.Description;
            if (entityToBeUpdate.Price != entity.Price)
            {
                entityToBeUpdate.PriceListName = "Manual assigned";
            }
            entityToBeUpdate.Price = entity.Price;
            entityToBeUpdate.Quantity = entity.Quantity;
        }
    }
}
