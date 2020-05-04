using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Routing.Demo
{
    /// <summary>
    /// ·�����ս�� -- ��ι滮�����Web API
    ///     ע�᷽ʽ
    ///         ·��ģ�巽ʽ
    ///         RouteAttribute��ʽ
    ///     ·��Լ��
    ///         ����Լ��
    ///         ��ΧԼ��
    ///         ������ʽ
    ///         �Ƿ��ѡ
    ///         �Զ���IRouteConstraint
    ///     URL����
    ///         ��������ĸ���·����Ϣ����URL��ַ
    ///         LinkGenerator
    ///         IUrlHelper
    ///         
    /// Web API 
    ///     Restful ���Ǳ����
    ///     Լ���� API �ı����Լ
    ///     ��APIԼ�����ض�Ŀ¼�£���/api/
    ///     ʹ�� ObsoleteAttribute ���Ϊ����������API
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
