using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AsianDogFood.Core.AppService;
using AsianDogFood.Core.AppService.Service;
using AsianDogFood.Core.DataService;
using AsianDogFood.Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SQLite;

namespace DogFoodRestApi
{
    public class Startup : DbContextOptionsBuilder
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(Options => Options.AddPolicy("AllowEverything",
                Builder => Builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

            services.AddDbContext<PetAppDBContext>(
                optionsAction: opt =>
                {
                    opt.UseSqlite("Data Source=petApp.db");
                }
            );
            services.AddScoped<IPetRepository, PetRepository>();
            services.AddScoped<IPetService, PetService>();
            services.AddControllers();
            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("1", new OpenApiInfo
                {
                    Title = "Swagger PetFood",
                    Description = "Swagger for Petfood",
                    Version = "V1"

                }
                );
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetService<PetAppDBContext>();
                    ctx.Database.EnsureDeleted();
                    ctx.Database.EnsureCreated();
                }
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(options =>
                options.SwaggerEndpoint("/swagger/V1/swagger.json", "Swagger PetFood")
                );
        }
    }
}
