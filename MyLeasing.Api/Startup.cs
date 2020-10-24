namespace MyLeasing.Api
{
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //Repository
            services.AddTransient<IOwnerRepository, OwnerRepository>();

            //Mapper
            services.AddTransient<OwnerMapper>();

            //Application
            services.AddTransient<OwnerApplication>();
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
