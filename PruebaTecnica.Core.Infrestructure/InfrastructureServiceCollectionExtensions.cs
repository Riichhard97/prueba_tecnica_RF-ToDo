using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace PruebaTecnica.Core.Infrestructure
{
    public static class InfrastructureServiceCollectionExtensions
    {
        public static void AddInfrastructureServices(this IServiceCollection services, Assembly applicationAssembly)
        {
            services.AddLazy();
            //services.AddSingleton<IPaginator, DefaultPaginator>();

            
            //services.AddSingleton<IDateTime>(new SystemDateTime());

            // Add MediatR
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
        
            services.AddMediatR(cnf=> cnf.RegisterServicesFromAssembly(applicationAssembly));

        }

    
        public static IServiceCollection AddLazy(this IServiceCollection services)
        {
            return services.AddTransient(typeof(Lazy<>), typeof(LazyService<>));
        }

        private class LazyService<T> : Lazy<T>, IDisposable
        {
            private bool _disposed;

            public LazyService(IServiceProvider provider)
                : base(provider.GetRequiredService<T>)
            {
            }

            public void Dispose()
            {
                if (!IsValueCreated)
                {
                    return;
                }

                if (_disposed)
                {
                    return;
                }

                if (Value is IDisposable disposable)
                {
                    disposable.Dispose();
                }

                _disposed = true;
            }
        }

        private static bool IsGenericType(this Type type, Type genericType)
            => type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition() == genericType;
    }
}