using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ScopeDisposed.Demo
{
    /// <summary>
    /// ������Ͷ����ͷ���Ϊ -- ��֪��IDisposable�����ͷŵ�ʱ���Ϳ��
    ///     ����ʵ����IDisposable�ӿ�����
    ///         DIֻ�����ͷ����䴴���Ķ���ʵ��
    ///         DI���������������ͷ�ʱ���ͷ����䴴���Ķ���ʵ��
    ///     �����ڸ�������ȡʵ����IDisposable�ӿڵ�˲ʱ����
    ///     �����ֶ�����ʵ����IDisposable�Ķ���Ӧ��ʹ����������������������
    ///     
    /// IHostApplicationLifetime
    ///     ������������Ӧ�ó������������
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
