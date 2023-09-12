using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Acme.MenClothingShop.Suppliers
{
    public class Supllier: AggregateRoot<Guid>
    {
        public string TenNCC { get; private set; }

        public string DiaChiNCC { get; set; }

        public string LienLacNCC { get; set; }

        public Supllier()
        {

        }

        public Supllier(Guid maNCC, [NotNull] string tenNCC, [CanBeNull] string diaChiNCC, [CanBeNull] string lienLacNCC): base(maNCC)
        {
            ChangeName(tenNCC);
            DiaChiNCC = diaChiNCC;
            LienLacNCC = lienLacNCC;
        }

        internal Supllier ChangeName([NotNull] string tenNCC)
        {
            SetName(tenNCC);
            return this;
        }

        private void SetName([NotNull] string tenNCC)
        {
            TenNCC = Check.NotNullOrWhiteSpace(
                tenNCC,
                nameof(tenNCC),
                maxLength: SupplierConsts.MaxNameLength
            );
        }
    }
}
