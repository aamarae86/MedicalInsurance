using Abp.Application.Services;
using ERP._System._modules;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System._Modules
{
    public interface IModulesAppService : IApplicationService, ISelect2
    {
    }
}
