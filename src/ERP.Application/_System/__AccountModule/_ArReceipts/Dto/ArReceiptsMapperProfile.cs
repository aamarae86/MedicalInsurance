using AutoMapper;
using ERP.Helpers.Core;

namespace ERP._System.__AccountModule._ArReceipts.Dto
{
    public class ArReceiptsMapperProfile : Profile
    {
        public ArReceiptsMapperProfile()
        {
            CreateMap<ArReceipts, ArReceiptsDto>()
               .ForMember(dest => dest.ReceiptDate, source => source.MapFrom(o => o.ReceiptDate.ToString(Formatters.DateFormat)));

            CreateMap<ArReceiptsCreateDto, ArReceipts>()
               .ForMember(dest => dest.ReceiptDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.ReceiptDate)));

            CreateMap<ArReceiptsEditDto, ArReceipts>()
               .ForMember(dest => dest.ReceiptDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.ReceiptDate)));

            CreateMap<ArReceiptsOnAccount, ArReceiptsOnAccountDto>()
                .ForMember(dest => dest.ApplyDate, source => source.MapFrom(o => o.ApplyDate.ToString(Formatters.DateFormat)));

            CreateMap<ArReceiptsOnAccountDto, ArReceiptsOnAccount>()
               .ForMember(dest => dest.ApplyDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.ApplyDate)));

            CreateMap<ArReceiptDetails, ArReceiptDetailsDto>()
               .ForMember(dest => dest.MaturityDate, source => source.MapFrom(o => o.MaturityDate.ToString(Formatters.DateFormat)));

            CreateMap<ArReceiptDetailsDto, ArReceiptDetails>()
               .ForMember(dest => dest.MaturityDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.MaturityDate)));
        }
    }
}
