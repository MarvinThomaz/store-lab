using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Store.Common.Extensions;
using Store.Product.API.Extensions;
using Store.Product.Application.Extensions;
using Store.Product.Presentation.Extensions;
using Store.Product.Repository.Extensions;
using Swashbuckle.AspNetCore.Examples;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;

namespace Store.Product.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddAPI();
            services.AddPresentation();
            services.AddApplication();
            services.AddRepository();
            services.AddMongo("Product");
            services.AddCommon();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                       new Info
                       {
                           Title = "Store - Product",
                           Version = "v1",
                           Description = "Product module of Store Application",
                           Contact = new Contact
                           {
                               Name = "Marvin Thomaz",
                               Url = "https://github.com/marvinthomaz/store-lab"
                           }
                       });

                var appPath = PlatformServices.Default.Application.ApplicationBasePath;
                var appName = PlatformServices.Default.Application.ApplicationName;
                var xmlPath = Path.Combine(appPath, $"{appName}.xml");

                options.OperationFilter<ExamplesOperationFilter>();
                options.IncludeXmlComments(xmlPath);
            });

            services.AddMvc();

            return services.BuildServiceProvider();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseException();
            app.UseSwagger();
            app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "Store - Product - v1"));
            app.UseMvc();
        }
    }
}
