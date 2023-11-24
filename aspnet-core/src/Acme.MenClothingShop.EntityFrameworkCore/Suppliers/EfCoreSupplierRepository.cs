using Acme.MenClothingShop.Clothes;
using Acme.MenClothingShop.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using Acme.MenClothingShop.Imports;

namespace Acme.MenClothingShop.Suppliers
{
    public class EfCoreSupplierRepository : EfCoreRepository<MenClothingShopDbContext, Supllier, Guid>, ISupplierRepository
    {
        private readonly IClotheRepository _clotheRepository;
        private readonly ISupplierClotheRepository _supplierClotheRepository;
        private readonly ClotheManager _clotheManager;
        private readonly ImportManager _importManager;
        public EfCoreSupplierRepository(IDbContextProvider<MenClothingShopDbContext> dbContextProvider, IClotheRepository clotheRepository, ISupplierClotheRepository supplierClotheRepository, ClotheManager clotheManager, ImportManager importManager) : base(dbContextProvider)
        {
            _clotheRepository = clotheRepository;
            _supplierClotheRepository = supplierClotheRepository;
            _clotheManager = clotheManager;
            _importManager = importManager;
        }

        public async Task<List<Clothe>> GetSupplierClothesAsync(Guid maNCC,int skipCount, int maxResultCount, string sorting)
        {
            var context = await GetDbContextAsync();

            var clotheList = await (from supplierClothe in context.SupplierClothes
            join clothe in context.Clothes
            on supplierClothe.MaMH equals clothe.Id
            where supplierClothe.MaNCC == maNCC
            select new
            {
                Id = clothe.Id,
                TenMH = clothe.TenMH,
                SizeMH = clothe.SizeMH,
                TonKho = clothe.TonKho,
                SLTonKhoToiThieu = clothe.SLTonKhoToiThieu

            }).OrderBy(sorting).Skip(skipCount).Take(maxResultCount).ToListAsync();

            List<Clothe> result = new List<Clothe>();

            foreach(var item in clotheList)
            {
                result.Add(_clotheManager.CreateSimplpeClothe(item.Id, item.TenMH, item.SizeMH, tonKho: item.TonKho, sLTonKhoToiThieu: item.SLTonKhoToiThieu));
            }

            return result;
        }

        public async Task<List<Import>> GetSupplierImportsAsync(Guid maNCC, int skipCount, int maxResultCount, string sorting)
        {
            var context = await GetDbContextAsync();

            var importList = await (from supplier in context.Suplliers
                              join import in context.Imports
                              on supplier.Id equals import.MaNCC
                              where supplier.Id == maNCC
                              select new
                              {
                                  Id = import.Id,
                                  NgayNhap = import.NgayNhap,
                              }).OrderBy(sorting).Skip(skipCount).Take(maxResultCount).ToListAsync();

            List<Import> result = new List<Import>();

            foreach(var item in importList)
            {
                result.Add(_importManager.CreateSimpleImport(item.Id, ngayNhap: item.NgayNhap));
            }

            return result;
        }
    }
}
