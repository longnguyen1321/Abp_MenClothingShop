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

        public Import Create([NotNull]Guid maNCC, [NotNull] Guid userId,[NotNull] Decimal tongTienNhap)
        {
            Import import = new Import(GuidGenerator.Create(), maNCC, userId, DateTime.Now, tongTienNhap, "Đã nhập");
            
            return new Import(GuidGenerator.Create(), maNCC, userId, DateTime.Now, tongTienNhap, "Đã nhập");
        }

        public void CancelImportAsync(Import selectedImportET)
        {
            selectedImportET.TinhTrangPX = "Đã hủy";
        }

        
    }
}
