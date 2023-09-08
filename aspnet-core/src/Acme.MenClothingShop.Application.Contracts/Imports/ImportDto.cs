using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Acme.MenClothingShop.Imports
{
    public class ImportDto : EntityDto<Guid>
    {
        public Guid MaNCC { get; set; }

        public Guid UserId { get; set; }

        public DateTime NgayNhap { get; set; }

        public Decimal TongTienNhap { get; set; }

        public String TinhTrangPX { get; set; }
    }
}
