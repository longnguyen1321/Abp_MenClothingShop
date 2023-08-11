using JetBrains.Annotations;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Users;

namespace Acme.MenClothingShop.Exports
{
    public class Export: FullAuditedAggregateRoot<Guid>
    {
        
        public Guid UserId { get; set; }

        public DateTime NgayXuat { get; set; }

        public Decimal TongTienXuat { get; set; }

        public String TinhTrangPX { get; set; }

        public ExportReason LyDoXuat { get; set; }

        private Export() { }

        internal Export(Guid id, Guid userId, Decimal tongTienXuat, String tinhTrangPX, [NotNull] ExportReason lyDoXuat) : base(id)
        {           
            UserId = userId;
            NgayXuat = DateTime.Now;
            TongTienXuat = tongTienXuat;
            TinhTrangPX = tinhTrangPX;
            LyDoXuat = lyDoXuat;
        }
    }
}
