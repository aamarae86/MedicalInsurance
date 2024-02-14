using Abp.Domain.Repositories;
using Abp.Events.Bus;
using Abp.UI;
using ERP._System._FndLookupValues;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System._ArCustomers
{
    public class ArCustomersManager : IArCustomersManager
    {
        public IEventBus EventBus { get; set; }

        private readonly IRepository<ArCustomers, long> _ArCustomersRepository;
        private readonly IRepository<FndLookupValues, long> _repoFndLookupValues;
        public ArCustomersManager
            (IRepository<ArCustomers, long> ArCustomersRepository,IRepository<FndLookupValues, long> repoFndLookupValues)
        {
            _ArCustomersRepository = ArCustomersRepository;
            _repoFndLookupValues = repoFndLookupValues;
        }

        public async Task<ArCustomers> CreateAsync(ArCustomers ArCustomers)
        {
            return await _ArCustomersRepository.InsertAsync(ArCustomers);
        }

        public async Task<ArCustomers> GetAsync(int id)
        {
            var ArCustomers = await _ArCustomersRepository.FirstOrDefaultAsync(id);
            if (ArCustomers == null)
            {
                throw new UserFriendlyException("Could not found the ArCustomers, maybe it's deleted!");
            }

            return ArCustomers;
        }

        public async Task<Select2PagedResult> GetArCustomersSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = await _ArCustomersRepository.GetAll()
                         .Where(z => string.IsNullOrEmpty(searchTerm) || (lang == "ar-EG" ? z.CustomerNameAr.Contains(searchTerm) : z.CustomerNameEn.Contains(searchTerm)))
                         .ToListAsync();

            var result = data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = lang == "ar-EG" ? z.CustomerNameAr : z.CustomerNameEn, altText = z.CustomerNumber.ToString() }).ToList();

            var select2pagedResult = new Select2PagedResult
            {
                Total = data.Count(),
                Results = result
            };

            return select2pagedResult;
        }
        public async Task<Select2PagedResult> GetArCustomersBytypeSelect2(string searchTerm,  string lang,bool IsCash, int pageSize = 1, int pageNumber = 1)
        {
            var CustomcontrolId = _repoFndLookupValues.GetAll().Where(z => z.NameEn == "Control Customer").Select(x => x.Id).SingleOrDefault();
            lang = _app.Reqlanguage;
            Expression< Func<ArCustomers, bool>> conds = null;

            if (IsCash == false || IsCash == null)
            {
                conds = z => z.CustomerTypeLkpId != CustomcontrolId ;
            }
            else
            {
                conds = z => (z.CustomerTypeLkpId == CustomcontrolId) ;
            }

            var data = await _ArCustomersRepository.GetAll()
                        .Where(predicate: conds)
                        .ToListAsync();

            var result = data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = lang == "ar-EG" ? z.CustomerNameAr : z.CustomerNameEn, altText = z.CustomerNumber.ToString() }).ToList();


            var select2pagedResult = new Select2PagedResult
            {
                Total = data.Count(),
                Results = result
            };

            return select2pagedResult;
        }


        public async Task<Select2PagedResult> GetPOSCustomersBytypeSelect2(string searchTerm, string lang, bool IsCash, int pageSize = 1, int pageNumber = 1)
        {
            lang = _app.Reqlanguage;
            Expression<Func<ArCustomers, bool>> conds = null;
            var data = await _ArCustomersRepository.GetAll().ToListAsync();
            if (IsCash == false )
            {
                data = data.ToList();
            }
            else
            {
                data = data.Where(x => x.CustomerTypeLkpId != 26).ToList();
            }


         

            var result = data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = lang == "ar-EG" ? z.CustomerNameAr : z.CustomerNameEn, altText = z.CustomerNumber.ToString() }).ToList();


            var select2pagedResult = new Select2PagedResult
            {
                Total = data.Count(),
                Results = result
            };

            return select2pagedResult;
        }


    }
}
