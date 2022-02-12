namespace SaibaMais.API.Estoque.Services.Configuration
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;

    public static class SuppresModelStateConfig
    {
        public static IServiceCollection AddSuppresModelState(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;

            });

            return services;
        }
    }
}
