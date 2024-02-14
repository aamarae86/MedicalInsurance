using Abp.Application.Services;
using Abp.Domain.Repositories;
using ERP._System.__HR._DocumentRequestType.Dto;
using ERP._System.__HR._HrPersonRequestDocument;
using ERP._System._Counters.Procs;
using ERP.Authorization;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__HR._DocumentRequestType
{
    
  public  class DocumentRequestTypeAppService : AsyncCrudAppService<DocumentRequestType, DocumentRequestTypeDto, long, DocumentRequestTypePagedDto, DocumentRequestTypeCreateDto, DocumentRequestTypeEditDto>, IDocumentRequestTypeAppService
    {
        private readonly IGetCounterRepository _repoProcCounter;
        private readonly IRepository<DocumentRequestType, long> _repoDocumentRequestType;

        public DocumentRequestTypeAppService(IRepository<DocumentRequestType, long> repoDocumentRequestType,
               IGetCounterRepository getCounterRepository) : base(repoDocumentRequestType)
        {
            _repoProcCounter = getCounterRepository;

            CreatePermissionName = PermissionNames.Pages_DocumentRequestType_Insert;
            UpdatePermissionName = PermissionNames.Pages_HrPersonPermission_Update;
            DeletePermissionName = PermissionNames.Pages_HrPersonPermission_Delete;
            GetAllPermissionName = PermissionNames.Pages_HrPersonPermission;
            _repoDocumentRequestType = repoDocumentRequestType;
        }

        public async Task<Select2PagedResult> GetDocumentRequestTypeSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = _repoDocumentRequestType.GetAll()
                      .Where(z => (string.IsNullOrEmpty(searchTerm) || z.DocumentRequestName.Contains(searchTerm) || z.DocumentRequestName.Contains(searchTerm)));

            long count = await data.LongCountAsync();

            var result = await data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize)
                        .Select(z => new Select2OptionModel { id = z.Id, text = z.DocumentRequestName, altText = z.DocumentRequestName })
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
