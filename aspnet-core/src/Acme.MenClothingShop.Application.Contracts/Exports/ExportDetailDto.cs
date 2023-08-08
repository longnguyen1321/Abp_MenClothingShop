using System;
using System.Collections.Generic;
using System.Text;

namespace Acme.MenClothingShop.Exports
{
    public class ExportDetailDto
    {
        public Guid ExportId { get; set; }

        public Guid ClotheId { get; set; }

        public int SoLuongXuat { get; set; }

        public decimal GiaXuat { get; set; }

        public decimal ThanhTienXuat { get; set; }
    }
}
