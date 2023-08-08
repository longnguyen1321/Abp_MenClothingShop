using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Acme.MenClothingShop;

[Dependency(ReplaceServices = true)]
public class MenClothingShopBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "MenClothingShop";
}
