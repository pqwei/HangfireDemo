using Hangfire;
using Hangfire.SqlServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace HangfireDemo
{
    public class Startup
    {
        /// <summary>
        /// Api版本信息
        /// </summary>
        private IApiVersionDescriptionProvider provider;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddApiVersioning(option =>
            {
                // 可选，为true时API返回支持的版本信息
                option.ReportApiVersions = true;
                // 不提供版本时，默认为1.0
                option.AssumeDefaultVersionWhenUnspecified = true;
                // 请求中未指定版本时默认为1.0
                option.DefaultApiVersion = new ApiVersion(1, 0);
            }).AddVersionedApiExplorer(option =>
            {　　　　　　　　　　// 版本名的格式：v+版本号
                option.GroupNameFormat = "'v'V";
                option.AssumeDefaultVersionWhenUnspecified = true;
            });

            this.provider = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();
            // 注册Swagger服务
            services.AddSwaggerGen(c =>
            {
                // 多版本控制
                foreach (var item in provider.ApiVersionDescriptions)
                {
                    // 添加文档信息
                    c.SwaggerDoc(item.GroupName, new OpenApiInfo
                    {
                        Title = "CoreWebApi",
                        Version = item.ApiVersion.ToString(),
                        Description = "ASP.NET CORE WebApi",
                        Contact = new OpenApiContact
                        {
                            Name = "魏朋强",
                            Email = "1531258932@qq.com",
                            Url = new Uri("https://cn.bing.com/")
                        }
                    });
                }
                #region 读取xml信息

                //使用反射获取xml文件。并构造出文件的路径
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                // 启用xml注释. 该方法第二个参数启用控制器的注释，默认为false.
                c.IncludeXmlComments(xmlPath, true);
                #endregion

            });

            // Add Hangfire services.
            services.AddHangfire(configuration => configuration
           .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
           .UseSimpleAssemblyNameTypeSerializer()
           .UseRecommendedSerializerSettings()
           .UseSqlServerStorage(Configuration.GetConnectionString("DataAggregationConnection"), new SqlServerStorageOptions
           {
               CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
               SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
               QueuePollInterval = TimeSpan.FromSeconds(15), // Default value,
               UseRecommendedIsolationLevel = true,
               UsePageLocksOnDequeue = true,
               DisableGlobalLocks = true
           }));

            services.AddHangfireServer();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            // 配置SwaggerUI
            app.UseSwaggerUI(c =>
            {
                foreach (var item in provider.ApiVersionDescriptions)
                {
                    c.SwaggerEndpoint($"/swagger/{item.GroupName}/swagger.json", "CoreAPI" + item.ApiVersion);
                }
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            var jobOptions = new BackgroundJobServerOptions
            {
                Queues = new[] { "back", "front", "default" },//队列名称，只能为小写
                //WorkerCount = Environment.ProcessorCount * 5, //并发任务数
                WorkerCount = Environment.ProcessorCount, //并发任务数
                ServerName = "conference hangfire1",//服务器名称
            };

            app.UseHangfireServer(jobOptions);//启动Hangfire服务

            app.UseHangfireDashboard();//启动hangfire面板

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
