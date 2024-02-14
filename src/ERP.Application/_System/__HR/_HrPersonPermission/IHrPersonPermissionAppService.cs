using Abp.Application.Services;
using ERP._System.__HR._HrPersonPermission.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__HR._HrPersonPermission
{
   public  interface IHrPersonPermissionAppService : IAsyncCrudAppService<HrPersonPermissionDto, long, HrPersonPermissionPagedDto, HrPersonPermissionCreateDto, HrPersonPermissionEditDto>
    {
    }
}
