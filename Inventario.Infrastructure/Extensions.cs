using Inventario.Application;
using Inventario.Domain.Repositories;
using Inventario.Infrastructure.EF;
using Inventario.Infrastructure.EF.Contexts;
using Inventario.Infrastructure.EF.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Inventario.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddApplication();
            services.AddMediatR(Assembly.GetExecutingAssembly());

            var connectionString =
                configuration.GetConnectionString("InventarioDbConnectionString");

            services.AddDbContext<ReadDbContext>(context =>
                context.UseSqlServer(connectionString));
            services.AddDbContext<WriteDbContext>(context =>
                context.UseSqlServer(connectionString));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IArticuloRepository, ArticuloRepository>();
            services.AddScoped<ITransaccionRepository, TransaccionRepository>();

            return services;
        }

    }
}
