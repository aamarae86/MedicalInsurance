using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__AidModule._ScFndProtalAttachmentSetting.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP._System.__AidModule._ScFndProtalAttachmentSetting
{
    public interface IScFndProtalAttachmentSettingAppService : IAsyncCrudAppService<ScFndProtalAttachmentSettingDto, long, PagedScFndProtalAttachmentSettingResultRequestDto, CreateScFndProtalAttachmentSettingDto, ScFndProtalAttachmentSettingEditDto>
    {
        Task<ScFndProtalAttachmentSettingDto> GetDetailAsync(EntityDto<long> input);

        Task<List<ScFndProtalAttachmentSettingDto>> GetAttachmentSettingByAidType(long aidTypeId);

        Task<ListResultDto<ScFndProtalAttachmentSettingDto>> GetProtalAttachmentSettingForAidRequestTypeLkp(long RequestTypeId);
    }
}
