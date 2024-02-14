using AutoMapper;
using ERP._System._ApMiscPaymentHeaders;
using ERP._System._ArMiscPayment._ApMiscPaymentHeaders.Dto;
using ERP.Helpers.Core;
using System.Linq;

namespace ERP._System.__AccountModule._ArMiscPayment._ApMiscPaymentHeaders.Dto
{
    public class ApMiscPaymentHeadersMapperProfile : Profile
    {
        public ApMiscPaymentHeadersMapperProfile()
        {
            CreateMap<ApMiscPaymentHeaders, ApMiscPaymentHeadersDto>()
              .ForMember(dest => dest.CheckNumber, source => source.MapFrom(o => o.ApMiscPaymentDetails.FirstOrDefault().CheckNumber))
              .ForMember(dest => dest.FirstLinePortalUserId, source => source.MapFrom(o => o.ApMiscPaymentLines.FirstOrDefault().PortalUsersId))
              .ForMember(dest => dest.MiscPaymentDate, source => source.MapFrom(o => o.MiscPaymentDate.HasValue ? o.MiscPaymentDate.Value.ToString(Formatters.DateFormat) : string.Empty));

            CreateMap<CreateApMiscPaymentHeadersDto, ApMiscPaymentHeaders>()
              .ForMember(dest => dest.MiscPaymentDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.MiscPaymentDate)));

            CreateMap<ApMiscPaymentHeadersEditDto, ApMiscPaymentHeaders>()
              .ForMember(dest => dest.MiscPaymentDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.MiscPaymentDate)));
        }
    }
}
