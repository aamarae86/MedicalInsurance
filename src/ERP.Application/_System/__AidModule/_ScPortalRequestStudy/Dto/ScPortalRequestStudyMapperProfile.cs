using AutoMapper;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__AidModule._ScPortalRequestStudy.Dto
{
    public class ScPortalRequestStudyMapperProfile : Profile
    {
        public ScPortalRequestStudyMapperProfile()
        {
            CreateMap<ScPortalRequestStudy, ScPortalRequestStudyDto>()
               .ForMember(dest => dest.StudyDate, source => source.MapFrom(o => o.StudyDate == null ? string.Empty : o.StudyDate.Value.ToString(Formatters.DateFormat)))
               .ForMember(dest => dest.DecisionInfo, source => source.MapFrom(o => o.ScPortalRequest.FinalDecision))
               .ForMember(dest => dest.IsMaintenance, source => source.MapFrom(o => o.ScPortalRequest.AidRequestType.IsMaintenance));

            CreateMap<CreateScPortalRequestStudyDto, ScPortalRequestStudy>()
               .ForMember(dest => dest.StudyDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.StudyDate)));

            CreateMap<ScPortalRequestStudyEditDto, ScPortalRequestStudy>()
               .ForMember(dest => dest.StudyDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.StudyDate)));
        }
    }
}
