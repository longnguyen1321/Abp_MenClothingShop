using Acme.MenClothingShop.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.EntityFrameworkCore;

namespace Acme.MenClothingShop.Suppliers
{
    public class SupplierAppService :
        CrudAppService<
            Supllier, //The supplier entity
            SupplierDto, //Used to show suppliers
            Guid, //Primary key of the supplier entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateSupplierDto>, //Used to create/update a supplier
        ISupplierAppService //implement the ISupplierAppService
    {
        private readonly SupplierManager _supplierManager;
        public SupplierAppService(IRepository<Supllier, Guid> repository, SupplierManager supplierManager) : base(repository)
        {
            _supplierManager = supplierManager;
        }

        public override async Task<SupplierDto> CreateAsync(CreateUpdateSupplierDto input)
        {
            var createdSupplier = await _supplierManager.CreateAsync(input.TenNCC, input.DiaChiNCC, input.LienLacNCC);

            return ObjectMapper.Map<Supllier, SupplierDto>(await this.Repository.InsertAsync(createdSupplier, autoSave: true));
        }

        public override async Task<SupplierDto> UpdateAsync(Guid id, CreateUpdateSupplierDto input)
        {
            var foundSupplier = await this.Repository.FindAsync(id);

            await _supplierManager.ChangeNameAsync(foundSupplier, input.TenNCC);
            foundSupplier.DiaChiNCC = input.DiaChiNCC;
            foundSupplier.LienLacNCC = input.LienLacNCC;

            await this.Repository.UpdateAsync(foundSupplier, autoSave: true);

            return ObjectMapper.Map<Supllier, SupplierDto>(foundSupplier);
        }
    }
}
