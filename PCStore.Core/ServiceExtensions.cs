using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCStore.Core.Services;
using PCStore.Core.Interfaces;
using PCStore.Core.AutoMapper.Categories;
using PCStore.Core.AutoMapper.Goods;

namespace PCStore.Core
{
    public static class ServiceExtensions
    {
        public static void AddCoreServices(this IServiceCollection services)
        {
            services.AddTransient<UserService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IGoodService, GoodService>();
        }
        public static void AddMapping(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperCategoryProfile));
            services.AddAutoMapper(typeof(AutoMapperGoodsProfile));
        }
    }
}
