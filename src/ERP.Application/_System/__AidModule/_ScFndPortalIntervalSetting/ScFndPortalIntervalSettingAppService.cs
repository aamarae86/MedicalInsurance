using System;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System.__AidModule._ScFndPortalIntervalSetting.Dto;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;

namespace ERP._System.__AidModule._ScFndPortalIntervalSetting
{
    [AbpAuthorize]
    public class ScFndPortalIntervalSettingAppService : AsyncCrudAppService<ScFndPortalIntervalSetting, ScFndPortalIntervalSettingDto, long, PagedScFndPortalIntervalSettingResultRequestDto, CreateScFndPortalIntervalSettingDto, ScFndPortalIntervalSettingEditDto>,
        IScFndPortalIntervalSettingAppService
    {
        public ScFndPortalIntervalSettingAppService(IRepository<ScFndPortalIntervalSetting, long> repository) : base(repository) { }

        public async override Task<ScFndPortalIntervalSettingDto> Create(CreateScFndPortalIntervalSettingDto input)
        {
            CheckCreatePermission();

            bool check = await CheckDateValidation((DateTime)DateTimeController.ConvertToDateTime(input.FromDate), (DateTime)DateTimeController.ConvertToDateTime(input.ToDate));

            if (check) return new ScFndPortalIntervalSettingDto { dateRangeValidation = true };

            _ = await base.Create(input);

            return new ScFndPortalIntervalSettingDto { dateRangeValidation = false };
        }

        public async override Task<ScFndPortalIntervalSettingDto> Update(ScFndPortalIntervalSettingEditDto input)
        {
            CheckUpdatePermission();

            bool check = await CheckDateValidation((DateTime)DateTimeController.ConvertToDateTime(input.FromDate), (DateTime)DateTimeController.ConvertToDateTime(input.ToDate), input.Id);

            if (check) return new ScFndPortalIntervalSettingDto { dateRangeValidation = true };

            _ = await base.Update(input);

            return new ScFndPortalIntervalSettingDto { dateRangeValidation = false };
        }

        protected override IQueryable<ScFndPortalIntervalSetting> CreateFilteredQuery(PagedScFndPortalIntervalSettingResultRequestDto input)
        {
            try
            {
                var queryable = Repository.GetAll();

                if (!string.IsNullOrEmpty(input.Params.FromDate) && !string.IsNullOrEmpty(input.Params.ToDate))
                {
                    DateTime fromDate = (DateTime)DateTimeController.ConvertToDateTime(input.Params.FromDate);
                    DateTime toDate = (DateTime)DateTimeController.ConvertToDateTime(input.Params.ToDate);

                    queryable = queryable.Where(z => (fromDate >= z.FromDate && fromDate <= z.ToDate) ||
                                    (toDate >= z.FromDate && toDate <= z.ToDate) ||
                                    (z.FromDate >= fromDate && z.FromDate <= toDate) ||
                                    (z.ToDate >= fromDate && z.ToDate <= toDate)
                                    );
                }

                if ((input.Params.NumberOfRequest != null) && input.Params.NumberOfRequest != 0)
                    queryable = queryable.Where(q => q.NumberOfRequest == input.Params.NumberOfRequest);

                queryable = queryable.OrderByDescending(x => x.CreationTime);

                return queryable;
            }
            catch (System.Exception ex)
            {
                return base.CreateFilteredQuery(input);
            }
        }

        private async Task<bool> CheckDateValidation(DateTime fromDate, DateTime toDate, long? id = null)
        {
            var check = await Repository.GetAll().Where(z => (id == null || z.Id != id) &&
                       ((fromDate.Date >= z.FromDate.Date && fromDate.Date <= z.ToDate.Date) ||
                        (toDate.Date >= z.FromDate.Date && toDate.Date <= z.ToDate.Date) ||
                        (z.FromDate.Date >= fromDate.Date && z.FromDate.Date <= toDate.Date) ||
                        (z.ToDate.Date >= fromDate.Date && z.ToDate.Date <= toDate.Date)
                        )).AnyAsync();

            return check;
        }
    }
}
