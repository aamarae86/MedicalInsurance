using Abp.Application.Services;
using ERP._System._ScComityMembers.Dto;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System._ScComityMembers
{
    public interface IScComityMembersAppService : IAsyncCrudAppService<ScComityMembersDto, long, PagedScComityMembersResultRequestDto, CreateScComityMembersDto, ScComityMembersEditDto>
    {
        Task<Select2PagedResult> GetCommitteeMembersSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
