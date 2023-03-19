using OnlineShopOnCore.Library.IdentitySever;
using OnlineShopOnCore.Library.options;

namespace OnlineShopOnCore.Library.Clients.IdentityServer
{
    public interface IIdentityServerClient
    {
        Task<Token> GetApiToken(IdentityServerApiOptions options);
    }
}
