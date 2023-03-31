﻿using Microsoft.Extensions.Options;
using OnlineShopOnCore.Library.ArticleService.Models;
using OnlineShopOnCore.Library.options;

namespace OnlineShopOnCore.Library.Clients.ArticlesService
{
    public class ArticlesClient : RepoClientBase<Article>
    {
        public ArticlesClient(HttpClient client, IOptions<ServiceAdressOptions> options) : base(client, options)
        { }

        protected override void InitializeClient(IOptions<ServiceAdressOptions> options)
        {
            HttpClient.BaseAddress = new Uri(options.Value.ArticleService);
        }

        protected override void SetControllerName()
        {
            ControllerName = "Articles";
        }
    }
}