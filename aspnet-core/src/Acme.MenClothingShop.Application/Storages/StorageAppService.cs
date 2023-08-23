using Acme.MenClothingShop.Clothes;
using Acme.MenClothingShop.Data;
using Acme.MenClothingShop.EntityFrameworkCore;
using Acme.MenClothingShop.Exports;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.SettingManagement;
using static Acme.MenClothingShop.Permissions.MenClothingShopPermissions;

namespace Acme.MenClothingShop.Storages
{
    public class StorageAppService : MenClothingShopAppService, IStorageAppService
    {
        private readonly IExportDetailRepository _exportDetailRepository;
        public StorageAppService(IExportDetailRepository exportDetailRepository)
        {
            _exportDetailRepository = exportDetailRepository;
        }
        public  async Task<PagedResultDto<ClotheStorageDto>> GetAsync(GetClotheStorageListDto input)
        {
            var context =  (MenClothingShopDbContext) await _exportDetailRepository.GetDbContextAsync(); /*
            var clotheStorageList = await context.Clothes.GroupJoin(context.ImportDetails, clothe1 => clothe1.Id, importedClothe => importedClothe.MaMH, (clothe1, importedClothe) => new
            {
                
                ClotheName = clothe1.TenMH,
                ClotheStatus = clothe1.SizeMH,
                ClotheImportedQuantity = importedClothe.ToList()
            }).GroupJoin(context.ExportDetails, clothe2 => clothe2.ClotheName.Id, exportedClothe => exportedClothe.ClotheId, (clothe2, exportedClothe) => new
            {
                ClotheId2 = clothe2, 
                ClotheExportedQuantity = exportedClothe.ToList()
            }).Select(selector => new ClotheStorageDto                  
            {
                TenMH = selector.clothe2.clothe1.TenMH,
                TonKho = selector.clothe2.clothe1.TonKho,
                TinhTrangMH = selector.clothe2.clothe1.SizeMH,
                TongNhapThangMH = selector.clothe2.clothe1.TonKho,//selector.clothe2.ImportDetails.Sum(s => s.SoLuongNhap) == null ? 0 : selector.clothe2.ImportDetails.Sum(s => s.SoLuongNhap),
                TongXuatThangMH = selector.clothe2.clothe1.TonKho//selector.ExportDetails.Sum(e => e.SoLuongXuat) == null ? 0 : selector.ExportDetails.Sum(e => e.SoLuongXuat)
            }).OrderBy(input.Sorting)
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount)
                .ToListAsync();

            */

            /*
            var clotheStorageDtoList = await context.Clothes.GroupJoin(context.ImportDetails, clothe1 => clothe1.Id, importedClothe => importedClothe.MaMH, (clothe1, importedClothe) => new
            {
                clothe1,
                ImportDetails = importedClothe.ToList(),
            }).GroupJoin(context.ExportDetails, clothe2 => clothe2.clothe1.Id, exportedClothe => exportedClothe.ClotheId, (clothe2, exportedClothe) => new 
            {
                clothe2, 
                ExportDetails = exportedClothe
            }).Select(selector => new ClotheStorageDto                  
            {
                TenMH = selector.clothe2.clothe1.TenMH, 
                TonKho = selector.ExportDetails.Sum(x => x.SoLuongXuat),
                TinhTrangMH = selector.clothe2.clothe1.SizeMH,
                TongNhapThangMH = selector.clothe2.clothe1.TonKho,//selector.clothe2.ImportDetails.Sum(s => s.SoLuongNhap) == null ? 0 : selector.clothe2.ImportDetails.Sum(s => s.SoLuongNhap),
                TongXuatThangMH = selector.clothe2.clothe1.TonKho//selector.ExportDetails.Sum(e => e.SoLuongXuat) == null ? 0 : selector.ExportDetails.Sum(e => e.SoLuongXuat)
            }).ToListAsync(); */ /*.Select(s => new
                         
            {
                Ma = s.clothe2.clothe1.Id,
                Ten = s.clothe2.clothe1.TenMH,
                TonKho = s.clothe2.clothe1.TonKho,
                TinhTrang = s.clothe2.clothe1.SizeMH,
                SLXuat = s.exportedClothe.SoLuongXuat,
                SLNhap = s.clothe2.importedClothe.SoLuongNhap
            })*/ /*
            var clotheStorageDtoList = await context.Clothes.Join(context.ImportDetails, clothe1 => clothe1.Id, importedClothe => importedClothe.MaMH, (clothe1, importedClothe) => new
            {
                clothe1,
                ImportDetails = importedClothe
            }).Join(context.ExportDetails, clothe2 => clothe2.clothe1.Id, exportedClothe => exportedClothe.ClotheId, (clothe2, exportedClothe) => new
            {
                clothe2,
                exportedClothe
            }).GroupBy(gs => new { gs.clothe2.clothe1.Id, gs.clothe2.clothe1.TenMH, gs.clothe2.clothe1.TonKho, gs.clothe2.clothe1.SLTonKhoToiThieu }).OrderBy(o => o.Key    ).Select(lSelector => new ClotheStorageDto
            {
                TongNhapThangMH = lSelector.Sum(im => im.clothe2.ImportDetails.SoLuongNhap),
                TongXuatThangMH = lSelector.Sum(ex => ex.exportedClothe.SoLuongXuat),
                TenMH = lSelector.Key.TenMH,
                TonKho = lSelector.Key.TonKho,
                TinhTrangMH = lSelector.Key.TenMH//lSelector.Key.SLTonKhoToiThieu < lSelector.Key.TonKho ? "Cần bổ sung" : "Còn hàng"
            }).ToListAsync();  */
            /*
            var clotheStorageDtoList2 = context.Clothes.Select(t => new ClotheStorageDto
            {
                TongNhapThangMH = t.SoLuongMH,
                TongXuatThangMH = t.SoLuongMH,
                TonKho = t.TonKho,
                TenMH = t.TenMH,
                TinhTrangMH = t.SizeMH
            }).ToList();*/
            
            var clotheStorageDtoList1 =(from clothe in context.Clothes
                                       join imp in context.ImportDetails
                                       on clothe.Id equals imp.MaMH into importedClothe
                                       
                                       from imp in importedClothe.DefaultIfEmpty()                                       
                                       join exp in context.ExportDetails
                                       on clothe.Id equals exp.ClotheId into exportedClothe

                                       from exp in exportedClothe.DefaultIfEmpty()                                        
                                       select new 
                                       {
                                           MaMH = clothe.Id,
                                           SLNhap = (imp == null ? 0 : imp.SoLuongNhap),
                                           SLXuat = (exp == null ? 0 : exp.SoLuongXuat),//importedClothe.ToList().Sum(x => x.SoLuongNhap),
                                           TonKho = clothe.TonKho,
                                           TenMH = clothe.TenMH,
                                           TinhTrangMH = clothe.TonKho < clothe.SLTonKhoToiThieu ? "Cần bổ sung!" : "Còn hàng"
                                       } into x
                                       group x by new { x.MaMH, x.TenMH, x.TonKho, x.TinhTrangMH } into y 
                                       select new ClotheStorageDto
                                       {
                                           TongNhapThangMH = y.Sum(q => q.SLNhap),
                                           TongXuatThangMH = y.Sum(w => w.SLXuat),
                                           TonKho = y.Key.TonKho,
                                           TenMH = y.Key.TenMH,
                                           TinhTrangMH = y.Key.TinhTrangMH
                                       });
            List<ClotheStorageDto> list = new List<ClotheStorageDto>();
            foreach(var t in clotheStorageDtoList1)
            {
                list.Add(t);
            } 
            /*List<ClotheStorageDto> list = new List<ClotheStorageDto>();
            foreach(var clothe in clotheStorageDtoList)
            {
                list.Add(new ClotheStorageDto
                {
                    TongNhapThangMH = 10,//clothe.ImportedClothe.Sum(x => x.SoLuongNhap),
                    TongXuatThangMH = 10,//importedClothe.Sum(x => x.SoLuongNhap),
                    TonKho = clothe.TonKho,
                    TenMH = clothe.TenMH,
                    TinhTrangMH = clothe.TonKho < clothe.SLTonKhoToiThieu ? "Cần bổ sung!" : "Còn hàng"
                });
            }*/
            return new PagedResultDto<ClotheStorageDto>(await context.Clothes.CountAsync(), list) ;
        }
    }
}
