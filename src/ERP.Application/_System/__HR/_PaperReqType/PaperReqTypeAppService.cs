using Abp.Application.Services;
using Abp.Domain.Repositories;
using ERP._System.__HR._HRPaperRequest;
using ERP._System.__HR._PaperReqType.Dto;
using ERP._System._Counters.Procs;
using ERP.Authorization;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__HR._PaperReqType
{
  public  class PaperReqTypeAppService : AsyncCrudAppService<PaperReqType, PaperReqTypeDto, long, PaperReqTypePagedDto, PaperReqTypeCreateDto, PaperReqTypeEditDto>, IPaperReqTypeAppService
    {
        private readonly IGetCounterRepository _repoProcCounter;
        private readonly IRepository<PaperReqType, long> _repoPaperReqType;

        public PaperReqTypeAppService(IRepository<PaperReqType, long> repoPaperReqType,
            IGetCounterRepository getCounterRepository) : base(repoPaperReqType)
        {
            _repoProcCounter = getCounterRepository;

            CreatePermissionName = PermissionNames.Pages_PaperReqType_Insert;
            UpdatePermissionName = PermissionNames.Pages_PaperReqType_Update;
            DeletePermissionName = PermissionNames.Pages_PaperReqType_Delete;
            GetAllPermissionName = PermissionNames.Pages_PaperReqType;
            _repoPaperReqType = repoPaperReqType;
        }
        public async Task<Select2PagedResult> GetPaperReqTypeSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = _repoPaperReqType.GetAll()
                      .Where(z => (string.IsNullOrEmpty(searchTerm) || z.PaperReqTypeName.Contains(searchTerm) || z.PaperReqTypeName.Contains(searchTerm)));

            long count = await data.LongCountAsync();

            var result = await data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize)
                        .Select(z => new Select2OptionModel { id = z.Id, text = z.PaperReqTypeName, altText = z.PaperReqTypeName })
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
