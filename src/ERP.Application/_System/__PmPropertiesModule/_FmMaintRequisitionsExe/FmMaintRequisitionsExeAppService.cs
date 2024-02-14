using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using ERP._System.__PmPropertiesModule._FmContracts;
using ERP._System.__PmPropertiesModule._FmEngineers;
using ERP._System.__PmPropertiesModule._FmMaintRequisitionsExe.Dto;
using ERP._System.__PmPropertiesModule._FmMaintRequisitionsHdr;
using ERP._System.__PmPropertiesModule._PmContract.Proc;
using ERP._System.PostRecords.Dto;
using ERP.Authorization;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__PmPropertiesModule._FmMaintRequisitionsExe
{
    [AbpAuthorize]
    public class FmMaintRequisitionsExeAppService : AsyncCrudAppService<FmMaintRequisitionsExe, FmMaintRequisitionsExeDto, long, FmMaintRequisitionsExePagedDto, FmMaintRequisitionsExeCreateDto, FmMaintRequisitionsExeEditDto>, IFmMaintRequisitionsExeAppService
    {
        private readonly IFmEngineersManager _fmEngineersManager;
        private readonly IFmContractsManager _fmContractsManager;
        private readonly IFmMaintRequisitionsHdrManager _fmMaintRequisitionsHdrManager;
        private readonly IPmContractRepository _pmContractRepository;
        private readonly IRepository<FmMaintRequisitionsHdr, long> _repoFmMaintRequisitionsHdr;

        public FmMaintRequisitionsExeAppService(IRepository<FmMaintRequisitionsExe, long> repository,
            IRepository<FmMaintRequisitionsHdr, long> repoFmMaintRequisitionsHdr, IPmContractRepository pmContractRepository,
            IFmMaintRequisitionsHdrManager fmMaintRequisitionsHdrManager, IFmContractsManager fmContractsManager,
            IFmEngineersManager fmEngineersManager) : base(repository)
        {
            _fmEngineersManager = fmEngineersManager;
            _fmContractsManager = fmContractsManager;
            _pmContractRepository = pmContractRepository;
            _repoFmMaintRequisitionsHdr = repoFmMaintRequisitionsHdr;
            _fmMaintRequisitionsHdrManager = fmMaintRequisitionsHdrManager;

            CreatePermissionName = PermissionNames.Pages_FmMaintRequisitionsExe_Insert;
            UpdatePermissionName = PermissionNames.Pages_FmMaintRequisitionsExe_Update;
            DeletePermissionName = PermissionNames.Pages_FmMaintRequisitionsExe_Delete;
            GetAllPermissionName = PermissionNames.Pages_FmMaintRequisitionsExe;
        }

        protected override IQueryable<FmMaintRequisitionsExe> CreateFilteredQuery(FmMaintRequisitionsExePagedDto input)
        {
            var iqueryable = Repository.GetAllIncluding(x => x.FndStatusLkp, x => x.FndExecuteTypeLkp, x => x.FmContracts, x => x.FmEngineers);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.ContractNumber))
                iqueryable = iqueryable.Where(z => z.FmContracts.ContractNumber.Contains(input.Params.ContractNumber));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.EngineerNumber))
                iqueryable = iqueryable.Where(z => z.FmEngineers.EngineerNumber.Contains(input.Params.EngineerNumber));

            if (input.Params != null && input.Params.ExecuteTypeLkpId != null)
                iqueryable = iqueryable.Where(z => z.ExecuteTypeLkpId == input.Params.ExecuteTypeLkpId);

            if (input.Params != null && input.Params.StatusLkpId != null)
                iqueryable = iqueryable.Where(z => z.StatusLkpId == input.Params.StatusLkpId);

            return iqueryable;
        }

        public async override Task<FmMaintRequisitionsExeDto> Get(EntityDto<long> input)
            => ObjectMapper.Map<FmMaintRequisitionsExeDto>(await Repository
                .GetAllIncluding(x => x.FndStatusLkp, x => x.FndExecuteTypeLkp, x => x.FmMaintRequisitionsHdr, x => x.FmContracts, x => x.FmContractVisits, x => x.FmEngineers)
                           .Where(x => x.Id == input.Id).FirstOrDefaultAsync());

        public async override Task<FmMaintRequisitionsExeDto> Create(FmMaintRequisitionsExeCreateDto input)
        {
            CheckCreatePermission();

            if (input.ExecuteTypeLkpId == /* periodicLkpType */ 11056) input.FmMaintRequisitionsHdrId = null;

            var validator = await ValidateFmMaintRequisitionsExe(ObjectMapper.Map<FmMaintRequisitionsExeDto>(input));

            if (!validator.Item1) throw new UserFriendlyException(validator.Item2);

            if (input.FmMaintRequisitionsHdrId.HasValue) await UpdateFmMaintRequisitionsHdrStatus(input.FmMaintRequisitionsHdrId.Value);

            return await base.Create(input);
        }

        public async override Task<FmMaintRequisitionsExeDto> Update(FmMaintRequisitionsExeEditDto input)
        {
            CheckUpdatePermission();

            if (input.ExecuteTypeLkpId == /* periodicLkpType */ 11056) input.FmMaintRequisitionsHdrId = null;

            var validator = await ValidateFmMaintRequisitionsExe(ObjectMapper.Map<FmMaintRequisitionsExeDto>(input));

            if (!validator.Item1) throw new UserFriendlyException(validator.Item2);

            return await base.Update(input);
        }

        public async Task<PostOutput> PostFmMaintRequisitionsExe(PostDto input)
        {
            input.UserId = (int)AbpSession.UserId;

            var result = await _pmContractRepository.Execute(input, "FmMaintRequisitionsExePost");

            return result.FirstOrDefault();
        }

        private async Task<(bool, string)> ValidateFmMaintRequisitionsExe(FmMaintRequisitionsExeDto dto)
        {
            string validateExecuteTypeLkpMessage = string.Empty;

            var validExecuteTypeLkp = ValidateExecuteTypeLkp(dto.ExecuteTypeLkpId, dto.FmMaintRequisitionsHdrId, dto.FmContractsId, out validateExecuteTypeLkpMessage);

            if (!validExecuteTypeLkp) return (false, validateExecuteTypeLkpMessage);

            int countForContractVisits = await Repository.CountAsync(x => x.FmContractsId == dto.FmContractsId && x.FmContractVisitsId == dto.FmContractVisitsId && x.Id != dto.Id);

            if (countForContractVisits > 0) return (false, "الزيارة مستخدمه من قبل");

            return (true, string.Empty);
        }

        private bool ValidateExecuteTypeLkp(long executeTypeLkpId, long? fmMaintRequisitionsHdrId, long? fmContractsId, out string message)
        {
            long emrgencyLkpType = 11055, periodicLkpType = 11056;

            message = string.Empty;

            if (executeTypeLkpId == emrgencyLkpType && !fmMaintRequisitionsHdrId.HasValue)
            {
                {
                    message = "رقم الطلب مطلوب";
                    return false;
                }
            }
            else if (executeTypeLkpId == periodicLkpType && !fmContractsId.HasValue)
            {
                {
                    message = "رقم العقد مطلوب";
                    return false;
                }
            }

            return true;
        }

        private async Task UpdateFmMaintRequisitionsHdrStatus(long fmMaintRequisitionsHdrId)
        {
            long statusLkpInProgressId = 11049;

            var fmMaintRequisitionsHdr = await _repoFmMaintRequisitionsHdr.GetAsync((long)fmMaintRequisitionsHdrId);

            fmMaintRequisitionsHdr.UpdateStatus(statusLkpInProgressId);

            _ = await _repoFmMaintRequisitionsHdr.UpdateAsync(fmMaintRequisitionsHdr);
        }

        public async Task<Select2PagedResult> GetFmEngineersNumberSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
            => await _fmEngineersManager.GetFmEngineersNumberSelect2(searchTerm, pageSize, pageNumber, lang);

        public async Task<Select2PagedResult> GetFmMaintRequisitionsNumberSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
            => await _fmMaintRequisitionsHdrManager.GetFmMaintRequisitionsNumberSelect2(searchTerm, pageSize, pageNumber, lang);

        public async Task<Select2PagedResult> GetFmContractsNumberSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
            => await _fmContractsManager.GetFmContractsNumberSelect2(searchTerm, pageSize, pageNumber, lang);

        public async Task<Select2PagedResult> GetFmContractsVisitsNumberSelect2(long contactId, string searchTerm, int pageSize, int pageNumber, string lang)
            => await _fmContractsManager.GetFmContractsVisitsNumberSelect2(contactId, searchTerm, pageSize, pageNumber, lang);
    }
}
