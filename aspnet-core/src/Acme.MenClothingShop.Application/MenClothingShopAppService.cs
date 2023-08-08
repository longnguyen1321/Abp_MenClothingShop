using System;
using System.Collections.Generic;
using System.Text;
using Acme.MenClothingShop.Localization;
using Volo.Abp.Application.Services;

namespace Acme.MenClothingShop;

/* Inherit your application services from this class.
 */
public abstract class MenClothingShopAppService : ApplicationService
{
    protected MenClothingShopAppService()
    {
        LocalizationResource = typeof(MenClothingShopResource);
    } 
}
