using System.Threading.Tasks;

namespace SeriesApp.Data;

public interface ISeriesAppDbSchemaMigrator
{
    Task MigrateAsync();
}
