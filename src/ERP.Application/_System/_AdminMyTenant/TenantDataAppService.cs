using Abp.Application.Services;
using Abp.Authorization;
using ERP.Authorization;
using ERP.MultiTenancy;
using ERP.MultiTenancy.Dto;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace ERP._System._AdminMyTenant
{
    [AbpAuthorize(PermissionNames.Pages_TenantData_Update)]
    public class TenantDataAppService : ApplicationService, ITenantData
    {
        private readonly TenantManager _tenantManager;
        private readonly IConfiguration _config;

        public TenantDataAppService(TenantManager tenentDetailManager, IConfiguration configuration)
        {
            _tenantManager = tenentDetailManager;
            _config = configuration;
        }

        public async Task<TenantDetailEditDto> GetTenantDetailDto()
        {
            var TenantId = AbpSession.TenantId.Value;
          
            var tenantDetail = await _tenantManager.GetDetails(TenantId);
          
            TenantDetailEditDto tenantDetailDto = new TenantDetailEditDto();
        
            tenantDetailDto.StripePublishablekey = _config["StripeApiData:Publishablekey"];


             var res= ObjectMapper.Map(tenantDetail, tenantDetailDto);
            if (tenantDetail.AdminSubEndDate != null)
            {
                res.AdminSubEndDate = tenantDetail.AdminSubEndDate.Value.ToString("dd/MM/yyyy");
            }
            return res ;
        }

        public async Task<bool> PostTenantDetailDto(TenantDetailEditDto tenantDetailDto)
        {
            PermissionChecker.IsGranted(PermissionNames.Pages_TenantData_Update);
          
            //if (AbpSession.TenantId.Value == tenantDetailDto.TenantId)
            //{
                var tenantDetail = await _tenantManager.GetDetails(AbpSession.TenantId.Value);

            var currentSubEndDate = tenantDetail.AdminSubEndDate;
            tenantDetailDto.AdminValue = tenantDetail.AdminValue.Value;
            tenantDetailDto.UserValue = tenantDetail.UserValue.Value;
       

               var obj = ObjectMapper.Map(tenantDetailDto, tenantDetail);
            if (currentSubEndDate.HasValue)
            {
                obj.SetSubEndDateValue(currentSubEndDate.Value);
            }

            var ret = await _tenantManager.PostDetails(obj, tenantDetailDto.BaseCurrency);
             
                return ret;
            //}
          
            //throw new Exception();
        }
    }
}
