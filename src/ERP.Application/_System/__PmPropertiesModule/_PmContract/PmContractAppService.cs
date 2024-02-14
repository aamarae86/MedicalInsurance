using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using ERP._System.__PmPropertiesModule._PmCancellationContracts.Dto;
using ERP._System.__PmPropertiesModule._PmContract;
using ERP._System.__PmPropertiesModule._PmContract.Dto;
using ERP._System.__PmPropertiesModule._PmContract.Proc;
using ERP._System.__PmPropertiesModule._PmContract.ProcDto;
using ERP._System.__PmPropertiesModule._PmContractAttachments;
using ERP._System.__PmPropertiesModule._PmContractAttachments.Dto;
using ERP._System.__PmPropertiesModule._PmContractPayments;
using ERP._System.__PmPropertiesModule._PmContractPayments.Dto;
using ERP._System.__PmPropertiesModule._PmContractUnitDetails;
using ERP._System.__PmPropertiesModule._PmContractUnitDetails.Dto;
using ERP._System.__PmPropertiesModule._PmOtherContractPayments;
using ERP._System.__PmPropertiesModule._PmOtherContractPayments.Dto;
using ERP._System._Counters.ProcDto;
using ERP._System._Counters.Procs;
using ERP._System._FndLookupValues;
using ERP._System.PostRecords.Dto;
using ERP.Authorization;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__PmContractModule._PmContract
{
    [AbpAuthorize]
    public class PmContractAppService : AttachBaseAsyncCrudAppService<PmContract, PmContractDto, long, PagedPmContractResultRequestDto, CreatePmContractDto, PmContractEditDto, PmContractAttachments>,
                 IPmContractAppService
    {
        private readonly IGetCounterRepository _repoProcCounter;
        private readonly IPmContractRepository _pmContractRepository;
        private readonly IGeContractScreenDataRepository _geContractScreenDataRepository;
        private readonly IRepository<PmContractAttachments, long> _repoPmContractAttachments;
        private readonly IRepository<PmContractPayments, long> _repoPmContractPayments;
        private readonly IRepository<PmContractUnitDetails, long> _repoPmContractUnitDetails;
        private readonly IRepository<PmOtherContractPayments, long> _repoPmOtherContractPayments;

        public PmContractAppService(IRepository<PmContract, long> repository,
             IRepository<PmContractAttachments, long> repoPmContractAttachments,
             IRepository<PmContractPayments, long> repoPmContractPayments,
             IRepository<PmContractUnitDetails, long> repoPmContractUnitDetails,
             IRepository<PmOtherContractPayments, long> repoPmOtherContractPayments,
             IGeContractScreenDataRepository geContractScreenDataRepository,
             IPmContractRepository pmContractRepository, IConfiguration config,
             IGetCounterRepository repoProcCounter) : base(repository, config)
        {
            _repoProcCounter = repoProcCounter;
            _pmContractRepository = pmContractRepository;
            _repoPmContractPayments = repoPmContractPayments;
            _repoPmContractAttachments = repoPmContractAttachments;
            _repoPmContractUnitDetails = repoPmContractUnitDetails;
            _repoPmOtherContractPayments = repoPmOtherContractPayments;
            _geContractScreenDataRepository = geContractScreenDataRepository;

            CreatePermissionName = PermissionNames.Pages_PmContract_Insert;
            UpdatePermissionName = PermissionNames.Pages_PmContract_Update;
            DeletePermissionName = PermissionNames.Pages_PmContract_Delete;
            GetAllPermissionName = PermissionNames.Pages_PmContract;

            PreFileName = "PmCon-Attchs";
            ServiceFolder = "PmContracts";
        }

        protected override async Task<PmContractAttachments> GetAttachmentEntityAsync(long ParentId, long Id, string filePath)
        {
            return await _repoPmContractAttachments.FirstOrDefaultAsync(att => att.Id == Id && att.PmContractId == ParentId && att.FilePath == filePath); ;
        }
        public async override Task<PagedResultDto<PmContractDto>> GetAll(PagedPmContractResultRequestDto input)
        {
            CheckGetAllPermission();

            var queryable = Repository.GetAllIncluding(x => x.FndStatusLkp,
                x => x.PmProperties, x => x.PmTenants, x => x.FndUnitTypeLkp);

            if (input.Params != null && input.Params.StatusLkpId != null)
                queryable = queryable.Where(q => q.StatusLkpId == input.Params.StatusLkpId);

            if (input.Params != null && input.Params.PropertyId != null)
                queryable = queryable.Where(q => q.PropertyId == input.Params.PropertyId);

            if (input.Params != null && input.Params.PmTenantId != null)
                queryable = queryable.Where(q => q.PmTenantId == input.Params.PmTenantId);

            if (input.Params != null && input.Params.PmUnitTypeLkpId != null)
                queryable = queryable.Where(q => q.PmUnitTypeLkpId == input.Params.PmUnitTypeLkpId);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.ContractNumber))
                queryable = queryable.Where(q => q.ContractNumber.Contains(input.Params.ContractNumber));

            var count = await queryable.CountAsync();
            var listOrder = new List<SortModel> { new SortModel { Sort = input.OrderByValue.Sort, ColId = input.OrderByValue.ColId } };

            queryable = queryable.DynamicOrderBy(listOrder);
            queryable = queryable.Skip(input.SkipCount);
            queryable = queryable.OrderByDescending(x => x.CreationTime);

            var data = await queryable.Take(input.MaxResultCount).ToListAsync();

            var data2 = ObjectMapper.Map(data, new List<PmContractDto>());

            var PagedResultDto = new PagedResultDto<PmContractDto>()
            {
                Items = data2 as IReadOnlyList<PmContractDto>,
                TotalCount = count
            };

            return PagedResultDto;
        }

        public async override Task<PmContractDto> Create(CreatePmContractDto input)
        {
            CheckCreatePermission();

            if (input.PmContUnitDetails.Count == 0) throw new UserFriendlyException("تفاصيل الوحدات مطلوبة");

            var checkUnitKlp = input.PmContUnitDetails.GroupBy(z => z.PropertiesUnitId).Select(y => y.Key).ToList();

            if (checkUnitKlp.Count > 1) throw new UserFriendlyException("رقم الوحدة متكرر");

            input.ContractNumber = await GetPmContractNumber();

            var PmContract = await base.Create(input);

            if (input.PmContAttachments.Count > 0)
            {
                foreach (var item in input.PmContAttachments)
                {
                    //string base64Str = !string.IsNullOrEmpty(item.base64Str) && item.base64Str.Contains(',') ? item.base64Str.Split(',')[1] : string.Empty;

                    //item.FilePath = GetFilePath(base64Str, item.fileExt);

                    item.PmContractId = PmContract.Id;

                    _ = await _repoPmContractAttachments.InsertAsync(ObjectMapper.Map<PmContractAttachments>(item));
                }
            }

            if (input.PmContPayments.Count > 0)
            {
                foreach (var item in input.PmContPayments)
                {
                    item.PmContractId = PmContract.Id;

                    _ = await _repoPmContractPayments.InsertAsync(ObjectMapper.Map<PmContractPayments>(item));
                }
            }

            if (input.PmOtherContPayments.Count > 0)
            {
                foreach (var item in input.PmOtherContPayments)
                {
                    item.PmContractId = PmContract.Id;

                    _ = await _repoPmOtherContractPayments.InsertAsync(ObjectMapper.Map<PmOtherContractPayments>(item));
                }
            }

            if (input.PmContUnitDetails.Count > 0)
            {
                foreach (var item in input.PmContUnitDetails)
                {
                    item.PmContractId = PmContract.Id;

                    _ = await _repoPmContractUnitDetails.InsertAsync(ObjectMapper.Map<PmContractUnitDetails>(item));
                }
            }

            return new PmContractDto { };
        }

        public async override Task<PmContractDto> Update(PmContractEditDto input)
        {
            CheckUpdatePermission();

            if (input.PmContUnitDetails.Count == 0) throw new UserFriendlyException("تفاصيل الوحدات مطلوبة");

            var checkUnitKlp = input.PmContUnitDetails.GroupBy(z => z.PropertiesUnitId).Select(y => y.Count()).ToList();


          var isValid=  checkUnitKlp.Any(s => s > 1)  ? false : true ;


            if (!isValid) throw new UserFriendlyException("رقم الوحدة متكرر");

            _ = await base.Update(input);

            if (input.PmContAttachments.Count > 0)
            {
                foreach (var item in input.PmContAttachments)
                {
                    //string base64Str = !string.IsNullOrEmpty(item.base64Str) && item.base64Str.Contains(',') ? item.base64Str.Split(',')[1] : string.Empty;

                    if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                    {
                        //item.FilePath = GetFilePath(base64Str, item.fileExt);

                        var concAttachments = await _repoPmContractAttachments.GetAsync((long)item.Id);

                        item.PmContractId = input.Id;

                        var mapped = ObjectMapper.Map(item, concAttachments);

                        _ = await _repoPmContractAttachments.UpdateAsync(concAttachments);

                    }
                    else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                    {
                        //item.FilePath = GetFilePath(base64Str, item.fileExt);
                        item.PmContractId = input.Id;

                        _ = await _repoPmContractAttachments.InsertAsync(ObjectMapper.Map<PmContractAttachments>(item));
                    }
                    else if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                    {
                        await _repoPmContractAttachments.DeleteAsync((long)item.Id);
                    }
                }
            }

            if (input.PmContPayments.Count > 0)
            {
                foreach (var item in input.PmContPayments)
                {
                    if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                    {
                        item.PmContractId = input.Id;

                        var contractPayments = await _repoPmContractPayments.GetAsync((long)item.Id);

                        ObjectMapper.Map(item, contractPayments);

                        _ = await _repoPmContractPayments.UpdateAsync(contractPayments);
                    }
                    else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                    {
                        item.PmContractId = input.Id;

                        _ = await _repoPmContractPayments.InsertAsync(ObjectMapper.Map<PmContractPayments>(item));
                    }
                    else if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                    {
                        await _repoPmContractPayments.DeleteAsync((long)item.Id);
                    }
                }
            }

            if (input.PmOtherContPayments.Count > 0)
            {
                foreach (var item in input.PmOtherContPayments)
                {
                    if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                    {
                        item.PmContractId = input.Id;

                        var contractOtherPayments = await _repoPmOtherContractPayments.GetAsync((long)item.Id);

                        ObjectMapper.Map(item, contractOtherPayments);

                        _ = await _repoPmOtherContractPayments.UpdateAsync(contractOtherPayments);

                    }
                    else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                    {
                        item.PmContractId = input.Id;

                        _ = await _repoPmOtherContractPayments.InsertAsync(ObjectMapper.Map<PmOtherContractPayments>(item));
                    }
                    else if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                    {
                        await _repoPmOtherContractPayments.DeleteAsync((long)item.Id);
                    }
                }
            }

            if (input.PmContUnitDetails.Count > 0)
            {
                foreach (var item in input.PmContUnitDetails)
                {
                    if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                    {
                        var propUnits = await _repoPmContractUnitDetails.GetAsync((long)item.Id);

                        item.PmContractId = input.Id;

                        var mapped = ObjectMapper.Map(item, propUnits);

                        _ = await _repoPmContractUnitDetails.UpdateAsync(propUnits);

                    }
                    else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                    {
                        item.PmContractId = input.Id;

                        _ = await _repoPmContractUnitDetails.InsertAsync(ObjectMapper.Map<PmContractUnitDetails>(item));
                    }
                    else if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                    {
                        await _repoPmContractUnitDetails.DeleteAsync((long)item.Id);
                    }
                }
            }

            return new PmContractDto { };
        }

        public async Task<PmContractDto> GetDetailAsync(EntityDto<long> input)
        {
            var current = await Repository.GetAllIncluding(x => x.PmTenants, x => x.FndActivityLkp,
                                x => x.FndPaymentNoLkp, x => x.FndStatusLkp,
                                x => x.FndUnitTypeLkp, x => x.PmProperties)
                           .Where(z => z.Id == input.Id)
                           .FirstOrDefaultAsync();

            return ObjectMapper.Map<PmContractDto>(current);
        }

        public async Task<List<PmContractAttachmentsDto>> GetAllAttachments(EntityDto<long> input)
        {
            return ObjectMapper.Map<List<PmContractAttachmentsDto>>(await _repoPmContractAttachments.GetAllIncluding()
                .Where(d => d.PmContractId == input.Id).ToListAsync());
        }

        public async Task<List<PmContractUnitDetailsDto>> GetAllPmContractUnits(EntityDto<long> input)
        {
            var output = new List<PmContractUnitDetailsDto>();

            var listData = await _repoPmContractUnitDetails.GetAllIncluding(x => x.PmPropertiesUnits)
                .Where(d => d.PmContractId == input.Id).ToListAsync();

            foreach (var item in listData)
            {
                var current = new PmContractUnitDetailsDto
                {
                    Id = item.Id,
                    PropertiesUnitId = item.PropertiesUnitId,
                    Amount = item.Amount,
                    PropertiesUnit = item.PmPropertiesUnits.UnitNo,
                    PmContractId = item.PmContractId,
                    AreaSize = item.PmPropertiesUnits.AreaSize,
                    Notes = item.Notes,
                    rowStatus = DetailRowStatus.RowStatus.NoAction.ToString()
                };

                output.Add(current);
            }

            return output;
        }

        public async Task<List<PmContractPaymentsDto>> GetAllPmPayments(EntityDto<long> input, string lang = "ar-EG")
        {
            var output = new List<PmContractPaymentsDto>();

            var listData = await _repoPmContractPayments.GetAllIncluding(
                x => x.FndPaymentTypeLkp, x => x.FndBankLkp
                ).Where(d => d.PmContractId == input.Id).ToListAsync();

            foreach (var item in listData)
            {
                var current = new PmContractPaymentsDto
                {
                    Id = item.Id,
                    Comments = item.Comments,
                    Amount = item.Amount,
                    CheckNumber = item.CheckNumber,
                    PaymentDate = item.PaymentDate.ToString(Formatters.DateFormat),
                    BankLkpId = item.BankLkpId,
                    BankLkp = (lang== "ar-EG"? item.FndBankLkp?.NameAr ?? string.Empty: item.FndBankLkp?.NameEn ?? string.Empty),
                    PaymentNo = item.PaymentNo,
                    PaymentTypeLkp = (lang == "ar-EG" ? item.FndPaymentTypeLkp?.NameAr ?? string.Empty : item.FndPaymentTypeLkp?.NameEn ?? string.Empty),
                    PaymentTypeLkpId = item.PaymentTypeLkpId,
                    PmContractId = item.PmContractId,
                    rowStatus = DetailRowStatus.RowStatus.NoAction.ToString()
                };

                output.Add(current);
            }

            return output;
        }

        public async Task<List<PmOtherContractPaymentsDto>> GetAllPmOtherPayments(EntityDto<long> input)
        {
            var output = new List<PmOtherContractPaymentsDto>();

            var listData = await _repoPmOtherContractPayments.GetAllIncluding(x => x.PmOtherPaymentTypes)
                                 .Where(d => d.PmContractId == input.Id).ToListAsync();

            foreach (var item in listData)
            {
                var current = new PmOtherContractPaymentsDto
                {
                    Id = item.Id,
                    Notes = item.Notes,
                    PmContractId = item.PmContractId,
                    Amount = item.Amount,
                    OtherPaymentTypesId = item.OtherPaymentTypesId,
                    OtherPaymentTypes = item.PmOtherPaymentTypes.PaymentTypeName,
                    rowStatus = DetailRowStatus.RowStatus.NoAction.ToString()
                };

                output.Add(current);
            }

            return output;
        }

        public async Task<Select2PagedResult> GetPmContractSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {

            var data = await Repository.GetAll()
                .Where(z =>
                 string.IsNullOrEmpty(searchTerm) || (lang == "ar-EG" ? z.ContractNumber.Contains(searchTerm) : z.ContractNumber.Contains(searchTerm)) || z.ContractNumber.Contains(searchTerm))
                .ToListAsync();

            var result = data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = lang == "ar-EG" ? z.ContractNumber : z.ContractNumber }).ToList();

            var select2pagedResult = new Select2PagedResult
            {
                Total = data.Count(),
                Results = result
            };

            return select2pagedResult;
        }

        public async Task<ModelForAjaxCall> GetPmContractForAjaxCall(long id)
        {
            var data = await Repository.GetAllIncluding(x => x.PmTenants).Where(z => z.Id == id)
                .FirstOrDefaultAsync();

            return ObjectMapper.Map<ModelForAjaxCall>(data);
        }

        public async Task<PostOutput> PostContract(PostDto input)
        {
            input.UserId = (int)AbpSession.UserId;

            var result = await _pmContractRepository.Execute(input, "PmPostContract");

            return result.FirstOrDefault();
        }

        public async Task<PostOutput> RenewContract(PostDto input)
        {
            input.UserId = (int)AbpSession.UserId;

            var result = await _pmContractRepository.Execute(input, "PmRenewContract");

            return result.FirstOrDefault();
        }

        public async Task<PostOutput> CancelContract(PostDto input)
        {
            input.UserId = (int)AbpSession.UserId;

            var result = await _pmContractRepository.Execute(input, "PmCancelContract");

            return result.FirstOrDefault();
        }

        public async Task<PostOutput> ExpireContract(PostDto input)
        {
            input.UserId = (int)AbpSession.UserId;

            var result = await _pmContractRepository.Execute(input, "PmExprireContract");

            return result.FirstOrDefault();
        }

        public async Task<List<GeContractScreenDataOutput>> GetContractScreenData(IdLangInputDto input)
        {
            var result = await _geContractScreenDataRepository.Execute(input, "GeContractScreenData");

            return result.ToList();
        }

        //private string GetFilePath(string base64, string fileExtension = ".jpeg")
        //     => _imageConfig.SaveImage(base64, $"PmCon-Attchs-{Guid.NewGuid().ToString()}", fileExtension, "AppAttachments/PmContracts");

        private async Task<string> GetPmContractNumber(string lang = "ar-EG", int year = 0)
        {
            var counterInput = new GetCounterInputDto { CounterName = "PmContract", TenantId = (int)AbpSession.TenantId, Lang = lang, year = year };

            var result = await _repoProcCounter.Execute(counterInput, "GetCounter");

            return result?.FirstOrDefault()?.OutputStr ?? "0";
        }
    }
}
