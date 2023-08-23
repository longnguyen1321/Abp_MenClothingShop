using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Acme.MenClothingShop.Storages
{
    public interface IStorageAppService
    {
        public Task<PagedResultDto<ClotheStorageDto>> GetAsync(GetClotheStorageListDto input);
        
    }
}
