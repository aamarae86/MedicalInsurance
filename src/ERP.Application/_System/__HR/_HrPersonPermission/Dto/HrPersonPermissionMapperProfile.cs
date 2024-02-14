using AutoMapper;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__HR._HrPersonPermission.Dto
{
   public  class HrPersonPermissionMapperProfile :Profile
    {
        public HrPersonPermissionMapperProfile()
        {
            CreateMap<HrPersonPermission, HrPersonPermissionDto>()
               .ForMember(dest => dest.PermissionDate, source => source.MapFrom(o => o.PermissionDate.ToString(Formatters.DateFormat)));


            CreateMap<HrPersonPermissionCreateDto, HrPersonPermission>()
               .ForMember(dest => dest.PermissionDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.PermissionDate)));


            CreateMap<HrPersonPermissionEditDto, HrPersonPermission>()
               .ForMember(dest => dest.PermissionDate, source => source.MapFrom(o => DateTimeController.ConvertToDateTime(o.PermissionDate)));
              
        }
    }
}
