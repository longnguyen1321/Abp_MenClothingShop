using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Acme.MenClothingShop.Imports
{
    public interface IImportAppService : IApplicationService
    {
        public Task<ImportDto> CreateAsync(CreateImportDto input);

        public Task<ImportDto> UpdateAsync(CancelImportDto input);
    }
}
