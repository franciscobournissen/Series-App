using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace SeriesApp.Data;

/* This is used if database provider does't define
 * ISeriesAppDbSchemaMigrator implementation.
 */
public class NullSeriesAppDbSchemaMigrator : ISeriesAppDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
