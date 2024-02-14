using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using ERP._System.__CRM.Deals;
using ERP._System.__HR._ActivityMeeting;
using ERP._System._Counters.ProcDto;
using ERP._System._Counters.Procs;
using ERP._System.PostRecords.Dto;
using ERP.Authorization;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__CRM._ActivityMeeting.Dto
{
    public class ActivityMeetingAppService : AsyncCrudAppService<ActivityMeeting, ActivityMeetingDto, long, PagedActivityMeetingRequestDto, CreateActivityMeetingDto, ActivityMeetingEditDto>,
        IActivityMeetingAppService
    {
        private readonly IRepository<CrmDeals, long> _repoCrmDeals;
        private readonly IRepository<ActivityMeetingParticipant, long> _repoActivityMeetingParticipant;
 
        public ActivityMeetingAppService(IRepository<ActivityMeeting, long> repository,
              IRepository<CrmDeals, long> repoCrmDeals,
                  IRepository<ActivityMeetingParticipant, long> repoActivityMeetingParticipant ) : base(repository)
        {
            _repoCrmDeals = repoCrmDeals;
            _repoActivityMeetingParticipant = repoActivityMeetingParticipant;

            CreatePermissionName = PermissionNames.Pages_CrmLeadsPersons_Insert; /*PermissionNames.Pages_ActivityMeeting_Insert;*/
            UpdatePermissionName =PermissionNames.Pages_CrmLeadsPersons_Update; /*PermissionNames.Pages_ActivityMeeting_Update;*/
            DeletePermissionName =PermissionNames.Pages_CrmLeadsPersons_Delete; /*PermissionNames.Pages_ActivityMeeting_Delete;*/
            GetAllPermissionName = PermissionNames.Pages_CrmLeadsPersons;       /*PermissionNames.Pages_ActivityMeeting;*/
        }

        protected override IQueryable<ActivityMeeting> CreateFilteredQuery(PagedActivityMeetingRequestDto input)
        {
            var iqueryable = Repository.GetAllIncluding(z => z.PartiReminderLkps, x => x.CrmDeals, z => z.PartiReminderLkps
            , z => z.RelatedToLkps
            , z => z.CrmLeadsPersons );

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.Location))
                iqueryable = iqueryable.Where(z => z.Location == input.Params.Location);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.Title))
            {
                iqueryable = iqueryable.Where(z => z.Title == input.Params.Title);
            }

            if (input.Params != null &&  input.Params.CrmLeadsPersonsId!=null  )
            {
                iqueryable = iqueryable.Where(z => z.CrmLeadsPersonsId == input.Params.CrmLeadsPersonsId);
            }

            if (input.Params != null && input.Params.RelatedToLkpId != null)
            {
                iqueryable = iqueryable.Where(z => z.RelatedToLkpId == input.Params.RelatedToLkpId);
            }
            iqueryable.ForEachAsync(x => x.Lang = input.Params.Lang);

            return iqueryable;
        }

        public async override Task<ActivityMeetingDto> Create(CreateActivityMeetingDto input)
        {
            CheckCreatePermission();
 
 

            var EntityToAddDto = ObjectMapper.Map<ActivityMeeting>(input);

            _ = await Repository.InsertAsync(EntityToAddDto);
             
            if (input.ActivityMeetingParticipantList.Count() > 0)
            {
              var res= await  CRUS_Activity_Meeting_Participant(input.ActivityMeetingParticipantList, EntityToAddDto.Id);
            }

            return new ActivityMeetingDto { };
        }

        public async override Task<ActivityMeetingDto> Update(ActivityMeetingEditDto input)
        {
            CheckUpdatePermission();

            var current = await Repository.GetAsync(input.Id);

            ObjectMapper.Map(input, current);

            _ = await Repository.UpdateAsync(current);

            if (input.ActivityMeetingParticipantList.Count > 0)
            {
                var res = await CRUS_Activity_Meeting_Participant(input.ActivityMeetingParticipantList, current.Id);
            }


            return new ActivityMeetingDto { };
        }


        public async override Task<ActivityMeetingDto> Get(EntityDto<long> input)
        {
            var res = await Repository
                .GetAllIncluding(z => z.PartiReminderLkps, x => x.CrmDeals, z => z.PartiReminderLkps , z => z.CrmLeadsPersons
                , z => z.RelatedToLkps
                , z => z.ActivityMeetingParticipant)
                .Where(x => x.Id == input.Id).FirstOrDefaultAsync();
            var mapped = ObjectMapper.Map<ActivityMeetingDto>(res);
            return mapped;

        }

        
        public async Task<ActivityMeetingDto> GetSingle(EntityDto<long> input, string lang)
        {
            var res = await Repository
                .GetAllIncluding(z => z.PartiReminderLkps, x => x.CrmDeals, z => z.PartiReminderLkps , z => z.CrmLeadsPersons
                , z => z.RelatedToLkps
                , z => z.ActivityMeetingParticipant)
                .Where(x => x.Id == input.Id).FirstOrDefaultAsync();
            res.Lang = lang;
            var mapped = ObjectMapper.Map<ActivityMeetingDto>(res);
            return mapped;
        }



   




        public async Task<IReadOnlyList<ActivityMeetingParticipantDto>> GetDetailAsync(EntityDto<long> input)
        {
            try
            {
                var current = await _repoActivityMeetingParticipant
                               .GetAllIncluding(z => z.CrmLeadsPersons , z => z.RelatedToLkps)
                               .Where(z => z.ActivityMeetingId == input.Id)
                               .ToListAsync();

                var currentDto = ObjectMapper.Map<IReadOnlyList<ActivityMeetingParticipantDto>>(current);

                return currentDto;
            }
            catch (Exception x)
            {
                throw x;
            }
        }
 
        public override Task Delete(EntityDto<long> input)
        {
            var list = _repoActivityMeetingParticipant.GetAll().Where(x => x.ActivityMeetingId == input.Id);
            foreach (var item in list)
            {
                _repoActivityMeetingParticipant.Delete(item);
            }
            return base.Delete(input);
        }
 


        public async Task<bool> CRUS_Activity_Meeting_Participant(IEnumerable<ActivityMeetingParticipantDto> model ,long ActivityMeetingId)
        {


            if (model.Count() > 0)
            {
                foreach (var item in  model)
                {
                    if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                    {
                        var propUnits = await _repoActivityMeetingParticipant.GetAsync((long)item.Id);

                        item.ActivityMeetingId =ActivityMeetingId;

                        var mapped = ObjectMapper.Map(item, propUnits);

                        _ = await _repoActivityMeetingParticipant.UpdateAsync(propUnits);
                      
                    }
                    else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                    {

                        item.ActivityMeetingId = ActivityMeetingId;

                        var propUnits = ObjectMapper.Map<ActivityMeetingParticipant>(item);

                        _ = await _repoActivityMeetingParticipant.InsertAsync(propUnits);
                        

                    }
                    else if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                    {
                        await _repoActivityMeetingParticipant.DeleteAsync((long)item.Id);
                        

                    }
                }

                return true;
            }

            return false;

        }




        public async Task<Select2PagedResult> GetCrmDealsSelect2(long id, string searchTerm, int pageSize, int pageNumber, string lang)
        {

            var data = _repoCrmDeals.GetAll()
                     .Where(z => (z.Id != id) && (string.IsNullOrEmpty(searchTerm) || z.DealName.Contains(searchTerm)  ));

            long count = await data.LongCountAsync();

            var result = await data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize)
                        .Select(z => new Select2OptionModel { id = z.Id, text = $"{z.DealName} ", altText = z.Id.ToString() })
                        .ToListAsync();

            var select2pagedResult = new Select2PagedResult
            {
                Total = count,
                Results = result
            };

            return select2pagedResult;
        }






    }
}
