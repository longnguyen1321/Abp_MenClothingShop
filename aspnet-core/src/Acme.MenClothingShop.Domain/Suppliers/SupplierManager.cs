using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Acme.MenClothingShop.Suppliers
{
    public class SupplierManager : DomainService
    {
        IRepository<Supllier, Guid> _suppliersRepository;

        public SupplierManager(IRepository<Supllier, Guid> supplierRepository)
        {
            _suppliersRepository = supplierRepository;
        }

        public async Task<Supllier> CreateAsync([NotNull] string tenNCC, [CanBeNull] string diaChiNCC, [CanBeNull] string lienLacNCC)
        {
            if((await _suppliersRepository.FindAsync(x => x.TenNCC == tenNCC)) != null)
            {
                throw new SupplierNameAlreadyExistException(tenNCC);
            }

            return new Supllier(GuidGenerator.Create(), tenNCC, diaChiNCC, lienLacNCC);
        }

        public async Task<Supllier> ChangeNameAsync([NotNull] Supllier supllier, [NotNull] string newSupplierName)
        {
            if(supllier.TenNCC != newSupplierName && (await _suppliersRepository.FindAsync(x => x.TenNCC == newSupplierName)) != null)
            {
                throw new SupplierNameAlreadyExistException(newSupplierName);
            }

            return supllier.ChangeName(newSupplierName);
        }
    }
}
