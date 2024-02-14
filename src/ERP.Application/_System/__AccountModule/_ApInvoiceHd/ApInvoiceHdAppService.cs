using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System.__AccountModule._ApInvoiceHd._ApInvoiceTr;
using ERP._System.__AccountModule._ApInvoiceHd.Dto;
using ERP._System.__AccountModule._ApInvoiceHd.ProcDto;
using ERP._System.__AccountModule._ApInvoiceHd.Procs;
using ERP._System.__CharityBoxes._TmCharityBoxReceive;
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

namespace ERP._System.__AccountModule._ApInvoiceHd
{
    [AbpAuthorize]
    public class ApInvoiceHdAppService : EditBaseAsyncCrudAppService<ApInvoiceHd, ApInvoiceHdDto, long, PagedApInvoiceHdResultRequestDto, ApInvoiceHdCreateDto, ApInvoiceHdEditDto>,
        IApInvoiceHdAppService
    {
        private readonly IGlCodeComDetailsManager _glCodeComDetailsManager;
        private readonly ITmCharityBoxReceiveRepository _repoPost;
        private readonly IRepository<ApInvoiceTr, long> _repoApInvoiceTr;
        private readonly IEntityCounterManager _entityCounterManager;
        private readonly IGetApInvoiceHdScreenDataRepository _getApInvoiceHdScreenDataRepository;


        public ApInvoiceHdAppService(IGlCodeComDetailsManager glCodeComDetailsManager,
            ITmCharityBoxReceiveRepository tmCharityBoxReceiveRepository, IGetApInvoiceHdScreenDataRepository getApInvoiceHdScreenDataRepository,
            IRepository<ApInvoiceHd, long> repository, IRepository<ApInvoiceTr, long> repoApInvoiceTr
            , IEntityCounterManager entityCounterManager) : base(repository)
        {
            _glCodeComDetailsManager = glCodeComDetailsManager;
            _getApInvoiceHdScreenDataRepository = getApInvoiceHdScreenDataRepository;
            _repoApInvoiceTr = repoApInvoiceTr;
            _entityCounterManager = entityCounterManager;
            _repoPost = tmCharityBoxReceiveRepository;

            CreatePermissionName = PermissionNames.Pages_ApInvoiceHd_Insert;
            UpdatePermissionName = PermissionNames.Pages_ApInvoiceHd_Update;
            DeletePermissionName = PermissionNames.Pages_ApInvoiceHd_Delete;
            GetAllPermissionName = PermissionNames.Pages_ApInvoiceHd;
        }

        protected override IQueryable<ApInvoiceHd> CreateFilteredQuery(PagedApInvoiceHdResultRequestDto input)
        {
            var iqueryable = Repository.GetAllIncluding(x => x.FndStatusLkp, x => x.ApVendors);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.HdInvNo))
                iqueryable = iqueryable.Where(z => z.HdInvNo.Contains(input.Params.HdInvNo));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.VendorNo))
                iqueryable = iqueryable.Where(z => z.ApVendors.VendorNumber.Contains(input.Params.VendorNo));

            if (input.Params != null && input.Params.StatusLkpId != null)
                iqueryable = iqueryable.Where(z => z.StatusLkpId == input.Params.StatusLkpId);

            if (input.Params != null && input.Params.HdTypeLkpId != null)
                iqueryable = iqueryable.Where(z => z.HdTypeLkpId == input.Params.HdTypeLkpId);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.HdDate))
            {
                DateTime dt = (DateTime)DateTimeController.ConvertToDateTime(input.Params.HdDate);
                iqueryable = iqueryable.Where(z => z.HdDate == dt);
            }

            return iqueryable;
        }

        internal override async Task EntityCreatePreExecute(ApInvoiceHdCreateDto input)
        {
            input.HdInvNo = await _entityCounterManager.GetEntityNumber("ApInvoiceHd", (int)AbpSession.TenantId);

            if (!string.IsNullOrEmpty(input.codeComUtilityIds))
                input.FromAccountId = await _glCodeComDetailsManager.CreateAndRetrieveCodeComOneId(input.codeComUtilityIds);

            if (!string.IsNullOrEmpty(input.codeComUtilityIds_alt1))
                input.ToAccountId = await _glCodeComDetailsManager.CreateAndRetrieveCodeComOneId(input.codeComUtilityIds_alt1);
        }

        internal override async Task EntityCreatePostExecute(ApInvoiceHdCreateDto input, long EntityId)
        {
            if (input.InvoiceDetails?.Count > 0)
                foreach (var item in input.InvoiceDetails)
                {
                    item.AccountId = (long)await _glCodeComDetailsManager.CreateAndRetrieveCodeComOneId(item.codeComUtilityIds);
                    item.ApInvoiceHdId = EntityId;
                    item.TaxAmount = ApInvoiceTr.GetTaxAmount(item.TaxPercentageLkpId, item.Amount);

                    _ = await _repoApInvoiceTr.InsertAsync(ObjectMapper.Map<ApInvoiceTr>(item));
                }
        }

        internal override async Task EntityUpdatePreExecute(ApInvoiceHdEditDto input)
        {
            if (!string.IsNullOrEmpty(input.codeComUtilityIds))
                input.FromAccountId = await _glCodeComDetailsManager.CreateAndRetrieveCodeComOneId(input.codeComUtilityIds);

            if (!string.IsNullOrEmpty(input.codeComUtilityIds_alt1))
                input.ToAccountId = await _glCodeComDetailsManager.CreateAndRetrieveCodeComOneId(input.codeComUtilityIds_alt1);


            if (input.InvoiceDetails != null && input.InvoiceDetails.Count > 0)
            {
                foreach (var item in input.InvoiceDetails)
                {
                    item.ApInvoiceHdId = input.Id;
                    if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                    {
                        var apInvoiceTr = await _repoApInvoiceTr.GetAsync((long)item.Id);

                        item.AccountId = (long)await _glCodeComDetailsManager.CreateAndRetrieveCodeComOneId(item.codeComUtilityIds);
                        item.TaxAmount = ApInvoiceTr.GetTaxAmount(item.TaxPercentageLkpId, item.Amount);

                        ObjectMapper.Map(item, apInvoiceTr);

                        _ = await _repoApInvoiceTr.UpdateAsync(apInvoiceTr);
                    }
                    else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                    {
                        item.AccountId = (long)await _glCodeComDetailsManager.CreateAndRetrieveCodeComOneId(item.codeComUtilityIds);
                        item.TaxAmount = ApInvoiceTr.GetTaxAmount(item.TaxPercentageLkpId, item.Amount);

                        _ = await _repoApInvoiceTr.InsertAsync(ObjectMapper.Map<ApInvoiceTr>(item));
                    }
                    else if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                    {
                        await _repoApInvoiceTr.DeleteAsync((long)item.Id);
                    }
                }
            }
        }

        public async Task<List<ApInvoiceTrDto>> GetAllDetails(long id)
        {
            var output = new List<ApInvoiceTrDto>();

            var listData = await _repoApInvoiceTr.GetAllIncluding(z => z.GlCodeComDetails, x => x.FndTaxPercentageLkp)
                                     .Where(d => d.ApInvoiceHdId == id).ToListAsync();

            foreach (var item in listData)
            {
                (string ids, string txts) = await _glCodeComDetailsManager.GetCodeComTextsIds(item.GlCodeComDetails, _app.Reqlanguage);

                var current = new ApInvoiceTrDto
                {
                    Id = item.Id,
                    codeComUtilityIds = ids,
                    codeComUtilityTexts = txts,
                    Amount = item.Amount,
                    Desc = item.Desc,
                    TaxAmount = item.TaxAmount,
                    Total = item.Amount + item.TaxAmount,
                    TaxPercentageLkpId = item.TaxPercentageLkpId,
                    TaxPercentageNameAr = item.FndTaxPercentageLkp?.NameAr ?? string.Empty,
                    TaxPercentageNameEn = item.FndTaxPercentageLkp?.NameEn ?? string.Empty,
                    rowStatus = DetailRowStatus.RowStatus.NoAction.ToString()
                };

                output.Add(current);
            }

            return output;
        }

        public async Task<ApInvoiceHdDto> GetDetailAsync(EntityDto<long> input)
        {
            var current = await Repository.GetAllIncluding(x => x.FndStatusLkp,
                                                x => x.FndHdTypeLkp, x => x.Currency,
                                                x => x.ApVendors, x => x.FromGlCodeComDetails,
                                                x => x.ToGlCodeComDetails)
                                    .Where(z => z.Id == input.Id)
                                    .FirstOrDefaultAsync();

            (string ids, string txts) = await _glCodeComDetailsManager.GetCodeComTextsIds(current.FromGlCodeComDetails, _app.Reqlanguage);
            (string ids1, string txts1) = await _glCodeComDetailsManager.GetCodeComTextsIds(current.ToGlCodeComDetails, _app.Reqlanguage);

            var mapped = ObjectMapper.Map<ApInvoiceHdDto>(current);

            mapped.codeComUtilityIds = ids;
            mapped.codeComUtilityIds_alt1 = ids1;
            mapped.codeComUtilityTexts = txts;
            mapped.codeComUtilityTexts_alt1 = txts1;

            return mapped;
        }

        public async Task<PostOutput> PostApInvoiceHd(PostDto postDto)
        {
            postDto.UserId = (long)AbpSession.UserId;

            var result = await _repoPost.Execute(postDto, "ApPostInvoice");

            return result.FirstOrDefault();
        }

        public async Task<IReadOnlyList<ApInvoiceHdScreenDataOutput>> GetApInvoiceHdScreenData(IdLangInputDto input)
        {
            var result = await _getApInvoiceHdScreenDataRepository.Execute(input, "GetApInvoiceHdScreenData");

            return result.ToList();
        }

        internal override async Task EntityDeletePreExecute(EntityDto<long> input) { }
    }
}
