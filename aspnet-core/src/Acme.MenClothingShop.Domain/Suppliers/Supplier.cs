using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace Acme.MenClothingShop.Suppliers
{
    public class Supllier: AggregateRoot<Guid>
    {

        public string TenNCC { get; set; }

        public string DiaChiNCC { get; set; }

        public string LienLacNCC { get; set; }

        public Supllier()
        {

        }

        public Supllier(Guid maNCC, string tenNCC, string diaChiNCC, string lienLacNCC): base(maNCC)
        {
            TenNCC = tenNCC;
            DiaChiNCC = diaChiNCC;
            LienLacNCC = lienLacNCC;
        }
    }
}
