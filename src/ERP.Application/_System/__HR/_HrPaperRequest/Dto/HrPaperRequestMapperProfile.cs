using AutoMapper;
using ERP._System.__HR._HRPaperRequest;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__HR._HrPaperRequest.Dto
{
   public  class HrPaperRequestMapperProfile :Profile
    {

        public HrPaperRequestMapperProfile()
        {
            CreateMap<HrPaperRequest, HrPaperRequestDto>()
               .ForMember(dest => dest.PaperReqDate, source => source.MapFrom(o => o.PaperReqDate.ToString(Formatters.DateFormat)));


            CreateMap<HrPaperRequestCreateDto, HrPaperRequest>()
               .ForMember(dest => dest.PaperReqDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.PaperReqDate)));


            CreateMap<HrPaperRequestEditDto, HrPaperRequest>()
               .ForMember(dest => dest.PaperReqDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.PaperReqDate)));



            CreateMap<HrPaperRequestAttachment, HrPaperRequestAttachmentDto>().ReverseMap();
           


        }
    }
}
