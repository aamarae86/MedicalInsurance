using AutoMapper;
using ERP.Helpers.Core;

namespace ERP._System.__PmPropertiesModule._FmEngineers.Dto
{
    public class FmEngineersMapperProfile : Profile
    {
        public FmEngineersMapperProfile()
        {
            CreateMap<FmEngineers, FmEngineersDto>()
               .ForMember(dest => dest.HireDate, source => source.MapFrom(o => o.HireDate == null ? string.Empty : o.HireDate.Value.ToString(Formatters.DateFormat)))
               .ForMember(dest => dest.EmployeeName, source => source.MapFrom(o => o.HrPersons.FirstName))
               .ForMember(dest => dest.BirthDate, source => source.MapFrom(o => o.HrPersons.BirthDate.ToString(Formatters.DateFormat)))
               .ForMember(dest => dest.GenderAr, source => source.MapFrom(o => o.HrPersons.FndGenderLkp.NameAr))
               .ForMember(dest => dest.GenderEn, source => source.MapFrom(o => o.HrPersons.FndGenderLkp.NameEn))
               .ForMember(dest => dest.NationalityAr, source => source.MapFrom(o => o.HrPersons.FndNationalityLkp.NameAr))
               .ForMember(dest => dest.NationalityEn, source => source.MapFrom(o => o.HrPersons.FndNationalityLkp.NameEn))
               .ForMember(dest => dest.FndStatusLkpNameAr, source => source.MapFrom(o => o.FndStatusLkp.NameAr))
               .ForMember(dest => dest.FndStatusLkpNameEn, source => source.MapFrom(o => o.FndStatusLkp.NameEn))
               ;

            CreateMap<FmEngineersCreateDto, FmEngineers>()
               .ForMember(dest => dest.HireDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.HireDate)));

            CreateMap<FmEngineersEditDto, FmEngineers>()
               .ForMember(dest => dest.HireDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.HireDate)));
        }
    }
}
