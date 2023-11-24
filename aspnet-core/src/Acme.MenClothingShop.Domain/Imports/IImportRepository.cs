using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Acme.MenClothingShop.Imports
{
    public interface IImportRepository : IRepository<Import, Guid>
    {
        Task InsertAsync(Import import);

        Task UpdateAsync(Import import);

        Task<List<Import>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting
        );

        Task<IQueryable> GetImportListToDisplay(
            int skipCount,
            int maxResultCount,
            string sorting
        );
    }
}
