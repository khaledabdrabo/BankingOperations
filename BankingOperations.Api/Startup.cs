using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankingOperations.Banking.Data.Context;
using BankingOperations.Infra.Ioc;
using MediatR;
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


namespace BankingOperations.Api
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
            services.AddMediatR(typeof(Startup));
            services.AddControllers();
            services.AddDbContext<Banking1DbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("BankingDBConnection")));
            DependencyContainer.RegisterServices(services);
            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo { Title = "Banking microservices", Version = "v1" });
            });
            //services.AddSwaggerGen(options => options.SwaggerDoc("V1", new OpenApiInfo {Title = "Banking microservices", Version = "v1" }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseSwagger();
            //app.UseSwaggerUI(c=> { 
            //     c.SwaggerEndpoint("/swagger/v1/swagger.json", "Banking microservices");
            //});
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "Banking microservices V1");

            });
            app.UseRouting();
            app.UseStaticFiles();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
