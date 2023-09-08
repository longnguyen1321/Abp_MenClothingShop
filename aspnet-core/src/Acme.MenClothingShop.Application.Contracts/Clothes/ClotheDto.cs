using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Acme.MenClothingShop.Clothes
{
    public class ClotheDto : AuditedEntityDto<Guid>
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
