using AutoMapper;
using ERP.Helpers.Core;

namespace ERP._System.Calender.Dto
{
    public class CalenderMemoProfile : Profile
    {
        public CalenderMemoProfile()
        {
            CreateMap<FndCalendarMemo, CalenderMemoDto>()
                .ForMember(dest => dest.MemoDate, source => source.MapFrom(o => o.MemoDate.ToString(Formatters.DateFormat)));

            CreateMap<CalenderMemoDto, FndCalendarMemo>()
                .ForMember(dest => dest.MemoDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.MemoDate)));
            CreateMap<CalenderMemoCreateDto, FndCalendarMemo>()
                .ForMember(dest => dest.MemoDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.MemoDate)));
            CreateMap<CalenderMemoEditDto, FndCalendarMemo>()
                .ForMember(dest => dest.MemoDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.MemoDate)));
        }
    }
}
