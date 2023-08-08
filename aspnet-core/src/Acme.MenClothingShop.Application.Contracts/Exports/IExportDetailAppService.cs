using System;
using System.Collections.Generic;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace Acme.MenClothingShop.Exports
{
    public interface IExportDetailAppService
    {
        Task<ExportDetailDto> CreateAsync(CreateExportDetailDto input);
    }
}
