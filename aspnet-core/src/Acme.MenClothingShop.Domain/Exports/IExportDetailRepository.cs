
using Acme.MenClothingShop.Storages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Acme.MenClothingShop.Exports
{
    public interface IExportDetailRepository: IRepository<ExportDetail>
    {
        //Task<Boolean> ValidateExportDetailInput(Guid maMH, int soLuongXuat, decimal giaXuat, decimal thanhTienXuat);
    }
}
