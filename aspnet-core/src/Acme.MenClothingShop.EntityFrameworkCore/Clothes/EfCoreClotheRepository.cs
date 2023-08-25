using Acme.MenClothingShop.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
