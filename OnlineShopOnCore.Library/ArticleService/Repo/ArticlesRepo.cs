using Microsoft.EntityFrameworkCore;
using OnlineShopOnCore.Library.ArticleService.Models;
using OnlineShopOnCore.Library.Common.Repos;
using OnlineShopOnCore.Library.Data;

namespace OnlineShopOnCore.Library.ArticleService.Repo
{
    public class ArticlesRepo : BaseRepo<Article>
    {
        public ArticlesRepo(OrdersDbContext context) : base(context)
        {
            Table = Context.Articles;
        }

        public override async Task<IEnumerable<Article>> GetAllAsync() 
            => await Table.Include(nameof(Article.PriceList)).ToListAsync();

        public override async Task<Article> GetOneAsync(Guid id)
            => await Task.Run(() => Table.Include(nameof(Article.PriceList)).FirstOrDefault(entity => entity.Id == id));
    }
}
