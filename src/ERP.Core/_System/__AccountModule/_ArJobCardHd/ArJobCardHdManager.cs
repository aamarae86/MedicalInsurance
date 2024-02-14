using Abp.Domain.Repositories;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__AccountModule._ArJobCardHd
{
    public class ArJobCardHdManager : IArJobCardHdManager
    {
        private readonly IRepository<ArJobCardHd, long> _repoArJobCardHd;

        public ArJobCardHdManager(IRepository<ArJobCardHd, long> repoArJobCardHd)
        {
            _repoArJobCardHd = repoArJobCardHd;
        }

        public async Task<Select2PagedResult> GetArJobCardHdJobNumberSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            try
            {
                var data = await _repoArJobCardHd.GetAllListAsync(predicate: z => string.IsNullOrEmpty(searchTerm) || z.JobNumber.Contains(searchTerm));
                //.Where(z => string.IsNullOrEmpty(searchTerm) || z.JobNumber.Contains(searchTerm));


                var result = data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = z.JobNumber }).ToList();

                var select2pagedResult = new Select2PagedResult
                {
                    Total = data.Count(),
                    Results = result
                };

                return select2pagedResult;
            }
            catch (System.Exception ex)
            {

                throw;
            }

           


        }
       
    }





}
