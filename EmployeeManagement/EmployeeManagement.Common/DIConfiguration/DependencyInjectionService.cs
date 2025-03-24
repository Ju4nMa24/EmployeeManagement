using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManagement.Common.DIConfiguration
{
    public static class DependencyInjectionService
    {
        /// <summary>
        /// DI Configuration builder.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddCommon(this IServiceCollection services)
        {
            return services;
        }
    }
}
