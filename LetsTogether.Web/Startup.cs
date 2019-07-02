using Microsoft.Owin;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using LetsTogether.DAL.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using LetsTogether.DAL.Entities;
using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using LetsTogether.BLL.Interfaces;
using LetsTogether.BLL.Services;
using LetsTogether.DAL.Interfaces;
using LetsTogether.DAL.Repositories;
using AutoMapper;
using LetsTogether.Web.Mapper;
using System.Reflection;

[assembly: OwinStartup(typeof(LetsTogether.Web.Startup))]

namespace LetsTogether.Web
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
            services.AddDbContext<AppDBContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), x => x.MigrationsAssembly("LetsTogether.DAL")));

            // dotnet ef migrations add InitDB --project ../LetsTogether.DAL -c AppDBContext
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<AppDBContext>();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });
            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
                options.AccessDeniedPath = "//Account/AccessDenied";
                options.SlidingExpiration = true;
            });



            services.AddMvc();

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUnitOfWork, IdentityUnitOfWork>();
            services.AddTransient<ILocationRepository, LocationRepository>();
            services.AddTransient<IAdminService, AdminService>();
            services.AddTransient<IProfileManager, ProfileManager>();
            services.AddTransient<IProfileService, ProfileService>();
            services.AddTransient<IPhotoRepository, PhotoRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IUserCategoryRepository, UserCategoryRepository>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IEventCategoryRepository, EventCategoryRepository>();
            services.AddTransient<IEventPhotoRepository, EventPhotoRepository>();
            services.AddTransient<IEventVisitorsRepository, EventVisitorsRepository>();
            services.AddTransient<IEventRepository, EventRepository>();
            services.AddTransient<IEventService, EventService>();


            services.AddAutoMapper(typeof(AutoMapping).GetTypeInfo().Assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

    }
}