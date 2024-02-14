using Abp.Domain.Repositories;
using ERP._System.__AidModule._ScMaintenancePayments;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__AidModule._ScMaintenanceContract
{
    public class ScMaintenanceContractManager : IScMaintenanceContractManager
    {
        private readonly IRepository<ScMaintenanceContract, long> _repoScMaintenanceContract;
        private readonly IRepository<ScMaintenancePayments, long> _ScMaintenancePayments;
        private readonly IRepository<ScMaintenanceContractPayments, long> _repoScMaintenanceContractPayments;

        public ScMaintenanceContractManager(IRepository<ScMaintenanceContract, long> repoScMaintenanceContract, IRepository<ScMaintenancePayments, long> scMaintenancePayments, IRepository<ScMaintenanceContractPayments, long> repoScMaintenanceContractPayments)
        {
            _repoScMaintenanceContract = repoScMaintenanceContract;
            _ScMaintenancePayments = scMaintenancePayments;
            _repoScMaintenanceContractPayments = repoScMaintenanceContractPayments;
        }

        public async Task<Select2PagedResult> GetScMaintenanceContractPaymentsSelect2(long contractId, string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = _repoScMaintenanceContractPayments.GetAll().Where(z =>  z.ScMaintenanceContractId == contractId && (string.IsNullOrEmpty(searchTerm) || z.PayemtNo.ToString().Contains(searchTerm)));

            var paymentsInContract = _ScMaintenancePayments.GetAllIncluding(x => x.ScMaintenanceContractPayments.ScMaintenanceContract).Where(x => x.ScMaintenanceContractPayments.ScMaintenanceContractId == contractId).Select(x => x.ScMaintenanceContractPaymentId);
            data = data.Where(x => !paymentsInContract.Contains(x.Id));

            var result = await data.OrderByDescending(q => q.CreationTime).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = z.PayemtNo.ToString(), altText = $"{z.Amount}-{z.MaturityDate.ToString(Formatters.DateFormat)}" }).ToListAsync();

            var select2pagedResult = new Select2PagedResult
            {
                Total = await data.CountAsync(),
                Results = result
            };

            return select2pagedResult;
        }

        public async Task<Select2PagedResult> GetScMaintenanceContractPaymentsByContractNumberSelect2(string contactNumber, string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = _repoScMaintenanceContractPayments.GetAllIncluding(x => x.ScMaintenanceContract).Where(z => z.ScMaintenanceContract.MaintenanceContractNumber.Contains(contactNumber) && (string.IsNullOrEmpty(searchTerm) || z.PayemtNo.ToString().Contains(searchTerm)));

            var result = await data.OrderByDescending(q => q.CreationTime).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = z.PayemtNo.ToString() }).ToListAsync();

            var select2pagedResult = new Select2PagedResult
            {
                Total = await data.CountAsync(),
                Results = result
            };

            return select2pagedResult;
        }

        public async Task<Select2PagedResult> GetScMaintenanceContractSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = _repoScMaintenanceContract.GetAllIncluding(z => z.ScMaintenanceQuotations.ScMaintenanceTechnicalReport.PortalRequest.PortalUser, x => x.ScMaintenanceQuotations.ApVendors).Where(z => z.StatusLkpId == 948 && (string.IsNullOrEmpty(searchTerm) || z.MaintenanceContractNumber.Contains(searchTerm)));

            var result = await data.OrderByDescending(q => q.CreationTime).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = z.MaintenanceContractNumber, altText = $"{z.ScMaintenanceQuotations.ScMaintenanceTechnicalReport.PortalRequest.PortalRequestNumber}-{z.ScMaintenanceQuotations.ScMaintenanceTechnicalReport.PortalRequest.PortalUser.Name}-{z.ScMaintenanceQuotations.ApVendors.VendorNameAr}.{z.ScMaintenanceQuotations.ApVendors.VendorNameEn}" }).ToListAsync();

            var select2pagedResult = new Select2PagedResult
            {
                Total = await data.CountAsync(),
                Results = result
            };

            return select2pagedResult;
        }
    }
}
