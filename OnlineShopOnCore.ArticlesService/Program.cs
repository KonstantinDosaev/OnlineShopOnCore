using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using OnlineShopOnCore.Library.ArticleService.Models;
using OnlineShopOnCore.Library.ArticleService.Repo;
using OnlineShopOnCore.Library.Common.Interfaces;
using OnlineShopOnCore.Library.Constants;
using OnlineShopOnCore.Library.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ArticlesService", Version = "v1" });
});

builder.Services.AddDbContext<OrdersDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString(ConnectionNames.OrdersConnection)));

builder.Services.AddTransient<IRepo<Article>, ArticlesRepo>();
builder.Services.AddTransient<IRepo<PriceList>, PriceListRepo>();

//builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
//    .AddEntityFrameworkStores<UsersDbContext>()
//    .AddDefaultTokenProviders();

//builder.Services.AddAuthentication(
//        IdentityServerAuthenticationDefaults.AuthenticationScheme)
//    .AddIdentityServerAuthentication(options =>
//    {
//        //options.ApiName = "https://localhost:5001/resources";
//        options.Authority = "https://localhost:5001";
//        options.RequireHttpsMetadata = false;
//    });

//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy("ApiScope", policy =>
//    {
//        policy.RequireAuthenticatedUser();
//        policy.RequireClaim("scope", IdConstants.ApiScope);
//    });
//});

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ArticlesService v1"));
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers()/*.RequireAuthorization("ApiScope")*/;

app.Run();
