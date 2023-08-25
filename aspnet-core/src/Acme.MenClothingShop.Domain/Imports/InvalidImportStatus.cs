using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace Acme.MenClothingShop.Imports
{
    public class InvalidImportStatus : BusinessException
    {
        public InvalidImportStatus(string currentImportStatus) : base(MenClothingShopDomainErrorCodes.InvalidImportStatus)
        {
            WithData("status", currentImportStatus);
        }
    }
}
