using Volo.Abp.Modularity;

namespace SeriesApp;

[DependsOn(
    typeof(SeriesAppApplicationModule),
    typeof(SeriesAppDomainTestModule)
)]
public class SeriesAppApplicationTestModule : AbpModule
{

}
