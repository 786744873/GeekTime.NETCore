using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace OptionPattern.Demo
{
    /// <summary>
    /// ѡ��ģʽ(���) -- ��������������õ����ʵ��
    ///     �����ռ䣺Microsoft.Extensions.Options
    ///     ע�����ʱ��ָ�����ã�services.Configure<OrderServiceOptions>(Configuration.GetSection("OrderService"));��
    ///     ����
    ///         ֧�ֵ���ģʽ��ȡ����
    ///         ֧�ֿ���
    ///         ֧�����ñ��֪ͨ
    ///         ֧������ʱ��̬�޸�ѡ��ֵ 
    ///     ���ԭ��
    ///         �ӿڷ���ԭ��ISP�����಻Ӧ����������ʹ�õ�����
    ///         ��ע����루SoC������ͬ�����������֮������ò�Ӧ�໥���������
    ///     ����
    ///         Ϊ���ǵķ������ XXXOptions 
    ///         ʹ��IOptions<XXXOptions>��IOptionsSnapshot<XXXOptions>��IOptionsMonitor<XXXOptions> ��Ϊ����Ĺ��캯���Ĳ���
    ///         
    /// ѡ�������ȸ��� -- �÷����֪���õı仯
    ///     �ؼ���
    ///         IOptionsMonitor<out TOptions>
    ///         IOptionsSnapshot<out TOptions>
    ///     ʹ�ó���
    ///         ��Χ����������ʹ�� IOptionsSnapshot
    ///         ��������ʹ�� IOptionsMonitor
    ///     ͨ���������ѡ��
    ///         IPostConfigureOptions<TOptions>
    ///             // ��̬��������������ļ���������Ч
    ///             services.PostConfigure<OrderServiceOptions>(option =>
    ///             {
    ///                 option.MaxOrderCount = 1000;
    ///             });   
    ///             
    /// Ϊѡ�����������֤ -- ����������õ�Ӧ�ý����û�����
    ///     ������֤����
    ///         ֱ��ע����֤����
    ///         ʵ��IValidateOptions<TOptions>
    ///         ʹ�� Microsoft.Extensions.Options.DataAnnotations
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
