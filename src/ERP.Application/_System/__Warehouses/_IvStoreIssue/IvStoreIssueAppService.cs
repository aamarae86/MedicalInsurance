using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using ERP._System.__Warehouses._IvStoreIssue.Dto;
using ERP._System.__Warehouses._IvStoreIssue.Proc;
using ERP._System.__Warehouses.IvStoreIssue.Proc;
using ERP._System.__Warehouses.IvStoreIssue.ProcDto;
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

namespace ERP._System.__Warehouses._IvStoreIssue
{
    public class IvStoreIssueAppService : AsyncCrudAppService<IvStoreIssueHd, IvStoreIssueDto, long, IvStoreIssuePagedDto, IvStoreIssueCreateDto, IvStoreIssueEditDto>
        , IIvStoreIssueAppService
    {
        private readonly IRepository<IvStoreIssueTr, long> _repoDetails;
        private readonly IIvStoreIssueManager _IvStoreIssueManager;
        private readonly IGetCounterRepository _repoProcCounter;
        private readonly IIvStoreIssuePostRepository _IvStoreIssuePostRepository;
        private readonly IGlCodeComDetailsManager _glCodeComDetailsManager;
        private readonly IGetIvStoreIssueHdScreenDataRepository _getIvStoreIssueHdScreenDataRepository;

        public IvStoreIssueAppService(IRepository<IvStoreIssueTr, long> repoDetails
            , IRepository<IvStoreIssueHd, long> repository
            , IGetIvStoreIssueHdScreenDataRepository getIvStoreIssueHdScreenDataRepository
            , IIvStoreIssueManager IvStoreIssueManager
            , IGetCounterRepository repoProcCounter
            , IIvStoreIssuePostRepository IvStoreIssuePostRepository
            , IGlCodeComDetailsManager glCodeComDetailsManager
            ) : base(repository)
        {
            CreatePermissionName = PermissionNames.Pages_IvStoreIssue_Insert;
            UpdatePermissionName = PermissionNames.Pages_IvStoreIssue_Update;
            DeletePermissionName = PermissionNames.Pages_IvStoreIssue_Delete;
            GetAllPermissionName = PermissionNames.Pages_IvStoreIssue;

            _repoDetails = repoDetails;
            _IvStoreIssueManager = IvStoreIssueManager;
            _repoProcCounter = repoProcCounter;
            _IvStoreIssuePostRepository = IvStoreIssuePostRepository;
            _glCodeComDetailsManager = glCodeComDetailsManager;
            _getIvStoreIssueHdScreenDataRepository = getIvStoreIssueHdScreenDataRepository;
        }

        public override async Task<IvStoreIssueDto> Create(IvStoreIssueCreateDto input)
        {
            CheckCreatePermission();

            input.StoreIssueNumber = await GetStoreIssueNumber();

            if (!string.IsNullOrEmpty(input.codeComUtilityIds))
            {
                var currentComCodeId = await _glCodeComDetailsManager.CreateAndRetrieveCodeComOneId(input.codeComUtilityIds);

                if (currentComCodeId == null) throw new UserFriendlyException("حساب الصرف مطلوب");

                input.AccountId = currentComCodeId.Value;
            }
            else throw new UserFriendlyException("حساب الصرف مطلوب");

            var StoreIssue = await base.Create(input);

            if (input.ListOfCreateDetails?.Count > 0)
                foreach (var item in input.ListOfCreateDetails)
                {
                    item.IvStoreIssueHdId = StoreIssue.Id;

                    var IvStoreIssueDetail = ObjectMapper.Map<IvStoreIssueTr>(item);

                    _ = await _repoDetails.InsertAsync(IvStoreIssueDetail);

                }

            return null;
        }

        public override async Task<IvStoreIssueDto> Update(IvStoreIssueEditDto input)
        {
            CheckUpdatePermission();

            var currentComCodeId = await _glCodeComDetailsManager.CreateAndRetrieveCodeComOneId(input.codeComUtilityIds);

            if (currentComCodeId == null) throw new UserFriendlyException("حساب الصرف مطلوب");

            input.AccountId = currentComCodeId.Value;

            _ = await base.Update(input);

            if (input.ListOfEditDetails?.Count > 0)
            {
                foreach (var item in input.ListOfEditDetails)
                {
                    if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                    {
                        item.IvStoreIssueHdId = input.Id;

                        var IvStoreIssueMember = await _repoDetails.GetAsync((long)item.Id);

                        ObjectMapper.Map(item, IvStoreIssueMember);

                        _ = await _repoDetails.UpdateAsync(IvStoreIssueMember);

                    }
                    else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                    {
                        item.IvStoreIssueHdId = input.Id;

                        _ = await _repoDetails.InsertAsync(ObjectMapper.Map<IvStoreIssueTr>(item));
                    }
                    else if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                    {
                        await _repoDetails.DeleteAsync((long)item.Id);
                    }
                }
            }

            return new IvStoreIssueDto { };
        }

        public async Task<IvStoreIssueDto> GetDetailAsync(EntityDto<long> input)
        {
            var current = await Repository.GetAll()
                .Include(z => z.FndLookupValuesStatusLkp)
                .Include(z => z.FndLookupValuesIssueTypeLkp)
                .Include(z => z.FndLookupValuesBeneficiaryTypeLkp)
                .Include(z => z.Warehouses)
                .Include(z => z.GlCodeComDetails)
                .Include(z => z.IvStoreIssueTrs).ThenInclude(d => d.Items)
                .Include(z => z.IvStoreIssueTrs).ThenInclude(d => d.Units)
                           .Where(z => z.Id == input.Id)
                           .FirstOrDefaultAsync();

            var currentDto = ObjectMapper.Map<IvStoreIssueDto>(current);

            var currentCodeCom = await _glCodeComDetailsManager.GetCodeComTextsIds(current.GlCodeComDetails, _app.Reqlanguage);

            currentDto.codeComUtilityIds = currentCodeCom.ids;
            currentDto.codeComUtilityTexts = currentCodeCom.texts;

            return currentDto;
        }

        protected override IQueryable<IvStoreIssueHd> CreateFilteredQuery(IvStoreIssuePagedDto input)
        {
            var iqueryable = Repository.GetAllIncluding(z => z.FndLookupValuesStatusLkp
                , z => z.FndLookupValuesIssueTypeLkp
                , z => z.FndLookupValuesBeneficiaryTypeLkp
                , z => z.Warehouses, z => z.Warehouses.IvUserWarehousesPrivileges
                , z => z.IvStoreIssueTrs);

            long userId = (long)AbpSession.UserId;

            iqueryable = iqueryable.Where(z => z.Warehouses.IvUserWarehousesPrivileges.Any(x => x.UserId == userId && x.HasIssue));

            if (input.Params != null && input.Params.IvWarehouseId != null)
                iqueryable = iqueryable.Where(z => z.IvWarehouseId == input.Params.IvWarehouseId);

            if (input.Params != null && input.Params.StoreIssueNumber != null)
                iqueryable = iqueryable.Where(z => z.StoreIssueNumber == input.Params.StoreIssueNumber);

            if (input.Params != null && input.Params.StoreIssueDate != null)
            {
                DateTime dt = ((DateTime)DateTimeController.ConvertToDateTime(input.Params.StoreIssueDate)).Date;
                iqueryable = iqueryable.Where(z => z.StoreIssueDate.Date == dt);
            }

            if (input.Params != null && input.Params.StatusId != null)
                iqueryable = iqueryable.Where(z => z.StatusLkpId == input.Params.StatusId);

            return iqueryable;
        }

        public async Task<PostOutput> PostIvStoreIssue(PostDto idLangInputDto)
        {
            idLangInputDto.UserId = AbpSession.UserId.Value;
            var result = await _IvStoreIssuePostRepository.Execute(idLangInputDto, "IvStoreIssuePost");

            return result.FirstOrDefault();
        }

        public override Task Delete(EntityDto<long> input)
        {
            _repoDetails.Delete(z => z.IvStoreIssueHdId == input.Id);
            return base.Delete(input);
        }

        public async Task<List<IvStoreIssueHdScreenDataOutput>> GetIvStoreIssueHdScreenData(IdLangInputDto input)
        {
            var result = await _getIvStoreIssueHdScreenDataRepository.Execute(input, "GetIvStoreIssueHdScreenData");

            return result.ToList();
        }

        private async Task<string> GetStoreIssueNumber(string lang = "ar-EG", int year = 0)
        {
            var counterInput = new GetCounterInputDto { CounterName = "IvStoreIssueHd", TenantId = (int)AbpSession.TenantId, Lang = lang, year = year };

            var result = await _repoProcCounter.Execute(counterInput, "GetCounter");

            return result.FirstOrDefault().OutputStr;
        }
    }
}
