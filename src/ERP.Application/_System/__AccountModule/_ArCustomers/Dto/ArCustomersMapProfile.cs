using AutoMapper;
using ERP.Core.Helpers.Parameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System._ArCustomers.Dto
{
    public class ArCustomersMapProfile : Profile
    {
        public ArCustomersMapProfile()
        {
            CreateMap<CreateArCustomersDto, ArCustomers>();
                 

            CreateMap<ArCustomersDto, ArCustomers>();
            CreateMap<GetAllPagedAndSortedWithParams<ArCustomersSearchDto>, GetAllPagedAndSortedWithParams<ArCustomers>>();
            CreateMap<GetAllPagedAndSortedWithParams<ArCustomers>, GetAllPagedAndSortedWithParams<ArCustomersSearchDto>>();


            CreateMap<ArCustomers, ArCustomersDto>();
              

            CreateMap<ArCustomersSearchDto, ArCustomers>();
            CreateMap<ArCustomers, ArCustomersSearchDto>();
            CreateMap<ArCustomers, ArCustomersEditDto>();

            CreateMap<ArCustomersEditDto, ArCustomers>();
        }

    }
}
