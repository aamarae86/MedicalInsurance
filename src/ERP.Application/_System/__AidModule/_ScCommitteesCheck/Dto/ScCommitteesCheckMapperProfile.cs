using AutoMapper;
using ERP.Helpers.Core;

namespace ERP._System.__AidModule._ScCommitteesCheck.Dto
{
    public class ScCommitteesCheckMapperProfile : Profile
    {
        public ScCommitteesCheckMapperProfile()
        {
            CreateMap<ScCommitteesCheck, ScCommitteesCheckDto>()
               .ForMember(dest => dest.MaturityDate, source => source.MapFrom(o => o.MaturityDate == null ? string.Empty : o.MaturityDate.Value.ToString(Formatters.DateFormat)))
               .ForMember(dest => dest.OperationDate, source => source.MapFrom(o => o.OperationDate == null ? string.Empty : o.OperationDate.Value.ToString(Formatters.DateFormat)));

            CreateMap<CreateScCommitteesCheckDto, ScCommitteesCheck>()
              .ForMember(dest => dest.MaturityDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.MaturityDate)))
              .ForMember(dest => dest.OperationDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.OperationDate)));

            CreateMap<ScCommitteesCheckEditDto, ScCommitteesCheck>()
              .ForMember(dest => dest.MaturityDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.MaturityDate)))
              .ForMember(dest => dest.OperationDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.OperationDate)));
        }
    }
}
