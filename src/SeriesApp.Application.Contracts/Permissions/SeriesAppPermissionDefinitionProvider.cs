using SeriesApp.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace SeriesApp.Permissions;

public class SeriesAppPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(SeriesAppPermissions.GroupName);

        var booksPermission = myGroup.AddPermission(SeriesAppPermissions.Books.Default, L("Permission:Books"));
        booksPermission.AddChild(SeriesAppPermissions.Books.Create, L("Permission:Books.Create"));
        booksPermission.AddChild(SeriesAppPermissions.Books.Edit, L("Permission:Books.Edit"));
        booksPermission.AddChild(SeriesAppPermissions.Books.Delete, L("Permission:Books.Delete"));
        //Define your own permissions here. Example:
        //myGroup.AddPermission(SeriesAppPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<SeriesAppResource>(name);
    }
}
