using AutoMapper;
using ERP.Core.Helpers.Parameters;

namespace ERP.Currencies.Dto
{
    public class CurrencyMapProfile : Profile
    {
        public CurrencyMapProfile()
        {
            CreateMap<CreateCurrencyDto, Currency>();
            
            CreateMap<CurrencyDto, Currency>();
            CreateMap<GetAllPagedAndSortedWithParams<CurrencySearchDto>, GetAllPagedAndSortedWithParams<Currency>>();
            CreateMap<GetAllPagedAndSortedWithParams<Currency>, GetAllPagedAndSortedWithParams<CurrencySearchDto>>();


            CreateMap<Currency, CurrencyDto>();

            CreateMap<CurrencySearchDto, Currency>();
            CreateMap<Currency, CurrencySearchDto>();
            CreateMap<Currency, CurrencyListDto>();
            CreateMap<Currency, CurrencyEditDto>();

            CreateMap<CurrencyEditDto,Currency>();
        }
    }
}
