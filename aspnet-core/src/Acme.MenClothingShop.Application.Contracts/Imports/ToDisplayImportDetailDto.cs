using System;
using System.Collections.Generic;
using System.Text;

namespace Acme.MenClothingShop.Imports
{
    public class ToDisplayImportDetailDto
    {
        public Guid MaMH { get; set; }

        public string TenMH { get; set; }

        public string SizeMH { get; set; }

        public int SoLuongNhap { get; set; }

        public decimal GiaNhap { get; set; }

        public decimal ThanhTienNhap { get; set; }
    }
}
