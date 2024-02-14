using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using ERP._System.__SpGuarantees._SpCaseOperations.Dto;
using ERP._System.__SpGuarantees._SpCases._SpCaseOperations.Proc;
using ERP._System.__SpGuarantees._SpCases._SpCaseOperations.ProcDto;
using ERP._System.__SpGuarantees._SpContracts._SpContractDetails;
using ERP._System.PostRecords.Dto;
using ERP.Authorization;
using ERP.Authorization.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__SpGuarantees._SpCaseOperations
{
    public class SpCaseOperationsAppService : ERPAppServiceBase, ISpCaseOperationsAppService
    {
        private readonly ISpCaseOperationsRepository _spCaseOperationsRepository;
        private readonly ISpCaseOperationsReplaceRepository _spCaseOperationsReplaceRepository;
        private readonly IRepository<SpContractDetails, long> _repoSpContractDetails;
        private readonly UserManager _userManager;

        public SpCaseOperationsAppService(IRepository<SpContractDetails, long> repoSpContractDetails,
            ISpCaseOperationsRepository spCaseOperationsRepository,
            ISpCaseOperationsReplaceRepository spCaseOperationsReplaceRepository,
             UserManager userManager)
        {
            _repoSpContractDetails = repoSpContractDetails;
            _userManager = userManager;
            _spCaseOperationsRepository = spCaseOperationsRepository;
            _spCaseOperationsReplaceRepository = spCaseOperationsReplaceRepository;
        }

        public async Task<SpCaseOperationsDataDto> Get(EntityDto<long> input)
        {
            var data = await _repoSpContractDetails
                             .GetAllIncluding(z => z.SpCases, x => x.SpCases.FndLookupValuesSponsorCategoryLkp, x => x.SpContracts, x => x.SpContracts.SpBeneficent)
                             .Where(z => (z.Id == input.Id)).FirstOrDefaultAsync();

            return ObjectMapper.Map<SpCaseOperationsDataDto>(data);
        }

        public async Task<IEnumerable<SpCaseOperationsDataDto>> GetSpCasesContractDetails(SpCaseOperationsSearchDto dto)
        {
            if (dto.BeneficentId == null && dto.CaseId == null) throw new UserFriendlyException("يجب اختيار محسن او حالة");

            var data = await _repoSpContractDetails
                 .GetAllIncluding(z => z.SpCases, x => x.SpCases.FndLookupValuesSponsorCategoryLkp, x => x.SpContracts, x => x.SpContracts.SpBeneficent)
                 .Where(z => (z.Id == z.SpCases.SpContractDetailsId && z.CaseStatusLkpId == z.SpCases.StatusLkpId &&
                                z.SpCases.StatusLkpId == 687) &&
                             (dto.CaseId == null || z.SpCaseId == dto.CaseId) &&
                             (dto.BeneficentId == null || z.SpContracts.SpBeneficentId == dto.BeneficentId) &&
                             (string.IsNullOrEmpty(dto.BeneficentNumber) || z.SpContracts.SpBeneficent.BeneficentNumber.Contains(dto.BeneficentNumber)) &&
                             (string.IsNullOrEmpty(dto.CaseNumber) || z.SpCases.CaseNumber.Contains(dto.CaseNumber))
                             )
                 .ToListAsync();

            return ObjectMapper.Map<List<SpCaseOperationsDataDto>>(data);
        }

        public async Task<PostOutput> OperateCase(SpCaseOperationsInputDto inputDto)
        {
            var userPermissions = await _userManager.GetGrantedPermissionsAsync(await _userManager.GetUserByIdAsync((long)AbpSession.UserId));

            if (inputDto.OperationTypeLkpId == 711 && !userPermissions.Any(x => x.Name.Contains(PermissionNames.Pages_SpCaseOperations_Post)))
                throw new UserFriendlyException("لا يوجد صلاحية لك للألغاء");
            else if (inputDto.OperationTypeLkpId == 710 && !userPermissions.Any(x => x.Name.Contains(PermissionNames.Pages_SpCaseOperations_Post)))
                throw new UserFriendlyException("لا يوجد صلاحية لك للأيقاف");

            try
            {
                string procOperationName = inputDto.OperationTypeLkpId == 711 ? "SpCaseOperationsCancel"
                                          : (inputDto.OperationTypeLkpId == 710 ? "SpCaseOperationsStop" : string.Empty);

                if (string.IsNullOrEmpty(procOperationName)) throw new UserFriendlyException("خطأ ف نوع العملية!!");

                inputDto.UserId = (long)AbpSession.UserId;
                inputDto.TenantId = (int)AbpSession.TenantId;

                var input = ObjectMapper.Map<SpCaseOperationsInputDto_Proc>(inputDto);

                var result = await _spCaseOperationsRepository.Execute(input, procOperationName);

                return result.FirstOrDefault();
            }
            catch (Exception x)
            {
                throw new UserFriendlyException(x.InnerException?.Message ?? x.Message);// for develop purpose
            }
        }

        public async Task<PostOutput> OperateReplaceCase(SpCaseOperationsReplaceInputDtoHelper inputDto)
        {
            var userPermissions = await _userManager.GetGrantedPermissionsAsync(await _userManager.GetUserByIdAsync((long)AbpSession.UserId));

            if (!userPermissions.Any(x => x.Name.Contains(PermissionNames.Pages_SpCaseOperationsReplace_Post)))
                throw new UserFriendlyException("لا يوجد صلاحية لك للاستبدال");

            try
            {
                inputDto.UserId = (long)AbpSession.UserId;
                inputDto.TenantId = (int)AbpSession.TenantId;

                var input = ObjectMapper.Map<SpCaseOperationsReplaceInputDto>(inputDto);

                var result = await _spCaseOperationsReplaceRepository.Execute(input, "SpCaseOperationsChange");

                return result.FirstOrDefault();
            }
            catch (Exception x)
            {
                throw new UserFriendlyException(x.InnerException?.Message ?? x.Message);// for develop purpose
            }
        }
    }
}
