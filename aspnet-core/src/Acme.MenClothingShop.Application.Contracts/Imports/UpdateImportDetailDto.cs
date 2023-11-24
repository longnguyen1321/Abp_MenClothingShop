using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Acme.MenClothingShop.Imports
{
    public class UpdateImportDetailDto
    {
        [Required]
        public Guid MaPN { get; set; }

        [Required]
        public Guid MaMH { get; set; }

        [Required]
        public int SoLuongNhap { get; set; }

        [Required]
        public Decimal GiaNhap { get; set; }
    }
}
