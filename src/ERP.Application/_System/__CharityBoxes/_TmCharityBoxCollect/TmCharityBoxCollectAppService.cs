using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using ERP._System.__CharityBoxes._TmCharityBoxCollect._TmCharityBoxCollectDetails;
using ERP._System.__CharityBoxes._TmCharityBoxCollect._TmCharityBoxCollectMembersDetail;
using ERP._System.__CharityBoxes._TmCharityBoxCollect.Dto;
using ERP._System.__CharityBoxes._TmCharityBoxCollect.ProcDto;
using ERP._System.__CharityBoxes._TmCharityBoxReceive;
using ERP._System._Counters.ProcDto;
using ERP._System._Counters.Procs;
using ERP._System._FndLookupValues.Dto;
using ERP._System.PostRecords.Dto;
using ERP.Authorization;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__CharityBoxes._TmCharityBoxCollect
{
    [Abp.Authorization.AbpAuthorize]
    public class TmCharityBoxCollectAppService : AsyncCrudAppService<TmCharityBoxCollect, TmCharityBoxCollectDto, long, PagedTmCharityBoxCollectResultRequestDto, TmCharityBoxCollectCreateDto, TmCharityBoxCollectEditDto>,
        ITmCharityBoxCollectAppService
    {
        private readonly IRepository<TmCharityBoxCollectDetails, long> _repoTmCharityBoxCollectDetails;
        private readonly IRepository<TmCharityBoxCollectMembersDetail, long> _repoTmCharityBoxCollectMembersDetail;
        private readonly IGetCounterRepository _repoProcCounter;
        private readonly ITmCharityBoxReceiveRepository _repoPost;
        private readonly IGetTmCharityBoxCollectScreenDataReository _getTmCharityBoxCollectScreenDataReository;

        public TmCharityBoxCollectAppService(IRepository<TmCharityBoxCollect, long> repository,
            IRepository<TmCharityBoxCollectDetails, long> repoTmCharityBoxCollectDetails,
            IRepository<TmCharityBoxCollectMembersDetail, long> repoTmCharityBoxCollectMembersDetail,
            IGetTmCharityBoxCollectScreenDataReository getTmCharityBoxCollectScreenDataReository,
            IGetCounterRepository getCounterRepository, ITmCharityBoxReceiveRepository tmCharityBoxReceiveRepository)
            : base(repository)
        {
            _repoTmCharityBoxCollectDetails = repoTmCharityBoxCollectDetails;
            _repoTmCharityBoxCollectMembersDetail = repoTmCharityBoxCollectMembersDetail;
            _repoProcCounter = getCounterRepository;
            _repoPost = tmCharityBoxReceiveRepository;
            _getTmCharityBoxCollectScreenDataReository = getTmCharityBoxCollectScreenDataReository;

            CreatePermissionName = PermissionNames.Pages_TmCharityBoxCollect_Insert;
            UpdatePermissionName = PermissionNames.Pages_TmCharityBoxCollect_Update;
            DeletePermissionName = PermissionNames.Pages_TmCharityBoxCollect_Delete;
            GetAllPermissionName = PermissionNames.Pages_TmCharityBoxCollect;
        }

        protected override IQueryable<TmCharityBoxCollect> CreateFilteredQuery(PagedTmCharityBoxCollectResultRequestDto input)
        {
            var iqueryable = Repository.GetAllIncluding(x => x.FndStatusLookup, x => x.ApBankAccounts);

            if (input.Params != null && input.Params.StatusLkpId.HasValue && input.Params.StatusLkpId.Value > 0)
                iqueryable = iqueryable.Where(z => z.StatusLkpId == input.Params.StatusLkpId);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.CollectNumber))
                iqueryable = iqueryable.Where(z => z.CollectNumber.Contains(input.Params.CollectNumber));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.FromDate))
            {
                DateTime dtFrom = (DateTime)DateTimeController.ConvertToDateTime(input.Params.FromDate);

                iqueryable = iqueryable.Where(q => dtFrom <= q.CollectDate);
            }

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.ToDate))
            {
                DateTime dtTo = (DateTime)DateTimeController.ConvertToDateTime(input.Params.ToDate);

                iqueryable = iqueryable.Where(q => dtTo >= q.CollectDate);
            }

            return iqueryable;
        }

        public override async Task<TmCharityBoxCollectDto> Create(TmCharityBoxCollectCreateDto input)
        {
            CheckCreatePermission();

            input.CollectNumber = await GetCharityCollectBoxNumber();

            var current = await base.Create(input);

            if (input.CharityBoxCollectDetails.Count > 0)
            {
                foreach (var item in input.CharityBoxCollectDetails)
                {
                    item.TmCharityBoxCollectId = current.Id;

                    _ = await _repoTmCharityBoxCollectDetails.InsertAsync(ObjectMapper.Map<TmCharityBoxCollectDetails>(item));
                }
            }

            if (input.CharityBoxCollectMembers.Count > 0)
            {
                foreach (var item in input.CharityBoxCollectMembers)
                {
                    item.TmCharityBoxCollectId = current.Id;

                    _ = await _repoTmCharityBoxCollectMembersDetail.InsertAsync(ObjectMapper.Map<TmCharityBoxCollectMembersDetail>(item));
                }
            }

            return new TmCharityBoxCollectDto { };
        }

        public override async Task<TmCharityBoxCollectDto> Update(TmCharityBoxCollectEditDto input)
        {
            CheckUpdatePermission();

            _ = await base.Update(input);

            if (input.CharityBoxCollectDetails.Count > 0)
            {
                foreach (var item in input.CharityBoxCollectDetails)
                {
                    if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                    {
                        var charityBoxCollectDetails = await _repoTmCharityBoxCollectDetails.GetAsync((long)item.Id);

                        item.TmCharityBoxCollectId = input.Id;

                        ObjectMapper.Map(item, charityBoxCollectDetails);

                        _ = await _repoTmCharityBoxCollectDetails.UpdateAsync(charityBoxCollectDetails);
                    }
                    else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                    {
                        item.TmCharityBoxCollectId = input.Id;

                        _ = await _repoTmCharityBoxCollectDetails.InsertAsync(ObjectMapper.Map<TmCharityBoxCollectDetails>(item));
                    }
                    else if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                    {
                        await _repoTmCharityBoxCollectDetails.DeleteAsync((long)item.Id);
                    }
                }
            }

            if (input.CharityBoxCollectMembers.Count > 0)
            {
                foreach (var item in input.CharityBoxCollectMembers)
                {
                    if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                    {
                        var charityBoxCollectMembers = await _repoTmCharityBoxCollectMembersDetail.GetAsync((long)item.Id);

                        item.TmCharityBoxCollectId = input.Id;

                        ObjectMapper.Map(item, charityBoxCollectMembers);

                        _ = await _repoTmCharityBoxCollectMembersDetail.UpdateAsync(charityBoxCollectMembers);
                    }
                    else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                    {
                        item.TmCharityBoxCollectId = input.Id;

                        _ = await _repoTmCharityBoxCollectMembersDetail.InsertAsync(ObjectMapper.Map<TmCharityBoxCollectMembersDetail>(item));
                    }
                    else if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                    {
                        await _repoTmCharityBoxCollectMembersDetail.DeleteAsync((long)item.Id);
                    }
                }
            }

            return new TmCharityBoxCollectDto { };
        }

        public async Task<List<TmCharityBoxCollectDetailsDto>> GetAllDetails(long id)
        {
            var output = new List<TmCharityBoxCollectDetailsDto>();

            var listData = await _repoTmCharityBoxCollectDetails
                                     .GetAllIncluding(
                                        z => z.TmCharityBoxActionDetails,
                                        z => z.TmCharityBoxActionDetails.OldTmCharityBoxes,
                                        z => z.TmCharityBoxActionDetails.TmLocationSub,
                                        z => z.TmCharityBoxActionDetails.TmLocationSub.TmLocation,
                                        z => z.TmCharityBoxActionDetails.TmLocationSub.TmLocation.Region,
                                        z => z.TmCharityBoxActionDetails.TmLocationSub.TmLocation.Region.FndLookupValues
                                        )
                                     .Where(d => d.TmCharityBoxCollectId == id).ToListAsync();

            foreach (var item in listData)
            {
                var current = new TmCharityBoxCollectDetailsDto
                {
                    Id = item.Id,
                    CharityBoxActionDetailId = item.CharityBoxActionDetailId,
                    barCode = item.TmCharityBoxActionDetails.OldTmCharityBoxes == null ? string.Empty : item.TmCharityBoxActionDetails.OldTmCharityBoxes.CharityBoxBarcode,
                    charityBoxName = item.TmCharityBoxActionDetails.OldTmCharityBoxes == null ? string.Empty : item.TmCharityBoxActionDetails.OldTmCharityBoxes.CharityBoxName,
                    subLocation =
                                $"{item.TmCharityBoxActionDetails.TmLocationSub.TmLocation.Region.FndLookupValues.NameAr}-" +
                                $"{item.TmCharityBoxActionDetails.TmLocationSub.TmLocation.Region.RegionName}-" +
                                $"{item.TmCharityBoxActionDetails.TmLocationSub.TmLocation.LocationName}-" +
                                $"{item.TmCharityBoxActionDetails.TmLocationSub.TmLocationSubName}",
                    rowStatus = DetailRowStatus.RowStatus.NoAction.ToString()
                };

                output.Add(current);
            }

            return output;
        }

        public async Task<List<TmCharityBoxCollectMembersDetailDto>> GetAllMembersDetails(long id)
        {
            var output = new List<TmCharityBoxCollectMembersDetailDto>();

            var listData = await _repoTmCharityBoxCollectMembersDetail
                                     .GetAllIncluding(
                                           x => x.TmCharityBoxCollectMembers,
                                           x => x.TmCharityBoxCollectMembers.FndMemberCategoryValues)
                                     .Where(d => d.TmCharityBoxCollectId == id)
                                     .ToListAsync();

            foreach (var item in listData)
            {
                var current = new TmCharityBoxCollectMembersDetailDto
                {
                    Id = item.Id,
                    memberName = item.TmCharityBoxCollectMembers.MemberName,
                    memberNumber = item.TmCharityBoxCollectMembers.MemberNumber,
                    memberCategory = item.TmCharityBoxCollectMembers.FndMemberCategoryValues.NameAr,
                    TmCharityBoxCollectMemberId = item.TmCharityBoxCollectMemberId,
                    rowStatus = DetailRowStatus.RowStatus.NoAction.ToString()
                };

                output.Add(current);
            }

            return output;
        }

        public async Task<TmCharityBoxCollectDto> GetDetailAsync(EntityDto<long> input)
        {
            var current = await Repository
                                    .GetAllIncluding(x => x.FndStatusLookup, x => x.ApBankAccounts)
                                    .Where(z => z.Id == input.Id)
                                    .FirstOrDefaultAsync();

            return ObjectMapper.Map<TmCharityBoxCollectDto>(current);
        }

        public async Task<PostOutput> PostTmCharityBoxCollect(PostDto postDto)
        {
            postDto.UserId = (long)AbpSession.UserId;

            var result = await _repoPost.Execute(postDto, "TmCharityBoxCollectPost");

            return result.FirstOrDefault();
        }

        public async Task<List<TmCharityBoxCollectScreenDataOutput>> GetTmCharityBoxCollectScreenData(IdLangInputDto input)
        {
            var result = await _getTmCharityBoxCollectScreenDataReository.Execute(input, "GetTmCharityBoxCollectScreenData");

            return result.ToList();
        }

        private async Task<string> GetCharityCollectBoxNumber(string lang = "ar-EG", int year = 0)
        {
            var counterInput = new GetCounterInputDto { CounterName = "TmCharityBoxCollect", TenantId = (int)AbpSession.TenantId, Lang = lang, year = year };

            var result = await _repoProcCounter.Execute(counterInput, "GetCounter");

            return result?.FirstOrDefault()?.OutputStr ?? "0";
        }
    }
}
