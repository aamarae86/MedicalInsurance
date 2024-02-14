using AutoMapper;
using ERP._System.__CRM.Leads;
using ERP._System._modules;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using ERP.MultiTenancy;
using System;
using System.Linq;
using System.Runtime.Serialization;

namespace ERP._System._TenantFreeModules.Dto
{
    public class TenantFreeModulesMapperProfile : Profile
    {
        public TenantFreeModulesMapperProfile()
        {
            CreateMap<Module, ModuleDto > ()
                .ForMember(dest => dest.TenantId, source => source.MapFrom(o => (o.TenantFreeModules!=null && o.TenantFreeModules.Count() >0) ? o.TenantFreeModules.FirstOrDefault().Tenant_ID : 0 ))
                .ForMember(dest => dest.IsFree, source => source.MapFrom(o => (o.TenantFreeModules!=null && o.TenantFreeModules.Count() >0) ? true:false));
            CreateMap<Tenant, HostTenancyDto>()
                .ForMember(dest => dest.CreationTime, source => source.MapFrom(o => o.CreationTime.ToString("dd/MM/yyyy")))
                .ForMember(dest => dest.RemainingDays, source => source.MapFrom(o => (o.AdminSubEndDate != null) ? o.AdminSubEndDate.Value.ClculateRemainingDays() : 0))
                .ForMember(dest => dest.AdminSubEndDate, source => source.MapFrom(o =>   (o.AdminSubEndDate != null) ? o.AdminSubEndDate.Value.ToString("dd/MM/yyyy") : ""));
        }
    }
}
