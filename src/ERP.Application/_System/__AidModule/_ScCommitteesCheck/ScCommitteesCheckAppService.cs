using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using ERP._System.__AidModule._ScCommittee;
using ERP._System.__AidModule._ScCommittee.Dto;
using ERP._System.__AidModule._ScCommitteesCheck.Dto;
using ERP._System.__AidModule._ScCommitteesCheck.Proc;
using ERP._System.__AidModule._ScCommitteesCheckDetails;
using ERP._System.__AidModule._ScPortalRequest;
using ERP._System.__AidModule._ScPortalRequestMgrDecision;
using ERP._System.__AidModule._ScPortalRequestStudy;
using ERP._System._Counters.ProcDto;
using ERP._System._Counters.Procs;
using ERP._System._FndLookupValues;
using ERP._System._FndLookupValues.Dto;
using ERP._System.PostRecords.Dto;
using ERP.Authorization;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__AidModule._ScCommitteesCheck
{
    [AbpAuthorize]
    public class ScCommitteesCheckAppService : AsyncCrudAppService<ScCommitteesCheck, ScCommitteesCheckDto, long, PagedScCommitteesCheckResultRequestDto, CreateScCommitteesCheckDto, ScCommitteesCheckEditDto>,
        IScCommitteesCheckAppService
    {
        private readonly IRepository<ScCommitteesCheckDetails, long> _repoScCommitteesCheckDetails;
        private readonly IRepository<ScPortalRequestMgrDecision, long> _repoScPortalRequestMgrDecision;
        private readonly IRepository<ScCommitteeDetail, long> _repoScCommitteeDetail;
        private readonly IRepository<ScPortalRequestStudy, long> _repoScPortalRequestStudy;
        private readonly IGetCounterRepository _repoProcCounter;
        private readonly IScCommitteesCheckPostRepository _scCommitteesCheckPostRepository;

        public ScCommitteesCheckAppService(IRepository<ScCommitteesCheckDetails, long> repoScCommitteesCheckDetails,
            IRepository<ScCommitteeDetail, long> repoScCommitteeDetail,
            IRepository<ScCommitteesCheck, long> repository,
            IRepository<ScPortalRequestStudy, long> repoScPortalRequestStudy,
            IRepository<ScPortalRequestMgrDecision, long> repoScPortalRequestMgrDecision,
            IGetCounterRepository getCounterRepository,
             IScCommitteesCheckPostRepository scCommitteesCheckPostRepository) : base(repository)
        {
            _repoScCommitteesCheckDetails = repoScCommitteesCheckDetails;
            _repoScCommitteeDetail = repoScCommitteeDetail;
            _repoScPortalRequestStudy = repoScPortalRequestStudy;
            _repoProcCounter = getCounterRepository;
            _repoScPortalRequestMgrDecision = repoScPortalRequestMgrDecision;
            _scCommitteesCheckPostRepository = scCommitteesCheckPostRepository;

            CreatePermissionName = PermissionNames.Pages_ScCommitteesCheck_Insert;
            UpdatePermissionName = PermissionNames.Pages_ScCommitteesCheck_Update;
            DeletePermissionName = PermissionNames.Pages_ScCommitteesCheck_Delete;
            GetAllPermissionName = PermissionNames.Pages_ScCommitteesCheck;
        }

        public async override Task<PagedResultDto<ScCommitteesCheckDto>> GetAll(PagedScCommitteesCheckResultRequestDto input)
        {
            CheckGetAllPermission();

            var queryable = Repository.GetAllIncluding(x => x.FndLookupValues, x => x.ScCommittee, x => x.ApBankAccounts, x => x.ScCommitteesCheckDetails);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.OperationNumber))
                queryable = queryable.Where(q => q.OperationNumber.Contains(input.Params.OperationNumber));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.OperationDate))
                queryable = queryable.Where(q => q.OperationDate == DateTimeController.ConvertToDateTime(input.Params.OperationDate));

            if (input.Params != null && input.Params.StatusLkpId != null)
                queryable = queryable.Where(q => q.StatusLkpId == input.Params.StatusLkpId);

            if (input.Params != null && input.Params.CommitteeId != null)
                queryable = queryable.Where(q => q.CommitteeId == input.Params.CommitteeId);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.Notes))
                queryable = queryable.Where(q => q.Notes.Contains(input.Params.Notes));

            var count = await queryable.CountAsync();
            var listOrder = new List<SortModel> { new SortModel { Sort = input.OrderByValue.Sort, ColId = input.OrderByValue.ColId } };
            queryable = queryable.DynamicOrderBy(listOrder);
            queryable = queryable.Skip(input.SkipCount);
            var data = await queryable.Take(input.MaxResultCount).ToListAsync();

            var data2 = ObjectMapper.Map(data, new List<ScCommitteesCheckDto>());

            var PagedResultDto = new PagedResultDto<ScCommitteesCheckDto>()
            {
                Items = data2 as IReadOnlyList<ScCommitteesCheckDto>,
                TotalCount = count
            };

            return PagedResultDto;
        }

        public async override Task<ScCommitteesCheckDto> Create(CreateScCommitteesCheckDto input)
        {
            CheckCreatePermission();

            input.OperationNumber = await GetCommitteeCheckNumber();

            var currentScCampains = await base.Create(input);

            if (input.ScCommitteesCheckDetailsList.Count > 0)
            {
                foreach (var item in input.ScCommitteesCheckDetailsList)
                {
                    item.CommitteesCheckId = currentScCampains.Id;

                    _ = await _repoScCommitteesCheckDetails.InsertAsync(ObjectMapper.Map<ScCommitteesCheckDetails>(item));
                }
            }

            return new ScCommitteesCheckDto { };
        }

        public async override Task<ScCommitteesCheckDto> Update(ScCommitteesCheckEditDto input)
        {
            CheckUpdatePermission();

            _ = await base.Update(input);

            if (input.ScCommitteesCheckDetailsList.Count > 0)
            {
                foreach (var item in input.ScCommitteesCheckDetailsList)
                {
                    if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                    {
                        item.CommitteesCheckId = input.Id;
                        var scCampainsDetail = await _repoScCommitteesCheckDetails.GetAsync((long)item.Id);

                        ObjectMapper.Map(item, scCampainsDetail);

                        _ = await _repoScCommitteesCheckDetails.UpdateAsync(scCampainsDetail);
                    }
                    else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                    {
                        item.CommitteesCheckId = input.Id;

                        _ = await _repoScCommitteesCheckDetails.InsertAsync(ObjectMapper.Map<ScCommitteesCheckDetails>(item));
                    }
                    else if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                    {
                        await _repoScCommitteesCheckDetails.DeleteAsync((long)item.Id);
                    }
                }
            }

            return new ScCommitteesCheckDto { };
        }

        public async Task<ScCommitteesCheckDto> GetDetailAsync(EntityDto<long> input)
        {
            var current = await Repository.GetAllIncluding(x => x.ScCommittee, x => x.ApBankAccounts,
                                                       x => x.FndLookupValues)
                           .Where(z => z.Id == input.Id).FirstOrDefaultAsync();

            return ObjectMapper.Map<ScCommitteesCheckDto>(current);
        }

        public async override Task Delete(EntityDto<long> input)
        {
            CheckDeletePermission();

            var ids = await _repoScCommitteesCheckDetails.GetAll().Where(z => z.CommitteesCheckId == input.Id).Select(z => z.Id).ToListAsync();

            foreach (var id in ids) await _repoScCommitteesCheckDetails.DeleteAsync(id);

            await Repository.DeleteAsync(input.Id);
        }

        public async Task<List<CommitteeRequestDataDto>> GetCommitteeCheckDetail(long committeeCheckId)
        {
            var details = await _repoScCommitteesCheckDetails.GetAll()
                                      .Where(z => z.CommitteesCheckId == committeeCheckId)
                                      .Include(x => x.ScPortalRequestMgrDecision)
                                      .Include(x => x.ScPortalRequestMgrDecision.ScPortalRequestStudy.ScPortalRequest)
                                      .Include(x => x.ScCommitteeDetail)
                                      .ThenInclude(x => x.RequestStudy)
                                      .ThenInclude(x => x.ScPortalRequest)
                                      .ToListAsync();

            var output = new List<CommitteeRequestDataDto>();

            foreach (var item in details)
            {
                var dtoOutput = new CommitteeRequestDataDto
                {
                    Id = item.Id,
                    AidAmount = item?.ScCommitteeDetail?.AidAmount ?? (item?.ScPortalRequestMgrDecision?.Amount ?? 0),
                    CashingTo = item?.ScCommitteeDetail?.CashingTo ?? (item?.ScPortalRequestMgrDecision?.CashingTo ?? string.Empty),
                    IdNumber = item?.ScCommitteeDetail?.RequestStudy?.ScPortalRequest?.IdNumber ?? (item?.ScPortalRequestMgrDecision?.ScPortalRequestStudy?.ScPortalRequest?.IdNumber ?? string.Empty),
                    Name = item?.ScCommitteeDetail?.RequestStudy?.ScPortalRequest?.Name ?? (item?.ScPortalRequestMgrDecision?.ScPortalRequestStudy?.ScPortalRequest?.Name ?? string.Empty),
                    CheckNumber = item.CheckNumber,
                    CommitteeDetailsId = item.CommitteeDetailsId,
                    ScPortalRequestMgrDecisionId = item.ScPortalRequestMgrDecisionId,
                    rowStatus = DetailRowStatus.RowStatus.NoAction.ToString()
                };

                output.Add(dtoOutput);
            }

            return output;
        }

        public async Task<PostOutput> PostScCommitteesCheck(PostDto postDto)
        {
            postDto.UserId = (long)AbpSession.UserId;

            var result = await _scCommitteesCheckPostRepository.Execute(postDto, "ScCommitteesCheckPost");

            return result.FirstOrDefault();
        }

        public async Task<List<CommitteeRequestDataDto>> GetCommitteeRequestData(long? committeeId, string maturityDate)
        {
            if (string.IsNullOrEmpty(maturityDate)) throw new UserFriendlyException("تاريخ الاستحقاق مطلوب !!");

            var dtMaturity = DateTimeController.ConvertToDateTime(maturityDate);

            long postedStatusId = Convert.ToInt64(FndEnum.FndLkps.Posted_ScCommitteeDetailsStatus);
            long postedMgrDecisionStatusId = Convert.ToInt64(FndEnum.FndLkps.Posted_ScPortalRequestMgrDecision);
            long postedCommitteStatusId = Convert.ToInt64(FndEnum.FndLkps.Posted_ScCommittee);

            var committeeDetails = await _repoScCommitteeDetail.GetAllIncluding(z => z.Committee)
                                          .Where(z => committeeId == null ? (z.Committee.CommitteeDate.Month < dtMaturity.Value.Month && z.Committee.CommitteeDate.Year == dtMaturity.Value.Year) : (z.CommitteeId == committeeId && z.Committee.CommitteeDate.Month < dtMaturity.Value.Month && z.Committee.CommitteeDate.Year == dtMaturity.Value.Year))
                                          .Where(z => z.AidAmount > 0)
                                          .Where(z => z.Committee.StatusLkpId == postedCommitteStatusId)
                                          .Where(z => z.StatusLkpId == postedStatusId)
                                          .ToListAsync();

            var mangerDecisions = await _repoScPortalRequestMgrDecision.GetAllListAsync(x => committeeId == null && x.PortalRequestStudyId != null && x.DecisionDate.HasValue && x.DecisionDate.Value.Month < dtMaturity.Value.Month && x.DecisionDate.Value.Year == dtMaturity.Value.Year && x.Amount > 0 && x.StatusLkpId == postedMgrDecisionStatusId);

            var requestStudyIds = committeeDetails.Select(z => z.RequestStudyId).ToList();
            var mngrsDecisionIds = mangerDecisions.Select(z => (long)z.PortalRequestStudyId).Distinct().ToList();

            requestStudyIds.AddRange(mngrsDecisionIds);

            var reqStudyIds = requestStudyIds.Distinct();

            var portalRequestsStudy = await _repoScPortalRequestStudy.GetAllIncluding(z => z.ScPortalRequest)
                                        .Where(z => reqStudyIds.Contains(z.Id))
                                        .ToListAsync();

            return await FillCommitteeRequestData(portalRequestsStudy, committeeDetails, mangerDecisions, dtMaturity);
        }

        private async Task<List<CommitteeRequestDataDto>> FillCommitteeRequestData(List<ScPortalRequestStudy> portalRequestStudies,
            List<ScCommitteeDetail> committeeDetails, List<ScPortalRequestMgrDecision> scPortalRequestMgrs, DateTime? dtMaturity)

        {
            var committeeRequestData = new List<CommitteeRequestDataDto>();

            foreach (var item in portalRequestStudies)
            {
                var currentCommitteDetail = committeeDetails.Where(z => z.RequestStudyId == item.Id).FirstOrDefault();
                var currentPortalRequestMgrs = scPortalRequestMgrs.Where(z => z.PortalRequestStudyId == item.Id).FirstOrDefault();

                if (currentCommitteDetail != null && await ValidateCommitteeRequestValidOneOperationInThSameMonth(currentCommitteDetail.Id, dtMaturity)) continue;
                if (currentCommitteDetail != null && !await ValidateCommitteeRequestValidDataCount(currentCommitteDetail.Id, currentCommitteDetail.NoOfMonths)) continue;

                if (currentPortalRequestMgrs != null && await ValidatePortalRequestMgrDecisionValidOneOperationInThSameMonth(currentPortalRequestMgrs.Id, dtMaturity)) continue;
                if (currentPortalRequestMgrs != null && !await ValidatePortalRequestMgrDecisionValidDataCount(currentPortalRequestMgrs.Id, currentPortalRequestMgrs.NumberOfMonths)) continue;

                var dtoOutput = new CommitteeRequestDataDto
                {
                    AidAmount = currentCommitteDetail?.AidAmount ?? currentPortalRequestMgrs.Amount,
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
            var count = await _repoScCommitteesCheckDetails.GetAllIncluding(z => z.ScCommitteesCheck)
                              .CountAsync(z => z.ScPortalRequestMgrDecisionId == requestMgrDecisionId &&
                                             z.ScCommitteesCheck.MaturityDate.Value.Month == dtMaturity.Value.Month);
            bool notValid = count > 0;

            return notValid;
        }

        private async Task<bool> ValidatePortalRequestMgrDecisionValidDataCount(long requestMgrDecisionId, int? noOfMonths)
        {
            var count = await _repoScCommitteesCheckDetails.CountAsync(z => z.ScPortalRequestMgrDecisionId == requestMgrDecisionId);

            bool valid = noOfMonths - (count + 1) > 0;

            return valid;
        }

        private async Task<bool> ValidateCommitteeRequestValidOneOperationInThSameMonth(long committeeDetailId, DateTime? dtMaturity)
        {
            var count = await _repoScCommitteesCheckDetails.GetAllIncluding(z => z.ScCommitteesCheck)
                              .CountAsync(z => z.CommitteeDetailsId == committeeDetailId &&
                                             z.ScCommitteesCheck.MaturityDate.Value.Month == dtMaturity.Value.Month);
            bool notValid = count > 0;

            return notValid;
        }

        private async Task<bool> ValidateCommitteeRequestValidDataCount(long committeeDetailId, int? noOfMonths)
        {
            var count = await _repoScCommitteesCheckDetails.CountAsync(z => z.CommitteeDetailsId == committeeDetailId);

            bool valid = noOfMonths - (count + 1) > 0;

            return valid;
        }

        private async Task<string> GetCommitteeCheckNumber(string lang = "ar-EG", int year = 0)
        {
            var counterInput = new GetCounterInputDto { CounterName = "ScCommitteesCheck", TenantId = (int)AbpSession.TenantId, Lang = lang, year = year };

            var result = await _repoProcCounter.Execute(counterInput, "GetCounter");

            return result?.FirstOrDefault()?.OutputStr ?? "0";
        }
    }
}
