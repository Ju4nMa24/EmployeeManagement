using EmployeeManagement.Application.DIConfiguration;
using EmployeeManagement.Common.DIConfiguration;
using EmployeeManagement.Domain.DIConfiguration;
using EmployeeManagement.External.DIConfiguration;
using EmployeeManagement.Persistence.DIConfiguration;
using EmployeeManagement.Api.DIConfiguration;
using HealthChecks.UI.Client;
using WatchDog;
using EmployeeManagement.Domain.Entities;

AppContext.SetSwitch("System.Globalization.Invariant", false);

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services
    .AddWebApi()
    .AddCommon()
    .AddApplication()
    .AddDomain()
    .AddExternal(builder.Configuration)
    .AddPersistence(builder.Configuration);
builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();
app.MapIdentityApi<UserEntity>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/");
    app.UseHsts();
}
app.UseCors(builder =>
{
    builder.AllowAnyMethod().AllowAnyHeader();
});
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseWatchDogExceptionLogger();
#region Health Check Configurations
app.MapHealthChecksUI();
app.MapHealthChecks("/health", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});
#endregion
#region WatchDog Configurations
app.UseWatchDog(configuration =>
{
    configuration.Serializer = WatchDog.src.Enums.WatchDogSerializerEnum.Newtonsoft;
    configuration.WatchPageUsername = builder.Configuration["WatchDog:WatchPageUsername"];
    configuration.WatchPagePassword = builder.Configuration["WatchDog:WatchPagePassword"];
});
#endregion
app.MapControllers();

app.Run();
