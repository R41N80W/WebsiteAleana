using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebsiteAleana
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute("redirect_main", "main", new { controller = "Home", action = "Index" });
                routes.MapRoute("redirect_business", "business", new { controller = "Home", action = "Business" });
                routes.MapRoute("redirect_act", "act", new { controller = "Home", action = "Act" });
                routes.MapRoute("redirect_real-estate", "real-estate", new { controller = "Home", action = "RealEstate" });
                routes.MapRoute("redirect_nalog", "nalog", new { controller = "Evaluation", action = "Tax" });
                routes.MapRoute("redirect_training", "training", new { controller = "Home", action = "Training" });
                routes.MapRoute("redirect_about", "about", new { controller = "About", action = "Index" });
                routes.MapRoute("redirect_about_command", "about/command", new { controller = "About", action = "Team" });
                routes.MapRoute("redirect_about_clients", "about/clients", new { controller = "About", action = "Clients" });
                routes.MapRoute("redirect_about_sertificates", "about/sertificates", new { controller = "About", action = "Certificates" });
                routes.MapRoute("redirect_about_partners", "about/partners", new { controller = "About", action = "Partners" });
                routes.MapRoute("redirect_ocenka", "ocenka", new { controller = "Evaluation", action = "Business" });
                routes.MapRoute("redirect_ocenka_business", "ocenka/business", new { controller = "Evaluation", action = "Business" });
                routes.MapRoute("redirect_ocenka_act", "ocenka/act", new { controller = "Evaluation", action = "Act" });
                routes.MapRoute("redirect_ocenka_real-estate", "ocenka/real-estate", new { controller = "Evaluation", action = "RealEstate" });
                routes.MapRoute("redirect_ocenka_auto", "ocenka/auto", new { controller = "Evaluation", action = "Auto" });
                routes.MapRoute("redirect_ocenka_equipment", "ocenka/equipment", new { controller = "Evaluation", action = "Equipment" });
                routes.MapRoute("redirect_ocenka_intellectual-property", "ocenka/intellectual-property", new { controller = "Evaluation", action = "IntellectualProperty" });
                routes.MapRoute("redirect_ocenka_ground", "ocenka/ground", new { controller = "Evaluation", action = "Ground" });
                routes.MapRoute("redirect_ocenka_price", "ocenka/price", new { controller = "Evaluation", action = "Price" });
                routes.MapRoute("redirect_ocenka_2013-07-27-08-43-02", "ocenka/2013-07-27-08-43-02", new { controller = "Evaluation", action = "Tax" });
                routes.MapRoute("redirect_ocenka_2013-08-06-19-18-47", "ocenka/2013-08-06-19-18-47", new { controller = "Evaluation", action = "NormativeBase" });
                routes.MapRoute("redirect_reorganization", "reorganization", new { controller = "Misc", action = "Reorganization" });
                routes.MapRoute("redirect_contacts", "contacts", new { controller = "Misc", action = "Contacts" });
                routes.MapRoute("redirect_articles", "articles", new { controller = "Misc", action = "Articles" });
                routes.MapRoute("redirect_articles_53-2010-08-02-15-05-55", "articles/53-2010-08-02-15-05-55", new { controller = "Articles", action = "_1" });
                routes.MapRoute("redirect_articles_54-2010-08-03-10-49-20", "articles/54-2010-08-03-10-49-20", new { controller = "Articles", action = "_2" });
                routes.MapRoute("redirect_actions", "actions", new { controller = "Misc", action = "SpecialOffers" });
            });
        }
    }
}
