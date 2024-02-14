using AutoMapper;
using ERP._System.__PmPropertiesModule._PmCancellationContracts.Dto;
using ERP._System.__PmPropertiesModule._PmContractPayments;
using ERP._System.__PmPropertiesModule._PmContractPayments.Dto;
using ERP.Helpers.Core;


namespace ERP._System.__SalesModule._IvReturnSaleHd.Dto
{
   public class IvReturnSaleHdMapperProfile : Profile
    {
        public IvReturnSaleHdMapperProfile()
        {
            CreateMap<IvReturnSaleHd, IvReturnSaleHdDto>()
                     .ForMember(dest => dest.IvReturnSaleTrdetails, source => source.MapFrom(o => o.IvReturnSaleTrs))
                .ForMember(dest => dest.IvReturnSaleDate, source => source.MapFrom(o => o.IvReturnSaleDate.ToString(Formatters.DateFormat)));


            CreateMap<IvReturnSaleHdDto, IvReturnSaleHd>()
                 .ForMember(dest => dest.IvReturnSaleTrs, source => source.MapFrom(o => o.IvReturnSaleTrdetails))
                    .ForMember(dest => dest.IvReturnSaleDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.IvReturnSaleDate.ToString())));

            CreateMap<IvReturnSaleHdCreateDto, IvReturnSaleHd>()
                .ForMember(dest => dest.CurrencyRate, source => source.MapFrom(o => o.ReturnCurrencyRate))
                .ForMember(dest => dest.IvReturnSaleDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.IvReturnSaleDate.ToString())));
              

            CreateMap<IvReturnSaleHd, IvReturnSaleHdEditDto>()
               .ForMember(dest => dest.IvReturnSaleDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.IvReturnSaleDate.ToString())));

            CreateMap<IvReturnSaleHdEditDto, IvReturnSaleHd>()
             .ForMember(dest => dest.IvReturnSaleDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.IvReturnSaleDate.ToString()))).ReverseMap();

            CreateMap<IvReturnSaleHdEditDto, IvReturnSaleHdDto>()
                 .ForMember(dest => dest.IvReturnSaleDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.IvReturnSaleDate.ToString()))).ReverseMap();
          
            CreateMap<IvReturnSaleTrDto, IvReturnSaleTr>()
                 .ForMember(dest => dest.Avilablequantity, source => source.MapFrom(o => o.AvailableQty))
                .ReverseMap();
         


        }



    }
}
