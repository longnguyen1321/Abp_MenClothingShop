using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.MenClothingShop.Clothes
{
    public class Clothe : AuditedAggregateRoot<Guid>
    {
        public String TenMH { get; set; }

        public String SizeMH { get; set; }

        public int SoLuongMH { get; set; }

        public int TonKho { get; set; }

        public int SLTonKhoToiThieu { get; set; }

        public ClotheType LoaiMH { get; set; }

        public Decimal GiaMH { get; set; }

        public ClotheMaterial ChatLieuMH { get; set; }

        public String AnhMH { get; set; }

        public String MoTaMH { get; set; }
    }
}
