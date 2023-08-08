using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Validation;
using Xunit;

namespace Acme.MenClothingShop.Clothes
{
    public class ClotheAppService_Tests : MenClothingShopApplicationTestBase
    {
        private readonly IClotheAppService _clotheAppService;

        public ClotheAppService_Tests()
        {
            _clotheAppService = GetRequiredService<IClotheAppService>();
        }

        [Fact]
        public async Task Should_Get_List_Of_Clothes()
        {
            //Act
            var result = await _clotheAppService.GetListAsync(new Volo.Abp.Application.Dtos.PagedAndSortedResultRequestDto());

            //Assert
            result.TotalCount.ShouldBeGreaterThan(0);
            result.Items.ShouldContain(c => c.TenMH == "Áo gió đen");
        }

        [Fact]
        public async Task Should_Create_A_Valid_Clothe()
        {
            var result = await _clotheAppService.CreateAsync(
                new CreateUpdateClotheDto
                {
                    TenMH = "New test clothe",
                    SizeMH = "L",
                    SoLuongMH = 10,
                    TonKho = 0,
                    SLTonKhoToiThieu = 5,
                    LoaiMH = ClotheType.AoGiuNhiet,
                    GiaMH = 1000,
                    ChatLieuMH = ClotheMaterial.Nano,
                    AnhMH = "",
                    MoTaMH = "Testing"
                }
                );
            //Assert
            result.Id.ShouldNotBe(Guid.Empty);
            result.TenMH.ShouldBe("New test clothe");
        }

        [Fact]
        public async Task Should_Not_Create_A_Clothe_Without_Name()
        {
            var exception = await Assert.ThrowsAsync<AbpValidationException>(async () =>
            {
                await _clotheAppService.CreateAsync(
                    new CreateUpdateClotheDto
                    {
                        TenMH = "",
                        SizeMH = "L",
                        SoLuongMH = 10,
                        TonKho = 0,
                        SLTonKhoToiThieu = 5,
                        LoaiMH = ClotheType.AoGiuNhiet,
                        GiaMH = 1000,
                        ChatLieuMH = ClotheMaterial.Nano,
                        AnhMH = "",
                        MoTaMH = "Testing"
                    }
                );
            });

            exception.ValidationErrors
                .ShouldContain(err => err.MemberNames.Any(mem => mem == "TenMH"));
        }
    }
}
