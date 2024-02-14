using AutoMapper;
using ERP._System.__CRM.Leads;
using ERP.Authorization.Users;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using System;
using System.Runtime.Serialization;

namespace ERP._System.__CRM._CrmLeadsPersons.Dto
{
    public class CrmLeadsPersonsMapperProfile : Profile
    {
        public CrmLeadsPersonsMapperProfile()
        {
            CreateMap<CrmLeadsPersons, CrmLeadsPersonsDto>() 
              .ForMember(dest => dest.CountryVal, source => source.MapFrom(o =>o.Countrys.GetLookupValue()))
              .ForMember(dest => dest.IndustryVal, source => source.MapFrom(o => o.Industrys.GetLookupValue()))
              .ForMember(dest => dest.LeadSourceVal, source => source.MapFrom(o => o.LeadSources.GetLookupValue()))
              .ForMember(dest => dest.LeadStatusVal, source => source.MapFrom(o => o.LeadStatus.GetLookupValue()))
              .ForMember(dest => dest.RatingVal, source => source.MapFrom(o => o.Ratings.GetLookupValue()))
              .ForMember(dest => dest.CrmProductAr, source => source.MapFrom(o => o.CrmProducts.ProductNameAr))
              .ForMember(dest => dest.CrmProductEn, source => source.MapFrom(o => o.CrmProducts.ProductNameEn))
               .ForMember(dest => dest.CrmServiceAr, source => source.MapFrom(o => o.CrmServices.ServiceNameAr))
              .ForMember(dest => dest.CrmServiceEn, source => source.MapFrom(o => o.CrmServices.ServiceNameEn))
              .ForMember(dest => dest.RatingVal, source => source.MapFrom(o => o.Ratings.GetLookupValue()))
              .ForMember(dest => dest.OtherCountryLkpVal, source => source.MapFrom(o => o.OtherCountryLkp.GetLookupValue()))
              .ForMember(dest => dest.RegisterDate, source => source.MapFrom(o => o.RegisterDate.HasValue ? o.RegisterDate.Value.ToString(Formatters.DateFormat):""))
              .ForMember(dest => dest.DateOfBirth, source => source.MapFrom(o => o.DateOfBirth.HasValue? o.DateOfBirth.Value.ToString(Formatters.DateFormat) :"" ))
              .ForMember(dest => dest.CreatedBy, source => source.MapFrom(o => o.CreatorUserId))
              .ReverseMap()
                    .ForMember(dest => dest.CrmServices, source => source.Ignore())
                    .ForMember(dest => dest.CrmProducts, source => source.Ignore());

            CreateMap<CrmLeadsPersonsCreateDto, CrmLeadsPersons>()
               .ForMember(dest => dest.RegisterDate, source => source.MapFrom(o => string.IsNullOrEmpty(o.RegisterDate)? DateTime.MinValue : DateTimeController.ConvertToDateTime(o.RegisterDate))) 
               
               
               .ForMember(dest => dest.DateOfBirth, source => source.MapFrom(o => string.IsNullOrEmpty(o.DateOfBirth) ? null : DateTimeController.ConvertToDateTime(o.DateOfBirth))) ;

    
            CreateMap<CrmLeadsPersonsEditDto, CrmLeadsPersons>()
               .ForMember(dest => dest.RegisterDate, source => source.MapFrom(o => string.IsNullOrEmpty(o.RegisterDate) ? DateTime.MinValue : DateTimeController.ConvertToDateTime(o.RegisterDate)))
               .ForMember(dest => dest.DateOfBirth, source => source.MapFrom(o => string.IsNullOrEmpty(o.DateOfBirth) ? null : DateTimeController.ConvertToDateTime(o.DateOfBirth)));


        }
    }
}
