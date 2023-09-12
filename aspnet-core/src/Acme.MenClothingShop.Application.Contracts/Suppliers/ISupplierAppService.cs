using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.MenClothingShop.Suppliers
{
    public interface ISupplierAppService : ICrudAppService< //Defines CRUD methods
            SupplierDto, //Used to show suppliers
            Guid, //Primary key of the supplier entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateSupplierDto> //Used to create/update a supplier
        {
        new Task<SupplierDto> CreateAsync(CreateUpdateSupplierDto input);

        new Task<SupplierDto> UpdateAsync(Guid id, CreateUpdateSupplierDto input);
    }
}
