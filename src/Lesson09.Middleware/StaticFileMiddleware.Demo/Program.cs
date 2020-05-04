using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace StaticFileMiddleware.Demo
{
    /// <summary>
    /// ��̬�ļ��м�� -- ǰ��˷��뿪�����ϲ�����ɧ����
    ///     app.UseStaticFiles();
    ///     ����
    ///         ֧��ָ�����·��
    ///         ֧��Ŀ¼���:services.AddDirectoryBrowser(); app.UseDirectoryBrowser();
    ///         ֧������Ĭ���ĵ�:app.UseDefaultFiles();
    ///         ֧�ֶ�Ŀ¼ӳ��
    /// 
    /// ʵ��ǰ��HTML5 History ·��ģʽ֧��
    ///     ���ó���api֮������󣬶���Ӧindex.html
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
