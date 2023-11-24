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
using Acme.MenClothingShop.Clothes;
using Acme.MenClothingShop.Imports;

namespace Acme.MenClothingShop.Suppliers
{
    public class EfCoreSupplierClotheRepository : EfCoreRepository<MenClothingShopDbContext, SupplierClothe>, ISupplierClotheRepository
    {
        public EfCoreSupplierClotheRepository(IDbContextProvider<MenClothingShopDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<SupplierClothe>> GetListAsync(int skipCount, int maxResultCount, string sorting)
        {
            var dbSet = await GetDbSetAsync();

            return await dbSet.OrderBy(sorting).Skip(skipCount).Take(maxResultCount).ToListAsync();
        }

        public async Task<List<SupplierClothe>> GetClotheListBySupplier(Guid maNCC, int skipCount, int maxResultCount, string sorting)
        {
            var dbSet = await GetDbSetAsync();

            return await dbSet.Where(x => x.MaNCC == maNCC).OrderBy(sorting).Skip(skipCount).Take(maxResultCount).ToListAsync();
        }
    }
}
