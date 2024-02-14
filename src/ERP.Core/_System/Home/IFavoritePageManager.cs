using Abp.Domain.Services;
using ERP._System._modules;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP._System.Home
{
    public interface IFavoritePageManager : IDomainService
    {
        Task<List<FavoritePage>> GetAll(long userId);

        Task<FavoritePage> Add(FavoritePage favoritePage);

        Task Remove(long id, long? userId);

        Task<bool> IsPageFavorite(string pageName, long userId);

        Task<Page> GetFileVideoPage(string pageName);

        Task<bool> ToggleFavoritePage(string pageName, long userId, int? tenantId);
    }
}
