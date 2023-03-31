using OnlineShopOnCore.Library.Common.Repos;
using OnlineShopOnCore.Library.Data;
using OnlineShopOnCore.Library.ArticleService.Models;

namespace OnlineShopOnCore.Library.OrdersService.Repo
{
    public class OrderedArticlesRepo : BaseRepo<OrderedArticle>
    {
        public OrderedArticlesRepo(OrdersDbContext context) : base(context)
        {
            Table = Context.OrderedArticles;
        }
    }
}
