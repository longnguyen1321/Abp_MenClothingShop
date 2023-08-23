using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Acme.MenClothingShop.Imports
{
    public class ImportManager : DomainService
    {
        private readonly IImportRepository _importRepository;

        public ImportManager(IImportRepository importRepository)
        {
            _importRepository = importRepository;
        }

        public Import CreateAsync([NotNull]Guid maNCC, [NotNull] Guid userId,[NotNull] Decimal tongTienNhap)
        {
            Import import = new Import(GuidGenerator.Create(), maNCC, userId, DateTime.Now, tongTienNhap, "Đã xuất");
            
            return new Import(GuidGenerator.Create(), maNCC, userId, DateTime.Now, tongTienNhap, "Đã xuất");
        }

        public void CancelImportAsync(Import selectedImportET)
        {
            selectedImportET.TinhTrangPX = "Đã hủy";
        }
    }
}
