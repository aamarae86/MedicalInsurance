using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Events.Bus;
using ERP._System.__PmPropertiesModule._PmTenants;
using ERP._System.__PmPropertiesModule._PmTenants.Dto;
using ERP._System.__PmPropertiesModule._PmTenantsAttachments;
using ERP._System._ArCustomers;
using ERP._System._ArCustomers.Dto;
using ERP._System._Counters.ProcDto;
using ERP._System._Counters.Procs;
using ERP.Authorization;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__PmTenantsModule._PmTenants
{
    [AbpAuthorize]
    public class PmTenantsAppService : AttachBaseAsyncCrudAppService<PmTenants, PmTenantsDto, long, PagedPmTenantsResultRequestDto, PmTenantsCreateDto, PmTenantsEditDto, PmTenantsAttachments>, IPmTenantsAppService
    {
        private readonly IRepository<PmTenantsAttachments, long> _repoDetail;
        private readonly IGetCounterRepository _repoProcCounter;
        private readonly IImageConfig _imageConfig;
        private readonly IArCustomersAppService _arCustomersAppService;
        private readonly IPmTenantsManager _pmTenantsManager;

        public IEventBus EventBus { get; set; }

        public PmTenantsAppService(IRepository<PmTenants, long> repository,
            IRepository<PmTenantsAttachments, long> repoDetail,
            IGetCounterRepository repoProcCounter, IImageConfig imageConfig,
            IArCustomersAppService arCustomersAppService,
            IConfiguration config,
            IPmTenantsManager pmTenantsManager) : base(repository, config)
        {
            _repoDetail = repoDetail;
            _repoProcCounter = repoProcCounter;
            _imageConfig = imageConfig;
            _arCustomersAppService = arCustomersAppService;
            _pmTenantsManager = pmTenantsManager;

            CreatePermissionName = PermissionNames.Pages_PmTenants_Insert;
            UpdatePermissionName = PermissionNames.Pages_PmTenants_Update;
            DeletePermissionName = PermissionNames.Pages_PmTenants_Delete;
            GetAllPermissionName = PermissionNames.Pages_PmTenants;

            PreFileName = "PmProp-Attchs";
            ServiceFolder = "PmTenants";
        }

        protected override async Task<PmTenantsAttachments> GetAttachmentEntityAsync(long ParentId, long Id, string filePath)
        {
            return await _repoDetail.FirstOrDefaultAsync(att => att.Id == Id && att.PmTenantId == ParentId && att.FilePath == filePath); ;
        }

        public async override Task<PmTenantsDto> Create(PmTenantsCreateDto input)
        {
            CheckCreatePermission();

            input.TenantNumber = await GetTenantNumber();

            var current = MapToEntity(input);

            current = await Repository.InsertAsync(current);

            await CurrentUnitOfWork.SaveChangesAsync();

            if (input.PTAttachmentsList.Count > 0)
            {
                foreach (var item in input.PTAttachmentsList)
                {
                    item.PmTenantId = current.Id;

                    var currentPmTenantsAttachments = ObjectMapper.Map<PmTenantsAttachments>(item);

                    _ = await _repoDetail.InsertAsync(currentPmTenantsAttachments);
                }
            }

            var arCustomerDto = ObjectMapper.Map<CreateArCustomersDto>(input);
            arCustomerDto.SourceId = current.Id;

            _arCustomersAppService.SetCreatePermissionName(UpdatePermissionName);

            arCustomerDto.CustomerNumber = Convert.ToInt32(current.TenantNumber);

            await _arCustomersAppService.Create(arCustomerDto);

            return MapToEntityDto(current);
        }

        protected override IQueryable<PmTenants> CreateFilteredQuery(PagedPmTenantsResultRequestDto input)
        {
            try
            {
                var queryable = Repository.GetAllIncluding(o => o.FndStatusLkp, o => o.FndCountryLkp, o => o.FndCityLkp, o => o.FndNationalityLkp);

                if (input.Params.CountryLkpId.HasValue)
                    queryable = queryable.Where(o => o.CountryLkpId == input.Params.CountryLkpId.Value);

                if (input.Params.CityLkpId.HasValue)
                    queryable = queryable.Where(o => o.CityLkpId == input.Params.CityLkpId.Value);

                if (input.Params.NationalityLkpId.HasValue)
                    queryable = queryable.Where(o => o.NationalityLkpId == input.Params.NationalityLkpId.Value);

                if (input.Params.StatusLkpId.HasValue)
                    queryable = queryable.Where(o => o.StatusLkpId == input.Params.StatusLkpId.Value);

                if (input.Params.Id > 0)
                    queryable = queryable.Where(o => o.Id == input.Params.Id);

                if (!string.IsNullOrEmpty(input.Params.IdNumber))
                    queryable = queryable.Where(o => o.IdNumber.Contains(input.Params.IdNumber));

                if (!string.IsNullOrEmpty(input.Params.HomePhoneNumber))
                    queryable = queryable.Where(o => o.HomePhoneNumber.Contains(input.Params.HomePhoneNumber));

                if (!string.IsNullOrEmpty(input.Params.PassportNumber))
                    queryable = queryable.Where(o => o.PassportNumber.Contains(input.Params.PassportNumber) || o.CommercialLicenseNumber.Contains(input.Params.PassportNumber));

                queryable = queryable.OrderByDescending(x => x.CreationTime);

                return queryable;
            }
            catch (Exception)
            {
                return base.CreateFilteredQuery(input);
            }
        }

        public async override Task<PmTenantsDto> Update(PmTenantsEditDto input)
        {
            CheckUpdatePermission();

            _ = await base.Update(input);

            if (input.PTAttachmentsList.Count > 0)
            {
                foreach (var item in input.PTAttachmentsList)
                {
                    item.PmTenantId = input.Id;

                    if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                    {
                        var PmTenantsAttachments = await _repoDetail.GetAsync(item.Id);

                        ObjectMapper.Map(item, PmTenantsAttachments);

                        _ = await _repoDetail.UpdateAsync(PmTenantsAttachments);

                    }
                    else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                    {
                        _ = await _repoDetail.InsertAsync(ObjectMapper.Map<PmTenantsAttachments>(item));
                    }
                    else if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                    {
                        await _repoDetail.DeleteAsync((long)item.Id);
                    }
                }
            }

            var customerDto = ObjectMapper.Map<ArCustomersEditDto>(input);
            _arCustomersAppService.SetGetAllPermissionName(GetAllPermissionName);
            var customerFromDB = await _arCustomersAppService.GetAll(new PagedArCustomersResultRequestDto()
            {
                Params = new ArCustomersSearchDto() { SourceCodeLkpId = 285, SourceId = input.Id },
                OrderByValue = new Core.Helpers.Extensions.SortModel { ColId = "Id", Sort = "desc" }
            });

            if (customerFromDB.Items.Count > 0)
            {
                customerDto.Id = customerFromDB.Items.First().Id;
                _arCustomersAppService.SetUpdatePermissionName(UpdatePermissionName);
                _ = await _arCustomersAppService.Update(customerDto);
            }

            return new PmTenantsDto();
        }

        public async Task<PmTenantsDto> GetDetailAsync(EntityDto<long> input)
        {
            var current = await Repository.GetAll()
                .Include(z => z.FndStatusLkp)
                .Include(z => z.FndNationalityLkp)
                .Include(z => z.FndCountryLkp)
                .Include(z => z.FndCityLkp)

                .Include(z => z.PmTenantsAttachments)
                .Include(z => z.FndMaritalStatusLkp)
                .Include(z => z.FndPaymentMethodLkp)
                .Include(z => z.FndSpecialGenderLkp)
                .Include(z => z.FndPassportCountryLkp)

                .Where(z => z.Id == input.Id).FirstOrDefaultAsync();

            PmTenantsDto pmTenantsDto = new PmTenantsDto();

            return ObjectMapper.Map(current, pmTenantsDto);
        }

        public async override Task Delete(EntityDto<long> input)
        {
            var listDetails = await _repoDetail.GetAll().Where(z => z.PmTenantId == input.Id).Select(z => z.Id).ToListAsync();

            foreach (var taxDetailId in listDetails) await _repoDetail.DeleteAsync(taxDetailId);

            _arCustomersAppService.SetGetAllPermissionName(GetAllPermissionName);
            var customerFromDB = await _arCustomersAppService.GetAll(new PagedArCustomersResultRequestDto()
            {
                Params = new ArCustomersSearchDto() { SourceCodeLkpId = 285, SourceId = input.Id },
                OrderByValue = new Core.Helpers.Extensions.SortModel()
                {
                    Sort = "asc",
                    ColId = "Id"
                }
            });

            if (customerFromDB.Items.Count > 0)
            {
                EntityDto<long> customerDto = new EntityDto<long>();

                customerDto.Id = customerFromDB.Items.First().Id;

                _arCustomersAppService.SetDeletePermissionName(DeletePermissionName);

                await _arCustomersAppService.Delete(customerDto);
            }

            await Repository.DeleteAsync(input.Id);
        }

        public async Task<List<PmTenantsAttachmentsDto>> GetAllAttachments(EntityDto<long> input)
        {
            return ObjectMapper.Map<List<PmTenantsAttachmentsDto>>(await _repoDetail.GetAllIncluding()
                                                           .Where(d => d.PmTenantId == input.Id)
                                                           .ToListAsync());
            //var output = new List<PmTenantsAttachmentsDto>();

            //var listData = await _repoDetail.GetAllIncluding().Where(d => d.PmTenantId == input.Id).ToListAsync();

            //foreach (var item in listData)
            //{
            //    var current = new PmTenantsAttachmentsDto
            //    {
            //        Id = item.Id,
            //        AttachmentName = item.AttachmentName,
            //        PmTenantId = item.PmTenantId,
            //        rowStatus = DetailRowStatus.RowStatus.NoAction.ToString()
            //    };

            //    output.Add(current);
            //}

            //return output;
        }

        private async Task<string> GetTenantNumber(string lang = "ar-EG", int year = 0)
        {
            var counterInput = new GetCounterInputDto { CounterName = "ArCustomers", TenantId = (int)AbpSession.TenantId, Lang = lang, year = year };

            var result = await _repoProcCounter.Execute(counterInput, "GetCounter");

            return result?.FirstOrDefault()?.OutputStr ?? string.Empty;
        }

        private void CurrentUnitOfWork_Completed(object sender, EventArgs e)
        {
            // EventBus.Trigger(new PmTenantAndArCustomerAreCreatedEventData() { PmTenantId = current.Id, ArCustomerId = customer.Id });
        }

        public async Task<Select2PagedResult> GetPmTenantsNameAndIdNumberSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
            => await _pmTenantsManager.GetPmTenantsNameAndIdNumberSelect2(searchTerm, pageSize, pageNumber, lang);

        public async Task<Select2PagedResult> GetPmTenantsSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
            => await _pmTenantsManager.PmTenantsSelect2(searchTerm, pageSize, pageNumber, lang);

        private string GetFilePath(string base64, string fileExtension = ".jpeg")
            => _imageConfig.SaveImage(base64, $"PmProp-Attchs-{Guid.NewGuid().ToString()}", fileExtension, "AppAttachments/PmTenants");
    }
}
