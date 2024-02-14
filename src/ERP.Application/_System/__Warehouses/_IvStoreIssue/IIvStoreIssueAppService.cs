using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using ERP._System.__Warehouses._IvStoreIssue.Dto;
using ERP._System.__Warehouses.IvStoreIssue.ProcDto;
using ERP._System._Counters.ProcDto;
using ERP._System._Counters.Procs;
using ERP._System.PostRecords.Dto;
using ERP.Authorization;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__Warehouses._IvStoreIssue
{
    public interface IIvStoreIssueAppService : IAsyncCrudAppService<IvStoreIssueDto, long, IvStoreIssuePagedDto, IvStoreIssueCreateDto, IvStoreIssueEditDto>
    {
        Task<IvStoreIssueDto> GetDetailAsync(EntityDto<long> input);
        //Task<Select2PagedResult> GetIvStoreIssueSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
        Task<PostOutput> PostIvStoreIssue(PostDto idLangInputDto);

        Task<List<IvStoreIssueHdScreenDataOutput>> GetIvStoreIssueHdScreenData(IdLangInputDto input);
    }
}
