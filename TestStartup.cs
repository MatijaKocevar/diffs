using Diffing.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Diffing
{
    public class TestStartup
    {
        //access to configuration API
        public TestStartup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //configure DBContext to use withing application, with options(sql server and connection string) 
            services.AddDbContext<DiffingContext>(opt => opt.UseSqlServer(
               Configuration.GetConnectionString("DiffsConnection")
           ));

            services.AddControllers().AddApplicationPart(typeof(Diffing.Startup).Assembly);

            services.AddAutoMapper(typeof(Startup));

            services.AddScoped<IDiffsRepo, SqlDiffsRepo>();

            //services.AddScoped<IDiffsRepo, SqlDiffsRepo>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //order is important
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
