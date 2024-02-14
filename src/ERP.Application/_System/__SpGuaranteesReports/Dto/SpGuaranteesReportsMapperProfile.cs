using AutoMapper;
using ERP._System.__SpGuaranteesReports.Inputs;
using ERP.Helpers.Core;

namespace ERP._System.__SpGuaranteesReports.Dto
{
    public class SpGuaranteesReportsMapperProfile : Profile
    {
        public SpGuaranteesReportsMapperProfile()
        {
            CreateMap<SpCaseOperationsDataListInputHelper, SpCaseOperationsDataListInput>()
              .ForMember(dest => dest.ToDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.ToDate)))
              .ForMember(dest => dest.FromDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.FromDate)));
        }
    }
}
