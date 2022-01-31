using BackgroundJobs.Jobs;
using Business.Abstract;
using Business.Concrete;
using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Hangfire;
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ExchangeRateWebAPI", Version = "v1" });
            });

            //Database
            services.AddDbContext<ExchangeRateDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //Dependecies
            services.AddScoped<IUnitOfWork, EfUnitOfWork>();
            services.AddScoped<ICurrencyTypeRepository, CurrencyTypeRepository>();
            services.AddScoped<ICurrencyRepository, CurrencyRepository>();
            services.AddScoped<ICurrencyTypeService, CurrencyTypeService>();
            services.AddScoped<ICurrencyService, CurrencyService>();
            services.AddScoped<IExchangeRateService, ExchangeRateService>();

            //Hangfire
            services.AddHangfire(config => config.UseSqlServerStorage(Configuration["ConnectionStrings:HangfireConnection"]));
            services.AddHangfireServer();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ExchangeRateWebAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            //Hangfire => endpoint host:port/hangfire
            app.UseHangfireDashboard();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            //Hamgfire recurring job 
            RecurringJobs.CreateOrUpdateCurrency();
            RecurringJobs.ChangeSatus();
        }
    }
}
