using AutoMapper;
using ERP._System.__SpGuarantees._SpCases;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__SpGuarantees._SpFamilies.Dto
{
    public class SpFamiliesMapperProfile : Profile
    {
        public SpFamiliesMapperProfile()
        {
            CreateMap<SpFamilies, SpFamiliesDto>()
              .ForMember(dest => dest.MotherDiedDate, source => source.MapFrom(o => o.MotherDiedDate == null ? string.Empty : o.MotherDiedDate.Value.ToString(Formatters.DateFormat)))
              .ForMember(dest => dest.IdExpirationDate, source => source.MapFrom(o => o.IdExpirationDate == null ? string.Empty : o.IdExpirationDate.Value.ToString(Formatters.DateFormat)))
              .ForMember(dest => dest.FatherDiedDate, source => source.MapFrom(o => o.FatherDiedDate == null ? string.Empty : o.FatherDiedDate.Value.ToString(Formatters.DateFormat)))
              .ForMember(dest => dest.RegistrationDate, source => source.MapFrom(o => o.RegistrationDate.ToString(Formatters.DateFormat)))
              .ForMember(dest => dest.BirthDate, source => source.MapFrom(o => o.BirthDate.ToString(Formatters.DateFormat)));

            CreateMap<SpFamiliesCreateDto, SpFamilies>()
               .ForMember(dest => dest.BirthDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.BirthDate)))
               .ForMember(dest => dest.FatherDiedDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.FatherDiedDate)))
               .ForMember(dest => dest.IdExpirationDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.IdExpirationDate)))
               .ForMember(dest => dest.MotherDiedDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.MotherDiedDate)))
               .ForMember(dest => dest.RegistrationDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.RegistrationDate)))
               ;

            CreateMap<SpFamiliesEditDto, SpFamilies>()
               .ForMember(dest => dest.BirthDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.BirthDate)))
               .ForMember(dest => dest.FatherDiedDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.FatherDiedDate)))
               .ForMember(dest => dest.IdExpirationDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.IdExpirationDate)))
               .ForMember(dest => dest.MotherDiedDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.MotherDiedDate)))
               .ForMember(dest => dest.RegistrationDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.RegistrationDate)))
               ;

            CreateMap<SpFamilyCasesDto, SpCases>()
                .ForMember(dest => dest.BirthDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.BirthDate)));

            CreateMap<SpFamilies, SpFamilyCasesDto>()
              .ForMember(dest => dest.BirthDate, source => source.MapFrom(o => o.BirthDate.ToString(Formatters.DateFormat)));

        }
    }
}
