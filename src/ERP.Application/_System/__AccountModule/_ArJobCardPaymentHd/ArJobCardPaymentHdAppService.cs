using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System.__AccountModule._ApInvoiceHd;
using ERP._System.__AccountModule._ApInvoiceHd._ApInvoiceTr;
using ERP._System.__AccountModule._ArInvoiceHd.Dto;
using ERP._System.__AccountModule._ArJobCardHd;
using ERP._System.__AccountModule._ArJobCardPayment._ArJobCardPaymentHd;
using ERP._System.__AccountModule._ArJobCardPayment._ArJobCardPaymentHd.Proc;
using ERP._System.__AccountModule._ArJobCardPayment._ArJobCardPaymentTr;
using ERP._System.__AccountModule._ArJobCardPaymentHd.Dto;
using ERP._System.__AccountModule._ArJobCardPaymentTr.Dto;
using ERP._System.__PmPropertiesModule._ArInvoiceHd;
using ERP._System.__PmPropertiesModule._ArInvoiceHd.Proc;
using ERP._System.__PmPropertiesModule._ArInvoiceHd.ProcDto;
using ERP._System.__PmPropertiesModule._ArInvoiceTr;
using ERP._System._ApMiscPaymentHeaders;
using ERP._System._ApMiscPaymentLines;
using ERP._System._ArCustomers;
using ERP._System._ArInvoiceHd.Dto;
using ERP._System._ArInvoiceTr.Dto;
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
using Newtonsoft.Json;
using ERP._System._ArMiscPayment._ApMiscPaymentHeaders.Dto;
using ERP._System.__AccountModule._ArJobCardPaymentHd.Dto;
using Abp.EntityFrameworkCore;
using ERP._System._FndLookupValues;

namespace ERP._System.__AccountModule._ArJobCardPaymentHd
{

