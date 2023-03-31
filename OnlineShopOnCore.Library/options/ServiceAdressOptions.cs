using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopOnCore.Library.options
{
    public class ServiceAdressOptions
    {
        public const string SectionName = nameof(ServiceAdressOptions);
        public string? IdentityServer { get; set; }
        public string? UserManagementService { get; set; }
        public string OrderService { get; set; }
        public string ArticleService { get; set; }
    }
}
