using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Store.Common.Extensions;
using Store.Product.API.Extensions;
using Store.Product.Application.Extensions;
using Store.Product.Presentation.Extensions;
using Store.Product.Repository.Extensions;
using System;

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
            services.AddSwaggerGen(options => options.IncludeXmlComments("", true));
            services.AddMvc();

            return services.BuildServiceProvider();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseException();
            app.UseMvc();
        }
    }
}
