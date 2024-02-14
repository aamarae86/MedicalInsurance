using Abp.Application.Services;
using ERP._System.__AidModule._ScDeliveryOtherAids.Dto;
using ERP._System.PostRecords.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP._System.__AidModule._ScDeliveryOtherAids
{
    public interface IScDeliveryOtherAidsAppService : IAsyncCrudAppService<ScDeliveryOtherAidsDto, long, ScDeliveryOtherAidsPagedDto, ScDeliveryOtherAidsCreateDto, ScDeliveryOtherAidsEditDto>
    {
        Task<List<ScDeliveryOtherAidDetailsDto>> GetScDeliveryOtherAidDetailsDetail(long scDeliveryOtherAidsId);

        Task<PostOutput> PostScDeliveryOtherAids(PostDto postDto);

        Task<List<ScDeliveryOtherAidDetailsDto>> GetScDeliveryOtherAidDetailsData(long? committeeId, string maturityDate);
    }
}
