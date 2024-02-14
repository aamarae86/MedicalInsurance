using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System.__SalesModule._ArInvoiceSettlementHd.Dto;
using ERP._System.__SalesModule.ArInvoiceSettlement;
using ERP.Authorization;
using ERP.Helpers.Core;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Microsoft.EntityFrameworkCore;
using ERP._System.PostRecords.Dto;
using ERP._System._Counters.Procs;
using Abp.Application.Services;
using ERP._System._Counters.ProcDto;
using ERP._System.__AccountModuleExtend._GlJeIntegrationHeaders;
using ERP._System._FndLookupValues;
using ERP._System.__AccountModule._ArReceipts;
using ERP._System.__PmPropertiesModule._ArInvoiceTr;
using ERP._System.__PmPropertiesModule._ArInvoiceHd;
using System;
using ERP._System.__SalesModule._IvReturnSaleHd;
using ERP._System.__SalesModule._IvSaleHd;

namespace ERP._System.__SalesModule._ArInvoiceSettlementHd
{
    [AbpAuthorize]
    public class ArInvoiceSettlementHdAppService : AsyncCrudAppService<ArInvoiceSettlementHd, ArInvoiceSettlementHdDto, long, ArInvoiceSettlementHdPagedDto
        , ArInvoiceSettlementHdCreateDto, ArInvoiceSettlementHdEditDto>, IArInvoiceSettlementHdAppService
    {
        private readonly IRepository<ArInvoiceSettlementCr, long> _repoArInvoiceSettlementCr;
        private readonly IRepository<ArInvoiceSettlementDr, long> _repoArInvoiceSettlementDr;
        private readonly IGetCounterRepository _repoProcCounter;
        private readonly IArInvoiceSettlementHdRepository _arInvoiceSettlementHdRepository;
        private readonly IRepository<GlJeIntegrationLines, long> _repoGlJeIntegrationLines;
        private readonly IRepository<FndLookupValues, long> _repoFndLookupValues;
        private readonly IRepository<ArReceipts, long> _repoArReceipts;
        private readonly IRepository<ArInvoiceTr, long> _repoArInvoiceTr;
        private readonly IRepository<ArInvoiceHd, long> _repoArInvoiceHd;
        private readonly IRepository<GlJeIntegrationHeaders, long> _repoGlJeIntegrationHeaders;
        private readonly IRepository<ArReceiptsOnAccount, long> _repoArReceiptsOnAccount;
        private readonly IRepository<IvReturnSaleTr, long> _repoIvReturnSaleTr;
        private readonly IRepository<IvReturnSaleHd, long> _repoIvReturnSaleHd;
        private readonly IRepository<IvSaleTr, long> _repoIvSalesTr;
        private readonly IRepository<IvSaleHd, long> _repoIvSalesHd;

        public ArInvoiceSettlementHdAppService(IRepository<ArInvoiceSettlementHd, long> repository
            , IRepository<ArInvoiceSettlementDr, long> repoArInvoiceSettlementDr
            ,IRepository<ArInvoiceSettlementCr, long> repoArInvoiceSettlementCr
            , IArInvoiceSettlementHdRepository arInvoiceSettlementHdRepository
            , IRepository<GlJeIntegrationLines, long> repoGlJeIntegrationLines
            , IRepository<FndLookupValues, long> repoFndLookupValues
            , IRepository<ArReceipts, long> repoArReceipts
            , IRepository<ArInvoiceTr, long> repoArInvoiceTr
            , IRepository<ArInvoiceHd, long> repoArInvoiceHd
            , IRepository<GlJeIntegrationHeaders, long> repoGlJeIntegrationHeaders
            , IRepository<ArReceiptsOnAccount, long> repoArReceiptsOnAccount
            , IRepository<IvReturnSaleTr, long> repoIvReturnSaleTr
            , IRepository<IvReturnSaleHd, long> repoIvReturnSaleHd
            , IRepository<IvSaleTr, long> repoIvSalesTr
            , IRepository<IvSaleHd, long> repoIvSalesHd
            , IGetCounterRepository repoProcCounter
            ) : base(repository)
        {
            _repoGlJeIntegrationLines = repoGlJeIntegrationLines;
            _repoFndLookupValues = repoFndLookupValues;
            _repoArReceipts = repoArReceipts;
            _repoArInvoiceTr = repoArInvoiceTr;
            _repoArInvoiceHd = repoArInvoiceHd;
            _repoIvReturnSaleTr = repoIvReturnSaleTr;
            _repoIvReturnSaleHd = repoIvReturnSaleHd;
            _repoIvSalesTr = repoIvSalesTr;
            _repoIvSalesHd = repoIvSalesHd;
            _repoGlJeIntegrationHeaders = repoGlJeIntegrationHeaders;
            _repoArInvoiceSettlementDr = repoArInvoiceSettlementDr;
            _repoArInvoiceSettlementCr = repoArInvoiceSettlementCr;
            _arInvoiceSettlementHdRepository = arInvoiceSettlementHdRepository;
            _repoArReceiptsOnAccount = repoArReceiptsOnAccount;
            _repoProcCounter = repoProcCounter;
            CreatePermissionName = PermissionNames.Pages_ArInvoiceSettlementHd_Insert;
            UpdatePermissionName = PermissionNames.Pages_ArInvoiceSettlementHd_Update;
            DeletePermissionName = PermissionNames.Pages_ArInvoiceSettlementHd_Delete;
            GetAllPermissionName = PermissionNames.Pages_ArInvoiceSettlementHd;

        }
        protected override IQueryable<ArInvoiceSettlementHd> CreateFilteredQuery(ArInvoiceSettlementHdPagedDto input)
        {
            var iqueryable = Repository.GetAllIncluding( x => x.ArCustomers, x => x.FndStatusLkp);
            //string SettlementNumber
            //long? StatusLkpId
            //double? SettlementAmount
            //string SettlementDate
            //long? ArCustomerId

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.SettlementNumber))
                iqueryable = iqueryable.Where(z => z.SettlementNumber.Contains(input.Params.SettlementNumber));

