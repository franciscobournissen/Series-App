using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace SeriesApp.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class SeriesAppDbContextFactory : IDesignTimeDbContextFactory<SeriesAppDbContext>
{
    public SeriesAppDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();
        
        SeriesAppEfCoreEntityExtensionMappings.Configure();

        var builder = new DbContextOptionsBuilder<SeriesAppDbContext>()
            .UseMySql(configuration.GetConnectionString("Default"), MySqlServerVersion.LatestSupportedServerVersion);
        
        return new SeriesAppDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../SeriesApp.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
