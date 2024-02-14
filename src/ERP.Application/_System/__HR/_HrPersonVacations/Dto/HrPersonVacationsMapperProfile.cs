using AutoMapper;
using ERP.Helpers.Core;

namespace ERP._System.__HR._HrPersonVacations.Dto
{
    public class HrPersonVacationsMapperProfile : Profile
    {
        public HrPersonVacationsMapperProfile()
        {
            CreateMap<HrPersonVacations, HrPersonVacationsDto>()
               .ForMember(dest => dest.OperationDate, source => source.MapFrom(o => o.OperationDate.ToString(Formatters.DateFormat)))
               .ForMember(dest => dest.StartDate, source => source.MapFrom(o => o.StartDate.ToString(Formatters.DateFormat)))
               .ForMember(dest => dest.EndDate, source => source.MapFrom(o => o.EndDate.ToString(Formatters.DateFormat)))
               .ForMember(dest => dest.NoOfDays, source => source.MapFrom(o => o.EndDate.Subtract(o.StartDate).Days + 1));

            CreateMap<HrPersonVacationsCreateDto, HrPersonVacations>()
               .ForMember(dest => dest.OperationDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.OperationDate)))
               .ForMember(dest => dest.StartDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.StartDate)))
               .ForMember(dest => dest.EndDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.EndDate)));

            CreateMap<HrPersonVacationsEditDto, HrPersonVacations>()
               .ForMember(dest => dest.OperationDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.OperationDate)))
               .ForMember(dest => dest.StartDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.StartDate)))
               .ForMember(dest => dest.EndDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.EndDate)));
        }
    }
}
