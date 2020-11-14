namespace MyLeasing.Api
{
    using AutoMapper;
    using FluentValidation.AspNetCore;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using MyLeasing.Api.Core.Application;
    using MyLeasing.Api.Infrastructure.Data;
    using MyLeasing.Api.Infrastructure.Data.Entities;
    using MyLeasing.Api.Infrastructure.Repository;
    using MyLeasing.Api.Infrastructure.Repository.Helper;
    using MyLeasing.Api.Infrastructure.Repository.Interface;
    using MyLeasing.Api.Infrastructure.Filter;
    using System;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(cfg => {
                cfg.UseSqlServer(Configuration.GetConnectionString("DefaultConection"));
            });

            services.AddIdentity<UserDto, IdentityRole>(cfg => {
                cfg.User.RequireUniqueEmail = true;
                cfg.Password.RequireDigit = false;
                cfg.Password.RequiredUniqueChars = 0;
                cfg.Password.RequireLowercase = false;
                cfg.Password.RequireNonAlphanumeric = false;
                cfg.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<DataContext>();

            services.AddTransient<SeedDatabase>();
            services.AddMvc(options => {
                options.Filters.Add<ValidationFilter>();
            }).AddFluentValidation(options => {
                options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //Repository
            services.AddScoped<IPropertyTypeRepository, PropertyTypeRepository>();
            services.AddScoped<IPropertyRepository, PropertyRepository>();
            services.AddScoped<IOwnerRepository, OwnerRepository>();
            services.AddScoped<IUserHelper, UserHelper>();
            services.AddScoped<IImageHelper, ImageHelper>();
            services.AddScoped<IPropertyImageRepository, PropertyImageRepository>();
            services.AddScoped<IContractRepository, ContractRepository>();
            services.AddScoped<ILesseeRepository, LesseeRepository>();

            //Application
            services.AddScoped<PropertyTypeApplication>();
            services.AddScoped<OwnerApplication>();
            services.AddScoped<PropertyApplication>();
            services.AddScoped<LesseeApplication>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment()) { app.UseDeveloperExceptionPage(); }
            else { app.UseHsts(); }
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
