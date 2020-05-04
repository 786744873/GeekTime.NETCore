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
using ScopeDisposed.Demo.Services;

namespace ScopeDisposed.Demo
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

            //˲ʱ���ӿ�������ϣ��ͷŶ��� 
            services.AddTransient<IOrderService, DisposableOrderService>();

            //��������������ֻ�ܻ��ͬһ����
            //services.AddScoped<IOrderService, DisposableOrderService>();

            //�������������Լ���������ֻ�ܻ��ͬһ����
            // �����������Ķ���Ӧ�ó����˳�ʱ���ͷ�����ʵ���� IDisposable �Ķ���
            //services.AddSingleton<IOrderService>(services => new DisposableOrderService());
            //services.AddScoped<IOrderService>(services => new DisposableOrderService());
            //services.AddTransient<IOrderService>(services => new DisposableOrderService());

            // �����ֶ��Լ������Ķ���Ӧ�ó����˳�ʱ���ᱻ�Զ��ͷ�
            //var orderService = new DisposableOrderService();
            //services.AddSingleton<IOrderService>(orderService);


            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // �����и�����Ҫע��
            // �Ӹ�������ȡ˲ʱ�������ֻ��Ӧ�ó����˳�ʱ�Ż��ͷţ���Ϊ��������һֱ���иö���
            var s = app.ApplicationServices.GetService<IOrderService>();
            var s2 = app.ApplicationServices.GetService<IOrderService>();

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
