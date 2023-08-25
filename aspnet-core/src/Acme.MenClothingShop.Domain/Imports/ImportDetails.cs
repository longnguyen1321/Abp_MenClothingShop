using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.MenClothingShop.Imports
{
    public class ImportDetail : Entity
    {
        public Guid MaPN { get; set; }

        public Guid MaMH { get; set; }

        public int SoLuongNhap { get; set; }

        public Decimal GiaNhap { get; set; }

        public Decimal ThanhTienNhap { get; set; }

        public ImportDetail() { }

        public ImportDetail(Guid maPN, Guid maMH, int soLuongNhap, decimal giaNhap, decimal thanhTienNhap)
        {
            MaPN = maPN;
            MaMH = maMH;
            SoLuongNhap = soLuongNhap;
            GiaNhap = giaNhap;
            ThanhTienNhap = thanhTienNhap;
        }

        public override object[] GetKeys()
        {
            return new object[] { MaPN, MaMH };
        }
    }
}
