using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Middleware.Demo
{
    /// <summary>
    /// �м�����ƿ���������̵Ĺؼ�
    ///     ����ԭ��������˹���ޣ�
    ///                     Middleware1         Middleware2         Middleware3     
    ///         Request ��    //logic
    ///                       next();     ��      //logic
    ///                                           next();     ��      //logic
    ///                                                       
    ///                                                               //more logic
    ///                                           //more logic   �� 
    ///                      //more logic   ��
    ///         Response ��
    ///         
    ///     ���Ķ���
    ///         IApplicationBuilder
    ///             ע���м��
    ///         RequestDelegate
    ///             �������������ί��
    ///             
    ///     �Զ����м����Լ���ķ�ʽ��
    ///         ����һ�� Invoke/InvokeAsync����������Ϊ HttpContext
    ///         
    ///         
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
                    webBuilder.UseStartup<Startup>();
                });
    }
}
