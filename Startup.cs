using API_Project_BenjaminGamrekeli.Entities;
using API_Project_BenjaminGamrekeli.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace API_Project_BenjaminGamrekeli
{
    public class Startup
    {
        private IConfiguration configuration;
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IDierData, DierData>();
            services.AddScoped<IKlasseData, KlasseData>();
            services.AddScoped<IHabitatData, HabitatData>();
            services.AddScoped<IDierHabitatData, DierHabitatData>();
            services.AddControllers();
            services.AddSwaggerGen();
            var connection = configuration.GetConnectionString("DierenDatabase");
            services.AddDbContext<DierContext>();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IConfiguration configuration)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("./swagger/v1/swagger.json", "API project Benjamin Gamrekeli");
                    c.RoutePrefix = string.Empty;
                });
            }
            else
            {
                app.UseExceptionHandler(new ExceptionHandlerOptions
                {
                    ExceptionHandler = context => context.Response.WriteAsync("OOPS")
                });
            }

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllerRoute("defautl", "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllers();
            });
        }
    }
}
