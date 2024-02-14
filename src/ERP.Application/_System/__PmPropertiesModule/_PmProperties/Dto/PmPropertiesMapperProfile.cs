using AutoMapper;
using ERP.Helpers.Core;

namespace ERP._System.__PmPropertiesModule._PmProperties.Dto
{
    public class PmPropertiesMapperProfile : Profile
    {
        public PmPropertiesMapperProfile()
        {
            CreateMap<PmProperties, PmPropertiesDto>()
               .ForMember(dest => dest.CompletionDate, source => source.MapFrom(o => o.CompletionDate.HasValue ? o.CompletionDate.Value.ToString(Formatters.DateFormat) : string.Empty));

            CreateMap<CreatePmPropertiesDto, PmProperties>()
               .ForMember(dest => dest.CompletionDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.CompletionDate)));

            CreateMap<PmPropertiesEditDto, PmProperties>()
               .ForMember(dest => dest.CompletionDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.CompletionDate)));
        }
    }
}
