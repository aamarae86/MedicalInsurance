using AutoMapper;
using ERP._System.__PmPropertiesModule._ArInvoiceHd;
using ERP._System.__PmPropertiesModule._ArInvoiceTr;
using ERP._System._ArInvoiceHd.Dto;
using ERP._System._ArInvoiceTr.Dto;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using System.Linq;

namespace ERP._System.__AccountModule._ArInvoiceHd.Dto
{
    public class ArInvoiceHdMapperProfile : Profile
    {
        public ArInvoiceHdMapperProfile()
        {
            CreateMap<ArInvoiceHd, ArInvoiceHdDto>()
                .ForPath(dest => dest.FndLookupValuesArInvoiceHdStatusLkp.NameAr, source => source.MapFrom(o => o.FndLookupValuesArInvoiceHdStatusLkp.GetLookupValue()))
                .ForPath(dest => dest.FndLookupValuesArInvoiceHdStatusLkp.NameEn, source => source.MapFrom(o => o.FndLookupValuesArInvoiceHdStatusLkp.GetLookupValue()))
                .ForPath(dest => dest.FndLookupValuesArInvoiceHdSourceLkp.NameAr, source => source.MapFrom(o => o.FndLookupValuesArInvoiceHdSourceLkp.GetLookupValue()))
                .ForPath(dest => dest.FndLookupValuesArInvoiceHdSourceLkp.NameEn, source => source.MapFrom(o => o.FndLookupValuesArInvoiceHdSourceLkp.GetLookupValue()))

                .ForMember(dest => dest.TotalAmount, source => source.MapFrom(o => o.ArInvoiceTr.Sum(s=>s.Amount) )) 
                .ForMember(dest => dest.HdDate, source => source.MapFrom(o => o.HdDate.HasValue ? o.HdDate.Value.ToString(Formatters.DateFormat) : string.Empty));


    

            CreateMap<CreateArInvoiceHdDto, ArInvoiceHd>()
                .ForMember(dest => dest.HdDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.HdDate)));

            CreateMap<ArInvoiceHdEditDto, ArInvoiceHd>()
                .ForMember(dest => dest.HdDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.HdDate)));

            CreateMap<ArInvoiceTrDto, ArInvoiceTr>().ReverseMap();
        }
    }
}
