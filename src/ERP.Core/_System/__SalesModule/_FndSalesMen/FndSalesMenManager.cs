﻿using Abp.Domain.Repositories;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__SalesModule._FndSalesMen
{
    public class FndSalesMenManager : IFndSalesMenManager
    {
        private readonly IRepository<FndSalesMen, long> _FndSalesMenRepository;

        public FndSalesMenManager( IRepository<FndSalesMen, long> FndSalesMenRepository )
        {
            _FndSalesMenRepository = FndSalesMenRepository;
        }
        public async Task<Select2PagedResult> GetFndSalesMenSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = await _FndSalesMenRepository.GetAll()
                         .Where(z => string.IsNullOrEmpty(searchTerm) || (lang == "ar-EG" ? z.SalesManNameAr.Contains(searchTerm) : z.SalesManNameEn.Contains(searchTerm)))
                         .ToListAsync();

            var result = data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = lang == "ar-EG" ? z.SalesManNameAr : z.SalesManNameEn, altText = z.Id.ToString() }).ToList();

            var select2pagedResult = new Select2PagedResult
            {
                Total = data.Count(),
                Results = result
            };

            return select2pagedResult;
        }
    }
}
