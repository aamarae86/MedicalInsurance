using Abp.Application.Features;
using Abp.Domain.Repositories;
using Abp.MultiTenancy;
using ERP.Authorization.Users;
using ERP.Editions;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.MultiTenancy
{
    public class TenantManager : AbpTenantManager<Tenant, User>
    {
        private readonly UserManager _userManager;
        public TenantManager(IRepository<Tenant> tenantRepository,
            IRepository<TenantFeatureSetting, long> tenantFeatureRepository, EditionManager editionManager,
            IAbpZeroFeatureValueStore featureValueStore, UserManager userManager) : base( tenantRepository,
                tenantFeatureRepository, editionManager, featureValueStore)
        {
            _userManager = userManager;
        }

        public async Task<Select2PagedResult> GetTenantsSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = await TenantRepository.GetAll().Where(z => z.IsActive &&
                  string.IsNullOrEmpty(searchTerm) || (lang == "ar-EG" ?
                  z.Name.Contains(searchTerm) :
                  z.TenancyName.Contains(searchTerm)))
                 .ToListAsync();

            var result = data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = lang == "ar-EG" ? z.Name : z.TenancyName }).ToList();

            var select2pagedResult = new Select2PagedResult
            {
                Total = data.Count(),
                Results = result
            };

            return select2pagedResult;
        }   
        
        
        public  IQueryable<Tenant>  GetTenants()
        {
            var data = TenantRepository.GetAll().AsQueryable();
            return   data;
        }
      

        public async Task<Tenant> GetDetails(int tenantId)
        {
            var tenantDetails = await TenantRepository.GetAllIncluding(t => t.FndCountryLkp, t => t.FndIndustryLkp, t => t.Currency)
                .FirstOrDefaultAsync(td => td.Id == tenantId);
            if(tenantDetails != null)
            {               
                var user = await _userManager.FindByNameOrEmailAsync(tenantDetails.Id, "admin");

                if (user != null)
                {
                    tenantDetails.AdminSubEndDate = user.SubEndDate;
                }
            }


            return tenantDetails;
        }

        public async Task<bool> PostDetails(Tenant tenant, int? CurrencyId)
        {
            try
            {
                await TenantRepository.UpdateAsync(tenant);

              //  var tenant = await TenantRepository.FirstOrDefaultAsync(tentnatObj.Id);

              //  tenant.SetDetails(tentnatObj, CurrencyId);

              //  await TenantRepository.UpdateAsync(tenant);

                return true;
            }
            catch (System.Exception x)
            {
                return false;
            }
        }
    }
}
