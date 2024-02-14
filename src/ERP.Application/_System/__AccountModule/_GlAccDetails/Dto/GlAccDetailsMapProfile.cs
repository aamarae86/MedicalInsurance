using AutoMapper;
using ERP._System.__AccountModule._GlJeHeaders.Dto;
using ERP._System._GlAccDetails;
using ERP._System._GlAccDetails.Dto;
using ERP._System._GlPeriods;
using ERP.Core.Helpers.Extensions;
using ERP.Core.Helpers.Parameters;
using ERP.Helpers.Core;
using System;

namespace ERP._System._GlJeHeaders.Dto
{
    public class GlAccDetailsMapProfile : Profile
    {
        public GlAccDetailsMapProfile()
        { 
            CreateMap<GlAccDetails, GlAccDetailsDto>()
               .ForMember(dest => dest.CanUpdated, source => source.MapFrom(o => o.CanEditGlAccDetails()));
        }
    }
}
