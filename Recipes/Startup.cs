using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Recipes.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Recipes
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration["Data:Recipes:ConnectionString"]));
            services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer(Configuration["Data:IdentityDatabase:ConnectionString"]));
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();
            // Configure Identity
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            });
            services.AddHttpContextAccessor();
            services.AddTransient<IRecipeRepository, EFRecipeRepository>();
            services.AddTransient<IUserRepository, EFUserRepository>();
            services.AddMvc();

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc(routes => {

                routes.MapRoute(
                    name: "AdminPagination",
                    template: "Recipes/{Admin}/Page{recipePage}",
                    defaults: new { Controller = "Admin", action = "Index" });

                routes.MapRoute(
                    name: "pagination",
                    template: "Recipes/{Home}/Page{recipePage}",
                    defaults: new { Controller = "Home", action = "RecipeList" });

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
                
            });
            SeedData.EnsurePopulated(app);
        }
    }
}
