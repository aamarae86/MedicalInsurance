using AutoMapper;
using ERP._System.__SpGuarantees._SpContracts._SpContractDetails;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__SpGuarantees._SpCaseEditData.Dto
{
    public class SpCaseEditDataMapperProfile : Profile
    {
        public SpCaseEditDataMapperProfile()
        {
            CreateMap<SpContractDetails, SpCaseEditDataDataDto>()
                .ForMember(target => target.Id, dest => dest.MapFrom(z => z.Id))
                .ForMember(target => target.SponsorLkpNameAr, dest => dest.MapFrom(z => z.SpCases.FndLookupValuesSponsorCategoryLkp.NameAr))
                .ForMember(target => target.SponsorLkpNameEn, dest => dest.MapFrom(z => z.SpCases.FndLookupValuesSponsorCategoryLkp.NameEn))
                .ForMember(target => target.BeneficentName, dest => dest.MapFrom(z => z.SpContracts.SpBeneficent.BeneficentName))
                .ForMember(target => target.BeneficentNumber, dest => dest.MapFrom(z => z.SpContracts.SpBeneficent.BeneficentNumber))
                .ForMember(target => target.ContractNumber, dest => dest.MapFrom(z => z.SpContracts.ContractNumber))
                .ForMember(target => target.CaseDate, dest => dest.MapFrom(z => (z.SpCases.RegistrationDate == null ? string.Empty : z.SpCases.RegistrationDate.Value.ToString(Formatters.DateFormat))))
                .ForMember(target => target.StartDate, dest => dest.MapFrom(z => (z.StartDate.ToString(Formatters.DateFormat))))
                .ForMember(target => target.ContractDate, dest => dest.MapFrom(z => z.SpContracts.ContractDate.ToString(Formatters.DateFormat)))
                .ForMember(target => target.CaseName, dest => dest.MapFrom(z => z.SpCases.CaseName))
                .ForMember(target => target.CaseId, dest => dest.MapFrom(z => z.SpCases.Id))
                .ForMember(target => target.BeneficentBankAr, dest => dest.MapFrom(z => z.FndBankLkp.NameAr))
                .ForMember(target => target.BeneficentBankEn, dest => dest.MapFrom(z => z.FndBankLkp.NameAr))
                .ForMember(target => target.AccountOwner, dest => dest.MapFrom(z => z.AccountOwnerName))
                .ForMember(target => target.AccountNumber, dest => dest.MapFrom(z => z.AccountNumber))
                .ForMember(target => target.NameFor, dest => dest.MapFrom(z => z.SponsFor))
                .ForMember(target => target.Amount, dest => dest.MapFrom(z => z.Amount.ToString()))
                .ForMember(target => target.BankLkpId, dest => dest.MapFrom(z => z.BankLkpId))
                .ForMember(target => target.BeneficentId, dest => dest.MapFrom(z => z.SpContracts.SpBeneficentId))
                .ForMember(target => target.SpContractDetailsId, dest => dest.MapFrom(z => z.Id))
                .ForMember(target => target.CaseNumber, dest => dest.MapFrom(z => z.SpCases.CaseNumber));
        }
    }
}
