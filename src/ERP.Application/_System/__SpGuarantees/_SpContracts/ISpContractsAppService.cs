using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__SpGuarantees._SpBeneficent;
using ERP._System.__SpGuarantees._SpContracts.Dto;
using ERP._System.PostRecords.Dto;
using ERP.Helpers.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP._System.__SpGuarantees._SpContracts
{
    public interface ISpContractsAppService : IAsyncCrudAppService<SpContractsDto, long, PagedSpContractsResultRequestDto, SpContractsCreateDto, SpContractsEditDto>
    {
        Task<Select2PagedResult> GetSpBeneficentBanksSelect2(long spBeneficentId, string searchTerm, int pageSize, int pageNumber, string lang);

        Task<SpBeneficentBanks> GetSpBeneficentBanksForContract(long id);

        Task<SpContractsDto> GetDetailAsync(EntityDto<long> input);

        Task<List<SpContractAttachmentsDto>> GetAllSpAttachments(EntityDto<long> input);

        Task<List<SpContractDetailsDto>> GetAllSpContractsDetails(EntityDto<long> input);

        Task<(SpBeneficent, SpBeneficentBanks)> GetSpBeneficentForContract(long id);

        Task<PostOutput> PostSpContracts(PostDto postDto);

    }
}
