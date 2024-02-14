using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System._modules;
using ERP._System._TenantFreeModules.Dto;

using ERP._System.TenantFreeModulesInput.Dto;
using ERP.Authorization;
using ERP.Authorization.Users;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using ERP.MultiTenancy;
using ERP.MultiTenancy.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System._TenantFreeModules
{
    //[AbpAuthorize(PermissionNames.Pages_TenantFreeModules)]
    public class TenantFreeModulesAppService : AsyncCrudAppService<TenantFreeModules, TenantFreeModulesDto, long, TenantFreeModulesPagedDto, TenantFreeModulesInputDto, TenantFreeModulesInputDto>, ITenantFreeModulesAppService
    {
        private readonly IRepository<Tenant, int> _tenantRepo;

        public readonly TenantManager _tenantManager;
        public readonly IModuleManager _moduleManager;
        private readonly UserManager _userManager;

        public TenantFreeModulesAppService(IRepository<TenantFreeModules, long> repository,
            TenantManager tenantManager,
            IModuleManager moduleManager,
            IRepository<Tenant, int> TenantRepo,
            UserManager userManager
            ) : base(repository)
        {
            UpdatePermissionName = PermissionNames.Pages_TenantFreeModules_Update;
            GetAllPermissionName = PermissionNames.Pages_TenantFreeModules;
            _tenantManager = tenantManager;
            _moduleManager = moduleManager;
            _tenantRepo = TenantRepo;
            _userManager = userManager;
        }


        public async Task<PagedResultDto<HostTenancyDto>> GetAllTenants(TenantFreeModulesPagedDto input)
        {
            CheckGetAllPermission();
            var queryable = _tenantManager.GetTenants().Include(s => s.TenantFreeModules).AsQueryable();

            foreach (var tenant in queryable)
            {
                tenant.AdminSubEndDate =  _userManager.FindByNameOrEmailAsync(tenant.Id, "admin")?.Result?.SubEndDate ;
            }

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.Name))
            {
                queryable =  queryable.Where(q =>  q.TenantNameAr.Contains(input.Params.Name) 
                                                ||  q.TenantNameEn.Contains(input.Params.Name) 
                                                ||  q.Name.Contains(input.Params.Name)
                                                ||  q.TenancyName.Contains(input.Params.Name));
            }

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.Phone))
            {
                queryable = queryable.Where(q => q.Tel==input.Params.Phone);
            }

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.Email))
            {
                queryable = queryable.Where(q => q.Email == input.Params.Email);
            }
            var count = await queryable.CountAsync();
            var listOrder = new List<SortModel> { new SortModel { Sort = input.OrderByValue.Sort, ColId = input.OrderByValue.ColId } };
            queryable =  queryable.DynamicOrderBy(listOrder);
            queryable = queryable.Skip(input.SkipCount);
            var data = await queryable.Take(input.MaxResultCount).ToListAsync();

            var data2 = ObjectMapper.Map(data, new List<HostTenancyDto>());

            var PagedResultDto = new PagedResultDto<HostTenancyDto>()
            {
                Items = data2 as IReadOnlyList<HostTenancyDto>,
                TotalCount = count
            };

            return PagedResultDto;
             
        }

        public async Task<TenantModuleDto> GetAppModules(EntityDto<long> input)
        {
            //CheckGetAllPermission();
            var ModelForReturn =new TenantModuleDto();
            List<ModuleDto> MappedModules = new List<ModuleDto>();
            var Modules = await _moduleManager.GetModules();
            var FreeModules = await Repository
                .GetAllIncluding(x => x.Tenant, x => x.Modules).Where(x => x.Tenant_ID == input.Id).ToListAsync();

            var Tenant =await _tenantManager.GetTenants().SingleOrDefaultAsync(s => s.Id == input.Id);

            var MappedHostTenant = ObjectMapper.Map(Tenant,new HostTenancyDto());

            var user = await _userManager.FindByNameOrEmailAsync(Convert.ToInt32(input.Id), "admin");

            if (user != null)
            {
                string subendDate = null;
                if (user.SubEndDate != null)
                    subendDate = user.SubEndDate.Value.ToString("dd/MM/yyyy");

                MappedHostTenant.AdminSubEndDate = subendDate;
            }

            foreach (var module in Modules)
            {
                var moduleDto = new ModuleDto {
                    ModuleId = module.Id,
                    NameAr=module.NameAr,
                    NameEn=module.NameEn,
                    Selector=module.Selector,
                    TenantId=Convert.ToInt32(input.Id),
                    IsFree = false 
                    
                };
                var IsModuleFree = FreeModules.Any(s => s.Module_ID == module.Id);
                if (FreeModules!=null && IsModuleFree)
                {
                    moduleDto.IsFree = true;
                }
                MappedModules.Add(moduleDto);

                ModelForReturn.TenantInfo = MappedHostTenant;
                ModelForReturn.TenantModules = MappedModules;
            }
            return ModelForReturn;
        }



        public async Task<TenantModuleDto> GetTenantAppModules(EntityDto<long> input)
        {

            var ModelForReturn = new TenantModuleDto();
            var MappedModules = new List<ModuleDto>();
            var FreeModules=new List<TenantFreeModules>();
            var Modules = await _moduleManager.GetModules();

            if (input?.Id >0)
            {
                FreeModules = await Repository
                              .GetAllIncluding(x => x.Tenant, x => x.Modules)
                              .Where(x => x.Tenant_ID == input.Id).ToListAsync();
            }
            
            var Tenant = await _tenantManager.GetTenants().SingleOrDefaultAsync(s => s.Id == input.Id);
            var MappedHostTenant = ObjectMapper.Map(Tenant, new HostTenancyDto());


            var user = await _userManager.FindByNameOrEmailAsync(Convert.ToInt32(input.Id), "admin");
            
            if (user != null)
            {
                string subendDate = null;    
                if(user.SubEndDate != null)
                    subendDate = user.SubEndDate.Value.ToString("dd/MM/yyyy");
                         
                MappedHostTenant.AdminSubEndDate = subendDate;
            }
                

            foreach (var module in Modules)
            {
                var moduleDto = new ModuleDto
                {
                    ModuleId = module.Id,
                    NameAr = module.NameAr,
                    NameEn = module.NameEn,
                    Selector = module.Selector,
                    TenantId = Convert.ToInt32(input.Id),
                    IsFree = false,
                    Pages=module.Pages.ToList()
                };
                var IsModuleFree = FreeModules.Any(s => s.Module_ID == module.Id);
                if (FreeModules != null && IsModuleFree)
                {
                    moduleDto.IsFree = true;
                }
                MappedModules.Add(moduleDto);

                ModelForReturn.TenantInfo = MappedHostTenant;
                ModelForReturn.TenantModules = MappedModules;
            }
            return ModelForReturn;
        }



        public async Task<bool> PostFreeModules(List<TenantFreeModulesInputDto> input)
        {
            CheckUpdatePermission();
            foreach (var module in input)
            {
                var IsModuleExsist = await Repository.GetAll().SingleOrDefaultAsync
                        (s => s.Module_ID == module.ModuleId && s.Tenant_ID == module.TenentId);

                var modulMapped = new TenantFreeModules { Module_ID = module.ModuleId, Tenant_ID = module.TenentId };
              
                if (module.Status== "NEW" && IsModuleExsist == null)
                {
                    var FreeModules = await Repository.InsertAsync(modulMapped);
                }
                else if (module.Status == "Delete" && IsModuleExsist != null)
                {
                   await Repository.DeleteAsync(IsModuleExsist.Id);
                }

            }
            return true;
        }

    }
}
