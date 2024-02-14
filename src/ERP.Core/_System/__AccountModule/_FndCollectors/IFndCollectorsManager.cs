using Abp.Domain.Services;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System._FndCollectors
{
    public interface IFndCollectorsManager : IDomainService
    {
        Task<Select2PagedResult> GetFndCollectorsSelect2(string searchTerm, int pageSize, int pageNumber, string lang);

    }
}
