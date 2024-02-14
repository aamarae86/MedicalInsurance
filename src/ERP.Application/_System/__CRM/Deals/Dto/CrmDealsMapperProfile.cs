using AutoMapper;
using ERP._System.__CRM.Deals;
using ERP.Helpers.Core;
using System;
 

namespace ERP._System.__CRM._CrmDeals.Dto
{
    public class CrmDealsMapperProfile : Profile
    {
        public CrmDealsMapperProfile()
        {
            CreateMap<CrmDeals, CrmDealsDto>()
              .ForMember(dest => dest.StageLkpVal, source => source.MapFrom(o => o.Lang == "ar-EG" ? o.StageLkps.NameAr : o.StageLkps.NameEn))
              .ForMember(dest => dest.LeadSourceLkpVal, source => source.MapFrom(o => o.Lang == "ar-EG" ? o.LeadSourceLkps.NameAr : o.LeadSourceLkps.NameEn))
              .ForMember(dest => dest.CrmLeadsPersonsVal, source => source.MapFrom(o => ( o.CrmLeadsPersons.FirstName +" " + o.CrmLeadsPersons.LastName )))
              .ForMember(dest => dest.DealTypeLkpval, source => source.MapFrom(o => o.Lang == "ar-EG" ? o.DealTypeLkps.NameAr :o.DealTypeLkps.NameEn))
              .ForMember(dest => dest.DealDate, source => source.MapFrom(o => o.DealDate.ToString(Formatters.DateFormat) )) 
              .ForMember(dest => dest.ClosingDate, source => source.MapFrom(o => o.ClosingDate.Value.ToString(Formatters.DateFormat) ));

            CreateMap<CrmDealsCreateDto, CrmDeals>()
               .ForMember(dest => dest.DealDate, source => source.MapFrom(o => string.IsNullOrEmpty(o.DealDate) ? DateTime.MinValue : DateTimeController.ConvertToDateTime(o.DealDate))) 
               .ForMember(dest => dest.ClosingDate, source => source.MapFrom(o => string.IsNullOrEmpty(o.ClosingDate) ? null : DateTimeController.ConvertToDateTime(o.ClosingDate))) ;

    
            CreateMap<CrmDealsEditDto, CrmDeals>()
               .ForMember(dest => dest.DealDate, source => source.MapFrom(o => string.IsNullOrEmpty(o.DealDate) ? DateTime.MinValue : DateTimeController.ConvertToDateTime(o.DealDate)))
               .ForMember(dest => dest.ClosingDate, source => source.MapFrom(o => string.IsNullOrEmpty(o.ClosingDate) ? null : DateTimeController.ConvertToDateTime(o.ClosingDate)));

        }
    }
}
