using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Acme.MenClothingShop.Exports
{
    public class ExportAppService_Test: MenClothingShopApplicationTestBase
    {
        private readonly IExportAppService _exportAppService;

        public ExportAppService_Test()
        {
            _exportAppService = GetRequiredService<IExportAppService>();
        }

        [Fact]
        public async Task Should_Create_A_New_Export()
        {
            var exportDto = await _exportAppService.CreateAsync(new CreateExportDto
            {
                TongTienXuat = 100000,
                TinhTrangPX = "Đã xuất",
                LyDoXuat = ExportReason.LyDoKhac
            });

            exportDto.UserId.ShouldNotBe(Guid.Empty);
            exportDto.TinhTrangPX.ShouldBe("Đã xuất");
            exportDto.LyDoXuat.ShouldBe(ExportReason.LyDoKhac);
        }
    }
}
