using AutoMapper;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;

namespace ERP._System.__AccountModule._ArJobCardHd.Dto
{
    public class ArJobCardHdMapperProfile : Profile
    {
        public ArJobCardHdMapperProfile()
        {
            CreateMap<ArJobCardHd, ArJobCardHdDto>()
               .ForMember(dest => dest.EndDate, source => source.MapFrom(o => o.EndDate == null ? string.Empty : o.EndDate.Value.ToString(Formatters.DateFormat)))
               .ForMember(dest => dest.StartDate, source => source.MapFrom(o => o.StartDate.ToString(Formatters.DateFormat)))
               .ForMember(dest => dest.JobDate, source => source.MapFrom(o => o.JobDate.ToString(Formatters.DateFormat)))
               .ForMember(dest => dest.InvoiceDate, source => source.MapFrom(o => o.InvoiceDate == null ? string.Empty : o.InvoiceDate.Value.ToString(Formatters.DateFormat)))
               .ReverseMap()
               .ForMember(dest => dest.ArJobCardAttachments, source => source.Ignore());


        CreateMap<ArJobCardHd, ArJobCardScreenDataOutput>()
                .ForMember(dest => dest.ClaimNo, source => source.MapFrom(o => o.ClaimNo == null ? string.Empty : o.ClaimNo))
                .ForMember(dest => dest.LpoNo, source => source.MapFrom(o => o.LpoNo == null ? string.Empty : o.LpoNo))
                .ForMember(dest => dest.EndDate, source => source.MapFrom(o => o.EndDate == null ? string.Empty : o.EndDate.Value.ToString(Formatters.DateFormat)))
                .ForMember(dest => dest.StartDate, source => source.MapFrom(o => o.StartDate == null ? string.Empty : o.StartDate.ToString(Formatters.DateFormat)))
                .ForMember(dest => dest.JobDate, source => source.MapFrom(o => o.JobDate == null ? string.Empty : o.JobDate.ToString(Formatters.DateFormat)))
                .ForMember(dest => dest.CustomerNo, source => source.MapFrom(o => o.ArCustomers.CustomerNumber.ToString()))
                .ForMember(dest => dest.CustomerMail, source => source.MapFrom(o => o.ArCustomers.Email == null ? string.Empty : o.ArCustomers.Email))
                .ForMember(dest => dest.CustomerAddress, source => source.MapFrom(o => o.ArCustomers.Address == null ? string.Empty : o.ArCustomers.Address))
                .ForMember(dest => dest.CustomerMobile, source => source.MapFrom(o => o.ArCustomers.Mobile == null ? string.Empty : o.ArCustomers.Mobile))
                .ForMember(dest => dest.CustomerNameAr, source => source.MapFrom(o => o.ArCustomers.CustomerNameAr == null ? string.Empty : o.ArCustomers.CustomerNameAr))
                .ForMember(dest => dest.CustomerNameEn, source => source.MapFrom(o => o.ArCustomers.CustomerNameEn == null ? string.Empty : o.ArCustomers.CustomerNameEn))
                .ForMember(dest => dest.VehicleMake, source => source.MapFrom(o => o.FndVehicleMakeLkp.GetLookupValue() ==null? string.Empty : o.FndVehicleMakeLkp.GetLookupValue()))
                .ForMember(dest => dest.VehicleModel, source => source.MapFrom(o => o.FndVehicleModelLkp.GetLookupValue() == null ? string.Empty : o.FndVehicleModelLkp.GetLookupValue()))
                .ForMember(dest => dest.PoliceReportSource, source => source.MapFrom(o => o.FndPoliceReportSourceLkp.GetLookupValue() == null ? string.Empty : o.FndPoliceReportSourceLkp.GetLookupValue()))
                .ForMember(dest => dest.VehiclePlateNo, source => source.MapFrom(o => o.VehiclePlateNo == null ? string.Empty : o.VehiclePlateNo));

            CreateMap<ArJobCardHdCreateDto, ArJobCardHd>()
               .ForMember(dest => dest.EndDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.EndDate)))
               .ForMember(dest => dest.StartDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.StartDate)))
               .ForMember(dest => dest.InvoiceDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.InvoiceDate)))
               .ForMember(dest => dest.JobDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.JobDate)))
               .ForMember(dest => dest.ArJobCardAttachments, source => source.Ignore());
                

            CreateMap<ArJobCardHdEditDto, ArJobCardHd>()
               .ForMember(dest => dest.EndDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.EndDate)))
               .ForMember(dest => dest.StartDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.StartDate)))
               .ForMember(dest => dest.InvoiceDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.InvoiceDate)))
               .ForMember(dest => dest.JobDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.JobDate)))
               .ForMember(dest => dest.ArJobCardAttachments, source => source.Ignore());


        }
    }
}
