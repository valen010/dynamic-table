using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using Entities.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using Newtonsoft.Json;

namespace Application.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddControllers();
            services.AddScoped<IRepository<Record>, Repository<Record>>();
            services.AddScoped<IRepository<Value>, Repository<Value>>();
            services.AddScoped<IRepository<Entities.Models.TableView>, Repository<Entities.Models.TableView>>();
            services.AddScoped<IRepository<Column>, Repository<Column>>();
            services.AddScoped<IColumns, r_column>();
            services.AddScoped<IValues, r_values>();
            services.AddScoped<IRepository<SystemLog>, Repository<SystemLog>>();
            services.AddScoped<IsystemLogs, r_systemLogs>();
            services.AddScoped<ITableview, DataAccessLayer.Concrete.TableView>();
            services.AddScoped<IRecord, r_records>();
            services.AddScoped<CoreDbContext>();
     
            //services.AddDbContext<CoreDbContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));
            //services.AddDbContext<CoreDbContext>();
           services.AddControllers().AddNewtonsoftJson(x =>
 x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddMvc()
     .AddNewtonsoftJson(
          options => {
              options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
          });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
