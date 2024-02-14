using AutoMapper;
using ERP.Helpers.Core;

namespace ERP._System.__Warehouses._IvStoreIssue.Dto
{
    public class IvStoreIssueProfile : Profile
    {
        public IvStoreIssueProfile()
        {
            CreateMap<IvStoreIssueHd, IvStoreIssueDto>()
                .ForMember(d => d.IvWarehouseName, options => options.MapFrom(s => s.Warehouses.WarehouseName))
                .ForMember(d => d.IvWarehouseNumber, options => options.MapFrom(s => s.Warehouses.WarehouseNumber))
                .ForMember(d => d.StoreIssueDate, options => options.MapFrom(s => s.StoreIssueDate.ToString(Formatters.DateFormat)))
                .ForMember(d => d.StatusAr, options => options.MapFrom(s => (s.FndLookupValuesStatusLkp == null) ? string.Empty : s.FndLookupValuesStatusLkp.NameAr))
                .ForMember(d => d.StatusEn, options => options.MapFrom(s => (s.FndLookupValuesStatusLkp == null) ? string.Empty : s.FndLookupValuesStatusLkp.NameEn))
                .ForMember(d => d.BeneficiaryTypeAr, options => options.MapFrom(s => (s.FndLookupValuesBeneficiaryTypeLkp == null) ? string.Empty : s.FndLookupValuesBeneficiaryTypeLkp.NameAr))
                .ForMember(d => d.BeneficiaryTypeEn, options => options.MapFrom(s => (s.FndLookupValuesBeneficiaryTypeLkp == null) ? string.Empty : s.FndLookupValuesBeneficiaryTypeLkp.NameEn))
                .ForMember(d => d.IssueTypeAr, options => options.MapFrom(s => (s.FndLookupValuesIssueTypeLkp == null) ? string.Empty : s.FndLookupValuesIssueTypeLkp.NameAr))
                .ForMember(d => d.IssueTypeEn, options => options.MapFrom(s => (s.FndLookupValuesIssueTypeLkp == null) ? string.Empty : s.FndLookupValuesIssueTypeLkp.NameEn))
                .ReverseMap();

            CreateMap<IvStoreIssueEditDto, IvStoreIssueHd>()
                .ForMember(d => d.StoreIssueDate, options => options.MapFrom(s => DateTimeController.ConvertToDateTime(s.StoreIssueDate)))
                .ReverseMap();

            CreateMap<IvStoreIssueCreateDto, IvStoreIssueHd>()
                .ForMember(d => d.StoreIssueDate, options => options.MapFrom(s => DateTimeController.ConvertToDateTime(s.StoreIssueDate)))
                .ReverseMap();

            CreateMap<IvStoreIssueTr, IvStoreIssueDetailsDto>()
                .ForMember(d => d.IvItemName, options => options.MapFrom(s => s.Items.ItemName))
                .ForMember(d => d.IvItemNumber, options => options.MapFrom(s => s.Items.ItemNumber))
                .ForMember(d => d.IvUnitName, options => options.MapFrom(s => s.Units.UnitName))
                .ReverseMap();
        }
    }
}
