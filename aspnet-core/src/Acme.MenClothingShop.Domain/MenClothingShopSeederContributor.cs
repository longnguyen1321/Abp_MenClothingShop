using Acme.MenClothingShop.Clothes;
using Acme.MenClothingShop.Exports;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Volo.Abp.Users;

namespace Acme.MenClothingShop
{
    public class MenClothingShopDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Clothe, Guid> _clotheRepository;
        private readonly IdentityUserManager _userManager;
        private readonly IExportDetailRepository _exportDetailRepository;
        private readonly IExportRepository _exportRepository;
        private readonly ExportManager _exportManager;
        private readonly ExportDetailManager _exportDetailManager;

        public MenClothingShopDataSeederContributor(IRepository<Clothe, Guid> clotheRepository, IExportRepository exportRepository, IExportDetailRepository exportDetailRepository, ExportManager exportManager, ExportDetailManager exportDetailManager, IdentityUserManager userManager)
        {
            _clotheRepository = clotheRepository;
            _exportRepository = exportRepository;
            _exportDetailRepository = exportDetailRepository;
            _exportManager = exportManager;
            _exportDetailManager = exportDetailManager;
            _userManager = userManager;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _clotheRepository.GetCountAsync() <= 0)
            {
                await _clotheRepository.InsertAsync(
                    new Clothe
                    {
                        TenMH = "Áo len dài tay",
                        SizeMH = "L",
                        SoLuongMH = 10,
                        TonKho = 20,
                        SLTonKhoToiThieu = 10,
                        LoaiMH = ClotheType.AoLen,
                        GiaMH = 100000,
                        ChatLieuMH = ClotheMaterial.Cotton,
                        AnhMH = "",
                        MoTaMH = "Loại áo len có ống tay dài!"
                    },
                    autoSave: true
                );

                await _clotheRepository.InsertAsync(
                   new Clothe
                   {
                       TenMH = "Áo gió đen",
                       SizeMH = "S",
                       SoLuongMH = 10,
                       TonKho = 20,
                       SLTonKhoToiThieu = 10,
                       LoaiMH = ClotheType.AoGio,
                       GiaMH = 200000,
                       ChatLieuMH = ClotheMaterial.Acrylic,
                       AnhMH = "",
                       MoTaMH = "Áo khoác gió màu đen!"
                   },
                   autoSave: true
               );
            }
            if (await _exportDetailRepository.GetCountAsync() == 0 && await _exportRepository.GetCountAsync() == 0)
            {
                List<Export> exportList = new List<Export>();

                Guid key = new Guid("c1d90460-9d10-3849-9a35-3a0ce56c6108");

                List<Clothe> listClothe = await _clotheRepository.GetPagedListAsync(0, 2, "TenMH");
                var export1 = await _exportManager.CreateAsync(key, 100000, "Đã xuất", ExportReason.LyDoKhac);
                var export2 = await _exportManager.CreateAsync(key, 200000, "Đã xuất", ExportReason.LyDoKhac);

                exportList.Add(export1);
                exportList.Add(export2);

                await _exportRepository.InsertManyAsync(exportList,true);

                foreach (var clothes in listClothe)
                {
                    var clothe1 = await _exportDetailManager.CreateAsync(export1.Id, clothes.Id, 1, 50000, 50000);
                    var clothe2 = await _exportDetailManager.CreateAsync(export2.Id, clothes.Id, 1, 100000, 50000);

                    await _exportDetailRepository.InsertAsync(clothe1, autoSave: true);
                    await _exportDetailRepository.InsertAsync(clothe2, autoSave: true);
                }
            }
            
        }
    }
}
