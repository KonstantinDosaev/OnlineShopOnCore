// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Linq;
using System.Security.Claims;
using OnlineShopOnCore.Library.Common.Models;
using OnlineShopOnCore.Library.Data;
using OnlineShopOnCore.Library.UserManagement.Models;

namespace OnlineShopOnCore.IdentityServer
{
    public class SeedData
    {
        public static void EnsureSeedData(string connectionString)
        {
            var services = new ServiceCollection();
            services.AddLogging();
            services.AddDbContext<UsersDbContext>(options =>
               options.UseSqlServer(connectionString));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<UsersDbContext>()
                .AddDefaultTokenProviders();

            using (var serviceProvider = services.BuildServiceProvider())
            {
                using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    var context = scope.ServiceProvider.GetService<UsersDbContext>();
                    context.Database.Migrate();

                    var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                    var konstantin = userMgr.FindByNameAsync("konstantin").Result;
                    if (konstantin == null)
                    {
                        konstantin = new ApplicationUser
                        {
                            UserName = "konstantin",
                            FirstName = "Konstantin",
                            LastName = "Dosaev",
                            Email = "dk@email.com",
                            EmailConfirmed = true,
                            DefaultAddress = new Address()
                            {
                                City = "Vl",
                                Country = "Russia",
                                PostalCode = "00-001",
                                AddressLine1 = "Glinki 21",
                                AddressLine2 = "34"
                            },
                            DeliveryAddress = new Address()
                            {
                                City = "Vl",
                                Country = "Russia",
                                PostalCode = "30-001",
                                AddressLine1 = "Pescareva 45"
                            },
                        };
                        var result = userMgr.CreateAsync(konstantin, "Pass_123").Result;
                        if (!result.Succeeded)
                        {
                            throw new Exception(result.Errors.First().Description);
                        }

                        result = userMgr.AddClaimsAsync(konstantin, new Claim[]{
                            new Claim(JwtClaimTypes.Name, "Konstantin Dosaev"),
                            new Claim(JwtClaimTypes.GivenName, "Konstantin"),
                            new Claim(JwtClaimTypes.FamilyName, "Dosaev"),
                            new Claim(JwtClaimTypes.WebSite, "https://https://github.com/KonstantinDosaev/"),
                        }).Result;
                        if (!result.Succeeded)
                        {
                            throw new Exception(result.Errors.First().Description);
                        }
                        Log.Debug("Konstantin has been created");
                    }
                    else
                    {
                        Log.Debug("Konstantin konstantin exists");

                        if (konstantin.DefaultAddress == null)
                        {
                            konstantin.DefaultAddress = new Address()
                            {
                                City = "Vl",
                                Country = "Russia",
                                PostalCode = "00-001",
                                AddressLine1 = "Glinki 21",
                                AddressLine2 = "34"
                            };
                        }

                        if (konstantin.DeliveryAddress == null)
                        {
                            konstantin.DeliveryAddress = new Address()
                            {
                                City = "Vl",
                                Country = "Russia",
                                PostalCode = "30-001",
                                AddressLine1 = "Pescareva 45"
                            };
                        }

                        var result = userMgr.UpdateAsync(konstantin).Result;
                        if (!result.Succeeded)
                        {
                            throw new Exception(result.Errors.First().Description);
                        }
                        Log.Debug("Konstantin has been updated");
                    }

                }
            }
        }
    }
}
