using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Acme.MenClothingShop.Exports
{
    public class CreateExportDetailDto
    {
        [Required]
        public Guid ExportId { get; set; }

        [Required]
        public Guid ClotheId { get; set; }

        [Required]
        public int SoLuongXuat { get; set; }

        [Required]
        public decimal GiaXuat { get; set; }

        [Required]
        public decimal ThanhTienXuat { get; set; }
    }
}
