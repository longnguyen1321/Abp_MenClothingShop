using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.MenClothingShop.Exports
{
    public interface IExportAppService: IApplicationService
    {
        Task<ExportDto> CreateAsync(CreateExportDto autoInput);

        Task CancelAsync(Guid id, CancelExportDto exportStatus);
    }
}
