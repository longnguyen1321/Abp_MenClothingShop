using Acme.MenClothingShop.Clothes;
using Microsoft.Extensions.Configuration.UserSecrets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Acme.MenClothingShop.Imports
{
    public class ImportDetailManager : DomainService
    {
        IClotheRepository _clotheRepo;
        IImportDetailRepository _importDetailRepo;
        IImportRepository _importRepository;
        ClotheManager _clotheManager;
        public ImportDetailManager(IClotheRepository clotheRepo, IImportDetailRepository importDetailRepo, IImportRepository importRepository, ClotheManager clotheManager)
        {
            _clotheRepo = clotheRepo;
            _importDetailRepo = importDetailRepo;
            _importRepository = importRepository;
            _clotheManager = clotheManager;
        }
        public ImportDetail Create(Guid maPN, Guid maMH, int soLuongNhap, Decimal giaNhap)
        {
            decimal thanhTien = Math.Round(soLuongNhap * giaNhap, 2);
            return new ImportDetail
            {
                MaPN = maPN,
                MaMH = maMH,
                SoLuongNhap = soLuongNhap,
                GiaNhap = giaNhap,
                ThanhTienNhap = thanhTien,
            };
        }

        public async Task UpdateClotheStorageAsync(Clothe selectedClothe, Guid maPN, int soLuongNhap)
        {
            var selectedImport = await _importRepository.FindAsync(maPN);

            //Kiểm tra tình trạng phiếu nhập 
            if(selectedImport.TinhTrangPX == "Đã hủy")
            {
                throw new InvalidImportStatus(selectedImport.TinhTrangPX);
            }
            else
            {
                _clotheManager.UpdateClotheStorage(selectedClothe, soLuongNhap);
            }
        }
    }
}
