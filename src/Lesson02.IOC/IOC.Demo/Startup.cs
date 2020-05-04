using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOC.Demo.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace IOC.Demo
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
            #region ע����񣬲�ͬ��������

            // ����
            services.AddSingleton<IMySingletonService, MySingletonService>();

            // ������
            services.AddScoped<IMyScopedService, MyScopedService>();

            // ˲ʱ
            services.AddTransient<IMyTransientService, MyTransientService>();
            #endregion

            #region ��ʽע��
            // ֱ��ע��ʵ��
            services.AddSingleton<IOrderService>(new OrderService());
            //services.AddSingleton<IOrderService, OrderService>();
            
            // ������ʽע��
            //services.AddSingleton<IOrderService>(serviceProvider =>  
            //{
            //    // ����ʹ�� serviceProvider �������л�ȡ������������װ��ע����Ҫ�ķ��� 
            //    //var testService = serviceProvider.GetService<ITest>();
            //    //return new NeedTestService(testService);
            //    return new OrderServiceEx();
            //});
            #endregion

            #region ����ע��
            // ����������Ѿ���ע�����һʵ�֣���ô�Ͳ���ע��
            //services.TryAddSingleton<IOrderService, OrderService>();
            //services.TryAddSingleton<IOrderService>(new OrderServiceEx());
            // ��ǰ������û��ͬһ�������͵�ʵ��ʱ����ȥִ��ע��÷���
            services.TryAddEnumerable(ServiceDescriptor.Singleton<IOrderService, OrderServiceEx>());
            #endregion

            #region �Ƴ����滻ע��
            //services.RemoveAll<IOrderService>();
            //services.Replace(ServiceDescriptor.Singleton<IOrderService, OrderServiceEx>());
            #endregion

            #region ע�᷺��ģ��
            services.AddSingleton(typeof(IGerericService<,>), typeof(GenericService<,>));
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
