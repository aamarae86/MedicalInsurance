using AutoMapper;
using ERP.Helpers.Core;
using ERP.Core.Helpers.Extensions;

namespace ERP._System.__Warehouses._IvAdjustmentHd.Dto
{
    public class IvAdjustmentHdMapperProfile : Profile
    {
        public IvAdjustmentHdMapperProfile()
        {
            CreateMap<IvAdjustmentHd, IvAdjustmentHdDto>()
                .ForPath(dest => dest.FndLookupValuesStatusLkpIvAdjustmentHd.NameAr, source => source.MapFrom(o => o.FndLookupValuesStatusLkpIvAdjustmentHd.GetLookupValue()))
                .ForPath(dest => dest.FndLookupValuesStatusLkpIvAdjustmentHd.NameEn, source => source.MapFrom(o => o.FndLookupValuesStatusLkpIvAdjustmentHd.GetLookupValue()))               
                .ForMember(dest => dest.AdjustmentDate, source => source.MapFrom(o => o.AdjustmentDate.HasValue ? o.AdjustmentDate.Value.ToString(Formatters.DateFormat) : string.Empty));


            CreateMap<CreateIvAdjustmentHdDto, IvAdjustmentHd>()
               .ForMember(dest => dest.AdjustmentDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.AdjustmentDate)));

            CreateMap<IvAdjustmentHdEditDto, IvAdjustmentHd>()
              .ForMember(dest => dest.AdjustmentDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.AdjustmentDate)));
        }
    }
}
