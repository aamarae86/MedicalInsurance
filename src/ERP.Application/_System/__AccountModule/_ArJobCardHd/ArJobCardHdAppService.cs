using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP.Authorization;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP._System.__AccountModule._ArJobCardHd.Dto;
using ERP._System.PostRecords.Dto;
using ERP._System.__PmPropertiesModule._ArInvoiceHd;
using ERP._System._FndLookupValues;
using Microsoft.AspNetCore.Mvc;

namespace ERP._System.__AccountModule._ArJobCardHd
{
    [AbpAuthorize]
    public class ArJobCardHdAppService : AttachBaseAsyncCrudAppService<ArJobCardHd, ArJobCardHdDto, long, ArJobCardHdPagedDto, ArJobCardHdCreateDto, ArJobCardHdEditDto, AttachAuditedEntity>, IArJobCardHdAppService
    {
        private readonly IRepository<ArInvoiceHd, long> _repoArInvoiceHd; 
        private readonly IRepository<ArJobCardAttachments, long> _repoArJobCardAttachments;
        private readonly IArJobCardRepository _arJobCardRepository;
        private readonly IArJobCardHdManager _arJobCardHdManager;
        private readonly IRepository<FndLookupValues, long> _repoFndLookupValues;

        public ArJobCardHdAppService(IRepository<ArJobCardHd, long> repository ,
            IArJobCardRepository arJobCardRepository
            , IConfiguration config
            , IRepository<ArJobCardAttachments, long> repoArJobCardAttachments
            , IRepository<ArInvoiceHd, long> repoArInvoiceHd
            , IRepository<FndLookupValues, long> repoFndLookupValues
            , IArJobCardHdManager arJobCardHdManager) : base(repository, config)
        {
            _repoArInvoiceHd = repoArInvoiceHd;
            _repoArJobCardAttachments = repoArJobCardAttachments;
            _arJobCardRepository = arJobCardRepository;
            _arJobCardHdManager = arJobCardHdManager;
            _repoFndLookupValues = repoFndLookupValues;

            CreatePermissionName = PermissionNames.Pages_ArJobCardHd_Insert;
            UpdatePermissionName = PermissionNames.Pages_ArJobCardHd_Update;
            DeletePermissionName = PermissionNames.Pages_ArJobCardHd_Delete;
            GetAllPermissionName = PermissionNames.Pages_ArJobCardHd;

            PreFileName = "JobCardHd";
            ServiceFolder = "JobCardHd";
        }
        protected override IQueryable<ArJobCardHd> CreateFilteredQuery(ArJobCardHdPagedDto input)
        {
            //var iqueryable = Repository.GetAll();
            var iqueryable = Repository.GetAllIncluding(x => x.FndExcessStatusLkp, x => x.FndJobTypeLkp, x => x.FndVehicleColorLkp,
                                                        x => x.FndVehicleEmirateLkp, x => x.FndVehicleMakeLkp, x => x.FndVehicleModelLkp,x => x.FndStatusLkp,
                                                         x => x.ArCustomers , x=>x.FndSalesMen, x=>x.FndPoliceReportSourceLkp);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.JobNumber))
                iqueryable = iqueryable.Where(z => z.JobNumber.Contains(input.Params.JobNumber));

