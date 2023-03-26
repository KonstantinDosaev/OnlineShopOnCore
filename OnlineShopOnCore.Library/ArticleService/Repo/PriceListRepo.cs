using OnlineShopOnCore.Library.ArticleService.Models;
using OnlineShopOnCore.Library.Common.Repos;
using OnlineShopOnCore.Library.Data;

namespace OnlineShopOnCore.Library.ArticleService.Repo
{
    public class PriceListRepo : BaseRepo<PriceList>
    {
        public PriceListRepo(OrdersDbContext context) : base(context)
        {
            Table = Context.PriceLists;
        }
    }
}
