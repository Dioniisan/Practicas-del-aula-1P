using AnimalSpawn.Domain.Interfaces;
using AnimalSpawn.Infraestructure;
using AnimalSpawn.Infraestructure.Data;
//using AnimalSpawn.Infraestructure.Data;
using AnimalSpawn.Infraestructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AnimalSpawn.Api
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
            services.AddDbContext<AnimalSpawnDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("AnimalConnection")));

            services.AddControllers();

            services.AddTransient<IAnimalRepository, AnimalRepository>();

            //services.AddTransient<IAnimalRepository, OtherDBRepository>();
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
        }
    }
}
