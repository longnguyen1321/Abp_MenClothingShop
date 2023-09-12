using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Acme.MenClothingShop.Clothes;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.MenClothingShop.Imports
{
    public interface IImportDetailAppService : IApplicationService
    {
        public Task<PagedResultDto<ImportClotheListDto>> GetClotheList(GetClotheListDto input);

        public Task CreateAsync(CreateManyImportDetailsDto impClotheList);

        public Task UpdateAsync(Guid maPN);
    }
}
