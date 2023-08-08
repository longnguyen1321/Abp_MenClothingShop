using Acme.MenClothingShop.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Acme.MenClothingShop;

[DependsOn(
    typeof(MenClothingShopEntityFrameworkCoreTestModule)
    )]
public class MenClothingShopDomainTestModule : AbpModule
{

}
