using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using OnlineShopOnCore.Library.ArticleService.Models;
using OnlineShopOnCore.Library.Common.Interfaces;
using OnlineShopOnCore.Library.Common.Repos;

namespace OnlineShopOnCore.ArticlesService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = "Bearer")]
    public class PriceListController : RepoControllerBase<PriceList>
    {
        public PriceListController(IRepo<PriceList> priceListRepo) : base(priceListRepo)
        { }
        
        protected override void UpdateProperties(PriceList entity, PriceList entityToBeUpdate)
        {
            entityToBeUpdate.Price = entity.Price;
            entityToBeUpdate.Name = entity.Name;
            entityToBeUpdate.ValidFrom = entity.ValidFrom;
            entityToBeUpdate.ValidTo = entity.ValidTo;
        }
    }
}
