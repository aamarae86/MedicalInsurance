using AutoMapper;
using ERP._System._Projects;
using ERP.Helpers.Core;

namespace ERP._System.__CRM._CrmProjects.Dto
{
    public class CrmProjectsMapperProfile : Profile
    {
        public CrmProjectsMapperProfile()
        {
            CreateMap<CrmProjects, CrmProjectsDto>()
               .ForMember(dest => dest.ProjectDate, source => source.MapFrom(o => o.ProjectDate == null ? string.Empty : o.ProjectDate.ToString(Formatters.DateFormat)));

            CreateMap<CrmProjectsCreateDto, CrmProjects>()
               .ForMember(dest => dest.ProjectDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.ProjectDate)));

            CreateMap<CrmProjectsEditDto, CrmProjects>()
               .ForMember(dest => dest.ProjectDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.ProjectDate)));
        }
    }
}
