using System;
using System.Collections.Generic;
using System.Text;

namespace Acme.MenClothingShop.Exports
{
    public class ExportDto
    {
        public Guid UserId { get; set; }

        public DateTime NgayXuat { get; set; }

        public Decimal TongTienXuat { get; set; }

        public String TinhTrangPX { get; set; }

        public ExportReason LyDoXuat { get; set; } 
    }
}
