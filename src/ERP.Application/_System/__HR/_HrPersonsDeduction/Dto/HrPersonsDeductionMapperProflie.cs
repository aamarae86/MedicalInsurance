using AutoMapper;
using ERP.Helpers.Core;

namespace ERP._System.__HR._HrPersonsDeduction.Dto
{
    public class HrPersonsDeductionMapperProflie : Profile
    {
        public HrPersonsDeductionMapperProflie()
        {
            CreateMap<HrPersonsDeductionTr, HrPersonsDeductionTrDto>()
               .ForMember(dest => dest.PersonName, source => source.MapFrom(o => $"{o.HrPersons.FirstName} {o.HrPersons.FatherName} {o.HrPersons.LastName}"))
               .ForMember(dest => dest.DeductionTypeLkpNameAr, source => source.MapFrom(o => o.FndDeductionTypeLkp.NameAr))
               .ForMember(dest => dest.DeductionTypeLkpNameEn, source => source.MapFrom(o => o.FndDeductionTypeLkp.NameEn))
               .ForMember(dest => dest.rowStatus, source => source.MapFrom(o => DetailRowStatus.RowStatus.NoAction));
        }
    }
}
