using AutoMapper;
using ERP.Helpers.Core;

namespace ERP._System.__AidModule._ScPortalRequestMgrDecision.Dto
{
    public class ScPortalRequestMgrDecisionMapperProfile : Profile
    {
        public ScPortalRequestMgrDecisionMapperProfile()
        {
            CreateMap<ScPortalRequestMgrDecision, ScPortalRequestMgrDecisionDto>()
               .ForMember(dest => dest.DecisionDate, source => source.MapFrom(o => o.DecisionDate == null ? string.Empty : o.DecisionDate.Value.ToString(Formatters.DateFormat)));

            CreateMap<ScPRMgrDecisionElectronicAidDto, ScPRMgrDecisionElectronicAid>();

            CreateMap<ScPRMgrDecisionElectronicAid, ScPRMgrDecisionElectronicAidDto>()
                .ForMember(dest => dest.ElectronicTypeLkpNameAr, source => source.MapFrom(o => o.FndElectronicTypeLkp.NameAr))
                .ForMember(dest => dest.ElectronicTypeLkpNameEn, source => source.MapFrom(o => o.FndElectronicTypeLkp.NameEn))
                ;

            CreateMap<ScPortalRequestMgrDecisionEditDto, ScPortalRequestMgrDecision>()
               .ForMember(dest => dest.DecisionDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.DecisionDate)));
        }
    }
}
