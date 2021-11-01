using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestReach.Exam.Application.Helpers;
using TestReach.Exam.Application.Helpers.Contracts;
using TestReach.Exam.Application.Services;
using TestReach.Exam.Application.Services.Contracts;
using TestReach.Exam.Core.Bus;
using TestReach.Exam.Core.Messages;
using TestReach.Exam.Data.Contexts;
using TestReach.Exam.Data.Repositories;
using TestReach.Exam.Domain.CommandHandlers;
using TestReach.Exam.Domain.Commands;
using TestReach.Exam.Domain.Repositories;

namespace TestReach.Exam.API.Configuration
{
    public static class DependencyRegister
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IExamAttemptService, ExamAttemptService>();

            services.AddScoped<IDbContext, ExamContext>();
            
            services.AddScoped<IExamAttemptRepository, ExamAttemptRepository>();
            services.AddScoped<IExamRepository, ExamRepository>();


            services.AddScoped<ExamAttemptCsvParser>();

            // Parser Factory
            services.AddTransient<Func<string, IExamAttemptFileParser>>(serviceProvider => fileExtension => {
                return fileExtension switch
                {
                    "csv" => serviceProvider.GetService<ExamAttemptCsvParser>(),
                    _ => throw new NotSupportedException("File type not supported")
                };
            }
            );

            services.AddScoped<IMediatorHandler, MediatorHandler>();

            services.AddScoped<IRequestHandler<BatchCreateExamAttemptCommand, GenericResult>, ExamAttemptCommandHandler>();
        }
    }
}
