using Acme.MenClothingShop.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Acme.MenClothingShop.Exports
{
    public class EfCoreExportRepository: EfCoreRepository<MenClothingShopDbContext, Export, Guid>, IExportRepository
    {
        public EfCoreExportRepository(IDbContextProvider<MenClothingShopDbContext> dbContextProvider): base(dbContextProvider)
        {

        }


    }
}
