using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SaibaMais.API.Estoque.Domain;
using SaibaMais.API.Estoque.Services.Configuration;
using AutoMapper;
using System.Globalization;

namespace SaibaMais.API.Estoque.Services
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region [MVC]

            services.AddMVC();

            #endregion

            #region [AutoMapper]

            services.AddAutoMapper(typeof(Startup));

            #endregion

            #region [AppSettings]

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            #endregion

            #region [Dependency Injection]

            services.ResolveDependencies();

            #endregion

            #region [Swagger]

            services.AddSwaggerConfig();

            #endregion

            #region [Suppres ModelState]

            services.AddSuppresModelState();

            #endregion

            #region [Cors Policy]

            services.AddCorsPolicy();

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("./swagger/v1/swagger.json", "Estoque API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();
            app.UseMvc();

            var supportedCulture = new[] { new CultureInfo("pt-BR") };
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture(culture: "pt-BR", uiCulture: "pt-BR"),
                SupportedCultures = supportedCulture,
                SupportedUICultures = supportedCulture
            });
        }
    }
}
