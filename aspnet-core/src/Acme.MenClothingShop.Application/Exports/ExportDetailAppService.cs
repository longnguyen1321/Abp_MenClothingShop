using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Acme.MenClothingShop.Exports
{
    public class ExportDetailAppService : MenClothingShopAppService, IExportDetailAppService
    {
        private readonly ExportDetailManager _exportDetailManager;

        private readonly IExportDetailRepository _exportDetailRepository;

        public ExportDetailAppService(IExportDetailRepository exportDetailRepository)
        {
            _exportDetailRepository = exportDetailRepository;
        }
        public async Task<ExportDetailDto> CreateAsync(CreateExportDetailDto input)
        {
            var exportDetail = await _exportDetailManager.CreateAsync(input.ExportId, input.ClotheId, input.SoLuongXuat, input.GiaXuat, input.ThanhTienXuat);

            await _exportDetailRepository.InsertAsync(exportDetail, autoSave: true);

            return ObjectMapper.Map<ExportDetail, ExportDetailDto>(exportDetail);
        }
    }
}
