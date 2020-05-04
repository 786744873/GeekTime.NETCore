using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace IOC.Demo
{
    /// <summary>
    /// ����ע��(Ĭ�Ͽ��) -- ���üܹ������
    ///     ��������
    ///         IServiceCollection���������ע��
    ///         ServiceDescriptor��ÿ������ע��ʱ����Ϣ
    ///         IServiceProvider�������������Ҳ����ServiceCollection Build������
    ///         IServiceScope����ʾһ������������������������
    ///     ��������
    ///         Singleton�����������������������������ǵ���ģʽ
    ///         Scoped����������ָ���ҵ���������������������������ͬһ�����󣨵���������������ͷţ�����Ҳ����ű��ͷ�
    ///         Transient��˲ʱ��ÿ�λ�ȡʱ������ȫ�µĶ���
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
