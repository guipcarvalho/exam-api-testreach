using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestReach.Exam.Application.Services;
using TestReach.Exam.Application.Services.Contracts;
using TestReach.Exam.Data.Contexts;

namespace TestReach.Exam.API.Configuration
{
    public static class DependencyRegister
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IExamAttemptService, ExamAttemptService>();

            services.AddScoped<IDbContext, ExamContext>();
        }
    }
}
