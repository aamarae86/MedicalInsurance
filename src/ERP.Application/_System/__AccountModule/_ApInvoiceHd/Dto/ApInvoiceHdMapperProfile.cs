using AutoMapper;
using ERP._System.__AccountModule._ApInvoiceHd._ApInvoiceTr;
using ERP.Helpers.Core;

namespace ERP._System.__AccountModule._ApInvoiceHd.Dto
{
    public class ApInvoiceHdMapperProfile : Profile
    {
        public ApInvoiceHdMapperProfile()
        {
            CreateMap<ApInvoiceHd, ApInvoiceHdDto>()
               .ForMember(dest => dest.HdDate, source => source.MapFrom(o => o.HdDate.ToString(Formatters.DateFormat)))
               .ForMember(dest => dest.TaxNo, source => source.MapFrom(o => o.ApVendors.TaxNo));

            CreateMap<ApInvoiceHdCreateDto, ApInvoiceHd>()
                .ForMember(dest => dest.HdDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.HdDate)));

            CreateMap<ApInvoiceHdEditDto, ApInvoiceHd>()
                .ForMember(dest => dest.HdDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.HdDate)));
        }
    }
}
