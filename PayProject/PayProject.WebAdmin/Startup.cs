using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PayProject.Extensions;
using PayProject.WebAdmin.MQ.Consumer;
using PayProject.WebAdmin.Rabbit;
using RabbitMQ.Client;

namespace PayProject.WebAdmin
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            this.Configuration = builder.Build();
            BaseConfigModel.SetBaseConfig(Configuration, env.ContentRootPath, env.WebRootPath);
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region 认证
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, o =>
            {
                o.LoginPath = new PathString("/admin/login");
            });
            
            #endregion

            #region 授权
            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("RequireApp", policy => policy.RequireRole("App").Build());
            //    options.AddPolicy("RequireAdmin", policy => policy.RequireRole("Admin").Build());
            //    options.AddPolicy("RequireAdminOrApp", policy => policy.RequireRole("Admin,App").Build());
            //});
            #endregion

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddRabbitConnection(Configuration);
            services.AddHostedService<PayOrderNotifyService>();
            services.AddHostedService<SettleOrderNotifyService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime applicationLifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            //认证
            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            applicationLifetime.ApplicationStopping.Register(OnShutdown, app);
        }

        private void OnShutdown(object app)
        {
            if (!(app is IApplicationBuilder builder))
            {
                return;
            }

            var connection = builder.ApplicationServices.GetService<IConnection>();
            connection?.Close();
            connection?.Dispose();
        }
    }
}
