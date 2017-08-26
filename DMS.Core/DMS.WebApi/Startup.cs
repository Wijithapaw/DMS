using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using DMS.Domain.Services;
using DMS.Services;
using DMS.Domain;
using DMS.Data;
using Microsoft.EntityFrameworkCore;
using DMS.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using DMS.WebApi.ErrorHandling;
using Microsoft.AspNetCore.Http;
using DMS.Utills;
using DMS.WebApi.Utills;
using DMS.Utills.CustomClaims;

namespace DMS.WebApi
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(options =>
              options.UseSqlServer(Configuration.GetConnectionString("DataContext")));

            services.AddIdentity<ApplicationUser, IdentityRole<int>>()
            .AddEntityFrameworkStores<DataContext, int>()
            .AddDefaultTokenProviders();

            // Add framework services.
            services.AddMvc();

            // Configure Identity
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;

                // User settings
                options.User.RequireUniqueEmail = true;
            });

            services.AddAuthorization(options => {
                options.AddPolicy("View Projects",
                    policy => policy.RequireClaim(CustomClaimTypes.Permission, new string[] { "projects.view" }));

                options.AddPolicy("Manage Projects",
                    policy => policy.RequireClaim(CustomClaimTypes.Permission, new string[] { "projects.edit" }));
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IEnvironmentDescriptor, WebEnvironmentDescriptor>();
            services.AddTransient<IProjectsService, ProjectsService>();
            services.AddTransient<IProjectCategoryService, ProjectCategoryService>();
            services.AddTransient<IAccountService, AccountService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
            IHostingEnvironment env, 
            ILoggerFactory loggerFactory, 
            DataContext context, 
            UserManager<ApplicationUser> userManager, 
            RoleManager<IdentityRole<int>> roleManager)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMiddleware<ErrorHandlingMiddleware>();

            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
                //builder.WithOrigins("http://localhost:4200")
                //    .AllowAnyMethod()
                //    .AllowAnyHeader());

            app.UseJwtBearerAuthentication(new JwtBearerOptions()
            {
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidIssuer = "localhost:4200",
                    ValidAudience = "localhost:4200",
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SuperSecretKey_GetThisFromAppSettings")),
                    ValidateLifetime = true
                }
            });

            app.UseMvc();

            //Apply any pending migrations
            DbInitializer.Initialize(context, userManager, roleManager);
        }
    }
}
