using SeriesApp.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace SeriesApp.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(SeriesAppEntityFrameworkCoreModule),
    typeof(SeriesAppApplicationContractsModule)
)]
public class SeriesAppDbMigratorModule : AbpModule
{
}
