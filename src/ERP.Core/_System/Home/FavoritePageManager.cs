using Abp.Domain.Repositories;
using ERP._System._modules;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.Home
{
    public class FavoritePageManager : IFavoritePageManager
    {
        private readonly IRepository<Page, int> _repoPage;
        private readonly IRepository<FavoritePage, long> _repository;

        public FavoritePageManager(IRepository<FavoritePage, long> repository, IRepository<Page, int> repoPage)
        {
            _repository = repository;
            _repoPage = repoPage;
        }

        public async Task<FavoritePage> Add(FavoritePage favoritePage)
        {
            return await _repository.InsertAsync(favoritePage);
        }

        public async Task<List<FavoritePage>> GetAll(long userId)
        {
            return await _repository.GetAllIncluding(f => f.Page).Where(f => f.CreatorUserId == userId).ToListAsync();
        }

        public async Task<bool> IsPageFavorite(string pageName, long userId)
        {
            Page currentPage = await FindPageByName(pageName);

            if (currentPage == null) return false;

            bool isPageFavorite = await _repository.GetAll().AnyAsync(x => x.PageId == currentPage.Id && x.CreatorUserId == userId);

            return isPageFavorite;
        }

        public async Task<bool> ToggleFavoritePage(string pageName, long userId, int? tenantId)
        {
            Page currentPage = await FindPageByName(pageName);

            if (currentPage == null) return false;

            var favPage = await _repository.GetAll().FirstOrDefaultAsync(x => x.PageId == currentPage.Id && x.CreatorUserId == userId);

            if (favPage != null)
            {
                await Remove(favPage.Id, favPage.CreatorUserId);
                return false;
            }

            if (favPage == null)
            {
                await Add(FavoritePage.Create(currentPage.Id,userId, tenantId));
                return true;
            }

            return false;
        }
        public async Task<Page> GetFileVideoPage(string pageName)
        {
            Page currentPage = await FindPageByName(pageName);

            if (currentPage == null) return null;

            return currentPage;
        }


        private async Task<Page> FindPageByName(string pageName)
        {
            Page currentPage = await _repoPage.GetAll().Where(x => x.Selector.Equals(pageName)).FirstOrDefaultAsync();

            return currentPage;
        }

        public async Task Remove(long id, long? userId)
        {
            var entity = _repository.Get(id);
            if (entity.CreatorUserId == userId)
                await _repository.DeleteAsync(entity);
        }
    }
}
