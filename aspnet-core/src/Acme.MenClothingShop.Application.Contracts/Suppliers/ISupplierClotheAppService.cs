using Acme.MenClothingShop.Clothes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.MenClothingShop.Suppliers
{
    public interface ISupplierClotheAppService : IApplicationService
    {
        public Task<SupplierClotheDto> CreateAsync(CreateSupplierClotheDto input);

        public Task DeleteAsync(DeleteSupplierClotheDto input);

    }
}
