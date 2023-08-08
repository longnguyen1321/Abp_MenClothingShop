using Acme.MenClothingShop.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Acme.MenClothingShop.Permissions;

public class MenClothingShopPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        //Define your own permissions here. Example:
        //myGroup.AddPermission(MenClothingShopPermissions.MyPermission1, L("Permission:MyPermission1"));
        var menClothingShopGroup = context.AddGroup(MenClothingShopPermissions.GroupName, L("Permission:MenClothingShop"));

        var clothesPermission = menClothingShopGroup.AddPermission(MenClothingShopPermissions.Clothes.Default, L("Permission:Clothes"));
        clothesPermission.AddChild(MenClothingShopPermissions.Clothes.Create, L("Permission:Clothes.Create"));
        clothesPermission.AddChild(MenClothingShopPermissions.Clothes.Edit, L("Permission:Clothes.Edit"));
        clothesPermission.AddChild(MenClothingShopPermissions.Clothes.Delete, L("Permission:Clothes.Delete"));

        var exportPermission = menClothingShopGroup.AddPermission(MenClothingShopPermissions.Exports.Default, L("Permission:Export"));
        exportPermission.AddChild(MenClothingShopPermissions.Exports.Create, L("Permission:Export.Create"));
        exportPermission.AddChild(MenClothingShopPermissions.Exports.Cancel, L("Permission:Export.Canccel"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<MenClothingShopResource>(name);
    }
}
