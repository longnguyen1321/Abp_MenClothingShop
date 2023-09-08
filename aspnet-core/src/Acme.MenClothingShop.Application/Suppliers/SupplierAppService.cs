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
        public SupplierAppService(IRepository<Supllier, Guid> repository) : base(repository)
        {

        }
    }
}
