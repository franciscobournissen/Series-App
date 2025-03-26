using Volo.Abp.Modularity;

namespace SeriesApp;

/* Inherit from this class for your domain layer tests. */
public abstract class SeriesAppDomainTestBase<TStartupModule> : SeriesAppTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
