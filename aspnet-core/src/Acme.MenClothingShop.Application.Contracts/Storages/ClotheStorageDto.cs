using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Acme.MenClothingShop.Storages
{
    public class ClotheStorageDto : EntityDto<Guid>
    {
        public string TenMH { get; set; }

        public int TonKho { get; set; }

        public string TinhTrangMH { get; set; }

        public int TongNhapThangMH { get; set; }

        public int TongXuatThangMH { get; set; }
    }
}
