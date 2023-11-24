using Acme.MenClothingShop.Clothes;
using Acme.MenClothingShop.EntityFrameworkCore;
using Acme.MenClothingShop.Suppliers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Acme.MenClothingShop.Imports
{
    public class ImportDetailAppService : ApplicationService, IImportDetailAppService
    {
        IImportDetailRepository _importDetailRepo;
        IClotheRepository _clotheRepo;
        ISupplierClotheRepository _supplierClotheRepository;

        ImportDetailManager _importDetailManager;


        public ImportDetailAppService(IImportDetailRepository importDetailRepository, IClotheRepository clotheRepo, ClotheManager clotheManager, ImportDetailManager importDetailManager, ISupplierClotheRepository supplierClotheRepository)
        {
            _importDetailRepo = importDetailRepository;
            _clotheRepo = clotheRepo;
            _importDetailManager = importDetailManager;
            _supplierClotheRepository = supplierClotheRepository;
        }

        public async Task<List<ToDisplayImportDetailDto>> GetImportDetailListToDisplay(Guid maMH)
        {
            var context = (MenClothingShopDbContext) await _importDetailRepo.GetDbContextAsync();

            var result = await (from impDetail in context.ImportDetails
                          join clothe in context.Clothes
                          on impDetail.MaMH equals clothe.Id
                          where impDetail.MaPN == maMH
                          select new ToDisplayImportDetailDto
                          {
                              MaMH = clothe.Id,
                              TenMH = clothe.TenMH,
                              SizeMH = clothe.SizeMH,
                              SoLuongNhap = impDetail.SoLuongNhap,
                              GiaNhap = impDetail.GiaNhap,
                              ThanhTienNhap = impDetail.ThanhTienNhap
                          }
                          ).ToListAsync();
            
            return result;
        }

        public async Task CreateAsync(CreateManyImportDetailsDto impClotheList)
        {
            foreach(var item in impClotheList.ImportDetails)
            {
                var createdDetail = _importDetailManager.Create(item.MaPN, item.MaMH, item.SoLuongNhap, item.GiaNhap); //Tạo Entity mới

                var selectedClothe = await _clotheRepo.FindAsync(item.MaMH);

                await _importDetailManager.UpdateClotheStorageAsync(selectedClothe, item.MaPN, item.SoLuongNhap); //Update trong thuộc tính TonKho của mặt hàng

                await _clotheRepo.UpdateAsync(selectedClothe, autoSave: true); //Update trong CSDL

                await _importDetailRepo.InsertAsync(createdDetail, autoSave: true);  

            }
        }

        public async Task UpdateImportClotheStorageAsync(Guid maPN)
        {
            var importDetailList = await _importDetailRepo.GetListAsync(maPN);

            foreach(var item in importDetailList)
            {
                var selectedClothe = await _clotheRepo.FindAsync(item.MaMH); //Tìm mặt hàng Clothe theo mã trong ChiTietPN

                await _importDetailManager.UpdateClotheStorageAsync(selectedClothe, maPN, item.SoLuongNhap); //Kiểm tra tình trạng phiếu nhập và Update trong thuộc tính TonKho của mặt hàng

                await _clotheRepo.UpdateAsync(selectedClothe, autoSave: true); //Update trong CSDL
            }
        }

        public async Task UpdateAsync(Guid maPN, UpdateManyImportDetailDto input)
        {
            foreach(var item in input.ImportDetails)
            {
                var oldImportDetail = await _importDetailRepo.FindAsync(x => x.MaPN == item.MaPN && x.MaMH == item.MaMH);

                //Nếu tồn tại
                if (oldImportDetail != null)
                {
                    var oldImportQuantity = oldImportDetail.SoLuongNhap;
                    var newImportQuantity = item.SoLuongNhap;

                    //Update tồn kho mặt hàng dựa trên chênh lệch giữa SoLuongNhap mới và SoLuongNhap cũ
                    var importedClothe = await _clotheRepo.FindAsync(item.MaMH);
                    await _importDetailManager.UpdateClotheStorageAsync(importedClothe, item.MaPN, newImportQuantity - oldImportQuantity) ;

                    //Update tồn kho trong CSDL
                    await _clotheRepo.UpdateAsync(importedClothe, autoSave: true); 

                    //Update ChiTietPN
                    oldImportDetail.SoLuongNhap = item.SoLuongNhap;
                    oldImportDetail.GiaNhap = item.GiaNhap;
                    oldImportDetail.ThanhTienNhap = Math.Round(oldImportDetail.SoLuongNhap * oldImportDetail.GiaNhap, 2);

                    await _importDetailRepo.UpdateAsync(oldImportDetail, autoSave: true);
                }
                else
                {
                    await _importDetailRepo.InsertAsync(_importDetailManager.Create(item.MaPN, item.MaMH, item.SoLuongNhap, item.GiaNhap), autoSave: true);

                    var importedClothe = await _clotheRepo.FindAsync(item.MaMH);

                    await _importDetailManager.UpdateClotheStorageAsync(importedClothe, item.MaPN, item.SoLuongNhap);

                    await _clotheRepo.UpdateAsync(importedClothe, autoSave: true);
                }
            }

            //Xóa những mặt hàng cũ không được chọn
            var oldImportDetailList = await _importDetailRepo.GetListAsync(maPN);

            foreach(var item in oldImportDetailList)
            {
                var importDetail = input.ImportDetails.Find(x => x.MaMH == item.MaMH);

                if(importDetail == null)
                {
                    await _importDetailRepo.DeleteAsync(x => x.MaMH == item.MaMH && x.MaPN == maPN);
                }
            }
        }
    }
}
