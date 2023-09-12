using Acme.MenClothingShop.Clothes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using static Volo.Abp.UI.Navigation.DefaultMenuNames.Application;

namespace Acme.MenClothingShop.Imports
{
    public class ImportDetailAppService : ApplicationService, IImportDetailAppService
    {
        IImportDetailRepository _importDetailRepo;
        ClotheManager _clotheManager;
        ImportDetailManager _importDetailManager;
        IClotheRepository _clotheRepo;
        

        public ImportDetailAppService(IImportDetailRepository importDetailRepository, IClotheRepository clotheRepo, ClotheManager clotheManager, ImportDetailManager importDetailManager)
        {
            _importDetailRepo = importDetailRepository;
            _clotheRepo = clotheRepo;
            _clotheManager = clotheManager;
            _importDetailManager = importDetailManager;
        }

        public async Task CreateAsync(CreateManyImportDetailsDto impClotheList)
        {
            foreach(var item in impClotheList.ImportDetails)
            {
                var createdDetail = _importDetailManager.Create(item.MaPN, item.MaMH, item.SoLuongNhap, item.GiaNhap); //Tạo Entity mới

                var selectedClothe = await _clotheRepo.FindAsync(item.MaMH);

                await _importDetailManager.UpdateClotheStorageAsync(selectedClothe, item.MaPN, item.SoLuongNhap, "create"); //Update trong thuộc tính TonKho của mặt hàng

                await _clotheRepo.UpdateAsync(selectedClothe, autoSave: true); //Update trong CSDL

                await _importDetailRepo.InsertAsync(createdDetail, autoSave: true);  

            }
        }

        public async Task UpdateAsync(Guid maPN)
        {
            var importDetailList = await _importDetailRepo.GetListAsync(maPN);

            foreach(var item in importDetailList)
            {
                var selectedClothe = await _clotheRepo.FindAsync(item.MaMH); //Tìm mặt hàng Clothe theo mã trong ChiTietPN

                await _importDetailManager.UpdateClotheStorageAsync(selectedClothe, maPN, item.SoLuongNhap, "cancel"); //Kiểm tra tình trạng phiếu nhập và Update trong thuộc tính TonKho của mặt hàng

                await _clotheRepo.UpdateAsync(selectedClothe, autoSave: true); //Update trong CSDL
            }
        }

        public async Task<PagedResultDto<ImportClotheListDto>> GetClotheList(GetClotheListDto input)
        {
            List<Clothe> impClotheList = await _clotheRepo.GetClotheListAsync(input.SkipCount, input.MaxResultCount, input.Sorting); 

            return new PagedResultDto<ImportClotheListDto>(impClotheList.Count, ObjectMapper.Map<List<Clothe>, List<ImportClotheListDto>>(impClotheList)); 
        }
    }
}
