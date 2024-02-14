using Abp.Domain.Repositories;
using Abp.Events.Bus;
using ERP._System.__AidModule._ScCommittee;
using ERP._System.__AidModule._ScMaintenanceTechnicalReport;
using ERP._System.__AidModule._ScPortalRequestStudy;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__AidModule._ScPortalRequest
{
    public class ScPortalRequestManager : IScPortalRequestManager
    {
        public IEventBus EventBus { get; set; }

        private readonly IRepository<ScPortalRequest, long> _scPortalRequestRepository;
        private readonly IRepository<ScCommitteeDetail, long> _repoScCommitteeDetail;
        private readonly IRepository<ScPortalRequestStudy, long> _repoScPortalRequestStudy;
        private readonly IRepository<ScMaintenanceTechnicalReport, long> _repoScMaintenanceTechnicalReport;

        public ScPortalRequestManager(IRepository<ScMaintenanceTechnicalReport, long> repoScMaintenanceTechnicalReport,
            IRepository<ScPortalRequest, long> scPortalRequestRepository, IRepository<ScCommitteeDetail, long> repoScCommitteeDetail, IRepository<ScPortalRequestStudy, long> repoScPortalRequestStudy)
        {
            _scPortalRequestRepository = scPortalRequestRepository;
            _repoScMaintenanceTechnicalReport = repoScMaintenanceTechnicalReport;
            _repoScCommitteeDetail = repoScCommitteeDetail;
            _repoScPortalRequestStudy = repoScPortalRequestStudy;
        }

        public async Task<Select2PagedResult> GetScPortalRequestSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = await _scPortalRequestRepository.GetAll()
                    .Where(z => !string.IsNullOrEmpty(searchTerm) ? (z.PortalRequestNumber.Contains(searchTerm)) && z.StatusLkpId != 149 && z.StatusLkpId != 151 : z.StatusLkpId != 149 && z.StatusLkpId != 151)
                    .ToListAsync();

            var result = data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = lang == "ar-EG" ? z.PortalRequestNumber : z.PortalRequestNumber }).ToList();

            var select2pagedResult = new Select2PagedResult
            {
                Total = data.Count(),
                Results = result
            };

            return select2pagedResult;
        }

        public async Task<Select2PagedResult> GetScPortalRequestMaintenanceSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
            => await GetScPortalRequestMaintenanceSelect2("number", searchTerm, pageSize, pageNumber, lang);

        public async Task<Select2PagedResult> GetScPortalRequestMaintenanceNameSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
            => await GetScPortalRequestMaintenanceSelect2("name", searchTerm, pageSize, pageNumber, lang);

        private async Task<Select2PagedResult> GetScPortalRequestMaintenanceSelect2(string trigger, string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var requsetsInMaintenanceReport = _repoScMaintenanceTechnicalReport.GetAll().Select(x => x.PortalRequestId);

            var data = _scPortalRequestRepository.GetAllIncluding(z => z.AidRequestType, x => x.ScPortalRequestStudy)
                    .Where(z => !requsetsInMaintenanceReport.Contains(z.Id) && (z.StatusLkpId == 10950 && z.AidRequestType.IsMaintenance) && (string.IsNullOrEmpty(searchTerm) || z.PortalRequestNumber.Contains(searchTerm) || z.Name.Contains(searchTerm)));

            var result = await data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            var filterdList = new List<Select2OptionModel>();

            foreach (var item in result)
            {
                foreach (var req in item.ScPortalRequestStudy)
                {
                    var committeDetails = await _repoScCommitteeDetail.GetAllListAsync(x => x.RequestStudyId == req.Id && x.StatusLkpId == 291);

                    if (committeDetails != null && committeDetails.Count > 0)
                    {
                        filterdList.Add(new Select2OptionModel { id = item.Id, text = trigger == "number" ? item.PortalRequestNumber : item.Name, altText = trigger == "number" ? $"{item.Name}-{committeDetails.FirstOrDefault().Id}" : $"{item.PortalRequestNumber}-{committeDetails.FirstOrDefault().Id}" });
                        break;
                    }
                }
            }

            var select2pagedResult = new Select2PagedResult
            {
                Total = result.Count(),
                Results = filterdList
            };

            return select2pagedResult;
        }

        public async Task<Select2PagedResult> GetScPortalRequestForMgrSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = await _scPortalRequestRepository.GetAll()
                    .Where(z => !string.IsNullOrEmpty(searchTerm) ? (z.PortalRequestNumber.Contains(searchTerm)) && z.StatusLkpId != 148 && z.StatusLkpId != 169 && z.StatusLkpId != 166 : z.StatusLkpId != 148 && z.StatusLkpId != 169 && z.StatusLkpId != 166)
                    .ToListAsync();

            var result = data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = lang == "ar-EG" ? z.PortalRequestNumber : z.PortalRequestNumber }).ToList();

            var select2pagedResult = new Select2PagedResult
            {
                Total = data.Count(),
                Results = result
            };

            return select2pagedResult;
        }

        public async Task<Select2PagedResult> GetScPortalRequestForStudySelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var requestsInStudy = _repoScPortalRequestStudy.GetAllIncluding(x=>x.ScPortalRequest.AidRequestType).Select(z => z.PortalRequestId);

            var data = _scPortalRequestRepository.GetAll()
                    .Where(z => (string.IsNullOrEmpty(searchTerm) || z.Name.Contains(searchTerm)) && (z.StatusLkpId == 150 && !requestsInStudy.Contains(z.Id)));

            var result = await data.OrderByDescending(q => q.CreationTime).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = z.PortalRequestNumber, altText = $"{z.Name}-{z.AidRequestType.IsMaintenance}" }).ToListAsync();

            var select2pagedResult = new Select2PagedResult
            {
                Total = await data.CountAsync(),
                Results = result
            };

            return select2pagedResult;
        }

        public async Task<Select2PagedResult> GetScPortalRequestForStudyByNameSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var requestsInStudy = _repoScPortalRequestStudy.GetAllIncluding(x => x.ScPortalRequest.AidRequestType).Select(z => z.PortalRequestId);

            var data = _scPortalRequestRepository.GetAll()
                    .Where(z => (string.IsNullOrEmpty(searchTerm) || z.Name.Contains(searchTerm)) && (z.StatusLkpId == 150 && !requestsInStudy.Contains(z.Id)));

            var result = await data.OrderByDescending(q => q.CreationTime).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = z.Name, altText = $"{z.PortalRequestNumber}-{z.AidRequestType.IsMaintenance}" }).ToListAsync();

            var select2pagedResult = new Select2PagedResult
            {
                Total = data.Count(),
                Results = result
            };

            return select2pagedResult;
        }
    }
}
