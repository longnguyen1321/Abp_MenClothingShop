using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;
using Volo.Abp.Users;

namespace Acme.MenClothingShop.Exports
{
    public class ExportManager: DomainService
    {
        private readonly IExportRepository _exportRepository;

        private readonly ICurrentUser _currentUser;

        public ExportManager(IExportRepository exportRepository, ICurrentUser currentUser)
        {
            _exportRepository = exportRepository;
            _currentUser = currentUser;
        }

        public async Task<Export> CreateAsync([NotNull] Guid userId, [NotNull] decimal tongTienXuat, [NotNull] string tinhTrangPX, [NotNull] ExportReason lyDoXuat)
        {
            Check.NotNullOrEmpty(tinhTrangPX, nameof(tinhTrangPX));
            Check.NotNullOrEmpty(lyDoXuat.ToString(), nameof(lyDoXuat));
            Check.NotNullOrEmpty(tongTienXuat.ToString(), nameof(tongTienXuat)); 
           
            return new Export(GuidGenerator.Create(), userId, tongTienXuat, tinhTrangPX, lyDoXuat);
        }
    }
}
