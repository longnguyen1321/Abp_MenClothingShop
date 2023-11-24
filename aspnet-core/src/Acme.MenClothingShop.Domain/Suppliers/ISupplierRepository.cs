using Acme.MenClothingShop.Clothes;
using Acme.MenClothingShop.Imports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Acme.MenClothingShop.Suppliers
{
    public interface ISupplierRepository : IRepository<Supllier, Guid>
    {
        public Task<List<Clothe>> GetSupplierClothesAsync(
            Guid maNCC,
            int skipCount,
            int maxResultCount,
            string sorting
        );

        public Task<List<Import>> GetSupplierImportsAsync(
            Guid maNCC,
            int skipCount,
            int maxResultCount,
            string sorting
        );
    }
}
