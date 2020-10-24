namespace MyLeasing.Api
{
    using AutoMapper;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using MyLeasing.Api.Core.Application;
    using MyLeasing.Api.Infrastructure.Data;
    using MyLeasing.Api.Infrastructure.Mapper;
    using MyLeasing.Api.Infrastructure.Repository;
    using MyLeasing.Api.Infrastructure.Repository.Interface;
    using System;

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
            services.AddDbContext<DataContext>(cfg => {
                cfg.UseSqlServer(Configuration.GetConnectionString("DefaultConection"));
            });

            services.AddTransient<SeedDatabase>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //Repository
            services.AddTransient<IOwnerRepository, OwnerRepository>();
            services.AddTransient<IPropertyTypeRepository, PropertyTypeRepository>();

            //Application
            services.AddTransient<OwnerApplication>();
            services.AddTransient<PropertyTypeApplication>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment()) { app.UseDeveloperExceptionPage(); }
            else { app.UseHsts(); }
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
