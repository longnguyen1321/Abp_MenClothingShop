using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.MenClothingShop.Exports
{
    public class ExportDetail : Entity
    {
        protected ExportDetail() { }

        internal ExportDetail(Guid exportId, Guid clotheId, int soLuongXuat, Decimal giaXuat, Decimal thanhTienXuat)
        {
            ExportId = exportId;
            ClotheId = clotheId;
            SoLuongXuat = soLuongXuat;
            GiaXuat = giaXuat;
            ThanhTienXuat = thanhTienXuat;
        }

        public Guid ExportId { get; set; }

        public Guid ClotheId { get; set; }

        public int SoLuongXuat { get; set; }

        public decimal GiaXuat { get; set; }

        public decimal ThanhTienXuat { get; set; }

        public override Object[] GetKeys()
        {
            return new Object[] { ExportId, ClotheId };
        }
    }
}
