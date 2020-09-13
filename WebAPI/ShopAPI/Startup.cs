using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShopAPI.Data;

namespace ShopAPI
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
            services.AddControllers();
            services.AddDbContext<DataContextShopDTO>(opts => opts.UseInMemoryDatabase("Database"));
            services.AddScoped<DataContextShopDTO, DataContextShopDTO>();
            services.AddSwaggerGen(options => {
                options.SwaggerDoc("v1",
                    new Microsoft.OpenApi.Models.OpenApiInfo { 
                    Title = "Swagger API Documentation",
                    Description = "This is the documentation of the API using swagger dependency " +
                    "wich generates an API for consumeble REST Web API",
                    Version = "V1"
                    });;
            });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("swagger/v1/swagger.json", "Swagger API Documentation");
            });
        }
    }
}
