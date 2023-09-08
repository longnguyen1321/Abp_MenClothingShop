using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Acme.MenClothingShop.Clothes;
using static Acme.MenClothingShop.Permissions.MenClothingShopPermissions;
using Acme.MenClothingShop.Imports;

namespace Acme.MenClothingShop.Clothes
{
    public interface IClotheAppService : 
        ICrudAppService<
            ClotheDto,
            Guid,
            PagedAndSortedResultRequestDto,
    CreateUpdateClotheDto> 
    {
       
    }
}
