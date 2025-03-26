using Volo.Abp.Modularity;

namespace SeriesApp;

public abstract class SeriesAppApplicationTestBase<TStartupModule> : SeriesAppTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
