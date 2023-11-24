using Acme.MenClothingShop.Clothes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.MenClothingShop.Imports
{
    public interface IImportAppService : IApplicationService
    {
        public Task<ImportDto> CreateAsync(CreateImportDto input);

        public Task<ImportDto> UpdateImportStatusAsync(CancelImportDto input);

        public Task<ImportDto> UpdateAsync(Guid maPN, UpdateImportDto input);

        public Task<PagedResultDto<ImportDto>> GetListAsync(PagedAndSortedResultRequestDto input);

        public Task<PagedResultDto<ToDisplayImportDto>> GetImportListToDisplay(PagedAndSortedResultRequestDto input);

        public Task<ImportDto> GetImportAsync(Guid maPN);
    }
}
