namespace SaibaMais.API.Estoque.Services.Configuration
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;

    public static class MvcConfig
    {
        public static IServiceCollection AddMVC(this IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            return services;
        }
    }
}
