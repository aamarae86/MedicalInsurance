using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System.__SpGuarantees._SpPaymentSetting.Dto;
using ERP.Authorization;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__SpGuarantees._SpPaymentSetting
{
    [AbpAuthorize]
    public class SpPaymentSettingAppService : AsyncCrudAppService<SpPaymentSetting, SpPaymentSettingDto, long, SpPaymentSettingPagedDto, SpPaymentSettingCreateDto, SpPaymentSettingEditDto>
        , ISpPaymentSettingAppService
    {
        public SpPaymentSettingAppService(IRepository<SpPaymentSetting, long> repository) : base(repository)
        {
            CreatePermissionName = PermissionNames.Pages_SpPaymentSetting_Insert;
            UpdatePermissionName = PermissionNames.Pages_SpPaymentSetting_Update;
            DeletePermissionName = PermissionNames.Pages_SpPaymentSetting_Delete;
            GetAllPermissionName = PermissionNames.Pages_SpPaymentSetting;
        }

        protected override IQueryable<SpPaymentSetting> CreateFilteredQuery(SpPaymentSettingPagedDto input)
        {
            var iqueryable = Repository.GetAllIncluding(x => x.FndSponsorCategoryLkp);

            if (input.Params != null && input.Params.SponsorCategoryLkpId != null)
                iqueryable = iqueryable.Where(z => z.SponsorCategoryLkpId == input.Params.SponsorCategoryLkpId);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.FromDate))
                iqueryable = iqueryable.Where(z => z.FromDate == DateTimeController.ConvertToDateTime(input.Params.FromDate));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.ToDate))
                iqueryable = iqueryable.Where(z => z.ToDate == DateTimeController.ConvertToDateTime(input.Params.ToDate));

            return iqueryable;
        }

        public async override Task<SpPaymentSettingDto> Get(EntityDto<long> input)
            => ObjectMapper.Map<SpPaymentSettingDto>(await Repository.GetAllIncluding(x => x.FndSponsorCategoryLkp).FirstOrDefaultAsync(x => x.Id == input.Id));
    }
}
