using Acme.MenClothingShop.Clothes;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Acme.MenClothingShop.Exports
{
    public class ExportDetailManager: DomainService
    {
        private readonly IExportDetailRepository _exportDetailRepository;

        private readonly IRepository<Clothe, Guid> _clotheRepository;

        public ExportDetailManager(IRepository<Clothe,Guid> clotheRepository)
        {
            _clotheRepository = clotheRepository;
        }

        public async Task<ExportDetail> CreateAsync([NotNull] Guid maPX,[NotNull] Guid maMH, [NotNull] int soLuongXuat, [NotNull] decimal giaXuat, [NotNull] decimal thanhTienXuat)
        {
            Check.NotNullOrEmpty(maPX.ToString(), nameof(maPX));
            Check.NotNullOrEmpty(maMH.ToString(), nameof(maMH));
            Check.NotNullOrEmpty(soLuongXuat.ToString(), nameof(soLuongXuat));
            Check.NotNullOrEmpty(giaXuat.ToString(), nameof(giaXuat));
            Check.NotNullOrEmpty(giaXuat.ToString(), nameof(giaXuat));

            var queriedClothe = await _clotheRepository.FindAsync(c => c.Id == maMH);

            if(queriedClothe.TonKho < soLuongXuat)
            { 
                Exception ex = new Exception("Tồn kho mặt hàng ${maMH} không đủ");
                throw ex;
            }

            return new ExportDetail(maPX, maMH, soLuongXuat, giaXuat, thanhTienXuat);
        }

        public async Task<Clothe> UpdateInStoreClothe([NotNull] Guid maMH, [NotNull] int soLuongDaXuat, [NotNull] String operation)
        {
            Check.NotNull(maMH, nameof(maMH));

            var queriedClothe = await _clotheRepository.FindAsync(c => c.Id == maMH);

            if(operation == "add")
            {
                queriedClothe.TonKho += soLuongDaXuat;
            }
            else
            {
                queriedClothe.TonKho -= soLuongDaXuat;
            }

            return queriedClothe;
        }
    }
}
