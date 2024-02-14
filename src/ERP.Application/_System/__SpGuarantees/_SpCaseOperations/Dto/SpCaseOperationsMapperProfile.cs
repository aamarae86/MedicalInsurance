using AutoMapper;
using ERP._System.__SpGuarantees._SpCases._SpCaseOperations.ProcDto;
using ERP._System.__SpGuarantees._SpContracts._SpContractDetails;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__SpGuarantees._SpCaseOperations.Dto
{
    public class SpCaseOperationsMapperProfile : Profile
    {
        public SpCaseOperationsMapperProfile()
        {
            CreateMap<SpContractDetails, SpCaseOperationsDataDto>()
                .ForMember(target => target.Id, dest => dest.MapFrom(z => z.Id))
                .ForMember(target => target.SponsorLkpNameAr, dest => dest.MapFrom(z => z.SpCases.FndLookupValuesSponsorCategoryLkp.NameAr))
                .ForMember(target => target.SponsorLkpNameEn, dest => dest.MapFrom(z => z.SpCases.FndLookupValuesSponsorCategoryLkp.NameEn))
                .ForMember(target => target.BeneficentName, dest => dest.MapFrom(z => z.SpContracts.SpBeneficent.BeneficentName))
                .ForMember(target => target.BeneficentNumber, dest => dest.MapFrom(z => z.SpContracts.SpBeneficent.BeneficentNumber))
                .ForMember(target => target.ContractNumber, dest => dest.MapFrom(z => z.SpContracts.ContractNumber))
                .ForMember(target => target.CaseDate, dest => dest.MapFrom(z => (z.StartDate.ToString(Formatters.DateFormat))))
                .ForMember(target => target.ContractDate, dest => dest.MapFrom(z => z.SpContracts.ContractDate.ToString(Formatters.DateFormat)))
                .ForMember(target => target.CaseName, dest => dest.MapFrom(z => z.SpCases.CaseName))
                .ForMember(target => target.CaseId, dest => dest.MapFrom(z => z.SpCases.Id))
                .ForMember(target => target.CaseNumber, dest => dest.MapFrom(z => z.SpCases.CaseNumber));

            CreateMap<SpCaseOperationsInputDto, SpCaseOperationsInputDto_Proc>()
               .ForMember(target => target.OperationDate, dest => dest.MapFrom(z => DateTimeController.ConvertToDateTime(z.OperationDate)));

            CreateMap<SpCaseOperationsReplaceInputDtoHelper, SpCaseOperationsReplaceInputDto>()
                .ForMember(target => target.OperationDate, dest => dest.MapFrom(z => DateTimeController.ConvertToDateTime(z.OperationDate)));
        }
    }
}
