using AutoMapper;
using ERP._System.__Warehouses._IvReceiveHd._IvReceiveTr;
using ERP._System.__Warehouses._PoPurchaseOrder;
using ERP.Helpers.Core;

namespace ERP._System.__Warehouses._IvReceiveHd.Dto
{
    public class IvReceiveMapperProfile : Profile
    {
        public IvReceiveMapperProfile()
        {
            CreateMap<IvReceiveTr, IvReceiveTrDto>()
                .ForMember(dest => dest.Id, source => source.MapFrom(o => o.Id))
                .ForMember(dest => dest.IvUnitId, source => source.MapFrom(o => o.IvUnitId))
                .ForMember(dest => dest.IvItemId, source => source.MapFrom(o => o.IvItemId))
                .ForMember(dest => dest.IvReceiveHdId, source => source.MapFrom(o => o.IvReceiveHdId))
                .ForMember(dest => dest.Qty, source => source.MapFrom(o => o.Qty))
                .ForMember(dest => dest.TaxAmount, source => source.MapFrom(o => o.TaxAmount))
                .ForMember(dest => dest.UnitPrice, source => source.MapFrom(o => o.UnitPrice))
                .ForMember(dest => dest.Item, source => source.MapFrom(o => o.IvItems.ItemName ?? string.Empty))
                .ForMember(dest => dest.Unit, source => source.MapFrom(o => o.IvUnits.UnitName ?? string.Empty))
                .ForMember(dest => dest.ItemNumber, source => source.MapFrom(o => o.IvItems.ItemNumber ?? string.Empty))
                .ForMember(dest => dest.rowStatus, source => DetailRowStatus.RowStatus.NoAction.ToString());

            CreateMap<PoPurchaseOrderTr, IvReceiveTrDto>()
                .ForMember(dest => dest.Id, source => source.MapFrom(o => 0))
                .ForMember(dest => dest.IvUnitId, source => source.MapFrom(o => o.Items.IvUnitId))
                .ForMember(dest => dest.IvItemId, source => source.MapFrom(o => o.IvItemId))
                .ForMember(dest => dest.Qty, source => source.MapFrom(o => o.QtyOrdered))
                .ForMember(dest => dest.UnitPrice, source => source.MapFrom(o => o.UnitPrice))
                .ForMember(dest => dest.TaxAmount, source => source.MapFrom(o => 0))
                .ForMember(dest => dest.Item, source => source.MapFrom(o => o.Items.ItemName ?? string.Empty))
                .ForMember(dest => dest.Unit, source => source.MapFrom(o => o.Items.IvUnits.UnitName ?? string.Empty))
                .ForMember(dest => dest.ItemNumber, source => source.MapFrom(o => o.Items.ItemNumber ?? string.Empty))
                .ForMember(dest => dest.rowStatus, source => DetailRowStatus.RowStatus.NoAction.ToString());
        }

    }
}
