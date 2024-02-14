using AutoMapper;
using ERP._System.__SpGuarantees._SpContracts._SpContractDetails;
using ERP.Helpers.Core;

namespace ERP._System.__SpGuarantees._SpContracts.Dto
{
    public class SpContractsMapperProfile : Profile
    {
        public SpContractsMapperProfile()
        {
            CreateMap<SpContracts, SpContractsDto>()
               .ForMember(dest => dest.ContractDate, source => source.MapFrom(o => o.ContractDate.ToString(Formatters.DateFormat)));

            CreateMap<SpContractsCreateDto, SpContracts>()
               .ForMember(dest => dest.ContractDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.ContractDate)));

            CreateMap<SpContractsEditDto, SpContracts>()
                .ForMember(dest => dest.ContractDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.ContractDate)));

            CreateMap<SpContractDetails, SpContractDetailsDto>()
                .ForMember(dest => dest.StartDate, source => source.MapFrom(o => o.StartDate.ToString(Formatters.DateFormat)))
                .ForMember(dest => dest.EndDate, source => source.MapFrom(o => o.EndDate.HasValue ? o.EndDate.Value.ToString(Formatters.DateFormat) : string.Empty));

            CreateMap<SpContractDetailsDto, SpContractDetails>()
               .ForMember(dest => dest.StartDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.StartDate)))
               .ForMember(dest => dest.EndDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.EndDate)))
               ;
        }
    }
}
