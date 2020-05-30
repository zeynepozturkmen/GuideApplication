using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GuideApplication.Core;
using GuideApplication.Core.Services;
using GuideApplication.Data;
using GuideApplication.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace GuideApplication.WebApi
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

            services.AddDbContext<GuideApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default"), x => x.MigrationsAssembly("GuideApplication.Data")));

            //Baðýmlýlýk enjeksiyonunu eklememiz gerekiyor, böylece uygulamamýz depo arayüzlerini (repository) kullandýðýmýzda bu depo uygulamalarýný enjekte etmesi gerektiðini biliyor.Ve þimdi yönteme bir Startup.cs sonraki kod satýrýný ekleyerek API birimimizin Ýþ Birimimiz (UnitOfWork) için baðýmlýlýk enjeksiyonu eklememiz gerekiyor

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IPersonInformationService, PersonInformationService>();

            services.AddAutoMapper(typeof(Startup));

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "My Guide Application", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Guide Application V1");
            });
        }
    }
}
