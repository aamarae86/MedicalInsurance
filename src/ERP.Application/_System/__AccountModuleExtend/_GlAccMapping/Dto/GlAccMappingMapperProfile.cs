using AutoMapper;
using ERP._System.__AccountModule._GlAccMappingHd._GlAccMappingTr;
using ERP._System.__AccountModule._GlAccMappingHd._GlAccMappingTrDtl;
using ERP.Helpers.Core;

namespace ERP._System.__AccountModuleExtend._GlAccMapping.Dto
{
    public class GlAccMappingMapperProfile : Profile
    {
        public GlAccMappingMapperProfile()
        {
            CreateMap<GlAccMappingTr, GlAccMappingTrDto>()
              .ForMember(dest => dest.trDtlCount, source => source.MapFrom(o => o.GlAccMappingTrDtl.Count))
              .ForMember(dest => dest.rowStatus, source => source.MapFrom(o => DetailRowStatus.RowStatus.NoAction.ToString()))
              ;

            CreateMap<GlAccMappingTrDtl, GlAccMappingTrDtlDto>()
              .ForMember(dest => dest.FromAccDescriptionAr, source => source.MapFrom(o => $"{o.GlAccDetailFrom.DescriptionAr}-{o.GlAccDetailFrom.Code}"))
              .ForMember(dest => dest.FromAccDescriptionEn, source => source.MapFrom(o => $"{o.GlAccDetailFrom.DescriptionEn}-{o.GlAccDetailFrom.Code}"))
              .ForMember(dest => dest.ToAccDescriptionAr, source => source.MapFrom(o => $"{o.GlAccDetailTo.DescriptionAr}-{o.GlAccDetailFrom.Code}"))
              .ForMember(dest => dest.ToAccDescriptionEn, source => source.MapFrom(o => $"{o.GlAccDetailTo.DescriptionEn}-{o.GlAccDetailFrom.Code}"))
              .ForMember(dest => dest.TypeLkpNameAr, source => source.MapFrom(o => o.FndTypeLkp.NameAr))
              .ForMember(dest => dest.TypeLkpNameEn, source => source.MapFrom(o => o.FndTypeLkp.NameEn))
              .ForMember(dest => dest.rowStatus, source => source.MapFrom(o => DetailRowStatus.RowStatus.NoAction.ToString()))
              ;
        }
    }
}
