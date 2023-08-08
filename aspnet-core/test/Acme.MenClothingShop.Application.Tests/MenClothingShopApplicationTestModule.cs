using Volo.Abp.Modularity;

namespace Acme.MenClothingShop;

[DependsOn(
    typeof(MenClothingShopApplicationModule),
    typeof(MenClothingShopDomainTestModule)
    )]
public class MenClothingShopApplicationTestModule : AbpModule
{

}
