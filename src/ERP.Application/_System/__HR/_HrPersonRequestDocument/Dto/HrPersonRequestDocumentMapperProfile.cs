using AutoMapper;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__HR._HrPersonRequestDocument.Dto
{
    public class HrPersonRequestDocumentMapperProfile : Profile
    {
        public HrPersonRequestDocumentMapperProfile()
        {
            CreateMap<HrPersonRequestDocument, HrPersonRequestDocumentDto>()
               .ForMember(dest => dest.DocRequestDate, source => source.MapFrom(o => o.DocRequestDate.ToString(Formatters.DateFormat)))
               .ForMember(dest => dest.Notes, source => source.MapFrom(o => o.Notes));


            CreateMap<HrPersonRequestDocumentCreateDto, HrPersonRequestDocument>()
               .ForMember(dest => dest.DocRequestDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.DocRequestDate)));


            CreateMap<HrPersonRequestDocumentEditDto, HrPersonRequestDocument>()
               .ForMember(dest => dest.DocRequestDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.DocRequestDate)));

        }
    }
}
