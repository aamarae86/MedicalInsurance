using AutoMapper;
using ERP.Helpers.Core;
using System.Linq;

namespace ERP._System.__HR._PyPayrollOperations.Dto
{
    public class PyPayrollOperationsMapperProfile : Profile
    {
        public PyPayrollOperationsMapperProfile()
        {
            CreateMap<PyPayrollOperations, PyPayrollOperationsDto>()
               .ForMember(dest => dest.OperationDate, source => source.MapFrom(o => o.OperationDate.ToString(Formatters.DateFormat)));

            CreateMap<PyPayrollOperationsCreateDto, PyPayrollOperations>()
               .ForMember(dest => dest.OperationDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.OperationDate)));

            CreateMap<PyPayrollOperationsEditDto, PyPayrollOperations>()
               .ForMember(dest => dest.OperationDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.OperationDate)));

            CreateMap<PyPayrollOperationPersons, PyPayrollOperationPersonsDto>()
               .ForMember(dest => dest.FullName, source => source.MapFrom(o => $"{o.HrPersons.GetFullName()}"))
               .ForMember(dest => dest.PayrollNetValue, source => source.MapFrom(o => o.PyPayrollOperationPersonDetails.Sum(z => z.EarningAmount - z.DeductionAmount)))
               .ForMember(dest => dest.HrPersonNumber, source => source.MapFrom(o => o.HrPersons.EmployeeNumber));

            CreateMap<PyPayrollOperationPersonDetails, PyPayrollOperationPersonDetailsDto>()
                .ForMember(dest => dest.HrPersonName, source => source.MapFrom(o => o.PyPayrollOperationPersons.HrPersons.GetFullName()))
                .ForMember(dest => dest.HrPersonNumber, source => source.MapFrom(o => o.PyPayrollOperationPersons.HrPersons.EmployeeNumber))
                .ForMember(dest => dest.PeriodNameAr, source => source.MapFrom(o => o.PyPayrollOperationPersons.PyPayrollOperations.Periods.PeriodNameAr))
                .ForMember(dest => dest.PeriodNameEn, source => source.MapFrom(o => o.PyPayrollOperationPersons.PyPayrollOperations.Periods.PeriodNameEn))
                .ForMember(dest => dest.StartDate, source => source.MapFrom(o => o.PyPayrollOperationPersons.PyPayrollOperations.Periods.StartDate.ToString(Formatters.DateFormat)))
                .ForMember(dest => dest.EndDate, source => source.MapFrom(o => o.PyPayrollOperationPersons.PyPayrollOperations.Periods.EndDate.ToString(Formatters.DateFormat)))
                .ForMember(dest => dest.PyPayrollTypeName, source => source.MapFrom(o => o.PyPayrollOperationPersons.PyPayrollOperations.PyPayrollTypes.PyPayrollTypeName))
                .ForMember(dest => dest.BankNameAr, source => source.MapFrom(o => o.PyPayrollOperationPersons.FndBankLkp.NameAr))
                .ForMember(dest => dest.BankNameAr, source => source.MapFrom(o => o.PyPayrollOperationPersons.FndBankLkp.NameEn))
                .ForMember(dest => dest.AccountNumber, source => source.MapFrom(o => o.PyPayrollOperationPersons.AccountNumber))
                .ForMember(dest => dest.PayrollNetValue, source => source.MapFrom(o => o.EarningAmount - o.DeductionAmount))
                ;
        }
    }
}
