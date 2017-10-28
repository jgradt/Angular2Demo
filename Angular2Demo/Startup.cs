using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using FizzWare.NBuilder;

namespace Angular2Demo
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
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });

            //using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            //{
            //    var context = serviceScope.ServiceProvider.GetService<DemoDbContext>();
            //    AddDatabaseSeedData(context);

            //    var d = context.Customers.ToList();
            //}

            
        }

        //private void AddDatabaseSeedData(DemoDbContext dbContext)
        //{
        //    if (!dbContext.Customers.Any())
        //    {
        //        var customers = Builder<Data.Entities.Customer>.CreateListOfSize(100)
        //            .All()
        //                .With(c => c.FirstName = Faker.Name.First())
        //                .With(c => c.LastName = Faker.Name.Last())
        //                //.With(c => c.EmailAddress = Faker.Internet.Email())
        //                //.With(c => c.TelephoneNumber = Faker.Phone.Number())
        //            .Build();

        //        dbContext.Customers.AddRange(customers.ToArray());
        //    }

        //    dbContext.SaveChanges();
        //}
    }
}
