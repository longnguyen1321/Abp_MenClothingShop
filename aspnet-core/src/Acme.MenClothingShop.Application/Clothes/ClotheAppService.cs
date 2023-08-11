using Acme.MenClothingShop.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Acme.MenClothingShop.Clothes
{
    public class ClotheAppService : CrudAppService<Clothe, ClotheDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateClotheDto>, IClotheAppService
    {
        public ClotheAppService(IRepository<Clothe, Guid> repository) : base(repository)
        { 
            GetPolicyName = MenClothingShopPermissions.Clothes.Default;
            GetListPolicyName = MenClothingShopPermissions.Clothes.Default;
            CreatePolicyName = MenClothingShopPermissions.Clothes.Create;
            UpdatePolicyName = MenClothingShopPermissions.Clothes.Edit;
            DeletePolicyName = MenClothingShopPermissions.Clothes.Delete;
        }
    }
}
