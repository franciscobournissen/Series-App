using Microsoft.Extensions.Localization;
using SeriesApp.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace SeriesApp;

[Dependency(ReplaceServices = true)]
public class SeriesAppBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<SeriesAppResource> _localizer;

    public SeriesAppBrandingProvider(IStringLocalizer<SeriesAppResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
