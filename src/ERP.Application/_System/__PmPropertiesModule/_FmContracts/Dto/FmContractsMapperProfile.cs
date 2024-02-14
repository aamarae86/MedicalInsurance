using AutoMapper;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using System;

namespace ERP._System.__PmPropertiesModule._FmContracts.Dto
{
    public class FmContractsMapperProfile : Profile
    {
        public FmContractsMapperProfile()
        {
            CreateMap<FmContracts, FmContractsDto>()
               .ForMember(dest => dest.Accountvalue, source => source.MapFrom(o => o.AccounGlCodeComDetails.AccId ))
               .ForMember(dest => dest.AdvAccountValue, source => source.MapFrom(o => o.AdvGlCodeComDetails.AccId ))
               .ForMember(dest => dest.PaymentTypeLkpValue, source => source.MapFrom(o =>_app.Reqlanguage== "ar-EG" ? o.PaymentTypesValues.NameAr: o.PaymentTypesValues.NameEn))
               .ForMember(dest => dest.StatusLkpValue, source => source.MapFrom(o =>_app.Reqlanguage == "ar-EG" ? o.StatusValues.NameAr: o.StatusValues.NameEn))
              
               //.ForMember(dest => dest.StatusLkpValue, source => source.MapFrom(o => o.StatusValues.NameAr))
               .ForMember(dest => dest.VendorValue, source => source.MapFrom(o => _app.Reqlanguage == "ar-EG" ? o.ApVendorsValues.VendorNameAr : o.ApVendorsValues.VendorNameEn ))

               .ForMember(dest => dest.StartDate, source => source.MapFrom(o => o.StartDate == null ? string.Empty : o.StartDate.ToString(Formatters.DateFormat)))
               .ForMember(dest => dest.EndDate, source => source.MapFrom(o => o.EndDate == null ? string.Empty : o.EndDate.ToString(Formatters.DateFormat)))
               .ForMember(dest => dest.ContractDate, source => source.MapFrom(o => o.ContractDate == null ? string.Empty : o.ContractDate.ToString(Formatters.DateFormat)))
              .ReverseMap()

               .ForMember(dest => dest.StartDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.StartDate)))
               .ForMember(dest => dest.EndDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.EndDate)))
               .ForMember(dest => dest.ContractDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.ContractDate)));
 

             CreateMap<FmContractsEditDto, FmContracts>()
               .ForMember(dest => dest.StartDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.StartDate)))
               .ForMember(dest => dest.EndDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.EndDate)))
               .ForMember(dest => dest.ContractDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.ContractDate)));


            CreateMap<FmContractsCreateDto, FmContracts>()
                .ForMember(dest => dest.StartDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.StartDate)))
               .ForMember(dest => dest.EndDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.EndDate)))
               .ForMember(dest => dest.ContractDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.ContractDate)));

            CreateMap<FmContractVisitsDto, FmContractVisits>()
                .ForMember(dest => dest.VisitDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.VisitDate)))
                .ReverseMap()
                .ForMember(dest => dest.engineerName, source => source.MapFrom(o => o.FmEngineers.EngineerName))
                .ForMember(dest => dest.VisitDate, source => source.MapFrom(o => o.VisitDate.ToString(Formatters.DateFormat)))
                .ForMember(dest => dest.contractText, source => source.MapFrom(o => o.FmContracts.ContractNumber));



            //CreateMap<FmContractVisitsDto, FmContractVisits>()
            //    .ForMember(dest => dest.VisitDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.VisitDate)))
            //    .ReverseMap()
            //    .ForMember(dest => dest.engineerName, source => source.MapFrom(o => o.FmEngineers.EngineerName))
            //    .ForMember(dest => dest.VisitDate, source => source.MapFrom(o => o.VisitDate.ToShortDateString()))
            //    .ForMember(dest => dest.contractText, source => source.MapFrom(o => o.FmContracts.ContractNumber));





            CreateMap< FmBuildingsContracts,FmBuildingsContractsDto > () 
                .ForMember(dest => dest.pmPropertiesName, source => source.MapFrom(o => _app.Reqlanguage == "ar-EG" ? o.PmProperties.PropertyNameAr :o.PmProperties.PropertyNameEn))
                .ForMember(dest => dest.contractText, source => source.MapFrom(o => o.FmContracts.ContractNumber));
                






        }
    }
}
