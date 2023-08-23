using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Acme.MenClothingShop.Imports
{
    public interface IImportRepository : IRepository<Import>
    {
        Task InsertAsync(Import import);

        Task UpdateAsync(Import import);
    }
}
