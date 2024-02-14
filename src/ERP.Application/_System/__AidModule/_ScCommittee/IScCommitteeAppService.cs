using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using ERP._System.__AidModule._ScCommittee.Dto;
using ERP._System.__AidModule._ScCommittee.ProcDto;
using ERP._System._ScComityMembers.Dto;
using ERP._System.PostRecords.Dto;
using ERP.Helpers.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP._System.__AidModule._ScCommittee
{
    public interface IScCommitteeAppService : IAsyncCrudAppService<ScCommitteeDto, long, ScCommitteePagedDto, ScCommitteeCreateDto, ScCommitteeEditDto>
    {
        Task<IReadOnlyList<ScComityMembersDto>> GetAllScCommittteeMembers();

        Task<Select2PagedResult> GetScCommitteeNamesSelect2(string searchTerm, int pageSize, int pageNumber, string lang);

        Task<PostOutput> PostScCommittee(PostDto postDto);

        Task<Select2PagedResult> GetScCommitteeForChecksSelect2(string searchTerm, int pageSize, int pageNumber, string lang);

        Task<PostOutput> RefuseCommittee(PostDto postDto);

        Task<PostOutputWithId> PostScCommitteeDetail(PostDto postDto);

        Task<PostOutputWithId> PostponeScCommitteeDetail(PostDto postDto, string refuseDescription);

        Task<PostOutputWithId> RejectScCommitteeDetail(PostDto postDto, string refuseDescription);

        Task<List<ScCommitteeScreenDataOutput>> GetScCommitteesScreenData(IdLangInputDto input);

        ICollection<Permission> GetCommitteeDetailsPermissions();

        Task<bool> AlterCommitteeDetailPermission(CommitteeDetailPermissionInputDto input);

        Task<IReadOnlyList<ScCommitteeDetailsElectronicAidDto>> GetAllScCommitteeDetailsElectronicAid(EntityDto<long> input);
    }
}
