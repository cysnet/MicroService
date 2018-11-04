using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace IdentityClient
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
            services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = $"http://{Configuration["iip"]}:{Configuration["iport"]}";
                    options.RequireHttpsMetadata = false;
                    options.ApiName = "MsgAPI";
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
            app.Use(async (context, next) =>
            {
                //await context.Response.WriteAsync("进入第一个委托 执行下一个委托之前\r\n");
                //调用管道中的下一个委托

                await next.Invoke();
                //await context.Response.WriteAsync("结束第一个委托 执行下一个委托之后\r\n");
            });
            app.UseMvc();
        }
    }
}
