using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Acme.MenClothingShop.Imports
{
    public class CreateSelectedImportClotheDto : EntityDto<Guid>
    {
        public int SoLuongNhap { get; set; }

        public decimal GiaNhap { get; set; }

        public decimal ThanhTienNhap { get; set; }
    }
}
