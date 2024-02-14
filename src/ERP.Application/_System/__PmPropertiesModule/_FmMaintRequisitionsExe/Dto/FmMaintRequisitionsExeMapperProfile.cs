using AutoMapper;
using ERP.Helpers.Core;
using System;

namespace ERP._System.__PmPropertiesModule._FmMaintRequisitionsExe.Dto
{
    public class FmMaintRequisitionsExeMapperProfile : Profile
    {
        public FmMaintRequisitionsExeMapperProfile()
        {
            CreateMap<FmMaintRequisitionsExe, FmMaintRequisitionsExeDto>()
              .ForMember(dest => dest.ExecuteTime, source => source.MapFrom(o => $"{o.ExecuteTime.Hour}:{o.ExecuteTime.Minute}"))
              .ForMember(dest => dest.ExecuteDate, source => source.MapFrom(o => o.ExecuteDate.ToString(Formatters.DateFormat)))
              .ForMember(dest => dest.EngineerName, source => source.MapFrom(o => o.FmEngineers.EngineerName))
              .ForMember(dest => dest.FmContractVisitNumber, source => source.MapFrom(o => o.FmContractVisits.VisitNumber))
              ;

            CreateMap<FmMaintRequisitionsExeCreateDto, FmMaintRequisitionsExe>()
               .ForMember(dest => dest.ExecuteDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.ExecuteDate)))
               .ForMember(dest => dest.ExecuteTime, source => source.MapFrom(o => DateTimeController.ConvertToDateTime($"{DateTime.Now.ToString(Formatters.DateFormat)} {o.ExecuteTime}")))
               ;

            CreateMap<FmMaintRequisitionsExeEditDto, FmMaintRequisitionsExe>()
               .ForMember(dest => dest.ExecuteDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.ExecuteDate)))
               .ForMember(dest => dest.ExecuteTime, source => source.MapFrom(o => DateTimeController.ConvertToDateTime($"{DateTime.Now.ToString(Formatters.DateFormat)} {o.ExecuteTime}")))
               ;

            CreateMap<FmMaintRequisitionsExeCreateDto, FmMaintRequisitionsExeDto>();
            CreateMap<FmMaintRequisitionsExeEditDto, FmMaintRequisitionsExeDto>();

        }
    }
}
