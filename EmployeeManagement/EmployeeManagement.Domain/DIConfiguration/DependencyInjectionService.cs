using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManagement.Domain.DIConfiguration
{
    public static class DependencyInjectionService
    {
        /// <summary>
        /// DI Configuration builder.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            return services;
        }
    }
}
