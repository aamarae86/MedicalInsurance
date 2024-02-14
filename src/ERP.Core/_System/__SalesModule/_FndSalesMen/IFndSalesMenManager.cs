using Abp.Domain.Services;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__SalesModule._FndSalesMen
{
    public interface IFndSalesMenManager : IDomainService
    {
        Task<Select2PagedResult> GetFndSalesMenSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
