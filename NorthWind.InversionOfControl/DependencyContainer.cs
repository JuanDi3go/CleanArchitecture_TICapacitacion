using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NorthWay.Entities.Interfaces;
using NorthWind.Repository.EFCore.DataContext;
using NorthWind.Repository.EFCore.Repositories;
using NorthWind.UseCases.Common.Behaviors;
using NorthWind.UseCases.CreateOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.InversionOfControl
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddNorthWindServices(this IServiceCollection  services, IConfiguration configuration)
        {
            services.AddDbContext<NorthWindContext>(op => op.UseSqlServer(configuration.GetConnectionString("NorthWindDb")));
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddMediatR(config => config.RegisterServicesFromAssemblies(typeof(CreateOrderInteractor).Assembly));
            services.AddValidatorsFromAssembly(typeof(CreateOrderValidator).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}
