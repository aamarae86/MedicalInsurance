using AutoMapper;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__AccountModuleExtend._ApPrepaid.Dto
{
    public class ApPrepaidMapperProfile : Profile
    {
        public ApPrepaidMapperProfile()
        {
            CreateMap<ApPrepaid, ApPrepaidDto>()
               .ForMember(dest => dest.TransactionDate, source => source.MapFrom(o => o.TransactionDate.ToString(Formatters.DateFormat)));
        }
    }
}
