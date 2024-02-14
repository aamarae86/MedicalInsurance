using Abp.Domain.Services;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System._ScCampainsAid
{
    public interface IScCampainsAidManager:IDomainService
    {
        Task<Select2PagedResult> GetScCampainsAidSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
