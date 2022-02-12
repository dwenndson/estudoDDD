namespace SaibaMais.API.Estoque.Services.Configuration
{
    using Microsoft.Extensions.DependencyInjection;

    public static class CorsPolicyConfig
    {
        public static IServiceCollection AddCorsPolicy(this IServiceCollection services)
        {
            services.AddCors(options =>
                options.AddPolicy("AllowSpecific", p => p.AllowAnyOrigin()
                                                         .AllowAnyMethod()
                                                         .AllowAnyHeader()));

            return services;
        }
    }
}
