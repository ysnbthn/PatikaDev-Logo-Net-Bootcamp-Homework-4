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
            //Diðer filtre türleri gibi, action filtresi de farklý kapsam seviyelerine eklenebilir: Global, Action, Controller.

            //Eðer filtremizi global olarak kullanmak istiyorsak, onu AddControllers() metodun içinde metodun içine kaydetmemiz gerekiyor
            services.AddControllers(config =>
            {
                config.Filters.Add(new ValidationFilterAttribute());
            });

            //Ancak filtremizi Action veya Controller düzeyinde bir hizmet türü olarak kullanmak istiyorsak,  IoC kapsayýcýsýnda bir hizmet olarak kaydetmemiz gerekir:
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
