using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Acme.MenClothingShop.Suppliers
{
    public class SupplierClotheAppService : ApplicationService, ISupplierClotheAppService
    {
        private readonly ISupplierClotheRepository _supplierClotheRepository;
        private readonly SupplierClotheManager _supplierClotheManager;
        
        public SupplierClotheAppService(ISupplierClotheRepository supplierClotheRepository, SupplierClotheManager supplierClotheManager)
        {
            _supplierClotheManager = supplierClotheManager;
            _supplierClotheRepository = supplierClotheRepository;
        }

        public async Task<SupplierClotheDto> CreateAsync(CreateSupplierClotheDto input)
        {
            var createSupplierClothe = await _supplierClotheRepository.InsertAsync(await _supplierClotheManager.CreateAsync(input.MaNCC, input.MaMH), autoSave: true);

            return ObjectMapper.Map<SupplierClothe, SupplierClotheDto>(createSupplierClothe);
        }

        public async Task DeleteAsync(DeleteSupplierClotheDto input)
        {
            var foundSupplierClothe = await _supplierClotheRepository.FindAsync(x => x.MaNCC == input.MaNCC && x.MaMH == input.MaMH);

            await _supplierClotheRepository.DeleteAsync(foundSupplierClothe, autoSave: true);
        }
    }
}
