using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__AidModule._ScCommittee.Dto;
using ERP._System.__AidModule._ScCommitteesCheck.Dto;
using ERP._System.PostRecords.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__AidModule._ScCommitteesCheck
{
    public interface IScCommitteesCheckAppService : IAsyncCrudAppService<ScCommitteesCheckDto, long, PagedScCommitteesCheckResultRequestDto, CreateScCommitteesCheckDto, ScCommitteesCheckEditDto>
    {

        Task<ScCommitteesCheckDto> GetDetailAsync(EntityDto<long> input);

        Task<List<CommitteeRequestDataDto>> GetCommitteeRequestData(long? committeeId, string maturityDate);

        Task<List<CommitteeRequestDataDto>> GetCommitteeCheckDetail(long committeeCheckId);

        Task<PostOutput> PostScCommitteesCheck(PostDto postDto);
    }
}
