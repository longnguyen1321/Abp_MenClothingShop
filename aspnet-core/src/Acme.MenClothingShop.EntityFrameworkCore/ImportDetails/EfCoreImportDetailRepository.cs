using Acme.MenClothingShop.EntityFrameworkCore;
using Acme.MenClothingShop.Imports;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Acme.MenClothingShop.ImportDetails
{
    public class EfCoreImportDetailRepository : EfCoreRepository<MenClothingShopDbContext, ImportDetail>, IImportDetailRepository
    {
        public EfCoreImportDetailRepository(IDbContextProvider<MenClothingShopDbContext> dbContextProvider ) : base(dbContextProvider)
        {
            
        }

        public override Task InsertManyAsync(IEnumerable<ImportDetail> entities, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            return base.InsertManyAsync(entities, autoSave, cancellationToken);
        }
    }
}
