using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Serilog;
using System;
using TestReach.Exam.API.Configuration;
using TestReach.Exam.Data.Contexts;

namespace TestReach.Exam.Registration
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
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {

                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "TestReach.Exam.API",
                        Version = "v1",
                        Description = "API to import and export test exam attempts.",
                        Contact = new OpenApiContact
                        {
                            Name = "Luis Guilherme Carvalho",
                            Url = new Uri("https://github.com/guipcarvalho")
                        }
                    });
            });

            services.AddDbContext<ExamContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddSerilogServices(Configuration);

            services.RegisterServices();

            services.ConfigureAutoMapper();

            services.AddMediatR(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ExamContext dataContext, ILogger logger, IConfiguration config)
        {
            logger.Information(config.GetConnectionString("DefaultConnection"));
            dataContext.Database.Migrate();

            app.UseDeveloperExceptionPage();
            
            app.UseSerilogRequestLogging();

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TestReach.Exam.API v1"));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
