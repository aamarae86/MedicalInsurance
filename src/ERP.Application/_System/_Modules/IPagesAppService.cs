using Abp.Application.Services;
using ERP._System._modules;
using ERP._System._Modules.Dto;

namespace ERP._System._Modules
{
    public interface IPagesAppService : IAsyncCrudAppService<PagesDto, int, PagesPagedDto, PagesCreateDto, PagesEditDto>, ISelect2WithParent
    {}
}
