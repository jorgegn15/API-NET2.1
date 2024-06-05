using ApiNetCore.DataAccess;
using ApiNetCore.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNetCore
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("V1", new OpenApiInfo
                {
                    Version = "V1",
                    Title = "Ejemplo API Net Core",
                    Description = "Ejemplo de API",
                     
                });
            });
            // Conecta con una base de datos InMemory
            services.AddDbContext<BBDDContext>(c => c.UseInMemoryDatabase("MiBBDD"));
            // Conecta con una base de datos real
            //services.AddDbContext<BBDDContext>(c => c.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<IBBDDContext, BBDDContext>();
            services.AddTransient<IModelItemRepository, ModelItemRepository>();
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
                app.UseHsts();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/V1/swagger.json", "Ejemplo API Net Core");
            });
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
