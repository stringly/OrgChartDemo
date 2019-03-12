﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using OrgChartDemo.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using OrgChartDemo.Persistence;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using OrgChartDemo.Models.Auth;

namespace OrgChartDemo {
    /// <summary>
    /// Startup Class
    /// </summary>
    public class Startup {
        IConfigurationRoot Configuration;
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="env">An <see cref="IHostingEnvironment"/> object.</param>
        public Startup(IHostingEnvironment env) {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json").Build();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940   
        /// </summary>
        /// <param name="services">An <see cref="IServiceCollection"/></param>
        public void ConfigureServices(IServiceCollection services) {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration["Data:OrgChartComponents:ConnectionString"]));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddAuthentication(Microsoft.AspNetCore.Server.IISIntegration.IISDefaults.AuthenticationScheme);
            services.AddMvc();
            services.AddAuthorization(options =>
            {
                options.AddPolicy(
                    "CanEditUser",
                    policyBuilder => policyBuilder.AddRequirements(
                        new CanEditUserRequirement()));
            });
            services.AddScoped<IClaimsTransformation, ClaimsLoader>();
            services.AddSingleton<IAuthorizationHandler, IsGlobalAdminHandler>();
            services.AddSingleton<IAuthorizationHandler, IsOwnerHandler>();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">An <see cref="IApplicationBuilder"/> object.</param>
        /// <param name="env">An <see cref="IHostingEnvironment"/> object.</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            app.UseStatusCodePagesWithReExecute("/Error/Error", "?statusCode={0}");
            app.UseAuthentication();
            app.UseStaticFiles();
            

            app.UseMvc(routes => {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=OrgChart}/{action=Index}/{id?}");
            });
        }
    }
}
