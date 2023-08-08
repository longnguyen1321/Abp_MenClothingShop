using Acme.MenClothingShop.Permissions;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.ObjectMapping;

namespace Acme.MenClothingShop.Exports
{
    [Authorize(MenClothingShopPermissions.Exports.Default)]
    public class ExportAppService : MenClothingShopAppService, IExportAppService
    {
        private readonly IExportRepository _exportRepository;

        private readonly ExportManager _exportManager;

        public ExportAppService(IExportRepository exportRepository, ExportManager exportManager)
        {
            _exportRepository = exportRepository;
            _exportManager = exportManager;
        }

        [Authorize(MenClothingShopPermissions.Exports.Create)]
        public async Task<ExportDto> CreateAsync(CreateExportDto input)
        {
            Guid id;
            if(CurrentUser.Id == null || CurrentUser.Id == Guid.Empty)
            {
                id = new Guid("6748c312-0908-f49f-c292-3a0c9d0cf6cd");
            }
            else
            {
                id = (Guid)CurrentUser.Id;
            }    
            var newCreatedExport = await _exportManager.CreateAsync(id, input.TongTienXuat, input.TinhTrangPX, input.LyDoXuat);

            await _exportRepository.InsertAsync(newCreatedExport);

            return ObjectMapper.Map<Export, ExportDto>(newCreatedExport);
        }

        [Authorize(MenClothingShopPermissions.Exports.Cancel)]
        public async Task CancelAsync(Guid id, CancelExportDto exportStatus)
        {
            var updatedExport = await _exportRepository.GetAsync(id);

            updatedExport.TinhTrangPX = "Đã hủy!";

            await _exportRepository.UpdateAsync(updatedExport);
        }
    }
}
