using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Startup.Demo
{
    /// <summary>
    /// Startup -- ����ASP.NET Core ����������
    /// ����ִ��˳��
    ///     1. ConfigureWebHostDefaults
    ///        �����˱�Ҫ�����������������õ���� 
    ///     2. ConfigureHostConfiguration
    ///        ��������ʱ��Ҫ�����ã�����Ҫ�����Ķ˿ڡ�URL�ȣ���������������ǿ��������Լ�������ע�뵽���ÿ����
    ///     3. ConfigureAppConfiguration
    ///        ��������Ƕ�������Լ��������ļ���Ӧ�ó����ȡ
    ///     4. ConfigureServices
    ///        ConfigureLogging
    ///        Startup
    ///        Startup.ConfigureServices
    ///        �⼸������������������ע�����ǵ�Ӧ�õ����
    ///     5. Startup.Configure
    ///        ע���м��������HttpContext�����������
    ///     
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    Console.WriteLine("ConfigureWebHostDefaults");
                    webBuilder.UseStartup<Startup>();
                    // Startup �࣬�Ǳ���ʹ�ã����·���ͬStartup������һ��
                    // Ϊ�˴���ṹ����������
                    //webBuilder.ConfigureServices(services =>
                    //{
                    //    Console.WriteLine("webBuilder.ConfigureServices");
                    //    services.AddControllers();
                    //});
                    //webBuilder.Configure(app =>
                    //{
                    //    Console.WriteLine("webBuilder.Configure");

                    //    //if (env.IsDevelopment())
                    //    //{
                    //    //    app.UseDeveloperExceptionPage();
                    //    //}
                    //    app.UseHttpsRedirection();
                    //    app.UseRouting();
                    //    app.UseAuthorization();
                    //    app.UseStaticFiles();
                    //    app.UseWebSockets();
                    //    app.UseEndpoints(endpoints =>
                    //    {
                    //        endpoints.MapControllers();
                    //    });
                    //});
                })
                .ConfigureServices(service =>
                {
                    Console.WriteLine("ConfigureServices");
                })
                .ConfigureAppConfiguration(builder =>
                {
                    Console.WriteLine("ConfigureAppConfiguration");
                })
                .ConfigureHostConfiguration(builder =>
                {
                    Console.WriteLine("ConfigureHostConfiguration");
                });
    }
}
