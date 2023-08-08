using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Acme.MenClothingShop.Clothes
{
    public class CreateUpdateClotheDto
    {
        [Required]
        [StringLength(128)]
        public String TenMH { get; set; }

        [Required]
        public String SizeMH { get; set; }

        [Required]
        public int SoLuongMH { get; set; }

        [Required]
        public int TonKho { get; set; }

        [Required]
        public int SLTonKhoToiThieu { get; set; }

        [Required]
        public ClotheType LoaiMH { get; set; } = ClotheType.Undefined;

        [Required]
        public Decimal GiaMH { get; set; }

        [Required]
        public ClotheMaterial ChatLieuMH { get; set; } = ClotheMaterial.Undefined;

        public String AnhMH { get; set; }

        [Required]
        public String MoTaMH { get; set; }
    }
}
