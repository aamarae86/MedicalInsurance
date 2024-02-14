using Abp.Domain.Repositories;
using Abp.Domain.Services;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System._modules
{
    public interface IModuleManager : IDomainService, ISelect2
    {
        Task<List<Module>> GetModules();
    }
}
