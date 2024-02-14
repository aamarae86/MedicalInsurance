using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System._ApUserBankAccess.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System._ApUserBankAccess
{
    public interface IApUserBankAccessAppService : IAsyncCrudAppService<ApUserBankAccessDto, long, PagedApUserBankAccessResultRequestDto, CreateApUserBankAccessDto,  ApUserBankAccessEditDto>
    {
        Task<bool> AddAllBanks(long UserId);
        Task<ApUserBankAccessDto> GetDetailAsync(EntityDto<long> input);
        Task<ApUserBankAccessDto> GetMainAccountAsync();
        Task<ApUserBankAccessDto> GetBankAccessName(long saleid);
    }
}
