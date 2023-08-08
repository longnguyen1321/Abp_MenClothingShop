using Acme.MenClothingShop.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Acme.MenClothingShop.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class MenClothingShopController : AbpControllerBase
{
    protected MenClothingShopController()
    {
        LocalizationResource = typeof(MenClothingShopResource);
    }
}
