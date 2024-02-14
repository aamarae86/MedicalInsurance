using AutoMapper;
using ERP._System.__CRM.Deals;
using ERP.Helpers.Core;
using System;
 

namespace ERP._System.__CRM._ActivityTasks.Dto
{
    public class ActivityTasksMapperProfile : Profile
    {
        public ActivityTasksMapperProfile()
        {
            CreateMap<ActivityTasks, ActivityTasksDto>()
              .ForMember(dest => dest.PriorityLkpVal, source => source.MapFrom(o => o.Lang == "ar-EG" ? o.PriorityLkps.NameAr: o.PriorityLkps.NameEn))
              .ForMember(dest => dest.CrmDealsVal, source => source.MapFrom(o => o.CrmDeals.DealName))
              .ForMember(dest => dest.RelatedToLkpVal, source => source.MapFrom(o => o.Lang == "ar-EG" ? o.RelatedToLkps.NameAr : o.RelatedToLkps.NameEn ))
              .ForMember(dest => dest.CrmLeadsPersonsVal, source => source.MapFrom(o => (o.CrmLeadsPersons.FirstName + " " + o.CrmLeadsPersons.LastName)))
              .ForMember(dest => dest.StatuesLkpVal, source => source.MapFrom(o => o.Lang == "ar-EG" ? o.StatuesLkps.NameAr : o.StatuesLkps.NameEn))

              
              .ForMember(dest => dest.DueDate, source => source.MapFrom(o => o.DueDate.ToString(Formatters.DateFormat)))
              .ForMember(dest => dest.ReminderDate, source => source.MapFrom(o => o.ReminderDate.ToString(Formatters.DateFormat)))
              .ForMember(dest => dest.ReminderTime, source => source.MapFrom(o => $"{o.ReminderTime.Hour}:{o.ReminderTime.Minute}"));




            CreateMap<ActivityTasksCreateDto, ActivityTasks>()
               .ForMember(dest => dest.DueDate, source => source.MapFrom(o => string.IsNullOrEmpty(o.DueDate) ? DateTime.MinValue : DateTimeController.ConvertToDateTime(o.DueDate)))
               .ForMember(dest => dest.ReminderDate, source => source.MapFrom(o => string.IsNullOrEmpty(o.ReminderDate) ? DateTime.MinValue : DateTimeController.ConvertToDateTime(o.ReminderDate)))
               .ForMember(dest => dest.ReminderTime, source => source.MapFrom(o => DateTimeController.ConvertToDateTime($"{DateTime.Now.ToString(Formatters.DateFormat)} {o.ReminderTime}")));

    
            CreateMap<ActivityTasksEditDto, ActivityTasks>()
                .ForMember(dest => dest.DueDate, source => source.MapFrom(o => string.IsNullOrEmpty(o.DueDate) ? DateTime.MinValue : DateTimeController.ConvertToDateTime(o.DueDate)))
               .ForMember(dest => dest.ReminderDate, source => source.MapFrom(o => string.IsNullOrEmpty(o.ReminderDate) ? DateTime.MinValue : DateTimeController.ConvertToDateTime(o.ReminderDate)))
               .ForMember(dest => dest.ReminderTime, source => source.MapFrom(o => DateTimeController.ConvertToDateTime($"{DateTime.Now.ToString(Formatters.DateFormat)} {o.ReminderTime}")));


        }
    }
}
