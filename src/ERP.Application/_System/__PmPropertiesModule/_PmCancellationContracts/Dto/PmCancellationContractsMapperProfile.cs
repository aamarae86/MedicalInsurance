using AutoMapper;
using ERP.Helpers.Core;

namespace ERP._System.__PmPropertiesModule._PmCancellationContracts.Dto
{
    public class PmCancellationContractsMapperProfile : Profile
    {
        public PmCancellationContractsMapperProfile()
        {
            CreateMap<PmCancellationContracts, PmCancellationContractsDto>()
               .ForMember(dest => dest.CancellationDate, source => source.MapFrom(o => o.CancellationDate.HasValue ? o.CancellationDate.Value.ToString(Formatters.DateFormat) : string.Empty));

            CreateMap<CreatePmCancellationContractsDto, PmCancellationContracts>()
               .ForMember(dest => dest.CancellationDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.CancellationDate)));

            CreateMap<PmCancellationContractsEditDto, PmCancellationContracts>()
              .ForMember(dest => dest.CancellationDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.CancellationDate)));
        }
    }
}
