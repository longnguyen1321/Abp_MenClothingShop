using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Acme.MenClothingShop.Clothes
{
    public class ClotheManager : DomainService
    {
        IClotheRepository _clotheRepo;

        public ClotheManager(IClotheRepository clotheRepo)
        {
            _clotheRepo = clotheRepo;
        }

        public void UpdateClotheStorage(Clothe selectedClotheE,int soLuongThayDoi)
        {
             selectedClotheE.TonKho += soLuongThayDoi;
        }

        public Clothe CreateSimplpeClothe([NotNull] Guid maMH, [CanBeNull] String? tenMH = "", [CanBeNull] String? sizeMH = "", [CanBeNull] int? soLuongMH = 0, [CanBeNull] int? tonKho = 0, [CanBeNull] int? sLTonKhoToiThieu = 0, [CanBeNull] ClotheType? loaiMH = 0, [CanBeNull] Decimal? giaMH = 0, [CanBeNull] ClotheMaterial chatLieuMH = 0, [CanBeNull] string? anhMH = "", [CanBeNull] string? moTaMH = "")
        {
            return new Clothe(maMH)
            {
                TenMH = tenMH,
                SizeMH = sizeMH,
                SoLuongMH = (int)soLuongMH,
                TonKho = (int)tonKho,
                SLTonKhoToiThieu = (int)sLTonKhoToiThieu,
                LoaiMH = (ClotheType)loaiMH,
                GiaMH = (decimal)giaMH,
                ChatLieuMH = chatLieuMH,
                AnhMH = anhMH,
                MoTaMH = moTaMH
            };
        }
    }
}
