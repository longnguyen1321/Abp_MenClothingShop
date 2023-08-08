using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Acme.MenClothingShop.Exports
{
    public class CreateExportDto
    {
        [Required]
        public Decimal TongTienXuat { get; set; }

        [Required]
        public String TinhTrangPX { get; set; }

        [Required]
        public ExportReason LyDoXuat { get; set; } = ExportReason.BanHang;
    }
}
