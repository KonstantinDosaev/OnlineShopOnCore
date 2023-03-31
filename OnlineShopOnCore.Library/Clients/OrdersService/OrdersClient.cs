using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using OnlineShopOnCore.Library.options;
using OnlineShopOnCore.Library.OrdersService.Models;

namespace OnlineShopOnCore.Library.Clients.OrdersService
{
    public class OrdersClient : RepoClientBase<Order>
    {
        public OrdersClient(HttpClient client, IOptions<ServiceAdressOptions> options) : base(client, options)
        { }

        protected override void InitializeClient(IOptions<ServiceAdressOptions> options)
        {
            HttpClient.BaseAddress = new Uri(options.Value.OrderService);
        }

        protected override void SetControllerName()
        {
            ControllerName = "Orders";
        }
    }
}
