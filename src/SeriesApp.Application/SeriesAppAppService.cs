using SeriesApp.Localization;
using Volo.Abp.Application.Services;

namespace SeriesApp;

/* Inherit your application services from this class.
 */
public abstract class SeriesAppAppService : ApplicationService
{
    protected SeriesAppAppService()
    {
        LocalizationResource = typeof(SeriesAppResource);
    }
}