            if (input.Params != null && input.Params.StatusLkpId != null)
                iqueryable = iqueryable.Where(z => z.StatusLkpId == input.Params.StatusLkpId);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.SettlementDate))
            {
                var dt = DateTimeController.ConvertToDateTime(input.Params.SettlementDate);

                iqueryable = iqueryable.Where(z => z.SettlementDate == dt);
            }
            if (input.Params != null && input.Params.ArCustomerId != null)
                iqueryable = iqueryable.Where(z => z.ArCustomerId == input.Params.ArCustomerId);

            if (input.Params != null && input.Params.SettlementAmount != null)
                iqueryable = iqueryable.Where(z => z.SettlementAmount == input.Params.SettlementAmount);

           
            return iqueryable;
        }
        public async override Task<ArInvoiceSettlementHdDto> Create(ArInvoiceSettlementHdCreateDto input)
        {
            CheckCreatePermission();

            var counterInput = new GetCounterInputDto { CounterName = "ArInvoiceSettlementH", TenantId = (int)AbpSession.TenantId, Lang = "ar-EG", year = 0 };

            var result = await _repoProcCounter.Execute(counterInput, "GetCounter");

            input.SettlementNumber = result?.FirstOrDefault()?.OutputStr ?? string.Empty;
            var arInvoiceSettlement = await base.Create(input);

            if (input.ArInvoiceSettlementCr?.Count > 0)
                foreach (var item in input.ArInvoiceSettlementCr)
                    await InsertArInvoiceSettlementCrData(item, arInvoiceSettlement.Id);

            if (input.ArInvoiceSettlementDr?.Count > 0)
                foreach (var item in input.ArInvoiceSettlementDr)
                    await InsertArInvoiceSettlementDrData(item, arInvoiceSettlement.Id);


            return new ArInvoiceSettlementHdDto { };
        }
        public async override Task<ArInvoiceSettlementHdDto> Update(ArInvoiceSettlementHdEditDto input)
        {
            CheckUpdatePermission();

            _ = await base.Update(input);

            await CRUD_ArInvoiceSettlementCr(input.ArInvoiceSettlementCr, input.Id);
            await CRUD_ArInvoiceSettlementDr(input.ArInvoiceSettlementDr, input.Id);

            return new ArInvoiceSettlementHdDto { };
        }

        public async Task<ArInvoiceSettlementHdDto> GetDetailAsync(EntityDto<long> input)
        {
            var mapped = ObjectMapper.Map<ArInvoiceSettlementHdDto>(await Repository.GetAllIncluding( x => x.ArCustomers, x => x.FndStatusLkp)
                           .Where(z => z.Id == input.Id).FirstOrDefaultAsync());
            return mapped;
        }
        public async override Task<ArInvoiceSettlementHdDto> Get(EntityDto<long> input)
        {
            return ObjectMapper.Map<ArInvoiceSettlementHdDto>(await Repository.GetAllIncluding(x => x.ArCustomers, x => x.FndStatusLkp).Where(x => x.Id == input.Id).FirstOrDefaultAsync());
        }
        private async Task InsertArInvoiceSettlementCrData(ArInvoiceSettlementCrDto invoiceSettlementCrDto, long invoiceSettlementHdId)
        {
            invoiceSettlementCrDto.ArInvoiceSettlementHdId = invoiceSettlementHdId;

            var invoiceSettlementCrs = ObjectMapper.Map<ArInvoiceSettlementCr>(invoiceSettlementCrDto);

            _ = await _repoArInvoiceSettlementCr.InsertAsync(invoiceSettlementCrs);

        }
        private async Task InsertArInvoiceSettlementDrData(ArInvoiceSettlementDrDto invoiceSettlementDrDto, long invoiceSettlementHdId)
        {
            invoiceSettlementDrDto.ArInvoiceSettlementHdId = invoiceSettlementHdId;

            var invoiceSettlementDrs = ObjectMapper.Map<ArInvoiceSettlementDr>(invoiceSettlementDrDto);

            _ = await _repoArInvoiceSettlementDr.InsertAsync(invoiceSettlementDrs);

        }
        private async Task CRUD_ArInvoiceSettlementCr(ICollection<ArInvoiceSettlementCrDto> invoiceSettlementCrDtos, long invoiceSettlementHdId)
        {
            if (invoiceSettlementCrDtos?.Count > 0)
            {
                foreach (var item in invoiceSettlementCrDtos)
                {
                    if (item.ArInvoiceSettlementCrId != 0 && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                    {
                        var invoiceSettlementCrs = await _repoArInvoiceSettlementCr.GetAsync((long)item.ArInvoiceSettlementCrId);

                        item.ArInvoiceSettlementHdId = invoiceSettlementHdId;
                        var Id = invoiceSettlementCrs.Id;
                        var TenantId = invoiceSettlementCrs.TenantId;

                                     //ObjectMapper.Map(invoiceSettlementCrs, item);
                        var result = ObjectMapper.Map(item, invoiceSettlementCrs);
                        result.Id = Id;
                        result.TenantId = TenantId;

                        _ = await _repoArInvoiceSettlementCr.UpdateAsync(result);
                    }
                    else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                    {
                        await InsertArInvoiceSettlementCrData(item, invoiceSettlementHdId);
                    }
                    else if (item.ArInvoiceSettlementCrId != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                    {
                        await _repoArInvoiceSettlementCr.DeleteAsync((long)item.ArInvoiceSettlementCrId);
                    }
                }
            }
        }
        private async Task CRUD_ArInvoiceSettlementDr(ICollection<ArInvoiceSettlementDrDto> invoiceSettlementDrDtos, long invoiceSettlementHdId)
        {
            if (invoiceSettlementDrDtos?.Count > 0)
            {
                foreach (var item in invoiceSettlementDrDtos)
                {
                    if (item.ArInvoiceSettlementDrId != 0 && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                    {
                        var invoiceSettlementDrs = await _repoArInvoiceSettlementDr.GetAsync((long)item.ArInvoiceSettlementDrId);

                        item.ArInvoiceSettlementHdId = invoiceSettlementHdId;

                        var Id = invoiceSettlementDrs.Id;
                        var TenantId = invoiceSettlementDrs.TenantId;

                   
                        var result = ObjectMapper.Map(item, invoiceSettlementDrs);
                        result.Id = Id;
                        result.TenantId = TenantId;

                        _ = await _repoArInvoiceSettlementDr.UpdateAsync(result);
                    }
                    else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                    {
                        await InsertArInvoiceSettlementDrData(item, invoiceSettlementHdId);
                    }
                    else if (item.ArInvoiceSettlementDrId != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                    {
                        await _repoArInvoiceSettlementDr.DeleteAsync((long)item.ArInvoiceSettlementDrId);
                    }
                }
            }
        }
        public async Task<List<ArInvoiceSettlementCrDto>> GetAllArInvoiceSettlementCrs(long invoiceSettlementHdId, string lang)
        {
            
             var data = await (from InvoiceSettlementCr in _repoArInvoiceSettlementCr.GetAll()
                              join Receipts in _repoArReceipts.GetAll() on InvoiceSettlementCr.SourceId equals Receipts.Id
                              join LookupValues in _repoFndLookupValues.GetAll() on InvoiceSettlementCr.SourceLkpId equals LookupValues.Id
                              join ReceiptsOnAccount in _repoArReceiptsOnAccount.GetAll() on Receipts.Id equals ReceiptsOnAccount.ReceiptId
                              where InvoiceSettlementCr.ArInvoiceSettlementHdId == invoiceSettlementHdId && InvoiceSettlementCr.SourceLkpId == 11572 
                              select new
                              {
                                  Id = InvoiceSettlementCr.Id,                                  
                                  SourceLkpId = InvoiceSettlementCr.SourceLkpId,
                                  SourceId = InvoiceSettlementCr.SourceId,
                                  CrSourceLkp = lang == "ar-EG" ? LookupValues.NameAr : LookupValues.NameEn,
                                  CrSource = Receipts.ReceiptNumber, //GlJeIntegrationNumber
                                  Amount = ReceiptsOnAccount.Amount,
                                  CrDate = Receipts.ReceiptDate.Date.ToString()
                              }
                               ).GroupBy(x => new { x.Id, x.SourceLkpId, x.SourceId, x.CrSourceLkp, x.CrDate, x.CrSource})
                            .Select(x => new {  Id = x.Key.Id, SourceLkpId = x.Key.SourceLkpId, SourceId = x.Key.SourceId, CrSourceLkp = x.Key.CrSourceLkp, CrSource = x.Key.CrSource, Amount = x.Sum(z => z.Amount), CrDate = x.Key.CrDate})
                        .Union(from InvoiceSettlementCr in _repoArInvoiceSettlementCr.GetAll()
                               join JeIntegrationLines in _repoGlJeIntegrationLines.GetAll() on InvoiceSettlementCr.SourceId equals JeIntegrationLines.Id
                               join JeIntegrationHeaders in _repoGlJeIntegrationHeaders.GetAll() on JeIntegrationLines.GlJeIntegrationHeaderId equals JeIntegrationHeaders.Id
                               join LookupValues in _repoFndLookupValues.GetAll() on InvoiceSettlementCr.SourceLkpId equals LookupValues.Id
                               where InvoiceSettlementCr.ArInvoiceSettlementHdId == invoiceSettlementHdId && InvoiceSettlementCr.SourceLkpId == 11571
                               select new
                               {
                                   Id = InvoiceSettlementCr.Id,                                  
                                   SourceLkpId = InvoiceSettlementCr.SourceLkpId,
                                   SourceId = InvoiceSettlementCr.SourceId,
                                   CrSourceLkp = lang == "ar-EG" ? LookupValues.NameAr : LookupValues.NameEn,
                                   CrSource = JeIntegrationHeaders.GlJeIntegrationNumber,
                                   Amount = JeIntegrationLines.CreditAmount,
                                   CrDate = JeIntegrationHeaders.GlJeIntegrationDate.Date.ToString()
                               })
                        .Union((from InvoiceSettlementCr in _repoArInvoiceSettlementCr.GetAll()
                                join IvReturnSaleTr in _repoIvReturnSaleTr.GetAll() on InvoiceSettlementCr.SourceId equals IvReturnSaleTr.IvReturnSaleHdId
                                join IvReturnSaleHd in _repoIvReturnSaleHd.GetAll() on IvReturnSaleTr.IvReturnSaleHdId equals IvReturnSaleHd.Id
                                join LookupValues in _repoFndLookupValues.GetAll() on InvoiceSettlementCr.SourceLkpId equals LookupValues.Id
                                where InvoiceSettlementCr.ArInvoiceSettlementHdId == invoiceSettlementHdId && InvoiceSettlementCr.SourceLkpId == 31630
                                select new
                                {
                                    Id = InvoiceSettlementCr.Id,
                                    SourceLkpId = InvoiceSettlementCr.SourceLkpId,
                                    SourceId = InvoiceSettlementCr.SourceId,
                                    CrSourceLkp = lang == "ar-EG" ? LookupValues.NameAr : LookupValues.NameEn,
                                    CrSource = IvReturnSaleHd.IvReturnSaleNumber,
                                    Amount = InvoiceSettlementCr.Amount,
                                    CrDate = IvReturnSaleHd.IvReturnSaleDate.Date.ToString()
                                }))
                        
                        .Select(x => new ArInvoiceSettlementCrDto
                               {
                                   Id = x.Id,
                                   ArInvoiceSettlementCrId = x.Id,
                                   SourceLkpId = x.SourceLkpId,
                                   SourceId = x.SourceId,
                                   CrSource = x.CrSource,
                                   CrSourceLkp = x.CrSourceLkp,
                                   Amount = x.Amount,
                                   CrDate = x.CrDate,

                               }).ToListAsync();
            
            return  data;
        }
        public async Task<List<ArInvoiceSettlementDrDto>> GetAllArInvoiceSettlementDrs(long invoiceSettlementHdId, string lang)
        {

            var data = await (from InvoiceSettlementDr in _repoArInvoiceSettlementDr.GetAll()
                              join InvoiceHd in _repoArInvoiceHd.GetAll() on InvoiceSettlementDr.SourceId equals InvoiceHd.Id
                              join LookupValues in _repoFndLookupValues.GetAll() on InvoiceSettlementDr.SourceLkpId equals LookupValues.Id
                              where InvoiceSettlementDr.ArInvoiceSettlementHdId == invoiceSettlementHdId && InvoiceSettlementDr.SourceLkpId == 11574
                              select new ArInvoiceSettlementDrDto
                              {
                                  //Id = InvoiceSettlementDr.Id,
                                  ArInvoiceSettlementDrId = InvoiceSettlementDr.Id,
                                  SourceLkpId = InvoiceSettlementDr.SourceLkpId,
                                  SourceId = InvoiceSettlementDr.SourceId,
                                  DrSourceLkp = lang == "ar-EG" ? LookupValues.NameAr : LookupValues.NameEn,
                                  DrSource = InvoiceHd.HdInvoiceNo,
                                  Amount = InvoiceSettlementDr.Amount,
                                  DrDate = InvoiceHd.HdDate.Value.Date.ToString(),
                                  DrJobCard = InvoiceHd.SourceNo
                              })

                        .Union(from InvoiceSettlementDr in _repoArInvoiceSettlementDr.GetAll()
                               join JeIntegrationLines in _repoGlJeIntegrationLines.GetAll() on InvoiceSettlementDr.SourceId equals JeIntegrationLines.Id
                               join JeIntegrationHeaders in _repoGlJeIntegrationHeaders.GetAll() on JeIntegrationLines.GlJeIntegrationHeaderId equals JeIntegrationHeaders.Id
                               join LookupValues in _repoFndLookupValues.GetAll() on InvoiceSettlementDr.SourceLkpId equals LookupValues.Id
                               where InvoiceSettlementDr.ArInvoiceSettlementHdId == invoiceSettlementHdId && InvoiceSettlementDr.SourceLkpId == 11573
                               select new ArInvoiceSettlementDrDto
                               {
                                   //Id = InvoiceSettlementDr.Id,
                                   ArInvoiceSettlementDrId = InvoiceSettlementDr.Id,
                                   SourceLkpId = InvoiceSettlementDr.SourceLkpId,
                                   SourceId = InvoiceSettlementDr.SourceId,
                                   DrSourceLkp = lang == "ar-EG" ? LookupValues.NameAr : LookupValues.NameEn,
                                   DrSource = JeIntegrationHeaders.GlJeIntegrationNumber,
                                   DrDate = JeIntegrationHeaders.GlJeIntegrationDate.Date.ToString(),
                                   Amount = InvoiceSettlementDr.Amount,
                                   DrJobCard = JeIntegrationHeaders.GlJeIntegrationSourceNo
                               })
                        .Union(from InvoiceSettlementDr in _repoArInvoiceSettlementDr.GetAll()
                               //join IvSalesTr in _repoIvSalesTr.GetAll() on InvoiceSettlementDr.SourceId equals IvSalesTr.IvSaleHdId
                               join IvSaleHd in _repoIvSalesHd.GetAll() on InvoiceSettlementDr.SourceId equals IvSaleHd.Id
                               join LookupValues in _repoFndLookupValues.GetAll() on InvoiceSettlementDr.SourceLkpId equals LookupValues.Id
                               where InvoiceSettlementDr.ArInvoiceSettlementHdId == invoiceSettlementHdId && InvoiceSettlementDr.SourceLkpId == 31629
                               select new ArInvoiceSettlementDrDto
                               {
                                   //Id = InvoiceSettlementDr.Id,
                                   ArInvoiceSettlementDrId = InvoiceSettlementDr.Id,
                                   SourceLkpId = InvoiceSettlementDr.SourceLkpId,
                                   SourceId = InvoiceSettlementDr.SourceId,
                                   DrSourceLkp = lang == "ar-EG" ? LookupValues.NameAr : LookupValues.NameEn,
                                   DrSource = IvSaleHd.IvSaleNumber,
                                   DrDate = IvSaleHd.IvSaleDate.Date.ToString(),
                                   Amount = InvoiceSettlementDr.Amount,
                                   DrJobCard = ""
                               })                        
                        .ToListAsync();            

            return  data;
        }

        public async Task<PostOutput> PostArInvoiceSettlement(PostDto input)
        {
            if (AbpSession.UserId.HasValue) { input.UserId = AbpSession.UserId.Value; }

            var postResult = await _arInvoiceSettlementHdRepository.Execute(input, "ArInvoiceSettlementHdPost");

            return postResult.FirstOrDefault();
        }

        public async Task<double> GetOutstanding(long coustumerId)
        {
            double res = 0.0;
            var data = await _repoArInvoiceTr.GetAll().Include(x => x.ArInvoiceHd)
                                                  .Where(z => z.ArInvoiceHd.StatusLkpId == 252 && z.ArInvoiceHd.ArCustomerId == coustumerId && (z.ArInvoiceHd.SourceLkpId == 11564 || z.ArInvoiceHd.SourceLkpId == 11565))
                                                  .GroupBy(x => new { x.ArInvoiceHd.HdInvoiceNo, x.ArInvoiceHd.HdDate, x.ArInvoiceHd.SourceNo, x.Id })
                                      .Select(x => new { Amount = x.Sum(s => (s.Amount + (s.Amount *( s.TaxPercent.Value / 100))))}).Select(a=>a.Amount)
                                      .ToListAsync();

            var data2 = await _repoGlJeIntegrationLines.GetAll().Include(x => x.GlJeIntegrationHeaders)
                                               .Where(z => z.IsSettled == false && z.GlJeIntegrationHeaders.StatusLkpId == 10977
                                                            && z.ArCustomerId == coustumerId && z.DebitAmount > 0)
                                   .Select(x => new { Amount = x.DebitAmount }).Select(a => a.Amount).ToListAsync();

            res = data.Sum(x => Convert.ToInt64(x)) + data2.Sum(x => Convert.ToInt64(x));
            return res;
        }
    }
}