    [AbpAuthorize]
    public class ArJobCardPaymentHdAppService : AsyncCrudAppService<ArJobCardPaymentHd, ArJobCardPaymentHdDto, long, PagedArJobCardPaymentHdResultRequestDto, ArJobCardPaymentHdCreateDto, ArJobCardPaymentHdEditDto>,
       IArJobCardPaymentHdAppService
    {

        private readonly IRepository<ApMiscPaymentHeaders, long> _repoApMiscPaymentHeaders;
        private readonly IRepository<ApMiscPaymentLines, long> _repoApMiscPaymentLines;
        private readonly IRepository<ApInvoiceHd, long> _repoApInvoiceHd;
        private readonly IRepository<ApInvoiceTr, long> _repoApInvoiceTr;
        private readonly IRepository<ArJobCardHd, long> _repoArJobCardHd;
        private readonly IRepository<ArCustomers, long> _repoArCustomers;
        private readonly IRepository<ArJobCardPaymentTr, long> _repoArJobCardPaymentTrDetails;        
        private readonly IArJobCardPaymentHdRepository _repoPost;
        private readonly IGetCounterRepository _repoProcCounter;
        private readonly IArJobCardHdManager _arJobCardHdManager;
        private readonly IRepository<FndLookupValues, long> _repoFndLookupValues;


        public ArJobCardPaymentHdAppService(IRepository<ArJobCardPaymentHd, long> repository,
            IRepository<ApMiscPaymentHeaders, long> repoApMiscPaymentHeaders,
            IRepository<ApMiscPaymentLines, long> repoApMiscPaymentLines,
            IRepository<ApInvoiceTr, long> repoApInvoiceTr,
            IRepository<ApInvoiceHd, long> repoApInvoiceHd,
            IRepository<ArJobCardHd, long> repoArJobCardHd,
            IRepository<ArCustomers, long> repoArCustomers,
            IRepository<ArJobCardPaymentTr, long> repoArJobCardPaymentTrDetails,
            IArJobCardPaymentHdRepository repoPost,
            IGetCounterRepository getCounterRepository,
            IArJobCardHdManager arJobCardHdManager,
            IRepository<FndLookupValues, long> repoFndLookupValues
                                            ) : base(repository)
        {
            _repoApMiscPaymentHeaders = repoApMiscPaymentHeaders;
            _repoApMiscPaymentLines = repoApMiscPaymentLines;
            _repoApInvoiceHd = repoApInvoiceHd;
            _repoApInvoiceTr = repoApInvoiceTr;
            _repoArJobCardHd = repoArJobCardHd;
            _repoArCustomers = repoArCustomers;
            _repoProcCounter = getCounterRepository;
            _repoArJobCardPaymentTrDetails = repoArJobCardPaymentTrDetails;
            _repoPost = repoPost;
            _arJobCardHdManager = arJobCardHdManager;
            _repoFndLookupValues = repoFndLookupValues;
            
            CreatePermissionName = PermissionNames.Pages_ArJobCardPaymentHd_Insert;
            UpdatePermissionName = PermissionNames.Pages_ArJobCardPaymentHd_Update;
            DeletePermissionName = PermissionNames.Pages_ArJobCardPaymentHd_Delete;
            GetAllPermissionName = PermissionNames.Pages_ArJobCardPaymentHd;
        }

        public async override Task<PagedResultDto<ArJobCardPaymentHdDto>> GetAll(PagedArJobCardPaymentHdResultRequestDto input)
        {
            var queryable =  Repository.GetAllIncluding(x => x.FndJobCardPaymenStatusLkp, x => x.ArJobCardHd, x => x.ArJobCardHd.ArCustomers, x => x.ArJobCardPaymentTr);


            if (input.Params != null && input.Params.CustomerLkpId != null)
                queryable = queryable.Where(q => q.ArJobCardHd.ArCustomerId == input.Params.CustomerLkpId);


            if (input.Params != null && !string.IsNullOrEmpty(input.Params.TransactionDate))
                queryable = queryable.Where(q => q.TransactionDate == DateTimeController.ConvertToDateTime(input.Params.TransactionDate));

            if (input.Params != null && input.Params.StatusLkpId != null)
                queryable = queryable.Where(q => q.StatusLkpId == input.Params.StatusLkpId);

            if (input.Params != null && input.Params.JobNumberLkpId != null)
                queryable = queryable.Where(q => q.ArJobCardHd.JobNumber.Contains(input.Params.JobNumberLkpId));

            var count = await queryable.CountAsync();
            var listOrder = new List<SortModel> { new SortModel { Sort = input.OrderByValue.Sort, ColId = input.OrderByValue.ColId } };
            queryable = queryable.DynamicOrderBy(listOrder);
            queryable = queryable.Skip(input.SkipCount);
            var data = await queryable.Take(input.MaxResultCount).ToListAsync();

            var data2 = ObjectMapper.Map(data, new List<ArJobCardPaymentHdDto>());

            var PagedResultDto = new PagedResultDto<ArJobCardPaymentHdDto>()
            {
                Items = data2 as IReadOnlyList<ArJobCardPaymentHdDto>,
                TotalCount = count
            };
            
            return PagedResultDto;
        }


        public async override Task<ArJobCardPaymentHdDto> Create(ArJobCardPaymentHdCreateDto input)
        {
            CheckCreatePermission();

            input.TransactionNumber = await GetOperationNumber();

            var arJobCardPaymentHd = await base.Create(input);

            if (input.ArJobCardPaymentTrList != null && input.ArJobCardPaymentTrList.Count > 0)
            {

                foreach (var item in input.ArJobCardPaymentTrList)
                    await InsertArJobCardPaymentTrData(item, arJobCardPaymentHd.Id);
            }
                


            return new ArJobCardPaymentHdDto { };
        }

        public async override Task<ArJobCardPaymentHdDto> Update(ArJobCardPaymentHdEditDto input)
        {
            CheckUpdatePermission();

            _ = await base.Update(input);

            await CRUD_ArJobCardPaymentTr(input.ArJobCardPaymentTrList, input.Id);


            return new ArJobCardPaymentHdDto { };
        }


        private async Task CRUD_ArJobCardPaymentTr(ICollection<ArJobCardPaymentTrDto> arJobCardPaymentTrDtos, long personId)
        {
            if (arJobCardPaymentTrDtos != null && arJobCardPaymentTrDtos.Count > 0)
            {
                foreach (var item in arJobCardPaymentTrDtos)
                {
                    if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                    {
                        var arJobCardPaymentTr = await _repoArJobCardPaymentTrDetails.GetAsync((long)item.Id);

                        //item.ArJobCardPaymentHdId  = personId;
                        var ArJobCardPaymentHdId = arJobCardPaymentTr.ArJobCardPaymentHdId;
                        ObjectMapper.Map(item, arJobCardPaymentTr);
                        arJobCardPaymentTr.ArJobCardPaymentHdId = ArJobCardPaymentHdId;

                         _ = await _repoArJobCardPaymentTrDetails.UpdateAsync(arJobCardPaymentTr);
                    }
                    else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                    {
                        await InsertArJobCardPaymentTrData(item, personId);
                    }
                    else if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                    {
                        await _repoArJobCardPaymentTrDetails.DeleteAsync((long)item.Id);
                    }
                }
            }
        }


        public async Task<ArJobCardPaymentHdDto> GetDetailAsync(EntityDto<long> input)
        {
            var mapped = ObjectMapper.Map<ArJobCardPaymentHdDto>(await Repository
                           .GetAllIncluding(x => x.FndJobCardPaymenStatusLkp,
                                            x => x.ArJobCardHd,
                                            x => x.ArJobCardHd.ArCustomers,
                                            x => x.ArJobCardPaymentTr)
                           .Where(z => z.Id == input.Id).FirstOrDefaultAsync());

            return mapped;
        }

        


        public async Task<List<ArJobCardPaymentHdDetailsDto>> GetAllArJobCardPaymentTrData(EntityDto<long> input)
        {
            var finalresult = new List<ArJobCardPaymentHdDetailsDto>();

            try
            {
                int tenantId = 0;
                tenantId = AbpSession.TenantId.Value;

                var postlkpId = _repoFndLookupValues.FirstOrDefault(c => c.LookupType == "ApInvoiceHdStatues" && c.NameEn == "Posted")?.Id;


                var Invoices = (from ArJobCardPaymentTr in _repoArJobCardPaymentTrDetails.GetAllIncluding(c => c.ArJobCardPaymentHd, c => c.ArJobCardPaymentHd.ArJobCardHd.ArCustomers)
                                join ApInvoiceTr in _repoApInvoiceTr.GetAllIncluding(c => c.ApInvoiceHd)
                                      on new { Desc = ArJobCardPaymentTr.ArJobCardPaymentHd.ArJobCardHd.JobNumber, ApInvoiceTrId = ArJobCardPaymentTr.SourceId }
                                  //equals new { ApInvoiceTr.Desc, ApInvoiceTr.ApInvoiceHdId }
                                  equals new { Desc = ApInvoiceTr.Desc, ApInvoiceTrId = ApInvoiceTr.Id }
                                where
                                  ArJobCardPaymentTr.ArJobCardPaymentHd.Id == input.Id &&
                                  ArJobCardPaymentTr.SourceTypeLkpId == 11570 &&
                                  ArJobCardPaymentTr.TenantId == tenantId && 
                                  ApInvoiceTr.ApInvoiceHd.StatusLkpId == postlkpId
                                select new ArJobCardPaymentResultDto
                                {
                                    ArJobCardPaymentTr = ArJobCardPaymentTr,
                                    ApInvoiceHd = ApInvoiceTr.ApInvoiceHd,
                                    ApInvoiceTr = ApInvoiceTr,
                                    ArJobCardHd = ArJobCardPaymentTr.ArJobCardPaymentHd.ArJobCardHd,
                                    Amount = (ApInvoiceTr.Amount + ApInvoiceTr.TaxAmount)
                                }
                               ).ToList();

                if (Invoices.Count > 0)
                {
                    var groupedInvoices = Invoices.GroupBy(s => new { ApInvoiceTrId = s.ApInvoiceTr.Id })
                                  .Select(z => new ArJobCardPaymentResultDto
                                  {
                                      ArJobCardPaymentTr = z.Select(c => c.ArJobCardPaymentTr).FirstOrDefault(),
                                      ApInvoiceHd = z.Select(c => c.ApInvoiceHd).FirstOrDefault(),
                                      ApInvoiceTr = z.Select(c => c.ApInvoiceTr).FirstOrDefault(),
                                      ArJobCardHd = z.Select(c => c.ArJobCardHd).FirstOrDefault(),
                                      Amount = z.Sum(c => c.ApInvoiceTr.Amount + c.ApInvoiceTr.TaxAmount)

                                  });


                    var MappedInvoiceResult = ObjectMapper.Map(groupedInvoices, new List<ArJobCardPaymentHdDetailsDto>());

                    if (MappedInvoiceResult.Count > 0)
                        finalresult.AddRange(MappedInvoiceResult);

                }


                var postlkpIdMisc = _repoFndLookupValues.FirstOrDefault(c => c.LookupType == "ApMiscPaymentHeadersPost"
                                                                        && c.NameEn == "Posted")?.Id;               

                var MiscPayments = (from ArJobCardPaymentTr in _repoArJobCardPaymentTrDetails.GetAllIncluding(c => c.ArJobCardPaymentHd, c => c.ArJobCardPaymentHd.ArJobCardHd.ArCustomers)
                                    join ApMiscPaymentLines in _repoApMiscPaymentLines.GetAllIncluding(c => c.ApMiscPaymentHeaders)
                                          on new { InvoiceNumber = ArJobCardPaymentTr.ArJobCardPaymentHd.ArJobCardHd.JobNumber, ApMiscPaymentLinesId = ArJobCardPaymentTr.SourceId }
                                      //equals new { ApMiscPaymentLines.InvoiceNumber, MiscPaymentId = Convert.ToInt64(ApMiscPaymentLines.MiscPaymentId) }
                                      equals new { ApMiscPaymentLines.InvoiceNumber, ApMiscPaymentLinesId = ApMiscPaymentLines.Id }
                                    where
                                      ArJobCardPaymentTr.ArJobCardPaymentHd.Id == input.Id &&
                                      ArJobCardPaymentTr.SourceTypeLkpId == 11569 &&
                                      ArJobCardPaymentTr.TenantId == tenantId &&
                                      ApMiscPaymentLines.ApMiscPaymentHeaders.PostedlkpId == postlkpIdMisc
                                    select new ArJobCardPaymentResultDto
                                    {
                                        ArJobCardPaymentTr = ArJobCardPaymentTr,
                                        ApMiscPaymentHeaders = ApMiscPaymentLines.ApMiscPaymentHeaders,
                                        ApMiscPaymentLines = ApMiscPaymentLines,
                                        ArJobCardHd = ArJobCardPaymentTr.ArJobCardPaymentHd.ArJobCardHd,
                                        Amount = (ApMiscPaymentLines.MiscPaymentAmount ?? 0) == 0 ? 0 :
                                                    ApMiscPaymentLines.MiscPaymentAmount + ((ApMiscPaymentLines.MiscPaymentAmount / 100) * ApMiscPaymentLines.TaxPercent ?? 0)
                                    }

                                    ).ToList();

                if (MiscPayments.Count > 0)
                {
                    var groupedMisc = MiscPayments.GroupBy(s => new { ApMiscPaymentLinesId = s.ApMiscPaymentLines.Id })
                                  .Select(z => new ArJobCardPaymentResultDto
                                  {
                                      ArJobCardPaymentTr = z.Select(c => c.ArJobCardPaymentTr).FirstOrDefault(),
                                      ApMiscPaymentHeaders = z.Select(c => c.ApMiscPaymentHeaders).FirstOrDefault(),
                                      ApMiscPaymentLines = z.Select(c => c.ApMiscPaymentLines).FirstOrDefault(),
                                      ArJobCardHd = z.Select(c => c.ArJobCardHd).FirstOrDefault(),
                                      Amount = z.Sum(c => c.Amount )

                                  });

                    var MappedApMiscResult = ObjectMapper.Map(groupedMisc, new List<ArJobCardPaymentHdDetailsDto>());

                    if (MappedApMiscResult.Count > 0)
                        finalresult.AddRange(MappedApMiscResult);

                }


                return finalresult;


            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<List<ArJobCardPaymentHdDetailsDto>> GetAllArJobCardPaymentTrByArJobCardId(EntityDto<long> input)
        {
            var finalresult = new List<ArJobCardPaymentHdDetailsDto>();

            try
            {
                int tenantId = 0;
                tenantId = AbpSession.TenantId.Value;

                var postlkpId = _repoFndLookupValues.FirstOrDefault(c => c.LookupType == "ApInvoiceHdStatues" && c.NameEn == "Posted")?.Id;


                var Invoices = (from ArJobCardPaymentTr in _repoArJobCardPaymentTrDetails.GetAllIncluding(c => c.ArJobCardPaymentHd, c => c.ArJobCardPaymentHd.FndJobCardPaymenStatusLkp)
                                join ApInvoiceTr in _repoApInvoiceTr.GetAllIncluding(c => c.ApInvoiceHd)
                                      on new { Desc = ArJobCardPaymentTr.ArJobCardPaymentHd.ArJobCardHd.JobNumber, ApInvoiceTrId = ArJobCardPaymentTr.SourceId }
                                  //equals new { ApInvoiceTr.Desc, ApInvoiceTr.ApInvoiceHdId }
                                  equals new { Desc = ApInvoiceTr.Desc, ApInvoiceTrId = ApInvoiceTr.Id }
                                where
                                  ArJobCardPaymentTr.ArJobCardPaymentHd.ArJobCardHdId == input.Id &&

                                  ArJobCardPaymentTr.SourceTypeLkpId == 11570 &&
                                  ArJobCardPaymentTr.TenantId == tenantId &&
                                  ApInvoiceTr.ApInvoiceHd.StatusLkpId == postlkpId
                                select new ArJobCardPaymentResultDto
                                {
                                    ArJobCardPaymentTr = ArJobCardPaymentTr,
                                    ApInvoiceHd = ApInvoiceTr.ApInvoiceHd,
                                    ApInvoiceTr = ApInvoiceTr,
                                    ArJobCardHd = ArJobCardPaymentTr.ArJobCardPaymentHd.ArJobCardHd,
                                    Amount = (ApInvoiceTr.Amount + ApInvoiceTr.TaxAmount)                                    
                                    
                                }
                               ).ToList();

                if (Invoices.Count > 0)
                {
                    var groupedInvoices = Invoices.GroupBy(s => new { ApInvoiceTrId = s.ApInvoiceTr.Id })
                                  .Select(z => new ArJobCardPaymentResultDto
                                  {
                                      ArJobCardPaymentTr = z.Select(c => c.ArJobCardPaymentTr).FirstOrDefault(),
                                      ApInvoiceHd = z.Select(c => c.ApInvoiceHd).FirstOrDefault(),
                                      ApInvoiceTr = z.Select(c => c.ApInvoiceTr).FirstOrDefault(),
                                      ArJobCardHd = z.Select(c => c.ArJobCardHd).FirstOrDefault(),
                                      Amount = z.Sum(c => c.ApInvoiceTr.Amount + c.ApInvoiceTr.TaxAmount)

                                  });


                    var MappedInvoiceResult = ObjectMapper.Map(groupedInvoices, new List<ArJobCardPaymentHdDetailsDto>());

                    if (MappedInvoiceResult.Count > 0)
                        finalresult.AddRange(MappedInvoiceResult);

                }


                var postlkpIdMisc = _repoFndLookupValues.FirstOrDefault(c => c.LookupType == "ApMiscPaymentHeadersPost"
                                                                        && c.NameEn == "Posted")?.Id;

                var MiscPayments = (from ArJobCardPaymentTr in _repoArJobCardPaymentTrDetails.GetAllIncluding(c => c.ArJobCardPaymentHd, c => c.ArJobCardPaymentHd.FndJobCardPaymenStatusLkp)
                                    join ApMiscPaymentLines in _repoApMiscPaymentLines.GetAllIncluding(c => c.ApMiscPaymentHeaders)
                                          on new { InvoiceNumber = ArJobCardPaymentTr.ArJobCardPaymentHd.ArJobCardHd.JobNumber, ApMiscPaymentLinesId = ArJobCardPaymentTr.SourceId }
                                      equals new { ApMiscPaymentLines.InvoiceNumber, ApMiscPaymentLinesId = Convert.ToInt64(ApMiscPaymentLines.Id) }
                                      //equals new { ApMiscPaymentLines.InvoiceNumber, MiscPaymentId = Convert.ToInt64(ApMiscPaymentLines.MiscPaymentId) }
                                    where
                                      ArJobCardPaymentTr.ArJobCardPaymentHd.ArJobCardHdId == input.Id &&
                                      ArJobCardPaymentTr.SourceTypeLkpId == 11569 &&
                                      ArJobCardPaymentTr.TenantId == tenantId &&
                                      ApMiscPaymentLines.ApMiscPaymentHeaders.PostedlkpId == postlkpIdMisc
                                    select new ArJobCardPaymentResultDto
                                    {
                                        ArJobCardPaymentTr = ArJobCardPaymentTr,
                                        ApMiscPaymentHeaders = ApMiscPaymentLines.ApMiscPaymentHeaders,
                                        ApMiscPaymentLines = ApMiscPaymentLines,
                                        ArJobCardHd = ArJobCardPaymentTr.ArJobCardPaymentHd.ArJobCardHd,
                                        Amount = (ApMiscPaymentLines.MiscPaymentAmount ?? 0) == 0 ? 0 :
                                                    ApMiscPaymentLines.MiscPaymentAmount + ((ApMiscPaymentLines.MiscPaymentAmount / 100) * ApMiscPaymentLines.TaxPercent ?? 0)
                                    }

                                    ).ToList();

                if (MiscPayments.Count > 0)
                {
                    var groupedMisc = MiscPayments.GroupBy(s => new { ApMiscPaymentLinesId = s.ApMiscPaymentLines.Id })
                                  .Select(z => new ArJobCardPaymentResultDto
                                  {
                                      ArJobCardPaymentTr = z.Select(c => c.ArJobCardPaymentTr).FirstOrDefault(),
                                      ApMiscPaymentHeaders = z.Select(c => c.ApMiscPaymentHeaders).FirstOrDefault(),
                                      ApMiscPaymentLines = z.Select(c => c.ApMiscPaymentLines).FirstOrDefault(),
                                      ArJobCardHd = z.Select(c => c.ArJobCardHd).FirstOrDefault(),
                                      Amount = z.Sum(c => c.Amount)

                                  });

                    var MappedApMiscResult = ObjectMapper.Map(groupedMisc, new List<ArJobCardPaymentHdDetailsDto>());

                    if (MappedApMiscResult.Count > 0)
                        finalresult.AddRange(MappedApMiscResult);

                }


                return finalresult;


            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async override Task<ArJobCardPaymentHdDto> Get(EntityDto<long> input)
        {
            return ObjectMapper.Map<ArJobCardPaymentHdDto>(await Repository.GetAllIncluding(x => x.FndJobCardPaymenStatusLkp,
                                                                                            x => x.ArJobCardHd,
                                                                                            x => x.ArJobCardHd.ArCustomers,
                                                                                            x => x.ArJobCardPaymentTr)
                                                                            .Where(x => x.Id == input.Id).FirstOrDefaultAsync());
        }


        private async Task InsertArJobCardPaymentTrData(ArJobCardPaymentTrDto arJobCardPaymentTrDto, long arJobCardPaymentHdId)
        {
            try
            {
                arJobCardPaymentTrDto.ArJobCardPaymentHdId = arJobCardPaymentHdId;

                var arJobCardPaymentTr = ObjectMapper.Map<ArJobCardPaymentTr>(arJobCardPaymentTrDto);

                _ = await _repoArJobCardPaymentTrDetails.InsertAsync(arJobCardPaymentTr);
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }

        private async Task<string> GetOperationNumber()
        {
            var counterInput = new GetCounterInputDto { CounterName = "ArJobCardPaymentHd", TenantId = (int)AbpSession.TenantId, Lang = "ar-EG", year = 0 };

            var result = await _repoProcCounter.Execute(counterInput, "GetCounter");

            return result?.FirstOrDefault()?.OutputStr ?? string.Empty;
        }

        public async Task<PostOutput> PostArJobCardPayment(PostDto input)
        {
            input.UserId = (long)AbpSession.UserId;

            var result = await _repoPost.Execute(input, "ArJobCardPaymentHdPost");

            return result.FirstOrDefault();
        }

        
        public async Task<Select2PagedResult> GetConditionalSelect2(string jobNumLkpId, long? sourceTypeLkpId, string searchTerm, int pageSize, int pageNumber, string lang)
        {
            

            if (string.IsNullOrEmpty(jobNumLkpId) || sourceTypeLkpId == null)
            {
                var select2pagedResult = new Select2PagedResult
                {
                    Total = 0,
                    Results = new List<Select2OptionModel>()
                };
                return select2pagedResult;
            }


            if (sourceTypeLkpId == 11569)
            {

                var postlkpId = _repoFndLookupValues.FirstOrDefault(c => c.LookupType == "ApMiscPaymentHeadersPost"
                                                                        && c.NameEn == "Posted")?.Id;

                var data = _repoApMiscPaymentLines.GetAllIncluding(c => c.ApMiscPaymentHeaders)
                                     .Where(c => !_repoArJobCardPaymentTrDetails.GetAll()
                                                                                 .Select(v => v.SourceId)
                                                                                 .Contains(c.Id))
                                     .Where(c => c.InvoiceNumber == jobNumLkpId && c.ApMiscPaymentHeaders.PostedlkpId == postlkpId)
                                     //.GroupBy(b => new { Id = b.MiscPaymentId.Value, InvoiceNo = b.ApMiscPaymentHeaders.PaymentNumber})
                                     .GroupBy(b => new { Id = b.Id, InvoiceNo = b.ApMiscPaymentHeaders.PaymentNumber })
                                     .Select(c => new { Id = c.Key.Id, InvoiceNo = c.Key.InvoiceNo })
                                     .AsQueryable();


                long count = data.Count();

                var result = data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize)
                            .Select(z => new Select2OptionModel { id = z.Id, text = z.InvoiceNo, altText = z.InvoiceNo })
                            .ToList();

                var select2pagedResult = new Select2PagedResult
                {
                    Total = count,
                    Results = result
                };

                return select2pagedResult;
            }
            else if (sourceTypeLkpId == 11570)
            {
                try
                {
                    var postlkpId = _repoFndLookupValues.FirstOrDefault(c => c.LookupType == "ApInvoiceHdStatues" && c.NameEn == "Posted")?.Id;

                    
                    var data = _repoApInvoiceTr.GetAllIncluding(c=>c.ApInvoiceHd)
                                     .Where(c => !_repoArJobCardPaymentTrDetails.GetAll()
                                                                                 .Select(v => v.SourceId)
                                                                                 .Contains(c.Id))
                                     .Where(c => c.Desc == jobNumLkpId && c.ApInvoiceHd.StatusLkpId == postlkpId)
                                     //.GroupBy(b=> new { Id = b.ApInvoiceHdId, InvoiceNo = b.ApInvoiceHd.HdInvNo })
                                     .GroupBy(b => new { Id = b.Id, InvoiceNo = b.ApInvoiceHd.HdInvNo })
                                     .Select(c=> new { Id = c.Key.Id, InvoiceNo= c.Key.InvoiceNo })
                                     .AsQueryable();


                    long count = data.Count();

                    var result = data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize)
                                .Select(z => new Select2OptionModel { id = z.Id, text = z.InvoiceNo, altText = z.InvoiceNo })
                                .ToList();

                    var select2pagedResult = new Select2PagedResult
                    {
                        Total = count,
                        Results = result
                    };

                    return select2pagedResult;
                    
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
            return null;
        }

        public async Task<ApMiscPaymentHeadersDto> GetPaymentDetails(string invoiceNum,long? invoiceId, long? sourceTypeLkpId, string jobNumLkpId)
        {

            var emptyResult = new ApMiscPaymentHeadersDto();

            if (sourceTypeLkpId == 11569)
            {
                var postlkpId = _repoFndLookupValues.FirstOrDefault(c => c.LookupType == "ApMiscPaymentHeadersPost"
                                                                        && c.NameEn == "Posted")?.Id;

                var data = await _repoApMiscPaymentLines.GetAllIncluding(c => c.ApMiscPaymentHeaders)
                                                    .Where(c => c.InvoiceNumber == jobNumLkpId &&
                                                                c.ApMiscPaymentHeaders.PostedlkpId == postlkpId &&
                                                                c.Id == invoiceId)
                                                               // c.MiscPaymentId == invoiceId)
                                                    .ToListAsync();

                if (data == null || data.Count == 0)
                    return emptyResult;

                var apMiscPaymentHeader = data.Select(c => c.ApMiscPaymentHeaders).FirstOrDefault();

                decimal? amount = 0;

                foreach (var apMiscLines in data)
                {
                    var amt = apMiscLines.MiscPaymentAmount;
                    var taxPercent = (apMiscLines.TaxPercent.HasValue) ? apMiscLines.TaxPercent.Value : 0;
                    var taxPercentVal = (amt / 100) * taxPercent;
                    amount += (amt + taxPercentVal);
                }

                
                var result = new ApMiscPaymentHeadersDto
                {
                    Id = apMiscPaymentHeader.Id,
                    MiscPaymentDate = apMiscPaymentHeader.MiscPaymentDate.Value.ToString("dd/MM/yyyy"),
                    Notes = apMiscPaymentHeader.Notes ?? string.Empty,
                    Amount = amount
                };

                return result;


            }
            else if (sourceTypeLkpId == 11570)
            {

                var postlkpId = _repoFndLookupValues.FirstOrDefault(c => c.LookupType == "ApInvoiceHdStatues" && c.NameEn == "Posted")?.Id;


                var data = await _repoApInvoiceTr.GetAllIncluding(c => c.ApInvoiceHd)
                                            .Where(c => c.ApInvoiceHd.StatusLkpId == postlkpId &&
                                                        c.Desc.Contains(jobNumLkpId) &&
                                                        c.Id == invoiceId)
                                                      //  c.ApInvoiceHdId == invoiceId.Value)
                                            .ToListAsync();

                if (data == null || data.Count == 0)
                    return emptyResult;

                var apInvoiceHeader = data.Select(c => c.ApInvoiceHd).FirstOrDefault();

                var amount = data.Sum(c => (c.Amount + c.TaxAmount));

                var result = new ApMiscPaymentHeadersDto
                {
                    Id = apInvoiceHeader.Id,
                    MiscPaymentDate = apInvoiceHeader.HdDate.ToString("dd/MM/yyyy"),
                    Notes = apInvoiceHeader.Comments ?? string.Empty,
                    Amount = amount
                };
                return result;

               
            }


            return emptyResult;
        }

        public async Task<Object> GetArCustomersDetails(long jobNumLkpId)
        {

            var data = await _repoArJobCardHd.GetAllIncluding(c => c.ArCustomers)
                                             .Where(c => c.Id == jobNumLkpId)
                                             .ToListAsync();



            var result = data.Select(c => new
            {
                CustomerNameAr = c.ArCustomers.CustomerNameAr,
                CustomerNameEn = c.ArCustomers.CustomerNameEn,
                OriginalAmount = c.OriginalAmount
            });

            return result;
        }


        public async Task<Select2PagedResult> GetArJobCardHdJobNumberSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
            => await _arJobCardHdManager.GetArJobCardHdJobNumberSelect2(searchTerm, pageSize, pageNumber, lang);

    }

}
