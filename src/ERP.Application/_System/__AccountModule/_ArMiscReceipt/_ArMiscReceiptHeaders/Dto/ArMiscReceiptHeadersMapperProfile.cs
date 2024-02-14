using AutoMapper;
using ERP._System._ArMiscReceipt._ArMiscReceiptHeaders.Dto;
using ERP._System._ArMiscReceiptHeaders;
using ERP.Helpers.Core;

namespace ERP._System.__AccountModule._ArMiscReceipt._ArMiscReceiptHeaders.Dto
{
    public class ArMiscReceiptHeadersMapperProfile : Profile
    {
        public ArMiscReceiptHeadersMapperProfile()
        {
            CreateMap<ArMiscReceiptHeaders, ArMiscReceiptHeadersDto>()
              .ForMember(dest => dest.MiscReceiptDate, source => source.MapFrom(o => o.MiscReceiptDate.HasValue ? o.MiscReceiptDate.Value.ToString(Formatters.DateFormat) : string.Empty))
              ;

            CreateMap<CreateArMiscReceiptHeadersDto, ArMiscReceiptHeaders>()
                .ForMember(dest => dest.MiscReceiptDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.MiscReceiptDate)));

            CreateMap<ArMiscReceiptHeadersEditDto, ArMiscReceiptHeaders>()
                .ForMember(dest => dest.MiscReceiptDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.MiscReceiptDate)));
        }
    }
}
