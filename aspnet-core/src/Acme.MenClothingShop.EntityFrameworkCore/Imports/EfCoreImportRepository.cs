using Acme.MenClothingShop.EntityFrameworkCore;
using Acme.MenClothingShop.Exports;
using Acme.MenClothingShop.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using Acme.MenClothingShop.Clothes;

namespace Acme.MenClothingShop.Imports
{
    public class EfCoreImportRepository : EfCoreRepository<MenClothingShopDbContext, Import, Guid>, IImportRepository
    {     
        public EfCoreImportRepository(IDbContextProvider<MenClothingShopDbContext> dbContextProvider) : base(dbContextProvider)
        {
            
        }

        public async Task<List<Import>> GetListAsync(int skipCount, int maxResultCount, string sorting)
        {
            var dbSet = await GetDbSetAsync();

            return await dbSet
                .OrderBy(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }

        public async Task InsertAsync(Import import)
        {
            MenClothingShopDbContext context =  await GetDbContextAsync();

            await context.Imports.AddAsync(import);

            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Import import)
        {
            var context = await GetDbContextAsync();

            context.Imports.Update(import);

            await context.SaveChangesAsync();
        }

        public async Task<IQueryable> GetImportListToDisplay(int skipCount, int maxResultCount, string sorting)
        {
            var context = await GetDbContextAsync();

            var query = (from import in context.Imports
                         join supplier in context.Suplliers
                         on import.Id equals supplier.Id

                         select new
                         {
                             MaPN = import.Id,
                             UserId = import.UserId,
                             TenNCC = supplier.TenNCC,
                             NgayNhap = import.NgayNhap,
                             TongTienNhap = import.TongTienNhap,
                             TinhTrangPN = import.TinhTrangPX
                         }
                         ).OrderBy(sorting).Skip(skipCount).Take(maxResultCount);

            return query;
        }
    }
}
