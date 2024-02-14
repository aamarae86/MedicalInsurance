using Abp.Application.Services;
using Abp.Domain.Repositories;
using ERP._System.__HR._HrPersonTimeSheet;
using ERP._System.__HR._TimeSheetType.Dto;
using ERP._System._Counters.Procs;
using ERP.Authorization;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__HR._TimeSheetType
{
  public  class TimeSheetTypeAppService : AsyncCrudAppService<TimeSheetType, TimeSheetTypeDto, long, TimeSheetTypePagedDto, TimeSheetTypeCreateDto, TimeSheetTypeEditDto>, ITimeSheetTypeAppService
    {
        private readonly IGetCounterRepository _repoProcCounter;
        private readonly IRepository<TimeSheetType, long> _repoTimeSheetType;


        public TimeSheetTypeAppService(IRepository<TimeSheetType, long> repoTimeSheetType,
           IGetCounterRepository getCounterRepository) : base(repoTimeSheetType)
        {
            _repoProcCounter = getCounterRepository;

            //CreatePermissionName = PermissionNames.Pages_HrPersonPermission_Insert;
            //UpdatePermissionName = PermissionNames.Pages_HrPersonPermission_Update;
            //DeletePermissionName = PermissionNames.Pages_HrPersonPermission_Delete;
            //GetAllPermissionName = PermissionNames.Pages_HrPersonPermission;
            _repoTimeSheetType = repoTimeSheetType;

        }

        public async Task<Select2PagedResult> GetTimeSheetTypeSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = _repoTimeSheetType.GetAll()
                      .Where(z => (string.IsNullOrEmpty(searchTerm) || z.TimeSheetTypeName.Contains(searchTerm) || z.TimeSheetTypeName.Contains(searchTerm)));

            long count = await data.LongCountAsync();

            var result = await data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize)
                        .Select(z => new Select2OptionModel { id = z.Id, text = z.TimeSheetTypeName, altText = z.TimeSheetTypeName })
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
