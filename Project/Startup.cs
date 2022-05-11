using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Project.Configurations;
using Project.Database;
using Project.Database.Repositories;
using Project.Database.Repositories.Interfaces;
using Project.Mapper;
using Project.Services;
using Project.Services.Interfaces;

namespace Project
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

            //services.AddDbContext<BaseApiContext>(opt => opt.UseInMemoryDatabase("BaseApi"));
            services.AddDbContext<BaseApiContext>(options => options.UseNpgsql(DBConfigurations.GetConnectionString(), options =>
            {
                options.MigrationsHistoryTable("__EFMigrationsHistory", DBConfigurations.Schema);
            }));

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerService, CustomerService>();

            services.AddSingleton(MapperConfigurations.GetConfiguredMappingConfig());

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BaseApi", Version = "v1" });
            });

            CreateDatabase(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BaseApi v1")); // Access in <app-url>/swagger/index.html
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });            
        }

        private void CreateDatabase(IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            using var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var scopedServices = serviceScope.ServiceProvider;

            var dbContext = scopedServices.GetRequiredService<BaseApiContext>();

            dbContext.Database.Migrate();
        }
    }
}
