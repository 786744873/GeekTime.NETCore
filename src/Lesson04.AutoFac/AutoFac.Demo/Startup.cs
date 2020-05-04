using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.DynamicProxy;
using AutoFac.Demo.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AutoFac.Demo
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
            services.AddControllers();// .AddControllersAsServices();
        }

        public  ILifetimeScope AutofacContainer { get; set; }
        public void ConfigureContainer(ContainerBuilder builder)
        {
            //builder.RegisterType<MyService>().As<IMyService>();

            #region ����ע��
            //builder.RegisterType<MyService2>().Named<IMyService>("service2");
            #endregion

            #region ����ע��
            //builder.RegisterType<MyNameService>();
            //builder.RegisterType<MyService2>().As<IMyService>().PropertiesAutowired();// ���ø÷����Ƿ���Ҫ����ע��
            #endregion

            #region ��̬���� AOP 
            // 1. ע��������
            //builder.RegisterType<MyIntercepter>();  
            // 2. ע����񣬲�����ָ����̬����
            //builder.RegisterType<MyService2>().As<IMyService>().PropertiesAutowired().InterceptedBy(typeof(MyIntercepter)).EnableInterfaceInterceptors();
            #endregion

            #region ��������������
            builder.RegisterType<MyNameService>().InstancePerMatchingLifetimeScope("myscope");
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            this.AutofacContainer = app.ApplicationServices.GetAutofacRoot();

            // ���ݽӿڻ�ȡ����ʵ��
            //var service = this.AutofacContainer.Resolve<IMyService>();
            //service.ShowCode();

            // ����������ȡ����ʵ��
            //var service2 = this.AutofacContainer.ResolveNamed<IMyService>("service2");
            //service2.ShowCode();

            #region ������
            using (var myscope = AutofacContainer.BeginLifetimeScope("myscope"))
            {
                var service0 = myscope.Resolve<MyNameService>();
                using (var scope= myscope.BeginLifetimeScope())
                {
                    var service1 = scope.Resolve<MyNameService>();
                    var service2 = scope.Resolve<MyNameService>();
                    Console.WriteLine($"service1=service2:{service1 == service2}");
                    Console.WriteLine($"service1=service0:{service1 == service0}");
                }
            }
            #endregion

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
