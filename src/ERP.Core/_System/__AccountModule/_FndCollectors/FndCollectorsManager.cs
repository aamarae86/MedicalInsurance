﻿using Abp.Domain.Repositories;
using Abp.Events.Bus;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System._FndCollectors
{
    public class FndCollectorsManager: IFndCollectorsManager
    {
        private readonly IRepository<FndCollectors,long> _repoFndCollectors;

        public FndCollectorsManager(IRepository<FndCollectors, long> repoFndCollectors)
        {
            _repoFndCollectors = repoFndCollectors;
        }

        public async Task<Select2PagedResult> GetFndCollectorsSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = await _repoFndCollectors.GetAll()
                .Where(z =>
                 string.IsNullOrEmpty(searchTerm) || (lang == "ar-EG" ? z.CollectorNameAr.Contains(searchTerm) : z.CollectorNameEn.Contains(searchTerm)))
                .ToListAsync();

            var result = data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = lang == "ar-EG" ? z.CollectorNameAr : z.CollectorNameEn }).ToList();

            var select2pagedResult = new Select2PagedResult
            {
                Total = data.Count(),
                Results = result
            };

            return select2pagedResult;
        }
    }
}
