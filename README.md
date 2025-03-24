# Employee Management - Entity Framework Core Migration Guide

## Prerequisites
Ensure you have installed the required packages:
```powershell
Install-Package Microsoft.EntityFrameworkCore.SqlServer
Install-Package Microsoft.EntityFrameworkCore.Tools
```

## 1. Creating a Migration
Run the following command to create a migration:
```powershell
Add-Migration InitialCreate -Context DataBaseService
```
- Replace `InitialCreate` with your migration name.

## 2. Applying the Migration to the Database
Apply the migration using:
```powershell
Update-Database -Context DataBaseService
```

## 3. Rolling Back the Last Migration (if needed)
If you need to revert the last migration, use:
```powershell
Remove-Migration -Context DataBaseService
```

## 4. Checking the Migration Status
To check the applied migrations, run:
```powershell
Get-Migrations -Context DataBaseService
```

## 5. Updating the Database After Model Changes
If you make changes to your models, generate a new migration:
```powershell
Add-Migration UpdateModels -Context DataBaseService
Update-Database -Context DataBaseService
```

## 6. Ensuring the DbContext is Registered
Make sure your `Program.cs` (or `Startup.cs`) includes:
```csharp
builder.Services.AddDbContext<DataBaseService>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SQLServerConnectionString")));
```

## 7. Accessing Watchdog
To access Watchdog, follow these steps:

1. Open your browser and navigate to:
   ```
   http://localhost:5000/watchdog
   ```
   (Replace `5000` with your application's actual running port if different.)

2. If authentication is required, log in with the following credentials:
   ```
   Username: admin
   Password: 123456
   ```

3. Once inside Watchdog, you can monitor logs, track exceptions, and analyze performance metrics in real time.

4. Use the filtering and search features to find specific logs or error reports.

---

Following these steps ensures smooth migrations in your EF Core project! 🚀

