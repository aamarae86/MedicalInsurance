using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using ERP._System.__HR._HrPaperRequest.Dto;
using ERP._System.__HR._HRPaperRequest;
using ERP._System._Counters.ProcDto;
using ERP._System._Counters.Procs;
using ERP.Authorization;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ERP._System.__HR._HrPaperRequest
{
   

   public class HrPaperRequestAppService : AttachBaseAsyncCrudAppService<HrPaperRequest, HrPaperRequestDto, long, HrPaperRequestPagedDto, HrPaperRequestCreateDto, HrPaperRequestEditDto, AttachAuditedEntity>, IHrPaperRequestAppService
    {
        private readonly IGetCounterRepository _repoProcCounter;
        private readonly IRepository<HrPaperRequestAttachment, long> _repoHrPaperRequestAttachment;
        public HrPaperRequestAppService(IRepository<HrPaperRequest, long> repository,
             IConfiguration config,
            IRepository<HrPaperRequestAttachment, long> repoHrPaperRequestAttachment,
          IGetCounterRepository getCounterRepository) : base(repository, config)
        {
            _repoProcCounter = getCounterRepository;
            _repoHrPaperRequestAttachment = repoHrPaperRequestAttachment;


            CreatePermissionName = PermissionNames.Pages_HrPaperRequest_Insert;
            UpdatePermissionName = PermissionNames.Pages_HrPaperRequest_Update;
            DeletePermissionName = PermissionNames.Pages_HrPaperRequest_Delete;
            GetAllPermissionName = PermissionNames.Pages_HrPaperRequest;
        }

        protected override IQueryable<HrPaperRequest> CreateFilteredQuery(HrPaperRequestPagedDto input)
        {
            var iqueryable = Repository.GetAll();

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.PaperReqNumber))
                iqueryable = iqueryable.Where(z => z.PaperReqNumber.Contains(input.Params.PaperReqNumber));

      
            return iqueryable;
        }
        public async Task<HrPaperRequestDto> GetDetailAsync(EntityDto<long> input)
             => ObjectMapper.Map<HrPaperRequestDto>(await Repository.GetAll()
                 .Where(z => z.Id == input.Id)
                 .FirstOrDefaultAsync());

        public async override Task<HrPaperRequestDto> Create(HrPaperRequestCreateDto input)
        {
            try
            {
                CheckCreatePermission();
                input.PaperReqNumber = await GetHrPaperRequestNumber();
                var HrPaperRequestList = ObjectMapper.Map<HrPaperRequest>(input);

                _ = await Repository.InsertAsync(HrPaperRequestList);


                if (input.HrPaperRequestAttachmentdetails != null && input.HrPaperRequestAttachmentdetails.Count > 0)
                    foreach (var item in input.HrPaperRequestAttachmentdetails)
                        await InsertPaperRequestListData(item, HrPaperRequestList.Id);

                return new HrPaperRequestDto { };

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private async Task InsertPaperRequestListData(HrPaperRequestAttachmentDto HrPaperRequestAttachmentListDto, long masterId)
        {
            try
            {
                HrPaperRequestAttachmentListDto.HrPaperRequestId = masterId;
                var HrPaperRequestList = ObjectMapper.Map<HrPaperRequestAttachment>(HrPaperRequestAttachmentListDto);

                _ = await _repoHrPaperRequestAttachment.InsertAsync(HrPaperRequestList);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public async Task<List<HrPaperRequestAttachmentDto>> GetAllPaperRequestlistDetails(EntityDto<long> input)
        {
            var listData = await _repoHrPaperRequestAttachment.GetAllIncluding(x => x.HrPersons, x => x.PaperReqType)
                               .Where(d => d.HrPaperRequestId == input.Id).ToListAsync();

            var listDto = ObjectMapper.Map<List<HrPaperRequestAttachmentDto>>(listData);
            foreach (var item in listDto)
            {
                item.HrPersonId = item.HrPersonId;
                item.PaperReqTypeId = item.PaperReqTypeId;

            }

            return listDto;

        }


        public async override Task<HrPaperRequestDto> Update(HrPaperRequestEditDto input)
        {
            CheckUpdatePermission();

            var current = await Repository.GetAsync(input.Id);

            //if (current.StatusLkpId != Convert.ToInt64(FndEnum.FndLkps.New_HrPersonVacationsStatues))
            //    throw new UserFriendlyException(" لا يمكن التعديل");

            //input.VacationBalance = await GetVacationsBalance(input.HrPersonId, input.HrVacationsTypeId);

            //if (input.NoOfDays > input.VacationBalance) throw new UserFriendlyException("عدد الايام اكبر من الرصيد !!");

            return await base.Update(input);
        }

        public async override Task Delete(EntityDto<long> input)
        {
            var current = await Repository.GetAsync(input.Id);

            //if (current.StatusLkpId != Convert.ToInt64(FndEnum.FndLkps.New_HrPersonVacationsStatues))
            //    throw new UserFriendlyException(" لا يمكن التعديل");

            await base.Delete(input);
        }

        private async Task<string> GetHrPaperRequestNumber()
        {
            var counterInput = new GetCounterInputDto { CounterName = "HrPaperRequest", TenantId = (int)AbpSession.TenantId, Lang = "ar-EG", year = 0 };

            var result = await _repoProcCounter.Execute(counterInput, "GetCounter");

            return result?.FirstOrDefault()?.OutputStr ?? string.Empty;
        }

    }
}
