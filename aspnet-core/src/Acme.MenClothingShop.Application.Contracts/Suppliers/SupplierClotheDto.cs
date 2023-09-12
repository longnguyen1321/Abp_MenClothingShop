using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Acme.MenClothingShop.Suppliers
{
    public class SupplierClotheDto : EntityDto
    {
        public Guid MaMH { get; set; }

        public Guid MaNCC { get; set; }
    }
}
