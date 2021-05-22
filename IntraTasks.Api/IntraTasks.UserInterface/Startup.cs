using IntraTasks.BusinessLogic.Repository;
using IntraTasks.DataAccess.Context;
using IntraTasks.DataAccess.Domain;
using IntraTasks.UserInterface.Extensions;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;

namespace IntraTasks.UserInterface
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
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<AppDbContext>(config =>
            {
                config.UseSqlServer(
                    Configuration.GetSection("ConnectionStrings").GetSection("Default").Value
                );
            });
            services.AddOData();
            services.AddControllers(options => options.EnableEndpointRouting = false).AddNewtonsoftJson();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.ConfigureExceptionHandler();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseMvc(options =>
            {
                options.EnableDependencyInjection();
                options.Expand().Select().Count().OrderBy().Filter().SkipToken();
                options.MapODataServiceRoute("odata", "odata", GetODataBuilder().GetEdmModel());
            });
        }

        ODataModelBuilder GetODataBuilder()
        {
            ODataModelBuilder builder = new ODataConventionModelBuilder();
            
            builder.EntitySet<Membro>("Membro");
            builder.EntitySet<Tarefa>("Tarefa");

            return builder;
        }

    }
}
