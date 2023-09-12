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
            var context =  (MenClothingShopDbContext) await _exportDetailRepository.GetDbContextAsync(); 
                       
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
            
            return new PagedResultDto<ClotheStorageDto>(await context.Clothes.CountAsync(), list) ;
        }
    }
}
