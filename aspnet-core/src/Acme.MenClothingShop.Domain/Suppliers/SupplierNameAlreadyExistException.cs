using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace Acme.MenClothingShop.Suppliers
{
    public class SupplierNameAlreadyExistException : BusinessException
    {
        public SupplierNameAlreadyExistException(string supplierName) : base(MenClothingShopDomainErrorCodes.SupplierNameAlreadyExist)
        {
            WithData("supplierName", supplierName);
        }
    }
}
