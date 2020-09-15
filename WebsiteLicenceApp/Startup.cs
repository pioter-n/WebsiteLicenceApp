using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using WebsiteLicenceApp.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using IdentityServer4.Models;
using System.Security.Claims;
using IdentityModel;
using IdentityServer4.Stores;
using Microsoft.AspNetCore.Authentication;
using WebsiteLicenceApp.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.CodeAnalysis.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using System.Collections.Generic;
using IdentityServer4;
using Microsoft.AspNetCore.Authentication.Cookies;
using System;

namespace WebsiteLicenceApp
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            var resources = new[]
           {
                new ApiResource("api", "My API", new[] {JwtClaimTypes.Name}),
            };
            services.AddSingleton<IClientStore, CustomClientStore>();
          
            services.AddIdentityServer()
                .AddDeveloperSigningCredential() /* replace in prod env */
                .AddApiAuthorization<ApplicationUser, ApplicationDbContext>()
                .AddClientStore<CustomClientStore>()
                .AddInMemoryApiResources(resources);

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = ".AspNetCore.Identity.WebsiteLicenceApp";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(2);
                options.SlidingExpiration = false;
            });
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
                options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
            }).AddIdentityServerJwt();

            services.AddControllersWithViews();
            services.AddRazorPages();
            services.Configure<JwtBearerOptions>(IdentityServerJwtConstants.IdentityServerJwtBearerScheme, options =>
            {
                options.TokenValidationParameters.ValidAudiences = new List<string> { "api" };
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseIdentityServer();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();



                endpoints.MapRazorPages();

            });
        }
    }
}
