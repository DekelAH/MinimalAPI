using Microsoft.EntityFrameworkCore;
using MinimalAPI.Core.Domain.RepositoryContracts;
using MinimalAPI.Core.ServiceContracts;
using MinimalAPI.Core.Services;
using MinimalAPI.Infrastructure.DatabaseContext;
using MinimalAPI.Infrastructure.Repositories;

namespace MinimalAPI.StartupExtensions
{
    public static class ConfigureServicesExtensions
    {
        #region Methods

        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IProductGetterRepository, ProductGetterRepository>();
            services.AddScoped<IProductAdderRepository, ProductAdderRepository>();
            services.AddScoped<IProductUpdaterRepository, ProductUpdaterRepository>();
            services.AddScoped<IProductDeleterRepository, ProductDeleterRepository>();

            services.AddScoped<IProductGetterService, ProductGetterService>();
            services.AddScoped<IProductAdderService, ProductAdderService>();
            services.AddScoped<IProductUpdaterService, ProductUpdaterService>();
            services.AddScoped<IProductDeleterService, ProductDeleterService>();

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Default"));
            });

            return services;
        }

        #endregion
    }
}
