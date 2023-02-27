﻿using DataAccessLayer.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestourantMenuAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                var categoryService = serviceProvider.GetRequiredService<ICategoryService>();
                var deneme = categoryService.GetAll();
                if (categoryService.GetAll().Count == 0)
                {
                    categoryService.Create(new DataAccessLayer.Dtos.CategoryDto() { Name = "Kategori", Status = true });
                    
                }

                var existCategory = categoryService.GetFirst();

                var foodService = serviceProvider.GetRequiredService<IFoodService>();
                if (foodService.GetAll().Count == 0)
                {
                    foodService.Create(new DataAccessLayer.Dtos.FoodDto() { Name = "Yemek", CategoryID = existCategory.CategoryID});
                }

                


            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
