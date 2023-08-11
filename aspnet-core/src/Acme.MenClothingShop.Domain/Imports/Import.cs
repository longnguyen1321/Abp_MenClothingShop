using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.MenClothingShop.Imports
{
    public class Import: FullAuditedAggregateRoot<Guid>
    {
        public Guid MaPN { get; set; }

        public Guid MaNCC { get; set; }

        public Guid UserId { get; set; }

        public DateTime NgayNhap { get; set; }

        public Decimal TongTienNhap { get; set; }

        public String TinhTrangPX { get; set; }

        public Import() { }

        internal Import(Guid maPN, Guid maNCC, Guid userId, DateTime ngayNhap, decimal tongTienNhap, string tinhTrangPX): base(maPN)
        {
            MaNCC = maNCC;
            UserId = userId;
            NgayNhap = ngayNhap;
            TongTienNhap = tongTienNhap;
            TinhTrangPX = tinhTrangPX;
        }
    }
}
