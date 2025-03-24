using EmployeeManagement.Application.Database;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Persistence.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WatchDog;

namespace EmployeeManagement.Persistence.DIConfiguration
{
    public static class DependencyInjectionService
    {
        /// <summary>
        /// Tags to Health Check pattern.
        /// </summary>
        private static readonly string[] tags = ["database"];
        /// <summary>
        /// DI Persistence Layer.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration["ConnectionStrings:SQLServerConnectionString"] ?? string.Empty;
            services.AddDbContext<DataBaseService>(options => options.UseSqlServer(connectionString));
            #region Identity Configuration
            services.AddIdentityCore<UserEntity>().AddRoles<IdentityRole>().AddEntityFrameworkStores<DataBaseService>();
            #endregion
            #region Health Check Configuration by SQL Server
            services.AddHealthChecks().AddSqlServer(connectionString, tags: tags);
            #endregion
            #region WatchDog Configuration to MySQL
            services.AddWatchDogServices(options =>
            {
                options.IsAutoClear = true;
                options.ClearTimeSchedule = WatchDog.src.Enums.WatchDogAutoClearScheduleEnum.Monthly;
            });
            #endregion
            #region Repositories
            services.AddScoped<IDataBaseService, DataBaseService>();
            #endregion
            return services;
        }
    }
}
