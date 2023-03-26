using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShopOnCore.Library.ArticleService.Models;
using OnlineShopOnCore.Library.Common.Interfaces;
using OnlineShopOnCore.Library.Common.Repos;

namespace OnlineShopOnCore.ArticlesService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = "Bearer")]
    public class ArticlesController : RepoControllerBase<Article>
    {
        public ArticlesController(IRepo<Article> articlesRepo) : base(articlesRepo)
        {
        }

        protected override void UpdateProperties(Article source, Article destination)
        {
            destination.Name = source.Name;
            destination.Description = source.Description;

        }
    }
}
