using AutoMapper;
using ERP._System.__CRM.AboutUs;
using ERP._System.__CRM.AboutUs.Dto;
using ERP._System._ArCustomers.Dto;
using ERP.Helpers.Core;

namespace ERP._System.__CRM._CrmAboutUs.Dto
{
    public class CrmAboutUsMapProfile : Profile
    {
        public CrmAboutUsMapProfile()
        {
           

            CreateMap<AboutUSSliderDto, AboutUSSlider>()
                .ForMember(t => t.SliderFilepath, options => options.MapFrom(input => input.FilePath))
                    .ReverseMap();
        }
    }
}
