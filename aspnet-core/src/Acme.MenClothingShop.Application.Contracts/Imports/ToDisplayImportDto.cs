using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Acme.MenClothingShop.Imports
{
    public class ToDisplayImportDto : EntityDto<Guid>
    {
        public string TenNCC { get; set; }

        public Guid UserId { get; set; }

        public DateTime NgayNhap { get; set; }
        
        public Decimal TongTienNhap { get; set; }   

        public string TinhTrangPN { get; set; }
    }
}
