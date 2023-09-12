using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace Acme.MenClothingShop.Suppliers
{
    public class SupplierClothe : Entity
    {
        public Guid MaMH { get; set; }

        public Guid MaNCC { get; set; }

        public override object[] GetKeys()
        {
            throw new NotImplementedException();
        }
    }
}
