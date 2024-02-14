using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using ERP._System.__SpGuarantees._SpCaseEditData.Dto;
using ERP._System.__SpGuarantees._SpCases._SpCaseEditData.Proc;
using ERP._System.__SpGuarantees._SpCases._SpCaseEditData.ProcDto;
using ERP._System.__SpGuarantees._SpContracts._SpContractDetails;
using ERP._System.PostRecords.Dto;
using ERP.Authorization;
using ERP.Authorization.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__SpGuarantees._SpCaseEditData
{
    public class SpCaseEditDataAppService : ERPAppServiceBase, ISpCaseEditDataAppService
    {
        private readonly ISpCaseEditDataRepository _spCaseEditDataRepository;
        private readonly IRepository<SpContractDetails, long> _repoSpContractDetails;
        private readonly UserManager _userManager;

        public SpCaseEditDataAppService(IRepository<SpContractDetails, long> repoSpContractDetails,
            ISpCaseEditDataRepository spCaseEditDataRepository, UserManager userManager)
        {
            _repoSpContractDetails = repoSpContractDetails;
            _userManager = userManager;
            _spCaseEditDataRepository = spCaseEditDataRepository;
        }

        public async Task<SpCaseEditDataDataDto> Get(EntityDto<long> input)
        {
            var data = await _repoSpContractDetails.GetAllIncluding(z => z.SpCases,
                                   x => x.SpCases.FndLookupValuesSponsorCategoryLkp,
                                   x => x.SpContracts,
                                   x => x.FndBankLkp,
                                   x => x.SpContracts.SpBeneficent)
                             .Where(z => (z.Id == input.Id)).FirstOrDefaultAsync();

            return ObjectMapper.Map<SpCaseEditDataDataDto>(data);
        }

        public async Task<IEnumerable<SpCaseEditDataDataDto>> GetSpCasesContractDetails(SpCaseEditDataSearchDto dto)
        {
            if (dto.BeneficentId == null && dto.CaseId == null) throw new UserFriendlyException("يجب اختيار محسن او حالة");

            var data = await _repoSpContractDetails.GetAllIncluding(z => z.SpCases, x => x.SpCases.FndLookupValuesSponsorCategoryLkp
                 , x => x.SpContracts, x => x.SpContracts.SpBeneficent, x => x.FndBankLkp)
                 .Where(z => (z.Id == z.SpCases.SpContractDetailsId && z.CaseStatusLkpId == z.SpCases.StatusLkpId &&
                                z.SpCases.StatusLkpId == 687) &&
                             (dto.CaseId == null || z.SpCaseId == dto.CaseId) &&
                             (dto.BeneficentId == null || z.SpContracts.SpBeneficentId == dto.BeneficentId) &&
                             (string.IsNullOrEmpty(dto.BeneficentNumber) || z.SpContracts.SpBeneficent.BeneficentNumber.Contains(dto.BeneficentNumber)) &&
                             (string.IsNullOrEmpty(dto.CaseNumber) || z.SpCases.CaseNumber.Contains(dto.CaseNumber))
                             )
                 .ToListAsync();

            return ObjectMapper.Map<List<SpCaseEditDataDataDto>>(data);
        }

        public async Task<PostOutput> EditCase(SpCaseEditDataInputDto inputDto)
        {
            return await ExecuteStored(inputDto, "SpCaseOperationsUpdate");
        }

        public async Task<PostOutput> EditAllCases(SpCaseEditDataInputDto inputDto)
        {
            return await ExecuteStored(inputDto, "SpCaseOperationsUpdateAll");
        }

        private async Task<PostOutput> ExecuteStored(SpCaseEditDataInputDto inputDto, string storedName)
        {
            //var userPermissions = await _userManager.GetGrantedPermissionsAsync(await _userManager.GetUserByIdAsync((long)AbpSession.UserId));

            try
            {
                inputDto.UserId = (long)AbpSession.UserId;
                inputDto.TenantId = (int)AbpSession.TenantId;

                var result = await _spCaseEditDataRepository.Execute(inputDto, storedName);

                return result.FirstOrDefault();
            }
            catch (Exception x)
            {
                throw new UserFriendlyException(x.InnerException?.Message ?? x.Message);// for develop purpose
            }
        }
    }
}
