using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__AccountModule._GeneralUnPost.Dto;
using ERP._System.__AccountModule._GeneralUnPost.Input;
using ERP._System.__AccountModule._GeneralUnPost.Output;
using ERP._System.PostRecords.Dto;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__AccountModule._GeneralUnPost
{
    public interface IGeneralUnPostAppService: IAsyncCrudAppService<GeneralUnPostDto, long, PagedGeneralUnPostResultRequestDto, CreateGeneralUnPostDto, GeneralUnPostEditDto>
    {
        Task<PostOutput> CreateFromPost(GeneralPostUnPostInput input);
        Task<GeneralUnPostDto> GetDetailAsync(EntityDto<long> input);
        Task<Select2PagedResult> GetGeneralUnPostSelect2(string searchTerm, int pageSize, int pageNumber, string lang, string TableCode);
        Task<GetGeneralPostNotesOutput> GetGeneralPostNotes(long SourceLkpId, long SourceId);
    }
}
