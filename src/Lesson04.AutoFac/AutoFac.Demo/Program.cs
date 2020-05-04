using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AutoFac.Demo
{
    /// <summary>
    /// Autofac -- ��Autofac��ǿ�����������������������̣�AOP��������
    /// �������³�������ʱ����������������ʵ��
    ///     �������Ƶ�ע��
    ///     ����ע��
    ///     ������
    ///     ���ڶ�̬�����AOP
    ///         ��������������
    ///         �ڲ��ı�ԭ����Ļ����ϣ��ڷ���ִ��ʱǶ��һЩ�߼�����ִ�й�������������Ĳ������ǵ��߼�
    /// ������չ��
    ///     public interface IServiceProviderFactory<TContainerBuilder>
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                // ע��Autofac����ʵ��
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
