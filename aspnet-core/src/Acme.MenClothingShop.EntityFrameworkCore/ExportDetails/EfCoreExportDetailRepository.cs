using Acme.MenClothingShop.Clothes;
using Acme.MenClothingShop.EntityFrameworkCore;
using Acme.MenClothingShop.Exports;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Acme.MenClothingShop.ExportDetails
{
    public class EfCoreExportDetailRepository: EfCoreRepository<MenClothingShopDbContext, ExportDetail>, IExportDetailRepository
    {
        public EfCoreExportDetailRepository(IDbContextProvider<MenClothingShopDbContext> dbContextProvider): base(dbContextProvider)
        {

        }
    }
}
