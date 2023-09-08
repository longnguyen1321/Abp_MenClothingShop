using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Acme.MenClothingShop.Clothes
{
    public interface IClotheRepository : IRepository<Clothe, Guid>
    {
        public Task<List<Clothe>> GetClotheListAsync(int skipCount, int maxResultCount, string sorting);
    }
}
