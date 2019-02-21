using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HoneySheet.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace Api
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //services.AddDbContext<HoneySheetContext>(opts => opts.UseSqlServer(Configuration["ConnectionString:HoneySheet"]));

            // CORS
            services.AddCors(options =>
            {
                // CorsPolicy 是自訂的 Policy 名稱
                options.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowCredentials();
                });
            });

            // Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "HoneySheet Api",
                    Version = "v1"
                });

                // 为 Swagger JSON and UI设置xml文档注释路径
                var basePath = Path.GetDirectoryName(typeof(Startup).Assembly.Location);
                //获取应用程序所在目录                
                //c.IncludeXmlComments(Path.Combine(basePath, "HoneySheet.EntityFrameworkCore.xml"));
                //c.IncludeXmlComments(Path.Combine(basePath, "HoneySheet.Api.xml"));
            });

            // Register services            
            services.AddSingleton<LdapService>();
            services.AddTransient<AuthorityService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            // Enable CORS
            app.UseCors("CorsPolicy");            

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            //启用中间件服务对swagger-ui，指定Swagger JSON终结点
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "HoneySheet Api V1");
            });

            app.UseMvc();
        }
    }
}
