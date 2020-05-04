using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace StaticFileMiddleware.Demo
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
            services.AddControllers();

            // ע��Ŀ¼�������
            //services.AddDirectoryBrowser();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            // ����Ĭ�Ϸ��� index �ļ�
            //app.UseDefaultFiles();

            // ����Ŀ¼���
            //app.UseDirectoryBrowser();

            // ������̬�ļ��м��
            app.UseStaticFiles();

            // �����Զ���Ŀ¼��̬�ļ�
            //app.UseStaticFiles(new StaticFileOptions()
            //{
            //    RequestPath="/files", // ����·��ӳ��
            //    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "assets"))
            //});

            // ���ó���api֮������󣬶���Ӧindex.html
            // /order/get
            app.MapWhen(context =>
            {
                return !context.Request.Path.Value.StartsWith("/api");
            }, appBuilder =>
            {
                // Rewrite ��ʽ�ض������� index.html
                //var option = new RewriteOptions();
                //option.AddRewrite(".*", "/index.html", true);
                //appBuilder.UseRewriter(option);
                //appBuilder.UseStaticFiles();

                // Run �۶�����ʽ
                // ȱ�㣺û�취��̬�ļ��м�����������ȷ��Http����ͷ
                appBuilder.Run(async context =>
                {
                    const int BufferSize = 64 * 1024;
                    var file = env.WebRootFileProvider.GetFileInfo("index.html");
                    context.Response.ContentType = "text/html";
                    using (var fileStream = new FileStream(file.PhysicalPath,FileMode.Open,FileAccess.Read))
                    {
                        await StreamCopyOperation.CopyToAsync(fileStream, context.Response.Body, null, BufferSize, context.RequestAborted);
                    }
                });



            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
