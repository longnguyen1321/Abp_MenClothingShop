using Acme.MenClothingShop.Clothes;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Acme.MenClothingShop.Suppliers
{
    public class SupplierClotheManager : DomainService
    {
        private readonly ISupplierClotheRepository _supplierClotheRepository;
        private readonly IClotheRepository _clotheRepository;
        public SupplierClotheManager(ISupplierClotheRepository supplierClotheRepository, IClotheRepository clotheRepository)
        {
            _supplierClotheRepository = supplierClotheRepository;
            _clotheRepository = clotheRepository;
        }

        public async Task<SupplierClothe> CreateAsync([NotNull]Guid maNCC, [NotNull] Guid maMH)
        {
            var foundSupplieClothe = await _supplierClotheRepository.FindAsync(x =>  x.MaNCC == maNCC && x.MaMH == maMH );

            if (foundSupplieClothe != null)
            {
                var clothe = await _clotheRepository.FindAsync(maMH);
                throw new SupplierAlreadyHasThisClotheException(clothe.TenMH);
            }

            return new SupplierClothe
            {
                MaNCC = maNCC,
                MaMH = maMH
            };
        }
    }
}
