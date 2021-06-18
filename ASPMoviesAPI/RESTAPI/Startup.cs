using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RESTAPI.Data;
using System.Linq.Expressions;
using RESTAPI.Services.Interfaces;
using RESTAPI.Services.Implementations;
using RESTAPI.Models;
using RESTAPI.Repositories.Interfaces;
using RESTAPI.Repositories.Implementations;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
namespace RESTAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        { 
            services.AddControllers(); 
            services.AddDbContext<CodeFirstContext>();
            services.AddAutoMapper(typeof(Startup));
            var config = new MapperConfiguration(cfg =>
              cfg.CreateMap<Movie, MovieDTO>());
            var mapper = new Mapper(config);
            services.AddSingleton<IMapper>(mapper);
            services.AddScoped<IRentMovieService, RentMovieService>();
            services.AddScoped<IReturnMovieService,ReturnMovieService>();
            services.AddScoped<MoviesRepository>();
            services.AddScoped<CopiesRepository>();
            services.AddScoped<ClientsRepository>();
            services.AddScoped<RentalsRepository>();
            services.AddScoped<StarringRepository>();
            services.AddScoped<ActorsRepository>();
            services.AddScoped<EmployeesRepository>();
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
