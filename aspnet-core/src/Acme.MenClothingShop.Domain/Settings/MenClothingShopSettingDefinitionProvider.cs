using Volo.Abp.Settings;

namespace Acme.MenClothingShop.Settings;

public class MenClothingShopSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(MenClothingShopSettings.MySetting1));
    }
}
