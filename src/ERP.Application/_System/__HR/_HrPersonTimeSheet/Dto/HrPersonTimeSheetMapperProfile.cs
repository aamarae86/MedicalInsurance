using AutoMapper;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__HR._HrPersonTimeSheet.Dto
{
   public  class HrPersonTimeSheetMapperProfile : Profile
    {
        public HrPersonTimeSheetMapperProfile()
        {
            CreateMap<HrPersonTimeSheet, HrPersonTimeSheetDto>()
               .ForMember(dest => dest.TimeSheetDate, source => source.MapFrom(o => o.TimeSheetDate.ToString(Formatters.DateFormat)));


            CreateMap<HrPersonTimeSheetCreateDto, HrPersonTimeSheet>()
               .ForMember(dest => dest.TimeSheetDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.TimeSheetDate)));


            CreateMap<HrPersonTimeSheetEditDto, HrPersonTimeSheet>()
               .ForMember(dest => dest.TimeSheetDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.TimeSheetDate)));

        }
    
    }
}
