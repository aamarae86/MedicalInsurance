using Abp.Domain.Repositories;
using ERP._System.__SpGuarantees._SpCaseHistory.Dto;
using ERP.Authorization.Users;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__SpGuarantees._SpCaseHistory
{
    public class SpCaseHistoryAppService : ERPAppServiceBase, ISpCaseHistoryAppService
    {
        private readonly IRepository<SpCaseHistory, long> _repository;
        private readonly UserManager _userManager;

        public SpCaseHistoryAppService(
            UserManager userManager,
            IRepository<SpCaseHistory, long> repository)
        {
            _repository = repository;
            _userManager = userManager;
        }

        public async Task<List<SpCaseHistoryDto>> GetSpCaseHistory(long caseId)
        {
            var data = await _repository.GetAllIncluding(x => x.SpCases,
                                                         x => x.SpBeneficent,
                                                         x => x.FndCaseStatusLkp,
                                                         x => x.FndOperationTypeLkp)
                                        .Where(z => z.SpCaseId == caseId)
                                        .OrderBy(z => z.Id)
                                        .ToListAsync();

            var mapped = ObjectMapper.Map<List<SpCaseHistoryDto>>(data);

            foreach (var item in mapped)
            {
                if (item.CreatorUserId != null)
                {
                    var currentUser = await _userManager.GetUserByIdAsync((long)item.CreatorUserId); ;
                    item.Creator = currentUser.Name;
                }
            }

            return mapped;
        }
    }
}
