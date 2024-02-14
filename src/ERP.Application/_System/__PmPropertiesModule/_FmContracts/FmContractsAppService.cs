using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using ERP._System.__PmPropertiesModule._FmContracts.Dto;
using ERP._System.__PmPropertiesModule._FmEngineers;
using ERP._System.__PmPropertiesModule._FmEngineers.Dto;
using ERP._System.__PmPropertiesModule._PmContract.Proc;
using ERP._System._Counters.ProcDto;
using ERP._System._Counters.Procs;
using ERP._System._GlCodeComDetails;
using ERP._System.PostRecords.Dto;
using ERP.Authorization;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__PmPropertiesModule._FmContracts
{
    [AbpAuthorize]
    public class FmContractsAppService : AsyncCrudAppService<FmContracts, FmContractsDto, long, FmContractsPagedDto, FmContractsCreateDto, FmContractsEditDto>, IFmContractsAppService
    {
        private readonly IRepository<FmContractVisits, long> _fmContractVisitsRepository;
        private readonly IRepository<FmContracts, long> _fmContractsRepository;
        private readonly IPmContractRepository _pmContractRepository;
        private readonly IRepository<FmBuildingsContracts, long> _fmBuildingsContractsRepository;
        private readonly IRepository<FmEngineers, long> _fmEngineersRepository;

        private readonly IGlCodeComDetailsManager _glCodeComDetailsManager;


        private readonly IGetCounterRepository _repoProcCounter;
        private readonly IEntityCounterManager _entityCounterManager;

        public FmContractsAppService(IRepository<FmContracts, long> repository
            ,IRepository<FmContractVisits, long> fmContractVisitsRepository
            ,IRepository<FmBuildingsContracts, long> fmBuildingsContractsRepository,
             IGlCodeComDetailsManager glCodeComDetailsManager 
            , IRepository<FmEngineers, long> fmEngineersRepository,
             IRepository<FmContracts, long> fmContractsRepository,
             IPmContractRepository pmContractRepository 
             , IGetCounterRepository repoProcCounter 

            , IEntityCounterManager entityCounterManager) : base(repository)
        {
            _fmContractVisitsRepository = fmContractVisitsRepository;
            _fmBuildingsContractsRepository = fmBuildingsContractsRepository;
            _repoProcCounter = repoProcCounter;
            _entityCounterManager = entityCounterManager;
            _fmContractsRepository = fmContractsRepository;
           _pmContractRepository = pmContractRepository;
            _fmEngineersRepository = fmEngineersRepository;
            _glCodeComDetailsManager = glCodeComDetailsManager;

            CreatePermissionName = PermissionNames.Pages_FmContracts_Insert;
            UpdatePermissionName = PermissionNames.Pages_FmContracts_Update;
            DeletePermissionName = PermissionNames.Pages_FmContracts_Delete;
            GetAllPermissionName = PermissionNames.Pages_FmContracts;
        }

        protected override IQueryable<FmContracts> CreateFilteredQuery(FmContractsPagedDto input)
        {
            var iqueryable = Repository.GetAllIncluding(x => x.StatusValues, x => x.PaymentTypesValues, x => x.ApVendorsValues);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.ContractDate))
            {
                var dt = DateTimeController.ConvertToDateTime(input.Params.ContractDate);
                iqueryable = iqueryable.Where(z => z.ContractDate == dt);

            }

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.ContractNumber))
                iqueryable = iqueryable.Where(z => z.ContractNumber == input.Params.ContractNumber);
              
            if (input.Params != null && input.Params.VendorId != null)
                iqueryable = iqueryable.Where(z => z.VendorId == input.Params.VendorId);
              
            if (input.Params != null && input.Params.StatusLkpId != null)
                iqueryable = iqueryable.Where(z => z.StatusLkpId == input.Params.StatusLkpId);

            return iqueryable;
        }

        public async override Task<FmContractsDto> Get(EntityDto<long> input)
        {
             
            var current = await Repository.GetAllIncluding(x => x.StatusValues
            , x => x.FmContractVisits, x => x.FmBuildingsContracts
            , x => x.ApVendorsValues, x => x.PaymentTypesValues, x => x.AdvGlCodeComDetails
            , x => x.AccounGlCodeComDetails
           
            ).Where(x=>x.Id == input.Id).FirstOrDefaultAsync();

            var currentDto = ObjectMapper.Map<FmContractsDto>(current);

            var currentCodeCom = await _glCodeComDetailsManager.GetCodeComTextsIds(current.AccounGlCodeComDetails, _app.Reqlanguage);
            currentDto.codeComUtilityIds = currentCodeCom.ids;
            currentDto.codeComUtilityTexts = currentCodeCom.texts;

            var currentCodeCom1 = await _glCodeComDetailsManager.GetCodeComTextsIds(current.AdvGlCodeComDetails, _app.Reqlanguage);
            currentDto.codeComUtilityIds_alt1 = currentCodeCom1.ids;
            currentDto.codeComUtilityTexts_alt1 = currentCodeCom1.texts;
 
            return currentDto;
        }

        public async override Task<FmContractsDto> Create(FmContractsCreateDto input)
        {
            CheckCreatePermission();


            var currentComCodeId = await _glCodeComDetailsManager.CreateAndRetrieveCodeComOneId(input.codeComUtilityIds);
            var codeComUtilityIds_alt1 = await _glCodeComDetailsManager.CreateAndRetrieveCodeComOneId(input.codeComUtilityIds_alt1);

            input.AccountId = (long)currentComCodeId;
            input.AdvAccountId = (long)codeComUtilityIds_alt1;
            input.StatusLkpId = 11039;


            var counterInput = new GetCounterInputDto { CounterName = "FmContracts", TenantId = (int)AbpSession.TenantId, Lang = "ar-EG", year = 0 };
            var result = await _repoProcCounter.Execute(counterInput, "GetCounter");
            input.ContractNumber = result?.FirstOrDefault()?.OutputStr ?? string.Empty;

            var entityToinsert = ObjectMapper.Map<FmContracts>(input);

            var current = await Repository.InsertAsync(entityToinsert);

            if (!input.FmBuildingsContractsList.Any())
                throw new UserFriendlyException($"FmBuildingsContractsList can't be Empty");
           
            if (!input.FmContractVisitsList.Any())
                throw new UserFriendlyException($"FmContractVisitsList can't be Empty");
 
            await CRUD_FmContractVisits(input.FmContractVisitsList, current.Id);
            await CRUD_FmBuildingsContracts(input.FmBuildingsContractsList, current.Id);
            return ObjectMapper.Map<FmContractsDto>(current);
        }


        public async override Task<FmContractsDto> Update(FmContractsEditDto input)
        {
            CheckUpdatePermission();
          
            var currentComCodeId = await _glCodeComDetailsManager.CreateAndRetrieveCodeComOneId(input.codeComUtilityIds);
            var codeComUtilityIds_alt1 = await _glCodeComDetailsManager.CreateAndRetrieveCodeComOneId(input.codeComUtilityIds_alt1);

            input.AccountId = (long)currentComCodeId;
            input.AdvAccountId = (long)codeComUtilityIds_alt1;
           
            var current = Repository.Get(input.Id);
            input.ContractNumber = current.ContractNumber;

            if (current.StatusLkpId != 11039)
                throw new UserFriendlyException($"Only new contracts can updated");


            input.StatusLkpId = current.StatusLkpId;
            _ = await base.Update(input);

            if (!input.FmBuildingsContractsList.Any())
                throw new UserFriendlyException($"FmBuildingsContractsList can't be Empty");

            if (!input.FmContractVisitsList.Any())
                throw new UserFriendlyException($"FmContractVisitsList can't be Empty");

            await CRUD_FmContractVisits(input.FmContractVisitsList, input.Id);

            await CRUD_FmBuildingsContracts(input.FmBuildingsContractsList, input.Id);

            return new FmContractsDto { };
        }


        public async Task<List<FmContractVisitsDto>> GetAllFmContractVisitsData(EntityDto<long> input)
        {
            var listData = await _fmContractVisitsRepository
                               .GetAllIncluding(x => x.FmContracts, x => x.FmEngineers)
                               .Where(d => d.ContractId == input.Id).ToListAsync();

            var FmContractVisitsDtodemo = ObjectMapper.Map<List<FmContractVisitsDto>>(listData);

            return FmContractVisitsDtodemo;
        }    
        
        public async Task<List<FmBuildingsContractsDto>> GetAllFmBuildingsContractsData(EntityDto<long> input)
        {
            var listData = await _fmBuildingsContractsRepository
                               .GetAllIncluding(x => x.FmContracts, x => x.PmProperties)
                               .Where(d => d.ContractId == input.Id).ToListAsync();

            return ObjectMapper.Map<List<FmBuildingsContractsDto>>(listData);
        }

        private async Task CRUD_FmContractVisits(ICollection<FmContractVisitsDto> FmContractVisits, long contracrId)
        {
                if (FmContractVisits != null && FmContractVisits.Count > 0)
                {
                    foreach (var item in FmContractVisits)
                    {
                        if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                        {
                            var detailsData = await _fmContractVisitsRepository.GetAsync((long)item.Id);

                            item.ContractId = contracrId;

                            ObjectMapper.Map(item, detailsData);                           

                            _ = await _fmContractVisitsRepository.UpdateAsync(detailsData);
                        }
                        else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                        {
                            item.ContractId = contracrId;
                            var entityToinsert =  ObjectMapper.Map<FmContractVisits>(item);
                            await _fmContractVisitsRepository.InsertAsync(entityToinsert);
                        }
                        else if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                        {
                            await _fmContractVisitsRepository.DeleteAsync((long)item.Id);
                        }
                    }
                }
        }

        private async Task CRUD_FmBuildingsContracts(ICollection<FmBuildingsContractsDto> FmBuildingsContracts, long contracrId)
        {
            if (FmBuildingsContracts != null && FmBuildingsContracts.Count > 0)
            {
                foreach (var item in FmBuildingsContracts)
                {
                    if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                    {
                        var detailsData = await _fmBuildingsContractsRepository.GetAsync((long)item.Id);

                        item.ContractId = contracrId;

                        ObjectMapper.Map(item, detailsData);

                        _ = await _fmBuildingsContractsRepository.UpdateAsync(detailsData);
                    }
                    else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                    {
                        item.ContractId = contracrId;
                        var entityToinsert = ObjectMapper.Map<FmBuildingsContracts>(item);
                        await _fmBuildingsContractsRepository.InsertAsync(entityToinsert);
                    }
                    else if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                    {
                        await _fmBuildingsContractsRepository.DeleteAsync((long)item.Id);
                    }
                }
            }
        }

        public async Task<Select2PagedResult> GetEngineersSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = await _fmEngineersRepository.GetAll()
                         .Where(z => string.IsNullOrEmpty(searchTerm) || (lang == "ar-EG" ? z.EngineerName.Contains(searchTerm) : z.EngineerName.Contains(searchTerm)))
                         .ToListAsync();

            var result = data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = lang == "ar-EG" ? z.EngineerName : z.EngineerName, altText = z.Id.ToString() }).ToList();

            var select2pagedResult = new Select2PagedResult
            {
                Total = data.Count(),
                Results = result
            };

            return select2pagedResult;
        }

        public async Task<Select2PagedResult> GetContractNumbersSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = await Repository.GetAll()
                         .Where(z => string.IsNullOrEmpty(searchTerm) || (lang == "ar-EG" ? z.ContractNumber==searchTerm : z.ContractNumber == searchTerm ))
                         .ToListAsync();

            var result = data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = lang == "ar-EG" ? z.ContractNumber : z.ContractNumber, altText = z.Id.ToString() }).ToList();

            var select2pagedResult = new Select2PagedResult
            {
                Total = data.Count(),
                Results = result
            };
            return select2pagedResult;
        }

        public async Task<PostOutput> PostFmContract(PostDto input)
        {
            input.UserId = (int)AbpSession.UserId;

            var result = await _pmContractRepository.Execute(input, "FmContractsPost");

            return result.FirstOrDefault();
        }

    }
}
