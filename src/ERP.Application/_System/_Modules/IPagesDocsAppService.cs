using ERP._System._Modules.Dto;

namespace ERP._System._Modules
{
    public interface IPagesDocsAppService : IAttachBaseAsyncCrudAppService<PagesDto, int, PagesPagedDto, PagesCreateDto, PagesDocsEditDto>
    {}
}
