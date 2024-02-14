using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System.__HR._HrPersonPermission;
using ERP._System._Counters.Procs;
using ERP.Authorization;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__HR._HrPermissionType
{
    //[AbpAuthorize]
    public class HrPermissionTypeAppService : AsyncCrudAppService<HrPermissionType, HrPermissionTypeDto, long, HrPermissionTypePagedDto, HrPermissionTypeCreateDto, HrPermissionTypeEditDto>, IHrPermissionTypeAppService
    {
         private readonly IGetCounterRepository _repoProcCounter;
         private readonly IRepository<HrPermissionType, long> _repoHrPermissionType;

    public HrPermissionTypeAppService(IRepository<HrPermissionType, long> repoHrPermissionType,
        IGetCounterRepository getCounterRepository) : base(repoHrPermissionType)
    {
        _repoProcCounter = getCounterRepository;

        CreatePermissionName = PermissionNames.Pages_HrPersonPermission_Insert;
        UpdatePermissionName = PermissionNames.Pages_HrPersonPermission_Update;
        DeletePermissionName = PermissionNames.Pages_HrPersonPermission_Delete;
        GetAllPermissionName = PermissionNames.Pages_HrPersonPermission;
        _repoHrPermissionType = repoHrPermissionType;
    }
    //public HrPermissionTypeAppService(IRepository<HrPermissionType, long> repoHrPermissionType)
    //    {
    //        _repoHrPermissionType = repoHrPermissionType;
    //    }
    //    private readonly IGetCounterRepository _repoProcCounter;
    //public HrPermissionTypeAppService(IRepository<HrPermissionType, long> repository,
    //  IGetCounterRepository getCounterRepository) : base(repository)
    //{
    //    _repoProcCounter = getCounterRepository;

    //    CreatePermissionName = PermissionNames.Pages_HrPermissionType_Insert;
    //    UpdatePermissionName = PermissionNames.Pages_HrPermissionType_Update;
    //    DeletePermissionName = PermissionNames.Pages_HrPermissionType_Delete;
    //    GetAllPermissionName = PermissionNames.Pages_HrPermissionType;
    //}

        
       public async Task<Select2PagedResult> GetPermissionTypeSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = _repoHrPermissionType.GetAll()
                      .Where(z => (string.IsNullOrEmpty(searchTerm) || z.PermissionName.Contains(searchTerm) || z.PermissionName.Contains(searchTerm)));

            long count = await data.LongCountAsync();

            var result = await data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize)
                        .Select(z => new Select2OptionModel { id = z.Id, text = z.PermissionName, altText = z.PermissionName })
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
