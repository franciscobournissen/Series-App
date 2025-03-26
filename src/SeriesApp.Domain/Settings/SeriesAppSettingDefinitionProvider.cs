using Volo.Abp.Settings;

namespace SeriesApp.Settings;

public class SeriesAppSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(SeriesAppSettings.MySetting1));
    }
}
