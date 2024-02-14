using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__AccountModule._ArSecurityDepositInterface.Dto;
using ERP._System.__AccountModule._ArSecurityDepositInterface.Input;
using ERP._System.__AccountModule._ArSecurityDepositInterface.Output;
using ERP._System._ArSecurityDepositInterface.Dto;
using ERP._System.PostRecords.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP._System._ArSecurityDepositInterface
{
    public interface IArSecurityDepositInterfaceAppService : IAsyncCrudAppService<ArSecurityDepositInterfaceDto, long, PagedArSecurityDepositInterfaceResultRequestDto, CreateArSecurityDepositInterfaceDto, ArSecurityDepositInterfaceEditDto>
    {
        Task<ArSecurityDepositInterfaceDto> GetDetailAsync(EntityDto<long> input);

        Task<(string text, long id)> GetNewArSecurityDepositInterfaceStatusSelect2Option();

        Task<PostOutput> PostArSecurityDepositInterface(PostDto postDto);

        Task<PostOutput> TransferArSecurityDepositInterface(PostDto postDto);

        Task<List<GetArSecurityDepositInterfaceScreenDataOutput>> GetArSecurityDepositInterfaceScreenData(IdLangInputDto postDto);

    }
}
