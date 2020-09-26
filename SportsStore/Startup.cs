using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
/*Microsoft.Extensions.Configuration containt libraries that were created as part of the ASP.NET Core framework.
 * Loading data from JSON is just one of many configuration sources you can with this namespace. 
*/
using Microsoft.EntityFrameworkCore;
using SportsStore.Models;


namespace SportsStore
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940 

       public Startup(IConfiguration config) => Configuration = config;
        /*
         * The constructor recieves the IConfiguaration object through its constructor and assigns it to the Configuration property
         * which is used to access the connection string. 
         */
       private IConfiguration Configuration { get; set; }
        /*
         * IConfiguration interface provides access to the ASP.NET Core configuration system, 
         * which includes the contents of the
            appsettings.json file
        */

        public void ConfigureServices(IServiceCollection services)
        { /*
           * benefit of services is they allow classes to use interfaces without needing
           * to know which implementation class is being used*/
            services.AddControllersWithViews();
            services.AddDbContext<StoreDbContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:SportsStoreConnection"]);
            }); /*
                 * This registers the database context class and configures the relationship with the database.
                 * The UseSqlServer method declares that the SQL Server
                 * will be used and the connection string is read via the IConfiguration object.
                 * Create a repository next.
                 */
            services.AddScoped<IStoreRepository, EFStoreRepository>();
            //AddScoped method creates a service where each HTTP request gets its own repository object.
            services.AddScoped<IOrderRepository, EFOrderRepository>();
            services.AddRazorPages();
            services.AddDistributedMemoryCache();//call sets up the in-memory data store
            services.AddSession();//registers the services used to access session data

            services.AddScoped<Carts>(sp => SessionCart.GetCart(sp));
            //AddScoped method specifies that the same object should be 
            //used to satisfy related requests for Cart instances

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }  /* AddSingleton method,  specifies that the same object should always be used.*/

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
                app.UseStaticFiles();
            }
            app.UseSession();/*allows the session system to automatically 
                              * associate requests with sessions when they arrive from the client. */ 

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("catpage",
                 "{category}/Page{productPage:int}",
                 new { Controller = "Home", action = "Index" });
                endpoints.MapControllerRoute("page", "Page{productPage:int}",
                new { Controller = "Home", action = "Index", productPage = 1 });
                endpoints.MapControllerRoute("category", "{category}",
                new { Controller = "Home", action = "Index", productPage = 1 });
                endpoints.MapControllerRoute("pagination",
                "Products/Page{productPage}",
                new { Controller = "Home", action = "Index", productPage = 1 });
                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
            });
            SeedData.EnsurePopulated(app);
        }
    }
}
