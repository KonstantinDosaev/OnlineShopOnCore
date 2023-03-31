using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineShopOnCore.Library.ArticleService.Models;
using OnlineShopOnCore.Library.Common.Interfaces;
using OnlineShopOnCore.Library.Common.Repos;
using OnlineShopOnCore.Library.Data;
using OnlineShopOnCore.Library.OrdersService.Models;

namespace OnlineShopOnCore.Library.OrdersService.Repo
{
    public class OrdersRepo : BaseRepo<Order>
    {
        private readonly IRepo<OrderedArticle> _orderedArticlesRepo;
        public OrdersRepo(IRepo<OrderedArticle> orderedArticlesRepo, OrdersDbContext context) : base(context)
        {
            _orderedArticlesRepo = orderedArticlesRepo;
            Table = Context.Orders;
        }

        public override async Task<IEnumerable<Order>> GetAllAsync()
            => await Table.Include(nameof(Order.Articles)).ToListAsync();

        public override async Task<Order>GetOneAsync(Guid id)
            => await Task.Run(() => Table.Include(nameof(Order.Articles)).FirstOrDefault(entity => entity.Id == id));
    }
}
