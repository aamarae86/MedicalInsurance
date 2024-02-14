using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System.__Warehouses.__IvInventorySetting.Dto;
using ERP._System._GlPeriods.Dto;
using ERP.Helpers.Core;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System._GlPeriods
{
    [AbpAuthorize]
    public class GlPeriodsDetailsAppService : ERPAppServiceBase, IGlPeriodsDetailsAppService
    {
        private readonly IGlPeriodsDetailsManager _glPeriodsDetailsManager;
        private readonly IRepository<GlPeriodsDetails, long> _repoGlPeriodsDetails;
        public GlPeriodsDetailsAppService(IGlPeriodsDetailsManager glPeriodsDetailsManager
            , IRepository<GlPeriodsDetails, long> repoGlPeriodsDetails)
        {
            _glPeriodsDetailsManager = glPeriodsDetailsManager;
            _repoGlPeriodsDetails = repoGlPeriodsDetails;
        }

        public async Task<Select2PagedResult> GetGlPeriodsSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
            => await _glPeriodsDetailsManager.GetGlPeriodsSelect2(searchTerm, pageSize, pageNumber, lang);

        public async Task<GlPeriodsDetails> GetPeriod(string transDate)
            => await _glPeriodsDetailsManager.GetPeriod((DateTime)DateTimeController.ConvertToDateTime(transDate));

        public async Task<GlPeriodsDetailsDto> GetFirstItemByUserId()
        {
            var data =  _repoGlPeriodsDetails.GetAllList(z => z.TenantId == AbpSession.TenantId && z.StartDate <= DateTime.Now);
            data = data.OrderByDescending(x => x.EndDate).ToList();
                                            
            var obj = ObjectMapper.Map<GlPeriodsDetailsDto>(data.FirstOrDefault());
            return obj;

        }
    }
}
