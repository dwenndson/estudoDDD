namespace SaibaMais.API.Estoque.Services.Configuration
{
    using Microsoft.Extensions.DependencyInjection;
    using SaibaMais.API.Estoque.Application.Interfaces;
    using SaibaMais.API.Estoque.Application.Notificator;
    using SaibaMais.API.Estoque.Application.Services;
    using SaibaMais.API.Estoque.Data.Repository;
    using SaibaMais.API.Estoque.Domain.Interfaces;

    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            #region [Services]

            services.AddScoped<IInventoryService, InventoryService>();
            services.AddScoped<INotificator, Notificator>();

            #endregion

            #region [Repository]

            services.AddScoped<IInventoryRepository, InventoryRepository>();

            #endregion

            return services;
        }
    }
}
