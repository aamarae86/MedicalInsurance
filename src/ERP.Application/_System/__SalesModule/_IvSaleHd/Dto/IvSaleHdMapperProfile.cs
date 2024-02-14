using AutoMapper;
using ERP._System.__PmPropertiesModule._PmCancellationContracts.Dto;
using ERP._System.__PmPropertiesModule._PmContractPayments;
using ERP._System.__PmPropertiesModule._PmContractPayments.Dto;
using ERP.Helpers.Core;

namespace ERP._System.__SalesModule._IvSaleHd.Dto
{
    public class IvSaleHdMapperProfile : Profile
    {
        public IvSaleHdMapperProfile()
        {
            CreateMap<IvSaleHd, IvSaleHdDto>()
                .ForMember(dest => dest.IvSaleTrDetails, source => source.MapFrom(o => o.IvSaleTrs))
                .ForMember(dest => dest.IvSaleDate, source => source.MapFrom(o => o.IvSaleDate.ToString(Formatters.DateTimeFormat)));

            CreateMap<IvSaleHdDto, IvSaleHd>()
                .ForMember(dest => dest.IvSaleDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.IvSaleDate.ToString())));

            CreateMap<IvSaleHdCreateDto, IvSaleHd>()
                .ForMember(dest => dest.IvSaleDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.saledateToday.ToString())))
                .ForMember(dest => dest.CurrencyRate, source => source.MapFrom(o => o.CustomerCurrencyRate));

            CreateMap<IvSaleHd, IvSaleHdEditDto>()
               .ForMember(dest => dest.IvSaleDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.IvSaleDate.ToString())));

            CreateMap<IvSaleHdEditDto, IvSaleHd>()
             .ForMember(dest => dest.IvSaleDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.IvSaleDate.ToString()))).ReverseMap();

            CreateMap<IvSaleHdEditDto, IvSaleHdDto>()
             .ForMember(dest => dest.IvSaleDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.IvSaleDate.ToString()))).ReverseMap();

            CreateMap<IvSaleTr, IvSaleTrDto>()
             .ForPath(dest => dest.ItemName, source => source.MapFrom(o => o.IvItems.ItemName));

            CreateMap<IvSaleTrDto, IvSaleTr>()
                 .ForMember(dest => dest.IvItems, source => source = null)
                .ForMember(dest => dest.IvSaleHd, source => source.Ignore());

        }
    }
}
