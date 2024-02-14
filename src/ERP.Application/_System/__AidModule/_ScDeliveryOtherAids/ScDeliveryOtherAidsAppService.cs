using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.UI;
using ERP._System.__AidModule._ScCommittee;
using ERP._System.__AidModule._ScCommitteesCheck.Proc;
using ERP._System.__AidModule._ScDeliveryOtherAids.Dto;
using ERP._System.__AidModule._ScPortalRequestMgrDecision;
using ERP._System.__AidModule._ScPortalRequestStudy;
using ERP._System._Counters.ProcDto;
using ERP._System._Counters.Procs;
using ERP._System._FndLookupValues.Dto;
using ERP._System.PostRecords.Dto;
using ERP.Authorization;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__AidModule._ScDeliveryOtherAids
{
    [AbpAuthorize]
    public class ScDeliveryOtherAidsAppService : AsyncCrudAppService<ScDeliveryOtherAids, ScDeliveryOtherAidsDto, long, ScDeliveryOtherAidsPagedDto, ScDeliveryOtherAidsCreateDto, ScDeliveryOtherAidsEditDto>, IScDeliveryOtherAidsAppService
    {
        private readonly IRepository<ScPortalRequestMgrDecision, long> _repoScPortalRequestMgrDecision;
        private readonly IRepository<ScCommitteeDetail, long> _repoScCommitteeDetail;
        private readonly IRepository<ScPortalRequestStudy, long> _repoScPortalRequestStudy;
        private readonly IRepository<ScDeliveryOtherAidDetails, long> _repoScDeliveryOtherAidDetails;
        private readonly IGetCounterRepository _repoProcCounter;
        private readonly IScCommitteesCheckPostRepository _scCommitteesCheckPostRepository;

        public ScDeliveryOtherAidsAppService(IRepository<ScDeliveryOtherAids, long> repository,
            IRepository<ScCommitteeDetail, long> repoScCommitteeDetail,
            IRepository<ScPortalRequestStudy, long> repoScPortalRequestStudy,
            IRepository<ScPortalRequestMgrDecision, long> repoScPortalRequestMgrDecision,
            IGetCounterRepository getCounterRepository, IRepository<ScDeliveryOtherAidDetails, long> repoScDeliveryOtherAids,
            IScCommitteesCheckPostRepository scCommitteesCheckPostRepository) : base(repository)
        {
            _repoProcCounter = getCounterRepository;
            _repoScCommitteeDetail = repoScCommitteeDetail;
            _repoScDeliveryOtherAidDetails = repoScDeliveryOtherAids;
            _repoScPortalRequestStudy = repoScPortalRequestStudy;
            _repoScPortalRequestMgrDecision = repoScPortalRequestMgrDecision;
            _scCommitteesCheckPostRepository = scCommitteesCheckPostRepository;

            CreatePermissionName = PermissionNames.Pages_ScDeliveryOtherAids_Insert;
            UpdatePermissionName = PermissionNames.Pages_ScDeliveryOtherAids_Update;
            DeletePermissionName = PermissionNames.Pages_ScDeliveryOtherAids_Delete;
            GetAllPermissionName = PermissionNames.Pages_ScDeliveryOtherAids;
        }

        public async override Task<PagedResultDto<ScDeliveryOtherAidsDto>> GetAll(ScDeliveryOtherAidsPagedDto input)
        {
            CheckGetAllPermission();

            var queryable = Repository.GetAllIncluding(x => x.FndStatusLkp, x => x.ScCommittee);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.OperationNumber))
                queryable = queryable.Where(q => q.OperationNumber.Contains(input.Params.OperationNumber));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.OperationDate))
                queryable = queryable.Where(q => q.OperationDate == DateTimeController.ConvertToDateTime(input.Params.OperationDate));

            if (input.Params != null && input.Params.StatusLkpId != null)
                queryable = queryable.Where(q => q.StatusLkpId == input.Params.StatusLkpId);

            if (input.Params != null && input.Params.CommitteeId != null)
                queryable = queryable.Where(q => q.CommitteeId == input.Params.CommitteeId);

            var count = await queryable.CountAsync();

            var listOrder = new List<SortModel> { new SortModel { Sort = input.OrderByValue.Sort, ColId = input.OrderByValue.ColId } };

            queryable = queryable.DynamicOrderBy(listOrder);
            queryable = queryable.Skip(input.SkipCount);

            var data = await queryable.Take(input.MaxResultCount).ToListAsync();

            var data2 = ObjectMapper.Map<List<ScDeliveryOtherAidsDto>>(data);

            for (int i = 0; i < data2.Count; i++)
            {
                data2[i].MaturityDate = data[i].MaturityDate.HasValue ? data[i].MaturityDate.Value.ToString(Formatters.DateFormat) : string.Empty;
                data2[i].OperationDate = data[i].OperationDate.ToString(Formatters.DateFormat);
            }

            var PagedResultDto = new PagedResultDto<ScDeliveryOtherAidsDto>()
            {
                Items = data2 as IReadOnlyList<ScDeliveryOtherAidsDto>,
                TotalCount = count
            };

            return PagedResultDto;
        }

        public async override Task<ScDeliveryOtherAidsDto> Create(ScDeliveryOtherAidsCreateDto input)
        {
            CheckCreatePermission();

            input.OperationNumber = await GetCommitteeCheckNumber();

            var currentScCampains = await base.Create(input);

            if (input.OtherAidDetails.Count > 0)
            {
                foreach (var item in input.OtherAidDetails)
                {
                    item.ScDeliveryOtherAidsId = currentScCampains.Id;

                    _ = await _repoScDeliveryOtherAidDetails.InsertAsync(ObjectMapper.Map<ScDeliveryOtherAidDetails>(item));
                }
            }

            return new ScDeliveryOtherAidsDto { };
        }

        public async override Task<ScDeliveryOtherAidsDto> Update(ScDeliveryOtherAidsEditDto input)
        {
            CheckUpdatePermission();

            _ = await base.Update(input);

            if (input.OtherAidDetails.Count > 0)
            {
                foreach (var item in input.OtherAidDetails)
                {
                    if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                    {
                        item.ScDeliveryOtherAidsId = input.Id;
                        var scCampainsDetail = await _repoScDeliveryOtherAidDetails.GetAsync((long)item.Id);

                        ObjectMapper.Map(item, scCampainsDetail);

                        _ = await _repoScDeliveryOtherAidDetails.UpdateAsync(scCampainsDetail);
                    }
                    else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                    {
                        item.ScDeliveryOtherAidsId = input.Id;

                        _ = await _repoScDeliveryOtherAidDetails.InsertAsync(ObjectMapper.Map<ScDeliveryOtherAidDetails>(item));
                    }
                    else if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                    {
                        await _repoScDeliveryOtherAidDetails.DeleteAsync((long)item.Id);
                    }
                }
            }

            return new ScDeliveryOtherAidsDto { };
        }

        public async override Task<ScDeliveryOtherAidsDto> Get(EntityDto<long> input)
        {
            var current = await Repository.GetAllIncluding(x => x.ScCommittee, x => x.FndStatusLkp)
                              .Where(z => z.Id == input.Id).FirstOrDefaultAsync();

            var mapped = ObjectMapper.Map<ScDeliveryOtherAidsDto>(current);

            mapped.MaturityDate = current.MaturityDate.HasValue ? current.MaturityDate.Value.ToString(Formatters.DateFormat) : string.Empty;
            mapped.OperationDate = current.OperationDate.ToString(Formatters.DateFormat);

            return mapped;
        }

        public async Task<List<ScDeliveryOtherAidDetailsDto>> GetScDeliveryOtherAidDetailsDetail(long scDeliveryOtherAidsId)
        {
            var details = await _repoScDeliveryOtherAidDetails.GetAll()
                                      .Where(z => z.ScDeliveryOtherAidsId == scDeliveryOtherAidsId)
                                      .Include(x => x.ScPortalRequestMgrDecision.FndOtherAidLkp)
                                      .Include(x => x.ScPortalRequestMgrDecision.ScPortalRequestStudy.ScPortalRequest)
                                      .Include(x => x.ScCommitteeDetail.FndOtherAidLkp)
                                      .Include(x => x.ScCommitteeDetail.RequestStudy).ThenInclude(x => x.ScPortalRequest)
                                      .ToListAsync();

            var output = new List<ScDeliveryOtherAidDetailsDto>();

            foreach (var item in details)
            {
                var dtoOutput = new ScDeliveryOtherAidDetailsDto
                {
                    Id = item.Id,
                    AidAmountAr = item?.ScCommitteeDetail?.FndOtherAidLkp?.NameAr ?? (item?.ScPortalRequestMgrDecision?.FndOtherAidLkp?.NameAr ?? string.Empty),
                    AidAmountEn = item?.ScCommitteeDetail?.FndOtherAidLkp?.NameEn ?? (item?.ScPortalRequestMgrDecision?.FndOtherAidLkp?.NameEn ?? string.Empty),
                    CashingTo = item?.ScCommitteeDetail?.CashingTo ?? (item?.ScPortalRequestMgrDecision?.CashingTo ?? string.Empty),
                    IdNumber = item?.ScCommitteeDetail?.RequestStudy?.ScPortalRequest?.IdNumber ?? (item?.ScPortalRequestMgrDecision?.ScPortalRequestStudy?.ScPortalRequest?.IdNumber ?? string.Empty),
                    Name = item?.ScCommitteeDetail?.RequestStudy?.ScPortalRequest?.Name ?? (item?.ScPortalRequestMgrDecision?.ScPortalRequestStudy?.ScPortalRequest?.Name ?? string.Empty),
                    rowStatus = DetailRowStatus.RowStatus.NoAction.ToString()
                };

                output.Add(dtoOutput);
            }

            return output;
        }

        public async Task<PostOutput> PostScDeliveryOtherAids(PostDto postDto)
        {
            postDto.UserId = (long)AbpSession.UserId;

            var result = await _scCommitteesCheckPostRepository.Execute(postDto, "ScDeliveryOtherAidsost");

            return result.FirstOrDefault();
        }

        public async Task<List<ScDeliveryOtherAidDetailsDto>> GetScDeliveryOtherAidDetailsData(long? committeeId, string maturityDate)
        {
            if (string.IsNullOrEmpty(maturityDate)) throw new UserFriendlyException("تاريخ الاستحقاق مطلوب !!");

            var dtMaturity = DateTimeController.ConvertToDateTime(maturityDate);

            long postedStatusId = Convert.ToInt64(FndEnum.FndLkps.Posted_ScCommitteeDetailsStatus);
            long postedMgrDecisionStatusId = Convert.ToInt64(FndEnum.FndLkps.Posted_ScPortalRequestMgrDecision);
            long postedCommitteStatusId = Convert.ToInt64(FndEnum.FndLkps.Posted_ScCommittee);

            var committeeDetails = await _repoScCommitteeDetail.GetAllIncluding(z => z.Committee, x => x.FndOtherAidLkp)
                                          .Where(z => committeeId == null ? (z.Committee.CommitteeDate.Month < dtMaturity.Value.Month && z.Committee.CommitteeDate.Year == dtMaturity.Value.Year) : (z.CommitteeId == committeeId && z.Committee.CommitteeDate.Month < dtMaturity.Value.Month && z.Committee.CommitteeDate.Year == dtMaturity.Value.Year))
                                          .Where(z => z.OtherAidLkpId != null)
                                          .Where(z => z.Committee.StatusLkpId == postedCommitteStatusId)
                                          .Where(z => z.StatusLkpId == postedStatusId)
                                          .ToListAsync();

            var mangerDecisions = await _repoScPortalRequestMgrDecision.GetAllIncluding(x => x.FndOtherAidLkp)
                                                                       .Where(x => committeeId == null && x.PortalRequestStudyId != null && x.DecisionDate.HasValue && x.DecisionDate.Value.Month < dtMaturity.Value.Month && x.DecisionDate.Value.Year == dtMaturity.Value.Year && x.OtherAidLkpId != null && x.StatusLkpId == postedMgrDecisionStatusId)
                                                                       .ToListAsync();

            var requestStudyIds = committeeDetails.Select(z => z.RequestStudyId).ToList();
            var mngrsDecisionIds = mangerDecisions.Select(z => (long)z.PortalRequestStudyId).Distinct().ToList();

            requestStudyIds.AddRange(mngrsDecisionIds);

            var reqStudyIds = requestStudyIds.Distinct();

            var portalRequestsStudy = await _repoScPortalRequestStudy.GetAllIncluding(z => z.ScPortalRequest)
                                        .Where(z => reqStudyIds.Contains(z.Id)).ToListAsync();

            return await FillCommitteeRequestData(portalRequestsStudy, committeeDetails, mangerDecisions, dtMaturity);
        }

        private async Task<List<ScDeliveryOtherAidDetailsDto>> FillCommitteeRequestData(List<ScPortalRequestStudy> portalRequestStudies,
            List<ScCommitteeDetail> committeeDetails, List<ScPortalRequestMgrDecision> scPortalRequestMgrs, DateTime? dtMaturity)

        {
            var committeeRequestData = new List<ScDeliveryOtherAidDetailsDto>();

            foreach (var item in portalRequestStudies)
            {
                var currentCommitteDetail = committeeDetails.Where(z => z.RequestStudyId == item.Id).FirstOrDefault();
                var currentPortalRequestMgrs = scPortalRequestMgrs.Where(z => z.PortalRequestStudyId == item.Id).FirstOrDefault();

                if (currentCommitteDetail != null && await ValidateCommitteeRequestValidOneOperationInThSameMonth(currentCommitteDetail.Id, dtMaturity)) continue;
                if (currentCommitteDetail != null && !await ValidateCommitteeRequestValidDataCount(currentCommitteDetail.Id, currentCommitteDetail.OtherMonthNo)) continue;

                if (currentPortalRequestMgrs != null && await ValidatePortalRequestMgrDecisionValidOneOperationInThSameMonth(currentPortalRequestMgrs.Id, dtMaturity)) continue;
                if (currentPortalRequestMgrs != null && !await ValidatePortalRequestMgrDecisionValidDataCount(currentPortalRequestMgrs.Id, currentPortalRequestMgrs.OtherMonthNo)) continue;

                var dtoOutput = new ScDeliveryOtherAidDetailsDto
                {
                    AidAmountAr = currentCommitteDetail?.FndOtherAidLkp.NameAr ?? currentPortalRequestMgrs.FndOtherAidLkp.NameAr,
                    AidAmountEn = currentCommitteDetail?.FndOtherAidLkp.NameEn ?? currentPortalRequestMgrs.FndOtherAidLkp.NameEn,
                    CashingTo = currentCommitteDetail?.CashingTo ?? currentPortalRequestMgrs.CashingTo,
                    CommitteeDetailsId = currentCommitteDetail?.Id ?? null,
                    ScPortalRequestMgrDecisionId = currentPortalRequestMgrs?.Id ?? null,
                    IdNumber = item.ScPortalRequest.IdNumber,
                    Name = item.ScPortalRequest.Name
                };

                committeeRequestData.Add(dtoOutput);
            }

            return committeeRequestData;
        }

        private async Task<bool> ValidatePortalRequestMgrDecisionValidOneOperationInThSameMonth(long requestMgrDecisionId, DateTime? dtMaturity)
        {
            var count = await _repoScDeliveryOtherAidDetails.GetAllIncluding(z => z.ScDeliveryOtherAids)
                              .CountAsync(z => z.ScPortalRequestMgrDecisionId == requestMgrDecisionId &&
                                             z.ScDeliveryOtherAids.MaturityDate.Value.Month == dtMaturity.Value.Month);
            bool notValid = count > 0;

            return notValid;
        }

        private async Task<bool> ValidatePortalRequestMgrDecisionValidDataCount(long requestMgrDecisionId, int? noOfMonths)
        {
            var count = await _repoScDeliveryOtherAidDetails.CountAsync(z => z.ScPortalRequestMgrDecisionId == requestMgrDecisionId);

            bool valid = noOfMonths - (count + 1) > 0;

            return valid;
        }

        private async Task<bool> ValidateCommitteeRequestValidOneOperationInThSameMonth(long committeeDetailId, DateTime? dtMaturity)
        {
            var count = await _repoScDeliveryOtherAidDetails.GetAllIncluding(z => z.ScDeliveryOtherAids)
                              .CountAsync(z => z.CommitteeDetailsId == committeeDetailId &&
                                             z.ScDeliveryOtherAids.MaturityDate.Value.Month == dtMaturity.Value.Month);
            bool notValid = count > 0;

            return notValid;
        }

        private async Task<bool> ValidateCommitteeRequestValidDataCount(long committeeDetailId, int? noOfMonths)
        {
            var count = await _repoScDeliveryOtherAidDetails.CountAsync(z => z.CommitteeDetailsId == committeeDetailId);

            bool valid = noOfMonths - (count + 1) > 0;

            return valid;
        }

        private async Task<string> GetCommitteeCheckNumber(string lang = "ar-EG", int year = 0)
        {
            var counterInput = new GetCounterInputDto { CounterName = "ScDeliveryOtherAids", TenantId = (int)AbpSession.TenantId, Lang = lang, year = year };

            var result = await _repoProcCounter.Execute(counterInput, "GetCounter");

            return result?.FirstOrDefault()?.OutputStr ?? "0";
        }
    }
}
