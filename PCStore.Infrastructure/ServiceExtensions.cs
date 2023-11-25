using Microsoft.Extensions.DependencyInjection;
using PCStore.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PCStore.Infrastructure
{
    public static class ServiceExtensions
    {
        public static void AddDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(opt =>

            {
                opt.UseSqlServer(connectionString);
                opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

        }
    }
}
