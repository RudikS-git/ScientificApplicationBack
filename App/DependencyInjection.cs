using App.Common.Behaviours;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MapsterMapper;
using Mapster;

namespace App
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddSingleton(GetConfiguredMappingConfig());
            services.AddScoped<IMapper, ServiceMapper>();

        //    services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
          //  services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehaviour<,>));
          //  services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        //    services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));

            return services;
        }

        private static TypeAdapterConfig GetConfiguredMappingConfig()
        {
            var config = TypeAdapterConfig.GlobalSettings;

            IList<IRegister> registers = config.Scan(Assembly.GetExecutingAssembly());

            config.Apply(registers);

            return config;
        }
    }
}
