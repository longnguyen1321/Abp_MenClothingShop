using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace Acme.MenClothingShop.Suppliers
{
    public class SupplierAlreadyHasThisClotheException : BusinessException
    {
        public SupplierAlreadyHasThisClotheException(string clotheName) : base(MenClothingShopDomainErrorCodes.SupplierAlreadyHasThisClothe)
        {
            WithData("clotheName", clotheName);
        }
    }
}
