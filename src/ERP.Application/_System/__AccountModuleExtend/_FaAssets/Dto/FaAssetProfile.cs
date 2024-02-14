using AutoMapper;
using ERP.Helpers.Core;

namespace ERP._System.__AccountModuleExtend._FaAssets.Dto
{
    public class FaAssetProfile : Profile
    {
        public FaAssetProfile()
        {
            CreateMap<FaAssets, FaAssetDto>()
                .ForMember(d => d.ParentAssetDescription, options => options.MapFrom(s => s.ParentAsset.Description))
                .ForMember(d => d.ParentAssetNumber, options => options.MapFrom(s => s.ParentAsset.AssetNumber))
                .ForMember(d => d.AmortizationStartDate, options => options.MapFrom(s => (s.AmortizationStartDate.HasValue) ? s.AmortizationStartDate.Value.ToString(Formatters.DateFormat) : ""))
                .ForMember(d => d.DatePlacedInService, options => options.MapFrom(s => (s.DatePlacedInService.HasValue) ? s.DatePlacedInService.Value.ToString(Formatters.DateFormat) : ""))
                .ForMember(d => d.ProrateDate, options => options.MapFrom(s => (s.ProrateDate.HasValue) ? s.ProrateDate.Value.ToString(Formatters.DateFormat) : ""))
                .ForMember(d => d.StatusAr, options => options.MapFrom(s => (s.StatusLkp == null) ? string.Empty : s.StatusLkp.NameAr))
                .ForMember(d => d.StatusEn, options => options.MapFrom(s => (s.StatusLkp == null) ? string.Empty : s.StatusLkp.NameEn))
                .ForMember(d => d.DeprenMethodLkpAr, options => options.MapFrom(s => (s.DeprenMethodLkp == null) ? string.Empty : s.DeprenMethodLkp.NameAr))
                .ForMember(d => d.DeprenMethodLkpEn, options => options.MapFrom(s => (s.DeprenMethodLkp == null) ? string.Empty : s.DeprenMethodLkp.NameEn))
                .ForMember(d => d.SalvageValueTypeLkpAr, options => options.MapFrom(s => (s.SalvageValueTypeLkp == null) ? string.Empty : s.SalvageValueTypeLkp.NameAr))
                .ForMember(d => d.SalvageValueTypeLkpEn, options => options.MapFrom(s => (s.SalvageValueTypeLkp == null) ? string.Empty : s.SalvageValueTypeLkp.NameEn))
                .ForMember(d => d.BookingTypeLkpAr, options => options.MapFrom(s => (s.BookingTypeLkp == null) ? string.Empty : s.BookingTypeLkp.NameAr))
                .ForMember(d => d.BookingTypeLkpEn, options => options.MapFrom(s => (s.BookingTypeLkp == null) ? string.Empty : s.BookingTypeLkp.NameEn))
                .ForMember(d => d.BoughtLkpAr, options => options.MapFrom(s => (s.BoughtLkp == null) ? string.Empty : s.BoughtLkp.NameAr))
                .ForMember(d => d.BoughtLkpEn, options => options.MapFrom(s => (s.BoughtLkp == null) ? string.Empty : s.BoughtLkp.NameEn))
                .ForMember(d => d.OwnershipLkpAr, options => options.MapFrom(s => (s.OwnershipLkp == null) ? string.Empty : s.OwnershipLkp.NameAr))
                .ForMember(d => d.OwnershipLkpEn, options => options.MapFrom(s => (s.OwnershipLkp == null) ? string.Empty : s.OwnershipLkp.NameEn))
                .ForMember(d => d.FaAssetCategoryAr, options => options.MapFrom(s => (s.AssetCategory == null) ? string.Empty : s.AssetCategory.AssetCategoryNameAr))
                .ForMember(d => d.FaAssetCategoryEn, options => options.MapFrom(s => (s.AssetCategory == null) ? string.Empty : s.AssetCategory.AssetCategoryNameEn))
                .ForMember(d => d.AssetTypeLkpAr, options => options.MapFrom(s => (s.AssetTypeLkp == null) ? string.Empty : s.AssetTypeLkp.NameAr))
                .ForMember(d => d.AssetTypeLkpEn, options => options.MapFrom(s => (s.AssetTypeLkp == null) ? string.Empty : s.AssetTypeLkp.NameEn))
                .ReverseMap();

            CreateMap<FaAssetEditDto, FaAssets>()
                .ForMember(d => d.AmortizationStartDate, options => options.MapFrom(s => DateTimeController.ConvertToDateTime(s.AmortizationStartDate)))
                .ForMember(d => d.DatePlacedInService, options => options.MapFrom(s => DateTimeController.ConvertToDateTime(s.DatePlacedInService)))
                .ForMember(d => d.ProrateDate, options => options.MapFrom(s => DateTimeController.ConvertToDateTime(s.ProrateDate)))
                .ReverseMap();

            CreateMap<FaAssetCreateDto, FaAssets>()
                .ForMember(d => d.AmortizationStartDate, options => options.MapFrom(s => DateTimeController.ConvertToDateTime(s.AmortizationStartDate)))
                .ForMember(d => d.DatePlacedInService, options => options.MapFrom(s => DateTimeController.ConvertToDateTime(s.DatePlacedInService)))
                .ForMember(d => d.ProrateDate, options => options.MapFrom(s => DateTimeController.ConvertToDateTime(s.ProrateDate)))
                .ReverseMap();
        }
    }
}
