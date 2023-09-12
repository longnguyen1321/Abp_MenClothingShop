using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Acme.MenClothingShop.Suppliers
{
    public interface ISupplierClotheRepository : IRepository<SupplierClothe>
    {
        public Task<List<SupplierClothe>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting
            );
    }
}
