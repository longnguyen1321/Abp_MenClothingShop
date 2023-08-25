using Acme.MenClothingShop.Clothes;
using Acme.MenClothingShop.EntityFrameworkCore;
using Acme.MenClothingShop.Imports;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Acme.MenClothingShop.ImportDetails
{
    public class EfCoreImportDetailRepository : EfCoreRepository<MenClothingShopDbContext, ImportDetail>, IImportDetailRepository
    {
        public EfCoreImportDetailRepository(IDbContextProvider<MenClothingShopDbContext> dbContextProvider) : base(dbContextProvider)
        {
            
        }

        public async Task<List<Clothe>> GetClotheListAsync(int skipCount, int maxResultCount, string sorting)
        {
            var context = await GetDbContextAsync();
            List<Clothe> finalResult = new List<Clothe>();

            var query =  (context.Clothes.OrderBy((sorting == null || sorting == "") ? "x=>x.TenMH" : sorting).Skip(skipCount).Take(maxResultCount).Select(s => new Clothe
                         {
                             TenMH = s.TenMH,
                             SizeMH = s.SizeMH,
                             TonKho = s.TonKho,
                             SLTonKhoToiThieu = s.SLTonKhoToiThieu  
                         }));

            foreach(var item in query)
            {
                finalResult.Add(item);
            }

            return finalResult;
        }

        public async Task<List<ImportDetail>> GetListAsync(Guid maPN)
        {
            var context = await GetDbContextAsync();

            var finalResult = await context.ImportDetails.Where(c => c.MaPN == maPN).ToListAsync();

            return finalResult;
        }

        public override async Task InsertManyAsync(IEnumerable<ImportDetail> entities, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            var context = await GetDbContextAsync();
            
            await context.ImportDetails.AddRangeAsync(entities, cancellationToken);

            if (autoSave)
            {
                await context.SaveChangesAsync();
            }
        }
    }
}
