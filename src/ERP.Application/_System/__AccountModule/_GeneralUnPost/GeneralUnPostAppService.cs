using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System.__AccountModule._ArJobCardHd;
using ERP._System.__AccountModule._GeneralUnPost.Dto;
using ERP._System.__AccountModule._GeneralUnPost.Input;
using ERP._System.__AccountModule._GeneralUnPost.Output;
using ERP._System.__AidModule._ScCommittee;
using ERP._System.__AidModule._ScPortalRequestMgrDecision;
using ERP._System.__PmPropertiesModule._PmContract;
using ERP._System._ApMiscPaymentHeaders;
using ERP._System._ArMiscReceiptHeaders;
using ERP._System._Counters.ProcDto;
using ERP._System._Counters.Procs;
using ERP._System._GlJeHeaders;
using ERP._System.PostRecords.Dto;
using ERP.Authorization;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__AccountModule._GeneralUnPost
{
    [AbpAuthorize]
    public class GeneralUnPostAppService : AsyncCrudAppService<GeneralUnPost, GeneralUnPostDto, long, PagedGeneralUnPostResultRequestDto, CreateGeneralUnPostDto, GeneralUnPostEditDto>, IGeneralUnPostAppService
    {
        private readonly IGetCounterRepository _repoProcCounter;
        private readonly IRepository<ApMiscPaymentHeaders, long> _repoApMiscPaymentHeaders;
        private readonly IRepository<ArMiscReceiptHeaders, long> _repoArMiscReceiptHeaders;
        private readonly IRepository<PmContract, long> _repoPmContract;
        private readonly IRepository<ScCommittee, long> _repoScCommittee;
        private readonly IRepository<ScPortalRequestMgrDecision, long> _repoScPortalRequestMgrDecision;
        private readonly IGetGeneralPostNotesRepository _getGeneralPostNotesRepository;
        private readonly IGetGeneralPostUnPostRepository _getGeneralPostUnPostRepository;
        private readonly IRepository<GlJeHeaders, long> _repoGlJeHeaders;
        private readonly IRepository<ArJobCardHd, long> _repoArJobCardHd;

        public GeneralUnPostAppService(IRepository<GeneralUnPost, long> repository,
            IRepository<ApMiscPaymentHeaders, long> repoApMiscPaymentHeaders,
            IRepository<ArMiscReceiptHeaders, long> repoArMiscReceiptHeaders,
            IRepository<PmContract, long> repoPmContract,
            IRepository<ScCommittee, long> repoScCommittee,
            IRepository<ScPortalRequestMgrDecision, long> repoScPortalRequestMgrDecision,
            IRepository<GlJeHeaders, long> repoGlJeHeaders,
            IGetGeneralPostNotesRepository getGeneralPostNotesRepository,
            IGetGeneralPostUnPostRepository getGeneralPostUnPostRepository,
            IRepository<ArJobCardHd, long> repoArJobCardHd,
            IGetCounterRepository getCounterRepository) : base(repository)
        {
            _repoScPortalRequestMgrDecision = repoScPortalRequestMgrDecision;
            _repoScCommittee = repoScCommittee;
            _repoPmContract = repoPmContract;
            _repoArMiscReceiptHeaders = repoArMiscReceiptHeaders;
            _repoGlJeHeaders = repoGlJeHeaders;
            _getGeneralPostNotesRepository = getGeneralPostNotesRepository;
            _repoApMiscPaymentHeaders = repoApMiscPaymentHeaders;
            _repoProcCounter = getCounterRepository;
            _getGeneralPostUnPostRepository = getGeneralPostUnPostRepository;
            _repoArJobCardHd = repoArJobCardHd;

            CreatePermissionName = PermissionNames.Pages_GeneralUnPost_Insert;
            UpdatePermissionName = PermissionNames.Pages_GeneralUnPost_Update;
            DeletePermissionName = PermissionNames.Pages_GeneralUnPost_Delete;
            GetAllPermissionName = PermissionNames.Pages_GeneralUnPost;
        }

        public async Task<PostOutput> CreateFromPost(GeneralPostUnPostInput input)
        {
            var counterInput = new GetCounterInputDto { CounterName = "GeneralUnPost", TenantId = (int)AbpSession.TenantId, Lang = input.Lang, year = 0 };

            var result = await _repoProcCounter.Execute(counterInput, "GetCounter");

            input.UserId = (long)AbpSession.UserId;
            input.TenantId = (int)AbpSession.TenantId;
            input.UnPostNo = result?.FirstOrDefault()?.OutputStr ?? "1";

            var post = await _getGeneralPostUnPostRepository.Execute(input, "GeneralPostUnPost");

            return post.FirstOrDefault();
        }

        public async Task<GeneralUnPostDto> GetDetailAsync(EntityDto<long> input)
        {
            var current = await Repository.GetAllIncluding(z => z.FndLookupGeneralUnPostSourceLkp, x => x.ApMiscPaymentHeaders)
                .Where(z => z.Id == input.Id).FirstOrDefaultAsync();

            var mapped = ObjectMapper.Map<GeneralUnPostDto>(current);

            return mapped;
        }

        public async override Task<PagedResultDto<GeneralUnPostDto>> GetAll(PagedGeneralUnPostResultRequestDto input)
        {
            CheckGetAllPermission();

            var queryable = Repository.GetAllIncluding(x => x.FndLookupGeneralUnPostSourceLkp);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.UnPostNo))
            {
                queryable = queryable.Where(q => q.UnPostNo == input.Params.UnPostNo);
            }

            if (input.Params != null && input.Params.UnPostDate != null)
            {
                queryable = queryable.Where(q => q.UnPostDate == DateTimeController.ConvertToDateTime(input.Params.UnPostDate));
            }

            if (input.Params != null && input.Params.SourceLkpId != null && input.Params.SourceLkpId != 0)
            {
                queryable = queryable.Where(q => q.SourceLkpId == input.Params.SourceLkpId);
            }

            var count = await queryable.CountAsync();

            var listOrder = new List<SortModel> { new SortModel { Sort = input.OrderByValue.Sort, ColId = input.OrderByValue.ColId } };

            queryable = queryable.DynamicOrderBy(listOrder);
            queryable = queryable.Skip(input.SkipCount);

            var data = await queryable.Take(input.MaxResultCount).ToListAsync();

            var data2 = ObjectMapper.Map(data, new List<GeneralUnPostDto>());

            var PagedResultDto = new PagedResultDto<GeneralUnPostDto>()
            {
                Items = data2 as IReadOnlyList<GeneralUnPostDto>,
                TotalCount = count
            };

            return PagedResultDto;
        }

        public async Task<Select2PagedResult> GetGeneralUnPostSelect2(string searchTerm, int pageSize, int pageNumber, string lang, string TableCode)
        {
            if (TableCode == "936")
            {
                var data = _repoApMiscPaymentHeaders.GetAll().Where(z => z.PostedlkpId == 61 && z.TenantId == AbpSession.TenantId.Value &&
                   (string.IsNullOrEmpty(searchTerm) || z.PaymentNumber.Contains(searchTerm)));

                var result = await data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = z.PaymentNumber }).ToListAsync();

                var select2pagedResult = new Select2PagedResult
                {
                    Total = await data.CountAsync(),
                    Results = result
                };

                return select2pagedResult;
            }
            else if (TableCode == "937")
            {
                var data = _repoArMiscReceiptHeaders.GetAll().Where(z => z.PostedLkpId == 53 && z.TenantId == AbpSession.TenantId.Value &&
                  (string.IsNullOrEmpty(searchTerm) || z.ReceiptNumber.Contains(searchTerm)));

                var result = await data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = z.ReceiptNumber }).ToListAsync();

                var select2pagedResult = new Select2PagedResult
                {
                    Total = await data.CountAsync(),
                    Results = result
                };

                return select2pagedResult;
            }
            else if (TableCode == "31623")
            {
                var data = _repoArJobCardHd.GetAll().Where(z => z.StatusLkpId == 11539 && z.TenantId == AbpSession.TenantId.Value &&
                  (string.IsNullOrEmpty(searchTerm) || z.JobNumber.Contains(searchTerm)));

                var result = await data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = z.JobNumber }).ToListAsync();

                var select2pagedResult = new Select2PagedResult
                {
                    Total = await data.CountAsync(),
                    Results = result
                };

                return select2pagedResult;
            }

            
            else if (TableCode == "944")
            {
                var data = _repoPmContract.GetAll().Where(z => z.StatusLkpId == 230 && z.TenantId == AbpSession.TenantId.Value &&
                   (string.IsNullOrEmpty(searchTerm) || z.ContractNumber.Contains(searchTerm)));

                var result = await data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = z.ContractNumber }).ToListAsync();

                var select2pagedResult = new Select2PagedResult
                {
                    Total = await data.CountAsync(),
                    Results = result
                };

                return select2pagedResult;
            }
            else if (TableCode == "945")
            {
                var data = _repoScCommittee.GetAll().Where(z => z.StatusLkpId == 157 && z.TenantId == AbpSession.TenantId.Value &&
                    (string.IsNullOrEmpty(searchTerm) || z.CommitteeNumber.Contains(searchTerm)));

                var result = await data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = z.CommitteeNumber }).ToListAsync();

                var select2pagedResult = new Select2PagedResult
                {
                    Total = await data.CountAsync(),
                    Results = result
                };

                return select2pagedResult;
            }
            else if (TableCode == "946")
            {
                var data = _repoScPortalRequestMgrDecision.GetAll().Where(z => z.StatusLkpId == 173 && z.TenantId == AbpSession.TenantId.Value &&
                            (string.IsNullOrEmpty(searchTerm) || z.DecisionNumer.Contains(searchTerm)));

                var result = await data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = z.DecisionNumer }).ToListAsync();

                var select2pagedResult = new Select2PagedResult
                {
                    Total = await data.CountAsync(),
                    Results = result
                };

                return select2pagedResult;
            }
            else if (TableCode == "11475")
            {
                var data = _repoGlJeHeaders.GetAll()
                                            .Where(z => z.StatusLkpId == 11 && z.TenantId == AbpSession.TenantId.Value 
                                                    && z.JeSourceLkpId == 13
                                                    && string.IsNullOrEmpty(searchTerm) || z.JeNumber.Contains(searchTerm));

                var result = await data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = z.JeNumber }).ToListAsync();

                var select2pagedResult = new Select2PagedResult
                {
                    Total = await data.CountAsync(),
                    Results = result
                };

                return select2pagedResult;
            }            
            else
            {
                return new Select2PagedResult { Results = new List<Select2OptionModel>(), Total = 0 };
            }
        }

        public async Task<GetGeneralPostNotesOutput> GetGeneralPostNotes(long SourceLkpId, long SourceId)
        {
            GetGeneralPostNotesInput getGeneralPostNotesInput = new GetGeneralPostNotesInput();
            getGeneralPostNotesInput.SourceId = SourceId;
            getGeneralPostNotesInput.SourceLkpId = SourceLkpId;

            var result = await _getGeneralPostNotesRepository.Execute(getGeneralPostNotesInput, "GetGeneralPostNotes");

            return result.FirstOrDefault();
        }

        public override Task<GeneralUnPostDto> Create(CreateGeneralUnPostDto input) => throw new System.Exception("Not Available");

        public override Task<GeneralUnPostDto> Update(GeneralUnPostEditDto input) => throw new System.Exception("Not Available");

        public override Task Delete(EntityDto<long> input) => throw new System.Exception("Not Available");
    }
}
