using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using OnlineShopOnCore.Library.ArticleService.Models;
using OnlineShopOnCore.Library.options;

namespace OnlineShopOnCore.Library.Clients.OrdersService
{
    public class OrderedArticlesClient : RepoClientBase<OrderedArticle>
    {
        public OrderedArticlesClient(HttpClient client, IOptions<ServiceAdressOptions> options) : base(client, options)
        {
        }
        protected override void InitializeClient(IOptions<ServiceAdressOptions> options)
        {
            HttpClient.BaseAddress = new Uri(options.Value.OrderService);
        }

        protected override void SetControllerName()
        {
            ControllerName = "OrderedArticles";
        }
    }
}
