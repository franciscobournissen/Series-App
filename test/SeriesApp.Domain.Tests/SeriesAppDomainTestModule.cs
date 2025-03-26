using Volo.Abp.Modularity;

namespace SeriesApp;

[DependsOn(
    typeof(SeriesAppDomainModule),
    typeof(SeriesAppTestBaseModule)
)]
public class SeriesAppDomainTestModule : AbpModule
{

}
