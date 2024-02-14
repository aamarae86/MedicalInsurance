using AutoMapper;
using ERP.Helpers.Core;

namespace ERP._System.__AidModule._ScDeliveryOtherAids.Dto
{
    public class ScDeliveryOtherAidsMapperProfile : Profile
    {
        public ScDeliveryOtherAidsMapperProfile()
        {
            CreateMap<ScDeliveryOtherAids, ScDeliveryOtherAidsDto>()
              .ForMember(dest => dest.MaturityDate, source => source.MapFrom(o => o.MaturityDate.HasValue ? o.MaturityDate.Value.ToString(Formatters.DateFormat) : string.Empty))
              .ForMember(dest => dest.OperationDate, source => source.MapFrom(o => o.OperationDate.ToString(Formatters.DateFormat)))
              ;

            CreateMap<ScDeliveryOtherAidsCreateDto, ScDeliveryOtherAids>()
              .ForMember(dest => dest.MaturityDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.MaturityDate)))
              .ForMember(dest => dest.OperationDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.OperationDate)))
              ;

            CreateMap<ScDeliveryOtherAidsEditDto, ScDeliveryOtherAids>()
              .ForMember(dest => dest.MaturityDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.MaturityDate)))
              .ForMember(dest => dest.OperationDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.OperationDate)))
              ;
        }
    }
}
