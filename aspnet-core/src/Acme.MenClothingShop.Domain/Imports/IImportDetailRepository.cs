using Acme.MenClothingShop.Clothes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Threading;

namespace Acme.MenClothingShop.Imports
{
    public interface IImportDetailRepository : IRepository<ImportDetail>
    {

        public new Task InsertManyAsync(IEnumerable<ImportDetail> entities, bool autoSave = false, CancellationToken cancellationToken = default);

        public Task<List<ImportDetail>> GetListAsync(Guid maMH);
    }
}
