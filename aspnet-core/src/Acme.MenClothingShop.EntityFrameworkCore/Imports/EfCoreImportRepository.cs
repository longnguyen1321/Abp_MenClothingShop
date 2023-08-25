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

namespace Acme.MenClothingShop.Imports
{
    public class EfCoreImportRepository : EfCoreRepository<MenClothingShopDbContext, Import, Guid>, IImportRepository
    {     
        public EfCoreImportRepository(IDbContextProvider<MenClothingShopDbContext> dbContextProvider) : base(dbContextProvider)
        {
            
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
    }
}
