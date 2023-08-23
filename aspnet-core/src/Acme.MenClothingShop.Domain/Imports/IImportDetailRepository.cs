using Acme.MenClothingShop.Clothes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Threading;

namespace Acme.MenClothingShop.Imports
{
    public interface IImportDetailRepository : IRepository<ImportDetail>
    {
        //public Task InsertAsync() 
    }
}
