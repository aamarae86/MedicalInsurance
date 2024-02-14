using Abp.Domain.Repositories;

namespace ERP._System.__HR._HrPersonVacations
{
    public class HrPersonVacationsManager : IHrPersonVacationsManager
    {
        private readonly IRepository<HrPersonVacations, long> _repoHrPersonVacations;

        public HrPersonVacationsManager(IRepository<HrPersonVacations, long> repoHrPersonVacations)
        {
            _repoHrPersonVacations = repoHrPersonVacations;
        }
    }
}
