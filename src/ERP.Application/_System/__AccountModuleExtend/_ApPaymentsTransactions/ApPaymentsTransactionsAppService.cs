using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using ERP._System.__AccountModuleExtend._ApPaymentsTransactions.Dto;
using ERP._System.__CharityBoxes._TmCharityBoxReceive;
using ERP._System._Counters.ProcDto;
using ERP._System._Counters.Procs;
using ERP._System._FndLookupValues.Dto;
using ERP._System.PostRecords.Dto;
using ERP.Authorization;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__AccountModuleExtend._ApPaymentsTransactions
{
    [AbpAuthorize]
    public class ApPaymentsTransactionsAppService : AsyncCrudAppService<ApPaymentsTransactions, ApPaymentsTransactionsDto, long, PagedApPaymentsTransactionsResultRequestDto, ApPaymentsTransactionsCreateDto, ApPaymentsTransactionsEditDto>,
        IApPaymentsTransactionsAppService
    {
        private readonly IGetCounterRepository _repoProcCounter;
        private readonly ITmCharityBoxReceiveRepository _repoPost;

        public ApPaymentsTransactionsAppService(IGetCounterRepository getCounterRepository,
            ITmCharityBoxReceiveRepository tmCharityBoxReceiveRepository,
            IRepository<ApPaymentsTransactions, long> repository) : base(repository)
        {
            _repoProcCounter = getCounterRepository;
            _repoPost = tmCharityBoxReceiveRepository;

            CreatePermissionName = PermissionNames.Pages_ApPaymentsTransactions_Insert;
            UpdatePermissionName = PermissionNames.Pages_ApPaymentsTransactions_Update;
            DeletePermissionName = PermissionNames.Pages_ApPaymentsTransactions_Delete;
            GetAllPermissionName = PermissionNames.Pages_ApPaymentsTransactions;
        }

        protected override IQueryable<ApPaymentsTransactions> CreateFilteredQuery(PagedApPaymentsTransactionsResultRequestDto input)
        {
            var iqueryable = Repository.GetAllIncluding(x => x.FndStatusLkp, x => x.ApVendors);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.PaymentNumber))
                iqueryable = iqueryable.Where(z => z.PaymentNumber.Contains(input.Params.PaymentNumber));

            if (input.Params != null && input.Params.StatusLkpId != null)
                iqueryable = iqueryable.Where(z => z.StatusLkpId == input.Params.StatusLkpId);

            if (input.Params != null && input.Params.VendorId != null)
                iqueryable = iqueryable.Where(z => z.VendorId == input.Params.VendorId);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.PaymentDate))
            {
                DateTime dt = (DateTime)DateTimeController.ConvertToDateTime(input.Params.PaymentDate);
                iqueryable = iqueryable.Where(z => z.PaymentDate == dt);
            }

            return iqueryable;
        }

        public async override Task<ApPaymentsTransactionsDto> Create(ApPaymentsTransactionsCreateDto input)
        {
            CheckCreatePermission();

            Validator(input.PaymentTypeLkpId, input.CheckNumber, input.BankAccountId);

            var counterInput = new GetCounterInputDto { CounterName = "ApPaymentsTransactions", TenantId = (int)AbpSession.TenantId, Lang = "ar-EG", year = 0 };

            var result = await _repoProcCounter.Execute(counterInput, "GetCounter");

            input.PaymentNumber = result?.FirstOrDefault()?.OutputStr ?? "0";

            return await base.Create(input);
        }

        public async override Task<ApPaymentsTransactionsDto> Update(ApPaymentsTransactionsEditDto input)
        {
            CheckUpdatePermission();

            Validator(input.PaymentTypeLkpId, input.CheckNumber, input.BankAccountId);

            return await base.Update(input);
        }

        public async Task<ApPaymentsTransactionsDto> GetDetailAsync(EntityDto<long> input)
        {
            var current = await Repository.GetAllIncluding(x => x.FndStatusLkp, x => x.ApBankAccounts, x => x.FndPaymentTypeLkp, x => x.ApVendors)
                                       .Where(z => z.Id == input.Id)
                                       .FirstOrDefaultAsync();
            return ObjectMapper.Map<ApPaymentsTransactionsDto>(current);
        }

        public async Task<PostOutput> PostApPaymentsTransactions(PostDto postDto)
        {
            postDto.UserId = (long)AbpSession.UserId;

            var result = await _repoPost.Execute(postDto, "ApPaymentsTransactionsPost");

            return result.FirstOrDefault();
        }

        private void Validator(long PaymentTypeLkpId, string CheckNumber, long? BankAccountId)
        {
            if (PaymentTypeLkpId == /* CheQ */ 715)
            {
                if (string.IsNullOrEmpty(CheckNumber))
                    throw new UserFriendlyException("رقم الشيك مطلوب!");

                if (BankAccountId == null || BankAccountId == 0)
                    throw new UserFriendlyException("البنك مطلوب");
            }
        }
    }
}
