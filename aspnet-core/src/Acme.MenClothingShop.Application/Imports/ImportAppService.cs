using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Acme.MenClothingShop.Imports
{
    public class ImportAppService : ApplicationService, IImportAppService
    {
        IImportRepository _importRepo;
        ImportManager _importManager;

        public ImportAppService(IImportRepository importRepo, ImportManager importManager)
        {
            _importRepo = importRepo;
            _importManager = importManager;
        }
        public async Task CreateAsync(CreateImportDto input)
        {
            Guid id = new Guid("c1d90460-9d10-3849-9a35-3a0ce56c6108");
            var createImprot = _importManager.Create(input.MaNCC, id, input.TongTienNhap);

            await _importRepo.InsertAsync(createImprot);
        }

        public async Task UpdateAsync(CancelImportDto input)
        {
            var selectedImport = await _importRepo.FindAsync(input.MaPN);

            selectedImport.TinhTrangPX = "Đã hủy";

            await _importRepo.UpdateAsync(selectedImport, autoSave: true);
        }
    }
}
