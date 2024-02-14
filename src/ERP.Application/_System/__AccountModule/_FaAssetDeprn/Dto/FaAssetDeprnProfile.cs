using AutoMapper;
using ERP.Helpers.Core;

namespace ERP._System.__AccountModule._FaAssetDeprn.Dto
{
    public class FaAssetDeprnProfile : Profile
    {
        public FaAssetDeprnProfile()
        {
            CreateMap<FaAssetDeprnHd, FaAssetDeprnHdDto>()
                .ForMember(d => d.StatusAr, options => options.MapFrom(s => s.StatusLkp.NameAr))
                .ForMember(d => d.StatusEn, options => options.MapFrom(s => s.StatusLkp.NameEn))
                .ForMember(d => d.PeriodAr, options => options.MapFrom(s => s.Period.PeriodNameAr))
                .ForMember(d => d.PeriodEn, options => options.MapFrom(s => s.Period.PeriodNameEn))
                .ForMember(d => d.StartDate, options => options.MapFrom(s => s.Period.StartDate.ToString(Formatters.DateFormat)))
                .ForMember(d => d.EndDate, options => options.MapFrom(s => s.Period.EndDate.ToString(Formatters.DateFormat)))
                .ForMember(d => d.AssetDescription, options => options.MapFrom(s => s.Asset != null ? s.Asset.Description.ToString() : string.Empty))
                .ForMember(d => d.AssetNumber, options => options.MapFrom(s => s.Asset != null ? s.Asset.AssetNumber.ToString() : string.Empty))
                .ForMember(d => d.AssetDeprnDate, options => options.MapFrom(s => s.AssetDeprnDate.HasValue ? s.AssetDeprnDate.Value.ToString(Formatters.DateFormat) : string.Empty))
                .ReverseMap();

            CreateMap<FaAssetDeprnHdCreateDto, FaAssetDeprnHd>()
               .ForMember(d => d.AssetDeprnDate, options => options.MapFrom(s => DateTimeController.ConvertToDateTime(s.AssetDeprnDate)))
               .ReverseMap();

            CreateMap<FaAssetDeprnHdEditDto, FaAssetDeprnHd>()
                .ForMember(d => d.AssetDeprnDate, options => options.MapFrom(s => DateTimeController.ConvertToDateTime(s.AssetDeprnDate)))
                .ReverseMap();

            CreateMap<FaAssetDeprnTr, FaAssetDeprnTrDto>()
                .ForMember(d => d.AssetLifeInMonths, options => options.MapFrom(s => s.Asset != null ? s.Asset.LifeInMonths.ToString() : string.Empty))
                .ForMember(d => d.AssetCurrentCost, options => options.MapFrom(s => s.Asset != null ? s.Asset.CurrentCost.ToString() : string.Empty))
                .ForMember(d => d.AssetOriginalCost, options => options.MapFrom(s => s.Asset != null ? s.Asset.OriginalCost.ToString() : string.Empty))
                .ForMember(d => d.AssetDescription, options => options.MapFrom(s => s.Asset != null ? s.Asset.Description.ToString() : string.Empty))
                .ForMember(d => d.AssetNumber, options => options.MapFrom(s => s.Asset != null ? s.Asset.AssetNumber.ToString() : string.Empty))
                .ForMember(d => d.AssetProrateDate, options => options.MapFrom(s => s.Asset != null ? s.Asset.ProrateDate.ToString() : string.Empty))
                .ForMember(d => d.AssetSalvageValue, options => options.MapFrom(s => s.Asset != null ? s.Asset.SalvageValue.ToString() : string.Empty))
                .ReverseMap();

            CreateMap<FaAssetDeprnTrDtl, FaAssetDeprnTrDtlDto>()
                .ForMember(d => d.GlCodeComDetails, options => options.MapFrom(s => s.GlCodeComDetails))
                .ForMember(d => d.Account, options => options.MapFrom(s => s.AccountId.ToString()))
                .ReverseMap();
        }
    }
}
