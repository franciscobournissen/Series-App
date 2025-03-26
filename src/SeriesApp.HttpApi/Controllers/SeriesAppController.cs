using SeriesApp.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace SeriesApp.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class SeriesAppController : AbpControllerBase
{
    protected SeriesAppController()
    {
        LocalizationResource = typeof(SeriesAppResource);
    }
}
