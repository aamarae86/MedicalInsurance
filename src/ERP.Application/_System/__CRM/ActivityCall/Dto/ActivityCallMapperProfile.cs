using AutoMapper;
using ERP._System.__CRM.Deals;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using System;
 

namespace ERP._System.__CRM._ActivityCall.Dto
{
    public class ActivityCallMapperProfile : Profile
    {
        public ActivityCallMapperProfile()
        {
            CreateMap<ActivityCall, ActivityCallDto>()
              .ForMember(dest => dest.CallDetailsLkpVal, source => source.MapFrom(o =>o.CallDetailsLkps.GetLookupValue()))
            //  .ForMember(dest => dest.CallDetailsLkpVal, source => source.MapFrom(o => o.Lang == "ar-EG" ? o.CallDetailsLkps.NameAr :o.CallDetailsLkps.NameEn))
              .ForMember(dest => dest.CallPurposeLkpVal, source => source.MapFrom(o => o.Lang == "ar-EG" ? o.CallPurposeLkps.NameAr:o.CallPurposeLkps.NameEn))
              .ForMember(dest => dest.CrmDealsVal, source => source.MapFrom(o => o.CrmDeals.DealName))
              .ForMember(dest => dest.CrmLeadsPersonsVal, source => source.MapFrom(o => (o.CrmLeadsPersons.FirstName + " " + o.CrmLeadsPersons.LastName)))
              .ForMember(dest => dest.CallResultLkpVal, source => source.MapFrom(o => o.Lang == "ar-EG" ? o.CallResultLkps.NameAr: o.CallResultLkps.NameEn ))
              .ForMember(dest => dest.CallTypeLkpVal, source => source.MapFrom(o => o.Lang == "ar-EG" ? o.CallTypeLkps.NameAr : o.CallTypeLkps.NameEn))
              .ForMember(dest => dest.RelatedToLkpVal, source => source.MapFrom(o => o.Lang == "ar-EG" ? o.RelatedToLkps.NameAr: o.RelatedToLkps.NameEn))
              .ForMember(dest => dest.StartDate, source => source.MapFrom(o => o.StartDate.ToString(Formatters.DateFormat)))
              .ForMember(dest => dest.StartTime, source => source.MapFrom(o => $"{o.StartTime.Hour}:{o.StartTime.Minute}"))
              .ForMember(dest => dest.EndTime, source => source.MapFrom(o => $"{o.EndTime.Hour}:{o.EndTime.Minute}"));




            CreateMap<ActivityCallCreateDto, ActivityCall>()
               .ForMember(dest => dest.StartDate, source => source.MapFrom(o => string.IsNullOrEmpty(o.StartDate) ? DateTime.MinValue : DateTimeController.ConvertToDateTime(o.StartDate))) 
               
               .ForMember(dest => dest.StartTime, source => source.MapFrom(o => DateTimeController.ConvertToDateTime($"{DateTime.Now.ToString(Formatters.DateFormat)} {o.StartTime}")))
               .ForMember(dest => dest.EndTime, source => source.MapFrom(o => DateTimeController.ConvertToDateTime($"{DateTime.Now.ToString(Formatters.DateFormat)} {o.EndTime}"))) ;

    
            CreateMap<ActivityCallEditDto, ActivityCall>()
                .ForMember(dest => dest.StartDate, source => source.MapFrom(o => string.IsNullOrEmpty(o.StartDate) ? DateTime.MinValue : DateTimeController.ConvertToDateTime(o.StartDate)))

               .ForMember(dest => dest.StartTime, source => source.MapFrom(o => DateTimeController.ConvertToDateTime($"{DateTime.Now.ToString(Formatters.DateFormat)} {o.StartTime}")))
               .ForMember(dest => dest.EndTime, source => source.MapFrom(o => DateTimeController.ConvertToDateTime($"{DateTime.Now.ToString(Formatters.DateFormat)} {o.EndTime}")));


        }
    }
}
