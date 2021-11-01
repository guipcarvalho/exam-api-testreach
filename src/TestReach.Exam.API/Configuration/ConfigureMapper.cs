using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestReach.Exam.Domain.Mappers;

namespace TestReach.Exam.API.Configuration
{
    public static class ConfigureMapper
    {
        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(CommandToDomainProfile));
        }
    }
}
