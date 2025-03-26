using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SeriesApp.Data;
using Volo.Abp.DependencyInjection;

namespace SeriesApp.EntityFrameworkCore;

public class EntityFrameworkCoreSeriesAppDbSchemaMigrator
    : ISeriesAppDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreSeriesAppDbSchemaMigrator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the SeriesAppDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<SeriesAppDbContext>()
            .Database
            .MigrateAsync();
    }
}
