using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OptionPattern.Demo.Services;

namespace OptionPattern.Demo
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
            #region ѡ��ģʽ
            // ����ע��
            ////services.AddSingleton<OrderServiceOptions>();
            //services.Configure<OrderServiceOptions>(Configuration.GetSection("OrderService"));
            //services.AddSingleton<IOrderService, OrderService>();
            #endregion

            #region ������ѡ�������ȸ��� -- IOptionsSnapshot
            //services.Configure<OrderServiceOptions>(Configuration.GetSection("OrderService"));
            //services.AddScoped<IOrderService, OrderService>();
            #endregion

            #region ������ѡ�������ȸ��� -- IOptionsMonitor
            //services.Configure<OrderServiceOptions>(Configuration.GetSection("OrderService"));
            //services.AddSingleton<IOrderService, OrderService>();
            #endregion

            #region ʹ����չ�������򻯷���ע���߼�
            services.AddOrderService(Configuration);
            #endregion

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
