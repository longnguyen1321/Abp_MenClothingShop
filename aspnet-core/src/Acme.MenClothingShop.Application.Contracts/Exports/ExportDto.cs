using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Acme.MenClothingShop.Exports
{
    public class ExportDto: EntityDto<Guid>
    {
        public Guid UserId { get; set; }

        public DateTime NgayXuat { get; set; }

        public Decimal TongTienXuat { get; set; }

        public String TinhTrangPX { get; set; }

        public ExportReason LyDoXuat { get; set; } 
    }
}
