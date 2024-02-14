using AutoMapper;
using ERP._System.__PmPropertiesModule._PmCancellationContracts.Dto;
using ERP._System.__PmPropertiesModule._PmContractPayments;
using ERP._System.__PmPropertiesModule._PmContractPayments.Dto;
using ERP.Helpers.Core;

namespace ERP._System.__Warehouses._IvReturnReceiveHd.Dto
{
   public  class IvReturnReceiveHdMapperProfile : Profile
    {
        public IvReturnReceiveHdMapperProfile()
        {
            CreateMap<IvReturnReceiveHd, IvReturnReceiveHdDto>()
                     .ForMember(dest => dest.IvReturnReceivedetails, source => source.MapFrom(o => o.IvReturnReceiveTrs))
                .ForMember(dest => dest.IvReturnReceiveDate, source => source.MapFrom(o => o.IvReturnReceiveDate.ToString(Formatters.DateFormat)));


            CreateMap<IvReturnReceiveHdDto, IvReturnReceiveHd>()
                 .ForMember(dest => dest.IvReturnReceiveTrs, source => source.MapFrom(o => o.IvReturnReceivedetails))
                    .ForMember(dest => dest.IvReturnReceiveDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.IvReturnReceiveDate.ToString())));

            CreateMap<IvReturnReceiveHdCreateDto, IvReturnReceiveHd>()
                .ForMember(dest => dest.CurrencyRate, source => source.MapFrom(o => o.ReturnCurrencyRate))
                .ForMember(dest => dest.IvReturnReceiveDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.IvReturnReceiveDate.ToString())));


            CreateMap<IvReturnReceiveHd, IvReturnReceiveHdEditDto>()
               .ForMember(dest => dest.IvReturnReceiveDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.IvReturnReceiveDate.ToString())));

            CreateMap<IvReturnReceiveHdEditDto, IvReturnReceiveHd>()
             .ForMember(dest => dest.IvReturnReceiveDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.IvReturnReceiveDate.ToString()))).ReverseMap();

            CreateMap<IvReturnReceiveHdEditDto, IvReturnReceiveHdDto>()
                     .ForMember(dest => dest.IvReturnReceiveDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.IvReturnReceiveDate.ToString()))).ReverseMap();
           
            CreateMap<IvReturnReceiveTrDto, IvReturnReceiveTr>().ReverseMap();
            


        }
    }
}
