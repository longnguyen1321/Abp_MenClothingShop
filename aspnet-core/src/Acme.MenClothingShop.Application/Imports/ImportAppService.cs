using Acme.MenClothingShop.Clothes;
using Acme.MenClothingShop.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using Volo.Abp.SettingManagement;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.Forms;

namespace Acme.MenClothingShop.Imports
{
    public class ImportAppService : ApplicationService, IImportAppService
    {
        IImportRepository _importRepo;
        IImportRepository _importRepository;
        IClotheRepository _clotheRepository;

        ImportManager _importManager;
        public ImportAppService(IImportRepository importRepo, ImportManager importManager, IImportRepository importRepository, IClotheRepository clotheRepository)
        {
            _importRepo = importRepo;
            _importManager = importManager;
            _importRepository = importRepository;
            _clotheRepository = clotheRepository;
        }
        public async Task<ImportDto> CreateAsync(CreateImportDto input)
        {
            Guid id = new Guid("c1d90460-9d10-3849-9a35-3a0ce56c6108"); 
            var createImport = _importManager.Create(input.MaNCC, (Guid)(CurrentUser.Id == null ? id : CurrentUser.Id), input.TongTienNhap);

            await _importRepo.InsertAsync(createImport);

            return ObjectMapper.Map<Import, ImportDto>(createImport);
        }

        public async Task<PagedResultDto<ImportDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(Import.NgayNhap);
            }
            var importList = await _importRepo.GetListAsync(input.SkipCount, input.MaxResultCount, input.Sorting);

            return new PagedResultDto<ImportDto>(importList.Count, ObjectMapper.Map<List<Import>, List<ImportDto>>(importList));
        }

        public async Task<ImportDto> UpdateImportStatusAsync(CancelImportDto input)
        {
            var selectedImport = await _importRepo.FindAsync(input.MaPN);

            selectedImport.TinhTrangPX = "Đã hủy";

            await _importRepo.UpdateAsync(selectedImport, autoSave: true);

            return ObjectMapper.Map<Import, ImportDto>(selectedImport);
        }

        public async Task<ImportDto> UpdateAsync(Guid maPN, UpdateImportDto input)
        {
            var selectedImport = await _importRepo.GetAsync(maPN);

            Guid id = new Guid("c1d90460-9d10-3849-9a35-3a0ce56c6108");

            selectedImport.MaNCC = input.MaNCC;
            selectedImport.UserId = (Guid)(CurrentUser.Id == null ? id : CurrentUser.Id);
            selectedImport.TongTienNhap = input.TongTienNhap;

            await _importRepo.UpdateAsync(selectedImport);

            return ObjectMapper.Map<Import, ImportDto>(selectedImport);
        }

        public async Task<PagedResultDto<ToDisplayImportDto>> GetImportListToDisplay(PagedAndSortedResultRequestDto input)
        {
            var context = (MenClothingShopDbContext) (await _importRepo.GetDbContextAsync());
           
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(Import.NgayNhap);
            }

            var query = await (from import in context.Imports
                         join supplier in context.Suplliers
                         on import.MaNCC equals supplier.Id

                         select new ToDisplayImportDto
                         {
                             Id = import.Id,
                             UserId = import.UserId,
                             TenNCC = supplier.TenNCC,
                             NgayNhap = import.NgayNhap,
                             TongTienNhap = import.TongTienNhap,
                             TinhTrangPN = import.TinhTrangPX
                         }
                         ).Skip(input.SkipCount).Take(input.MaxResultCount).OrderBy(input.Sorting).ToListAsync();

            return new PagedResultDto<ToDisplayImportDto>(query.Count, query);
        }

        public async Task<ImportDto> GetImportAsync(Guid maPN)
        {
            return ObjectMapper.Map<Import, ImportDto>(await _importRepo.GetAsync(maPN));
        }
    }
}
