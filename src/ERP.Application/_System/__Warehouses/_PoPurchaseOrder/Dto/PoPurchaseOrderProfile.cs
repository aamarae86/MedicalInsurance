using AutoMapper;
using ERP.Helpers.Core;

namespace ERP._System.__Warehouses._PoPurchaseOrder.Dto
{
    public class PoPurchaseOrderProfile : Profile
    {
        public PoPurchaseOrderProfile()
        {
            CreateMap<PoPurchaseOrderHd, PoPurchaseOrderDto>()
                .ForMember(d => d.IvWarehouseName, options => options.MapFrom(s => s.Warehouses.WarehouseName))
                .ForMember(d => d.IvWarehouseNumber, options => options.MapFrom(s => s.Warehouses.WarehouseNumber))
                .ForMember(d => d.VendorNameAr, options => options.MapFrom(s => s.Vendor.VendorNameAr))
                .ForMember(d => d.VendorNameEn, options => options.MapFrom(s => s.Vendor.VendorNameEn))
                .ForMember(d => d.VendorNumber, options => options.MapFrom(s => s.Vendor.VendorNumber))
                .ForMember(d => d.PurchaseOrderDate, options => options.MapFrom(s => s.PurchaseOrderDate.ToString(Formatters.DateFormat)))
                .ForMember(d => d.StatusAr, options => options.MapFrom(s => (s.FndLookupValuesStatusLkp == null) ? string.Empty : s.FndLookupValuesStatusLkp.NameAr))
                .ForMember(d => d.StatusEn, options => options.MapFrom(s => (s.FndLookupValuesStatusLkp == null) ? string.Empty : s.FndLookupValuesStatusLkp.NameEn))
                .ReverseMap();

            CreateMap<PoPurchaseOrderEditDto, PoPurchaseOrderHd>()
                .ForMember(d => d.PurchaseOrderDate, options => options.MapFrom(s => DateTimeController.ConvertToDateTime(s.PurchaseOrderDate)))
                .ReverseMap();

            CreateMap<PoPurchaseOrderCreateDto, PoPurchaseOrderHd>()
                .ForMember(d => d.PurchaseOrderDate, options => options.MapFrom(s => DateTimeController.ConvertToDateTime(s.PurchaseOrderDate)))
                .ReverseMap();

            CreateMap<PoPurchaseOrderTr, PoPurchaseOrderDetailsDto>()
                .ForMember(d => d.IvItemName, options => options.MapFrom(s => s.Items.ItemName))
                .ForMember(d => d.IvItemNumber, options => options.MapFrom(s => s.Items.ItemNumber))
                .ForMember(d => d.ReceivedDate, options => options.MapFrom(s => s.ReceivedDate.HasValue ? s.ReceivedDate.Value.ToString(Formatters.DateFormat) : string.Empty))
                .ReverseMap();
        }
    }
}
