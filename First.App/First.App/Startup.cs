using First.App.Filters;
using First.App.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace First.App
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
            services.AddControllersWithViews();
            //Di�er filtre t�rleri gibi, action filtresi de farkl� kapsam seviyelerine eklenebilir: Global, Action, Controller.

            //E�er filtremizi global olarak kullanmak istiyorsak, onu AddControllers() metodun i�inde metodun i�ine kaydetmemiz gerekiyor
            services.AddControllers(config =>
            {
                config.Filters.Add(new ValidationFilterAttribute());
            });

            //Ancak filtremizi Action veya Controller d�zeyinde bir hizmet t�r� olarak kullanmak istiyorsak,  IoC kapsay�c�s�nda bir hizmet olarak kaydetmemiz gerekir:
            //services.AddScoped<ValidationFilterAttribute>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseExceptionMiddleware();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
