using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopOnCore.Library.options
{
    public class IdentityServerApiOptions
    {
        public const string SectionName = nameof(ServiceAdressOptions);
        public string? ClientId { get; set; } = "test.client";
        public string? ClientSecret { get; set; } = "511536EF-F270-4058-80CA-1C89C192F69A";
        public string? Scope { get; set; } = "OnlineShopOnCore.Api";
        public string? GrantType { get; set; } = "client_credentials";
    }
}
