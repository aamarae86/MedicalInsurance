using Abp.Application.Services;
using ERP._System.__HR._HrPersonTimeSheet.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__HR._HrPersonTimeSheet
{
   public  interface IHrPersonTimeSheetAppService : IAsyncCrudAppService<HrPersonTimeSheetDto, long, HrPersonTimeSheetPagedDto, HrPersonTimeSheetCreateDto, HrPersonTimeSheetEditDto>
    {
    }
}
