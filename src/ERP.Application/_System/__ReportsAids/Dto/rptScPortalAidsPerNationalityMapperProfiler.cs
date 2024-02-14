using AutoMapper;
using ERP._System.__ReportsAids.Input;
using ERP.Helpers.Core;

namespace ERP._System.__ReportsAids.Dto
{
    public class rptScPortalAidsPerNationalityMapperProfiler : Profile
    {
        public rptScPortalAidsPerNationalityMapperProfiler()
        {
            CreateMap<rptScPortalAidsPerNationalityHelperInput, rptScPortalAidsPerNationalityInput>()
              .ForMember(dest => dest.ToDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.ToDate)))
              .ForMember(dest => dest.FromDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.FromDate)));
        }
    }
}