            if (input.Params != null && input.Params.StatusLkpId != null)
                iqueryable = iqueryable.Where(z => z.StatusLkpId == input.Params.StatusLkpId);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.ClaimNo))
                iqueryable = iqueryable.Where(z => z.ClaimNo.Contains(input.Params.ClaimNo));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.JobDate))
            {
                var dt = DateTimeController.ConvertToDateTime(input.Params.JobDate);

                iqueryable = iqueryable.Where(z => z.JobDate == dt);
            }

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.VehiclePlateNo))
                iqueryable = iqueryable.Where(z => z.VehiclePlateNo.Contains(input.Params.VehiclePlateNo));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.LpoNo))
                iqueryable = iqueryable.Where(z => z.LpoNo.Contains(input.Params.LpoNo));

            if (input.Params != null && input.Params.JobTypeLkpId != null)
                iqueryable = iqueryable.Where(z => z.JobTypeLkpId == input.Params.JobTypeLkpId);

            if (input.Params != null && input.Params.VehicleEmirateLkpId != null)
                iqueryable = iqueryable.Where(z => z.VehicleEmirateLkpId == input.Params.VehicleEmirateLkpId);

            if (input.Params != null && input.Params.VehicleColorLkpId != null)
                iqueryable = iqueryable.Where(z => z.VehicleColorLkpId == input.Params.VehicleColorLkpId);

            if (input.Params != null && input.Params.ArCustomerId != null)
                iqueryable = iqueryable.Where(z => z.ArCustomerId == input.Params.ArCustomerId);

            if (input.Params != null && input.Params.VehicleMakeLkpId != null)
                iqueryable = iqueryable.Where(z => z.VehicleMakeLkpId == input.Params.VehicleMakeLkpId);

            if (input.Params != null && input.Params.VehicleModelLkpId != null)
                iqueryable = iqueryable.Where(z => z.VehicleModelLkpId == input.Params.VehicleModelLkpId);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.VehicleType))
                iqueryable = iqueryable.Where(z => z.VehicleType.Contains(input.Params.VehicleType));

            return iqueryable;
        }
        public async  Task<PagedResultDto<ArJobCardHdDto>> GetAllArJobCards(ArJobCardHdPagedDto input)
        {
            var returnedModel = new PagedResultDto<ArJobCardHdDto>();
            var jobCards =  Repository.GetAllIncluding(x => x.FndExcessStatusLkp, x => x.FndJobTypeLkp, x => x.FndVehicleColorLkp,
                                  x => x.FndVehicleEmirateLkp, x => x.FndVehicleMakeLkp, x => x.FndVehicleModelLkp,x=>x.FndStatusLkp,
                                  x => x.ArCustomers , x => x.FndSalesMen, x=>x.FndPoliceReportSourceLkp);
            #region filter
            if (input.Params != null && !string.IsNullOrEmpty(input.Params.JobNumber))
                jobCards = jobCards.Where(z => z.JobNumber.Contains(input.Params.JobNumber));

            if (input.Params != null && input.Params.StatusLkpId != null)
                jobCards = jobCards.Where(z => z.StatusLkpId == input.Params.StatusLkpId);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.ClaimNo))
                jobCards = jobCards.Where(z => z.ClaimNo.Contains(input.Params.ClaimNo));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.JobDate))
            {
                var dt = DateTimeController.ConvertToDateTime(input.Params.JobDate);

                jobCards = jobCards.Where(z => z.JobDate == dt);
            }

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.VehiclePlateNo))
                jobCards = jobCards.Where(z => z.VehiclePlateNo.Contains(input.Params.VehiclePlateNo));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.LpoNo))
                jobCards = jobCards.Where(z => z.LpoNo.Contains(input.Params.LpoNo));

            if (input.Params != null && input.Params.JobTypeLkpId != null)
                jobCards = jobCards.Where(z => z.JobTypeLkpId == input.Params.JobTypeLkpId);

            if (input.Params != null && input.Params.VehicleEmirateLkpId != null)
                jobCards = jobCards.Where(z => z.VehicleEmirateLkpId == input.Params.VehicleEmirateLkpId);

            if (input.Params != null && input.Params.VehicleColorLkpId != null)
                jobCards = jobCards.Where(z => z.VehicleColorLkpId == input.Params.VehicleColorLkpId);

            if (input.Params != null && input.Params.ArCustomerId != null)
                jobCards = jobCards.Where(z => z.ArCustomerId == input.Params.ArCustomerId);

            if (input.Params != null && input.Params.VehicleMakeLkpId != null)
                jobCards = jobCards.Where(z => z.VehicleMakeLkpId == input.Params.VehicleMakeLkpId);

            if (input.Params != null && input.Params.VehicleModelLkpId != null)
                jobCards = jobCards.Where(z => z.VehicleModelLkpId == input.Params.VehicleModelLkpId);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.VehicleType))
                jobCards = jobCards.Where(z => z.VehicleType.Contains(input.Params.VehicleType));
            #endregion

            var jobCardsMapped = ObjectMapper.Map(jobCards, new List<ArJobCardHdDto>());
            returnedModel.TotalCount = jobCardsMapped.Count();
            returnedModel.Items = jobCardsMapped;

            return returnedModel;
        }
     
        public async Task<bool> GetCheckForClaimAndLpo(string claim,string lpo)
        {
          
            var jobCards =await Repository.GetAll().Where(x => x.LpoNo == lpo && x.ClaimNo == claim ).FirstOrDefaultAsync();

            if (jobCards != null) return true;

            return false;
        }
       
        public async Task<PagedResultDto<ArJobCardHdDto>> GetCheckForVehiclePlateAndEmirate(string plateno, long emirate)
        {
            try
            {
                var returnedModel = new PagedResultDto<ArJobCardHdDto>();
                var jobCards = await Repository.GetAll().Where(x => x.VehiclePlateNo == plateno && x.VehicleEmirateLkpId == emirate).ToListAsync();


                var jobCardsMapped = ObjectMapper.Map(jobCards, new List<ArJobCardHdDto>());
                returnedModel.TotalCount = jobCardsMapped.Count();
                returnedModel.Items = jobCardsMapped;
                return returnedModel;
            }
            catch (System.Exception e)
            {

                throw;
            }
          
           
        }

        public async override Task<ArJobCardHdDto> Create(ArJobCardHdCreateDto input)
        {
            try
            {
                CheckCreatePermission();
                input.CustomerVatPercentage = input.ExcessVatPercentage = 5;
                var arJobCardHd = await base.Create(input);

                if (input.ArJobCardAttachments?.Count > 0)
                    foreach (var item in input.ArJobCardAttachments)
                        await InsertArJobCardAttachmentsData(item, arJobCardHd.Id);
            }
            catch (System.Exception ex)
            {
                throw;
            }
            return new ArJobCardHdDto { };
        }

        public async Task<ArJobCardHdDto> SaveCreditNoteAsync(ArJobCardHdEditDto input) 
        {
            try
            {
                var entity = await Repository.FirstOrDefaultAsync(z => z.Id == input.Id);
                entity.CreditNote = input.CreditNote;
                var postResult = await _arJobCardRepository.UpdateAsync(entity);

                return new ArJobCardHdDto { };
            }
            catch (System.Exception ex){                
                throw;
            }            
        }

        public async override Task<ArJobCardHdDto> Update(ArJobCardHdEditDto input)
        {
            CheckUpdatePermission();

            _ = await base.Update(input);

            await CRUD_ArJobCardAttachments(input.ArJobCardAttachments, input.Id);

            return new ArJobCardHdDto { };
        }
        public async Task<ArJobCardHdDto> GetDetailAsync(EntityDto<long> input)
        {
            var data = await Repository.GetAllIncluding(x => x.FndExcessStatusLkp, x => x.FndJobTypeLkp, x => x.FndVehicleColorLkp,
                                  x => x.FndVehicleEmirateLkp, x => x.FndVehicleMakeLkp, x => x.FndVehicleModelLkp, x => x.FndStatusLkp,
                                  x => x.ArCustomers, x => x.FndSalesMen, x => x.FndPoliceReportSourceLkp)
                           .Where(z => z.Id == input.Id).FirstOrDefaultAsync();

            var mapped = ObjectMapper.Map<ArJobCardHdDto>(data);
            return mapped;
        }
        public async override Task<ArJobCardHdDto> Get(EntityDto<long> input)
        {
            return ObjectMapper.Map<ArJobCardHdDto>(await Repository.GetAllIncluding(x => x.FndExcessStatusLkp, x => x.FndJobTypeLkp, x => x.FndVehicleColorLkp, x => x.FndStatusLkp,
                                  x => x.FndVehicleEmirateLkp, x => x.FndVehicleMakeLkp, x => x.FndVehicleModelLkp, x=>x.FndPoliceReportSourceLkp).Where(x => x.Id == input.Id).FirstOrDefaultAsync());
        }
        private async Task InsertArJobCardAttachmentsData(ArJobCardAttachmentsDto attachmentsDto, long jobCardId)
        {
            attachmentsDto.ArJobCardHdId = jobCardId;

            var attachments = ObjectMapper.Map<ArJobCardAttachments>(attachmentsDto);

            _ = await _repoArJobCardAttachments.InsertAsync(attachments);

        }
        private async Task CRUD_ArJobCardAttachments(ICollection<ArJobCardAttachmentsDto> attachmentsDtos, long jobCardId)
        {
            if (attachmentsDtos?.Count > 0)
            {
                foreach (var item in attachmentsDtos)
                {
                    if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                    {
                        var attachments = await _repoArJobCardAttachments.GetAsync((long)item.Id);

                        item.ArJobCardHdId = jobCardId;

                        ObjectMapper.Map(item, attachments);

                        _ = await _repoArJobCardAttachments.UpdateAsync(attachments);
                    }
                    else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                    {
                        await InsertArJobCardAttachmentsData(item, jobCardId);
                    }
                    else if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                    {
                        await _repoArJobCardAttachments.DeleteAsync((long)item.Id);
                    }
                }
            }
        }
        public async Task<List<ArJobCardAttachmentsDto>> GetAllAttachments(EntityDto<long> input)
        {
            var listData = await _repoArJobCardAttachments.GetAllListAsync(d => d.ArJobCardHdId == input.Id);

            return ObjectMapper.Map<List<ArJobCardAttachmentsDto>>(listData);
        }

        public async Task<PostOutput> PostArJobCard(PostDto input)
        {
            if (AbpSession.UserId.HasValue) { input.UserId = AbpSession.UserId.Value; }

            var postResult = await _arJobCardRepository.Execute(input, "ArJobCardHdPost");

            return postResult.FirstOrDefault();
        }
        public async Task<PostOutput> UnPostArJobCard(PostDto input)
        {
            if (AbpSession.UserId.HasValue) { input.UserId = AbpSession.UserId.Value; }

            var unpostResult = await _arJobCardRepository.Execute(input, "ArJobCardHdUnPost");

            return unpostResult.FirstOrDefault();
        }

        public string GetCustomerInvoiceNo (EntityDto<long> input)
        {
            var invoiceNo = _repoArInvoiceHd.GetAll().Where(x => x.SourceId == input.Id && x.SourceLkpId == 11564).Select(x => x.HdInvoiceNo).FirstOrDefault();
            return invoiceNo;
        }

        public string GetExcessInvoiceNo (EntityDto<long> input)
        {
            var invoiceNo = _repoArInvoiceHd.GetAll().Where(x => x.SourceId == input.Id && x.SourceLkpId == 11565).Select(x => x.HdInvoiceNo).FirstOrDefault();
            return invoiceNo;
        }
        public string CheckJobNumber(string jobNum)
        {
            var jobNumber =    Repository.GetAll().Select(x=>x.JobNumber).Where(q =>q == jobNum).ToList();
            if(jobNumber.Count() == 0)
            {
                return "true";
            }
            else
            {
                return "false";
            }
            
        }


        public async Task<Select2PagedResult> GetArJobCardHdJobNumberSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {

            var data = await Repository.GetAll()
                         .Where(z => string.IsNullOrEmpty(searchTerm) || z.JobNumber.Contains(searchTerm) && z.TenantId == (int)AbpSession.TenantId)
                         .ToListAsync();

            var result = data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = z.JobNumber, altText = z.JobNumber.ToString() }).ToList();

            var select2pagedResult = new Select2PagedResult
            {
                Total = data.Count(),
                Results = result
            };

            return select2pagedResult;
        }

        public async Task<Select2PagedResult> GetArJobCardHdJobNumberByCustomerIdSelect2(string searchTerm, int pageSize, int pageNumber, string lang, long customerId = 0)
        {

            var data = await Repository.GetAll()
                         .Where(z => z.ArCustomerId == customerId && z.TenantId == (int)AbpSession.TenantId 
                                && string.IsNullOrEmpty(searchTerm) || z.JobNumber.Contains(searchTerm))
                         .ToListAsync();

            var result = data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = z.JobNumber, altText = z.JobNumber.ToString() }).ToList();

            var select2pagedResult = new Select2PagedResult
            {
                Total = data.Count(),
                Results = result
            };

            return select2pagedResult;
        }

        public async Task<List<ArJobCardScreenDataOutput>> GetArJobCardScreenData(EntityDto<long> input)
        {
            var mapped = ObjectMapper.Map<List<ArJobCardScreenDataOutput>>( Repository.GetAllIncluding(x => x.FndExcessStatusLkp, x => x.FndJobTypeLkp, x => x.FndVehicleColorLkp,
                                  x => x.FndVehicleEmirateLkp, x => x.FndVehicleMakeLkp, x => x.FndVehicleModelLkp, x => x.FndStatusLkp,
                                  x => x.ArCustomers, x => x.FndSalesMen,x=>x.FndPoliceReportSourceLkp)
                           .Where(z => z.Id == input.Id).ToList() );

            
            return mapped;
        }

        public async Task CloseArJobCard(ArJobCardHdDto input)
        {
            try
            {
                var entity = await Repository.FirstOrDefaultAsync(z => z.Id == input.Id);
                if (entity == null){                    
                    return;
                }
                var closelkpId = _repoFndLookupValues.FirstOrDefault(c => c.LookupType == "ArJobCardStatus" && c.NameEn == "Closed")?.Id;
                entity.CloseReason = input.CloseReason;
                entity.StatusLkpId = closelkpId;

                var result = await Repository.UpdateAsync(entity);

            }
            catch (System.Exception ex)
            {
                throw;
            }
        }
    }
}
