using AutoMapper;
using ERP.Helpers.Core;
using System;

namespace ERP._System.__PmPropertiesModule._FmMaintRequisitionsHdr.Dto
{
    public class FmMaintRequisitionsHdrMappingProfile : Profile
    {
        public FmMaintRequisitionsHdrMappingProfile()
        {
            CreateMap<FmMaintRequisitionsHdr, FmMaintRequisitionsHdrDto>()
               .ForMember(dest => dest.RequisitionTime, source => source.MapFrom(o => o.RequisitionTime.HasValue ? $"{o.RequisitionTime.Value.Hour}:{o.RequisitionTime.Value.Minute}" : string.Empty))
               .ForMember(dest => dest.RequisitionDate, source => source.MapFrom(o => o.RequisitionDate.HasValue ? o.RequisitionDate.Value.ToString(Formatters.DateFormat) : string.Empty))
               ;

            CreateMap<FmMaintRequisitionsHdrCreateDto, FmMaintRequisitionsHdr>()
               .ForMember(dest => dest.RequisitionDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.RequisitionDate)))
               .ForMember(dest => dest.RequisitionTime, source => source.MapFrom(o => DateTimeController.ConvertToDateTime($"{DateTime.Now.ToString(Formatters.DateFormat)} {o.RequisitionTime}")))
               ;

            CreateMap<FmMaintRequisitionsHdrEditDto, FmMaintRequisitionsHdr>()
               .ForMember(dest => dest.RequisitionDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.RequisitionDate)))
               .ForMember(dest => dest.RequisitionTime, source => source.MapFrom(o => DateTimeController.ConvertToDateTime($"{DateTime.Now.ToString(Formatters.DateFormat)} {o.RequisitionTime}")))
               ;
        }
    }
}
