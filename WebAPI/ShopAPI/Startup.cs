using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ShopAPI.Data;
using System.Linq;

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
            /*adding a G-ZIP compreension of the JSON file to be streamed 
             * and provided as binary for the server*/
            services.AddResponseCompression(opts =>
            {
                opts.Providers.Add<GzipCompressionProvider>();
                opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "application/json" });
            });
            /*adding a response cache wich allows user client-side to cache the API
             * this cacheable enables cache for all the application interface*/
            services.AddCors();
            services.AddResponseCaching();

            services.AddControllers();

            //encoder of secret string token as a stream of bytes
            var key = System.Text.Encoding.ASCII.GetBytes(Settings.Secret);
            services.AddAuthentication(a =>
            {
                a.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                a.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(jwt =>
            {
                jwt.RequireHttpsMetadata = false;
                jwt.SaveToken = true;
                jwt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };

            });

            //addition of the DbContext to SqlServer
            services.AddDbContext<DataContextShopDTO>(opts => opts.UseSqlServer(Configuration.GetConnectionString("connectionString")));
            
            /*add a single runtime instance of datacontext per excecution {NO MORE REQUIRED}
            services.AddScoped<DataContextShopDTO, DataContextShopDTO>(); */

            //addition of the swashbuckle swagger for API documentation
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Shop API Documentation",
                        Description = "This is the documentation of the API using swagger dependency " +
                    "wich generates an API for consumeble REST Web API",
                        Version = "V1"
                    }); ;
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
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("swagger/v1/swagger.json", "Shop API V1 Documentation");
            });

            app.UseCors(Cors => Cors
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
