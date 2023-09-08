using Acme.MenClothingShop.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Acme.MenClothingShop.Clothes
{
    public class EfCoreClotheRepository : EfCoreRepository<MenClothingShopDbContext, Clothe, Guid>, IClotheRepository
    {
        public EfCoreClotheRepository(IDbContextProvider<MenClothingShopDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }

        public async Task<List<Clothe>> GetClotheListAsync(int skipCount, int maxResultCount, string sorting)
        {
            var context = await GetDbContextAsync();

            return await context.Clothes.OrderBy(sorting.IsNullOrWhiteSpace() ? "x=>x.tenMH" : sorting).Skip(skipCount).Take(maxResultCount).ToListAsync();          
        }
    }
}
