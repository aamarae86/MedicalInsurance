using AutoMapper;
using ERP._System.__CRM.Deals;
using ERP.Helpers.Core;
using System;
 

namespace ERP._System.__CRM._ActivityMeeting.Dto
{
    public class ActivityMeetingMapperProfile : Profile
    {
        public ActivityMeetingMapperProfile()
        {
            CreateMap<ActivityMeeting, ActivityMeetingDto>()
              .ForMember(dest => dest.PartiReminderLkpVal, source => source.MapFrom(o => o.Lang == "ar-EG" ? o.PartiReminderLkps.NameAr:o.PartiReminderLkps.NameEn))
              .ForMember(dest => dest.CrmDealsVal, source => source.MapFrom(o => o.CrmDeals.DealName))
              .ForMember(dest => dest.RelatedToLkpVal, source => source.MapFrom(o => o.Lang == "ar-EG" ? o.RelatedToLkps.NameAr: o.RelatedToLkps.NameEn ))
              .ForMember(dest => dest.CrmLeadsPersonsVal, source => source.MapFrom(o => (o.CrmLeadsPersons.FirstName + " " + o.CrmLeadsPersons.LastName)))

              
              .ForMember(dest => dest.FromDay, source => source.MapFrom(o => o.FromDay.ToString(Formatters.DateFormat)))

              .ForMember(dest => dest.ToDay, source => source.MapFrom(o => o.ToDay.ToString(Formatters.DateFormat)))
              .ForMember(dest => dest.FromTime, source => source.MapFrom(o => $"{o.FromTime.Hour}:{o.FromTime.Minute}")) 
              .ForMember(dest => dest.ToTime, source => source.MapFrom(o => $"{o.ToTime.Hour}:{o.ToTime.Minute}"));




            CreateMap< CreateActivityMeetingDto , ActivityMeeting>()
               .ForMember(dest => dest.ToDay, source => source.MapFrom(o => string.IsNullOrEmpty(o.ToDay) ? DateTime.MinValue : DateTimeController.ConvertToDateTime(o.ToDay)))
               .ForMember(dest => dest.FromDay, source => source.MapFrom(o => string.IsNullOrEmpty(o.FromDay) ? DateTime.MinValue : DateTimeController.ConvertToDateTime(o.FromDay)))
               .ForMember(dest => dest.FromTime, source => source.MapFrom(o => DateTimeController.ConvertToDateTime($"{DateTime.Now.ToString(Formatters.DateFormat)} {o.FromTime}"))) 
               .ForMember(dest => dest.ToTime, source => source.MapFrom(o => DateTimeController.ConvertToDateTime($"{DateTime.Now.ToString(Formatters.DateFormat)} {o.ToTime}")));

    
            CreateMap<ActivityMeetingEditDto, ActivityMeeting>()
              .ForMember(dest => dest.ToDay, source => source.MapFrom(o => string.IsNullOrEmpty(o.ToDay) ? DateTime.MinValue : DateTimeController.ConvertToDateTime(o.ToDay)))
               .ForMember(dest => dest.FromDay, source => source.MapFrom(o => string.IsNullOrEmpty(o.FromDay) ? DateTime.MinValue : DateTimeController.ConvertToDateTime(o.FromDay)))
               .ForMember(dest => dest.FromTime, source => source.MapFrom(o => DateTimeController.ConvertToDateTime($"{DateTime.Now.ToString(Formatters.DateFormat)} {o.FromTime}")))
               .ForMember(dest => dest.ToTime, source => source.MapFrom(o => DateTimeController.ConvertToDateTime($"{DateTime.Now.ToString(Formatters.DateFormat)} {o.ToTime}")));



            CreateMap<ActivityMeetingParticipant, ActivityMeetingParticipantDto>()
              .ForMember(dest => dest.ActivityMeetingVal, source => source.MapFrom(o => o.ActivityMeetings.Title))
              .ForMember(dest => dest.RelatedToLkpVal, source => source.MapFrom(o => o.RelatedToLkps.NameAr))
              .ForMember(dest => dest.CrmLeadsPersonsVal, source => source.MapFrom(o => (o.CrmLeadsPersons.FirstName + " " + o.CrmLeadsPersons.LastName)));





        }
    }
}
