using Abp.Application.Services;
using ERP._System._modules;
using ERP.Helpers.Core;
using System.Threading.Tasks;

namespace ERP._System._Modules
{
    public class ModulesAppService : ApplicationService
    {
        private readonly IModuleManager _moduleManager;

        public ModulesAppService(IModuleManager moduleManager)
        {
            _moduleManager = moduleManager;
        }

        public async Task<Select2PagedResult> GetSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            return await _moduleManager.GetSelect2(searchTerm, pageSize, pageNumber, lang);
        }
    }
}
