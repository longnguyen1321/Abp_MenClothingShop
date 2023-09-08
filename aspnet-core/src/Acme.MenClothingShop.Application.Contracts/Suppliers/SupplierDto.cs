using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Acme.MenClothingShop.Suppliers
{
    public class SupplierDto : EntityDto<Guid>
    {
        public string TenNCC { get; set; }

        public string DiaChiNCC { get; set; }

        public string LienLacNCC { get; set; }
    }
}
