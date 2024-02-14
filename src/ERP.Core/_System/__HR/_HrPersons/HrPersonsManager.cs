using Abp.Domain.Repositories;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__HR._HrPersons
{
    public class HrPersonsManager : IHrPersonsManager
    {
        private readonly IRepository<HrPersons, long> _repoHrPersons;

        public HrPersonsManager(IRepository<HrPersons, long> repoHrPersons)
        {
            _repoHrPersons = repoHrPersons;
        }

        public async Task<Select2PagedResult> GetPersonsForPayRollSelect2(long pyPayrollTypeId, string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = _repoHrPersons.GetAll()
                     .Where(z => (z.PyPayrollTypeId == pyPayrollTypeId) && (string.IsNullOrEmpty(searchTerm) || z.FirstName.Contains(searchTerm) || z.LastName.Contains(searchTerm) || z.FatherName.Contains(searchTerm)));

            long count = await data.LongCountAsync();

            var result = await data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize)
                        .Select(z => new Select2OptionModel { id = z.Id, text = $"{z.FirstName} {z.FatherName} {z.LastName}", altText = z.EmployeeNumber })
                        .ToListAsync();

            var select2pagedResult = new Select2PagedResult
            {
                Total = count,
                Results = result
            };

            return select2pagedResult;
        }

        public async Task<Select2PagedResult> GetPersonsJobsForPayRollSelect2(long pyPayrollTypeId, string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = _repoHrPersons.GetAllIncluding(z => z.FndJobLkp)
                     .Where(z => (z.PyPayrollTypeId == pyPayrollTypeId) && (string.IsNullOrEmpty(searchTerm) || z.FirstName.Contains(searchTerm) || z.LastName.Contains(searchTerm) || z.FatherName.Contains(searchTerm)));

            long count = await data.LongCountAsync();

            var result = await data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize)
                        .Select(z => new Select2OptionModel { id = z.JobLkpId, text = lang == "ar-EG" ? z.FndJobLkp.NameAr : z.FndJobLkp.NameEn, altText = z.EmployeeNumber })
                        .ToListAsync();

            var select2pagedResult = new Select2PagedResult
            {
                Total = count,
                Results = result
            };

            return select2pagedResult;
        }

        public async Task<Select2PagedResult> GetPersonsNumbersSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = _repoHrPersons.GetAll()
                      .Where(z => (string.IsNullOrEmpty(searchTerm) || z.FirstName.Contains(searchTerm) || z.LastName.Contains(searchTerm) || z.FatherName.Contains(searchTerm)));

            long count = await data.LongCountAsync();

            var result = await data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize)
                        .Select(z => new Select2OptionModel { id = z.Id, text = $"{z.EmployeeNumber}", altText = JsonConvert.SerializeObject(z) })
                        .ToListAsync();

            var select2pagedResult = new Select2PagedResult
            {
                Total = count,
                Results = result
            };

            return select2pagedResult;
        }

        public async Task<Select2PagedResult> GetPersonsNumbersForEngineersSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = _repoHrPersons.GetAll()
                      .Where(z => (string.IsNullOrEmpty(searchTerm) || z.FirstName.Contains(searchTerm) || z.LastName.Contains(searchTerm) || z.FatherName.Contains(searchTerm)));

            long count = await data.LongCountAsync();

            var result = await data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize)
                        .Select(z => new Select2OptionModel { id = z.Id, text = $"{z.EmployeeNumber}", altText = JsonConvert.SerializeObject(z) })
                        .ToListAsync();

            var select2pagedResult = new Select2PagedResult
            {
                Total = count,
                Results = result
            };

            return select2pagedResult;
        }

        public async Task<Select2PagedResult> GetPersonsSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = _repoHrPersons.GetAll()
                     .Where(z => (string.IsNullOrEmpty(searchTerm) || z.FirstName.Contains(searchTerm) || z.LastName.Contains(searchTerm) || z.FatherName.Contains(searchTerm)));

            long count = await data.LongCountAsync();

            var result = await data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize)
                        .Select(z => new Select2OptionModel { id = z.Id, text = $"{z.FirstName} {z.FatherName} {z.LastName}", altText = z.EmployeeNumber })
                        .ToListAsync();

            var select2pagedResult = new Select2PagedResult
            {
                Total = count,
                Results = result
            };

            return select2pagedResult;
        }

        public async Task<Select2PagedResult> GetPersonSupervisorSelect2(long id, string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = _repoHrPersons.GetAll()
                     .Where(z => (z.Id != id) && (string.IsNullOrEmpty(searchTerm) || z.FirstName.Contains(searchTerm) || z.LastName.Contains(searchTerm) || z.FatherName.Contains(searchTerm)));

            long count = await data.LongCountAsync();

            var result = await data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize)
                        .Select(z => new Select2OptionModel { id = z.Id, text = $"{z.FirstName} {z.FatherName} {z.LastName}", altText = z.EmployeeNumber })
                        .ToListAsync();

            var select2pagedResult = new Select2PagedResult
            {
                Total = count,
                Results = result
            };

            return select2pagedResult;
        }
    }
}
