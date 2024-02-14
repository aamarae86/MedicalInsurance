using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using ERP._System.__CRM._ActivityCall;
using ERP._System.__CRM._CrmLeadsPersons.Dto;
using ERP._System.__CRM.Leads;
using ERP._System.__CRM.Leads.Dto;
using ERP._System.__CRM.Products;
using ERP._System.__CRM.Services;
using ERP._System.PostRecords.Dto;
using ERP.Authorization;
using ERP.Authorization.Users;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__PmPropertiesModule._CrmLeadsPersons
{
    [AbpAuthorize]
    public class CrmLeadsPersonsAppService : AttachBaseAsyncCrudAppService<CrmLeadsPersons, CrmLeadsPersonsDto, long, CrmLeadsPersonsPagedDto, CrmLeadsPersonsCreateDto, CrmLeadsPersonsEditDto, AttachAuditedEntity>, ICrmLeadsPersonsAppService
    {
        private readonly ICrmLeadsPersonsManager _crmLeadsPersonsManager;
        private readonly IRepository<User, long> _usersRepository;
        private readonly IRepository<ActivityCall, long> _repoActivityCall;
        private readonly IRepository<CrmLeadsPersons, long> _repoCrmLeadsPersons;

        public CrmLeadsPersonsAppService(IRepository<CrmLeadsPersons, long> repository ,
         IConfiguration config , 
         IImageConfig imageConfig ,
         IRepository<ActivityCall, long> repoActivityCall,
         IRepository<CrmLeadsPersons, long> repoCrmLeadsPersons,
         IRepository<User, long> usersRepository,
         ICrmLeadsPersonsManager crmLeadsPersonsManager
         ) : base(repository, config)
        {
            CreatePermissionName = PermissionNames.Pages_CrmLeadsPersons_Insert;
            UpdatePermissionName = PermissionNames.Pages_CrmLeadsPersons_Update;
            DeletePermissionName = PermissionNames.Pages_CrmLeadsPersons_Delete;
            GetAllPermissionName = PermissionNames.Pages_CrmLeadsPersons;


            _usersRepository = usersRepository;
            _crmLeadsPersonsManager = crmLeadsPersonsManager;
            _repoActivityCall = repoActivityCall;
            _repoCrmLeadsPersons = repoCrmLeadsPersons;
            PreFileName = "CRM";
            ServiceFolder = "CRM";
        }


        public async override Task<PagedResultDto<CrmLeadsPersonsDto>> GetAll(CrmLeadsPersonsPagedDto input)
        {
            var iqueryable = Repository        
                .GetAllIncluding(x => x.Countrys, x => x.Industrys,
                                                       x => x.LeadSources, x => x.LeadStatus, x => x.Ratings, x => x.ActivityCall, x => x.ActivityMeeting,
                                                       x => x.ActivityTasks, x => x.OtherCountryLkp )
                                                      ; //get only leads data TypeLkpId=11119
            if (input.Params.IsLead == 1)
                iqueryable = iqueryable.Where(s => s.TypeLkpId == 11119); //Lead
            else
                iqueryable = iqueryable.Where(s => s.TypeLkpId == 11121); //Contact



            if (input.Params != null && !string.IsNullOrEmpty(input.Params.City))
                iqueryable = iqueryable.Where(z => z.City.Contains(input.Params.City));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.State))
                iqueryable = iqueryable.Where(z => z.State.Contains(input.Params.State));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.FullName))
                iqueryable = iqueryable.Where(z => (z.FirstName +' '+z.LastName).Contains(input.Params.FullName));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.Company))
                iqueryable = iqueryable.Where(z => z.Company.Contains(input.Params.Company));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.Phone))
                iqueryable = iqueryable.Where(z => z.Phone.Contains(input.Params.Phone));

            if (input.Params != null && input.Params.IndustryLkpId != null)
                iqueryable = iqueryable.Where(z => z.IndustryLkpId == input.Params.IndustryLkpId);

            if (input.Params != null && input.Params.LeadSourceLkpId != null)
                iqueryable = iqueryable.Where(z => z.LeadSourceLkpId == input.Params.LeadSourceLkpId);

            if (input.Params != null && input.Params.RatingLkpId != null)
                iqueryable = iqueryable.Where(z => z.RatingLkpId == input.Params.RatingLkpId);

            if (input.Params != null && input.Params.CountryLkpId != null)
                iqueryable = iqueryable.Where(z => z.CountryLkpId == input.Params.CountryLkpId);

            if (input.Params != null && input.Params.CrmProductId != null)
                iqueryable = iqueryable.Where(z => z.CrmProductId == input.Params.CrmProductId);

            if (input.Params != null && input.Params.CrmServiceId != null)
                iqueryable = iqueryable.Where(z => z.CrmServiceId == input.Params.CrmServiceId);

            if (input.Params != null && input.Params.UserId !=null)
                iqueryable = iqueryable.Where(z => z.CreatorUserId == input.Params.UserId);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.CreatedDate))
            {
                var dt = DateTimeController.ConvertToDateTime(input.Params.CreatedDate);
                iqueryable = iqueryable.Where(z => z.CreationTime.Date == dt.Value.Date);
            }
            if (input.Params != null && !string.IsNullOrEmpty(input.Params.FromDate))
            {
                DateTime dtFrom = (DateTime)DateTimeController.ConvertToDateTime(input.Params.FromDate);

                iqueryable = iqueryable.Where(q => dtFrom.Date <= q.CreationTime.Date);
            }

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.ToDate))
            {
                DateTime dtTo = (DateTime)DateTimeController.ConvertToDateTime(input.Params.ToDate);

                iqueryable = iqueryable.Where(q => dtTo.Date >= q.CreationTime.Date);
            }

            if (input.Params != null && input.Params.CallResultLkpId != null)
            {
                long callResultLkpIdToSearch = input.Params.CallResultLkpId.Value;
                iqueryable = iqueryable.Where(z => z.ActivityCall.Any(activityCall => activityCall.CallResultLkpId == callResultLkpIdToSearch));
            }
            var count = await iqueryable.CountAsync();

            var listOrder = new List<SortModel> { new SortModel { Sort = input.OrderByValue.Sort, ColId = input.OrderByValue.ColId } };
            iqueryable = iqueryable.DynamicOrderBy(listOrder);
            iqueryable = iqueryable.Skip(input.SkipCount);
            var data = await iqueryable.Take(input.MaxResultCount).ToListAsync();
            
            var data2 = ObjectMapper.Map(data, new List<CrmLeadsPersonsDto>());

            foreach (var item in data2)
            {
                var user = await _usersRepository.FirstOrDefaultAsync(c => c.Id == item.CreatorUserId.Value);
                if (user != null)
                    item.CreatedBy = user.UserName;

                if (item.ActivityCall.Count() > 0)
                {
                    var selectedActivityCall = _repoActivityCall.GetAllIncluding(x => x.CallResultLkps).Where(x => x.Id == item.ActivityCall.FirstOrDefault().Id).ToList();
                    item.CallResultLkpVal = item.ActivityCall?.FirstOrDefault()?.CallResultLkps?.NameEn;
                }
                else
                {
                    item.CallResultLkpVal = "null";
                }

            }
       




            var PagedResultDto = new PagedResultDto<CrmLeadsPersonsDto>()
            {
                Items = data2 as IReadOnlyList<CrmLeadsPersonsDto>,
                TotalCount = count
            };

            return PagedResultDto;

        }        

        public async override Task<CrmLeadsPersonsDto> Get(EntityDto<long> input)
            => ObjectMapper.Map<CrmLeadsPersonsDto>(await Repository
                .GetAllIncluding(x => x.Countrys, x => x.Industrys, x => x.LeadSources, x => x.LeadStatus, x => x.Ratings
                 , x => x.OtherCountryLkp ,x => x.CrmProducts , x => x.CrmServices ).Where(x => x.Id == input.Id).FirstOrDefaultAsync());


        public async Task<CrmLeadsPersonsDto> Get1(EntityDto<long> input, string lang)
        { 
            var res= await Repository.GetAllIncluding(x => x.Countrys, x => x.Industrys, x => x.LeadSources, x => x.LeadStatus, x => x.Ratings
             , x => x.OtherCountryLkp, x => x.CrmProducts, x => x.CrmServices).Where(x => x.Id == input.Id).FirstOrDefaultAsync();
            res.Lang = lang;

            var result = ObjectMapper.Map<CrmLeadsPersonsDto>(res);
            var user = await _usersRepository.FirstOrDefaultAsync(c => c.Id == result.CreatorUserId);

            if (user != null)
                result.CreatedBy = user.UserName;

            return result;
        }
        public async Task<PagedResultDto<CrmLeadsPersonsDto>> GetCrmQueries(CrmLeadsPersonsPagedDto input)
        {
            var dataList = await Repository.GetAllIncluding(x => x.Countrys, x => x.Industrys, x => x.ActivityCall,
                x => x.ActivityMeeting, x => x.ActivityTasks, x => x.OtherCountryLkp).ToListAsync();

            if (input.Params != null && input.Params.UserId != null)
                dataList = dataList.Where(z => z.CreatorUserId == input.Params.UserId).ToList();

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.CreatedDate))
            {
                var dt = DateTimeController.ConvertToDateTime(input.Params.CreatedDate);
                dataList = dataList.Where(z => z.CreationTime.Date == dt.Value.Date).ToList();
            }

            var queryable = dataList.SelectMany(x => x.ActivityCall, (x, call) => new { x, call })
                    .Select(z => new CrmLeadsPersonsDto
                    {
                        Id = z.x.Id,
                        FirstName = z.x.FirstName,
                        LastName = z.x.LastName,
                        Phone = z.x.Phone,
                        Email = z.x.Email,
                        CountryVal = z.x.Countrys.GetLookupValue(),
                        IndustryVal = z.x.Industrys.GetLookupValue(),
                        City = z.x.City,
                        Company = z.x.Company,
                        ActivityType = input.Params.Lang == "ar-EG" ? "إتصال" : "Call",
                        ActivityDate = z.call.StartDate.ToString(Formatters.DateFormat),
                        CreatorUserId = z.call.CreatorUserId,
                        PostUserId = z.call.PostUserId,
                        UnPostUserId = z.call.UnPostUserId,
                        CreationTime = z.x.CreationTime
                        
                    }).Union(dataList.SelectMany(x => x.ActivityMeeting, (x, meet) => new { x, meet })
                    .Select(z => new CrmLeadsPersonsDto
                    {
                        Id = z.x.Id,
                        FirstName = z.x.FirstName,
                        LastName = z.x.LastName,
                        Phone = z.x.Phone,
                        Email = z.x.Email,
                        CountryVal = z.x.Countrys.GetLookupValue(),
                        IndustryVal = z.x.Industrys.GetLookupValue(),
                        City = z.x.City,
                        Company = z.x.Company,
                        ActivityType = input.Params.Lang == "ar-EG" ? "إجتماع" : "Meeting",
                        ActivityDate = z.meet.FromDay.ToString(Formatters.DateFormat),

                        CreatorUserId = z.meet.CreatorUserId,
                        PostUserId = z.meet.PostUserId,
                        UnPostUserId = z.meet.UnPostUserId,
                        CreationTime = z.x.CreationTime

                    })).Union(dataList.SelectMany(x => x.ActivityTasks, (x, meet) => new { x, meet })
                    .Select(z => new CrmLeadsPersonsDto
                    {
                        Id = z.x.Id,
                        FirstName = z.x.FirstName,
                        LastName = z.x.LastName,
                        Phone = z.x.Phone,
                        Email = z.x.Email,
                        CountryVal = z.x.Countrys.GetLookupValue(),
                        IndustryVal = z.x.Industrys.GetLookupValue(),
                        City = z.x.City,
                        Company = z.x.Company,
                        ActivityType = input.Params.Lang == "ar-EG" ? "مهمة" : "Task",
                        ActivityDate = z.meet.DueDate.ToString(Formatters.DateFormat),
                        CreatorUserId = z.meet.CreatorUserId,
                        PostUserId = z.meet.PostUserId,
                        UnPostUserId = z.meet.UnPostUserId,
                        CreationTime = z.x.CreationTime

                    })).OrderBy(a => a.ActivityDate).ToList();

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.Email))
                queryable = queryable.Where(z => string.IsNullOrEmpty(z.Email) ? false : z.Email.Contains(input.Params.Email)).ToList();

            if (input.Params != null && input.Params.Company != null)
                queryable = queryable.Where(z => string.IsNullOrEmpty(z.Company) ? false : z.Company.Contains(input.Params.Company)).ToList();

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.FullName))
                queryable = queryable.Where(z => z.FirstName + " " + z.LastName == input.Params.FullName).ToList();

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.ActivityType))
                queryable = queryable.Where(z => z.ActivityType == input.Params.ActivityType).ToList();

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.Phone))
                queryable = queryable.Where(z => string.IsNullOrEmpty(z.Phone) ? false : z.Phone.Contains(input.Params.Phone)).ToList();

            if (!string.IsNullOrEmpty(input.Params.FromDate))
            {
                DateTime fromDate = (DateTime)DateTimeController.ConvertToDateTime(input.Params.FromDate);

                queryable = queryable.Where(z => (DateTime)DateTimeController.ConvertToDateTime(z.ActivityDate) >= fromDate).ToList();
            }

            if (!string.IsNullOrEmpty(input.Params.ToDate))
            {
                DateTime toDate = (DateTime)DateTimeController.ConvertToDateTime(input.Params.ToDate);
                queryable = queryable.Where(z => (DateTime)DateTimeController.ConvertToDateTime(z.ActivityDate) <= toDate).ToList();
            }
            var count =  queryable.Count();

            var listOrder = new List<SortModel> { new SortModel { Sort = input.OrderByValue.Sort, ColId = input.OrderByValue.ColId } };

            //queryable = 
            var result = queryable.AsQueryable();

            result = result.DynamicOrderBy(listOrder);
            result = result.Skip(input.SkipCount).Take(input.MaxResultCount);


            var dataMapped = ObjectMapper.Map(result, new List<CrmLeadsPersonsDto>());

            var PagedResultDto = new PagedResultDto<CrmLeadsPersonsDto>()
            {
                Items = dataMapped as IReadOnlyList<CrmLeadsPersonsDto>,
                TotalCount = count
            };

            return PagedResultDto;

            //queryable = queryable.DynamicOrderBy(listOrder);
            //queryable = queryable.Skip(input.SkipCount);

            //var data = await queryable.Take(input.MaxResultCount).ToListAsync();

            //var dataMapped = ObjectMapper.Map(data, new List<CrmLeadsPersonsDto>());

            //var PagedResultDto = new PagedResultDto<CrmLeadsPersonsDto>()
            //{
            //    Items = dataMapped as IReadOnlyList<CrmLeadsPersonsDto>,
            //    TotalCount = count
            //};

            //return PagedResultDto;
            //queryable = queryable.Skip(input.SkipCount).Take(input.MaxResultCount).ToList();
            //return queryable;
        }
        public async override Task<CrmLeadsPersonsDto> Create(CrmLeadsPersonsCreateDto input)
        {

            if ( input.IsLead == 1 )
            {
                input.TypeLkpId = 11119;
            }
            else
            {
                input.TypeLkpId = 11121;
            }



            CheckCreatePermission();
            return await base.Create(input);
        }

        public async override Task<CrmLeadsPersonsDto> Update(CrmLeadsPersonsEditDto input)
        {
            var entityToUpdate=await Get(new EntityDto<long> { Id = input.Id });
            input.TypeLkpId = entityToUpdate.TypeLkpId;
            CheckUpdatePermission();
            return await base.Update(input);
        }

        public async Task<PostOutput> ConvertLeadToContact(EntityDto<long> input  )
        {

           var Lead= Repository.Get(input.Id);

            Lead.TypeLkpId = 11121; // convert statues from lead to contact
            Lead.WasLead = true;
            Lead.ConvertDate = DateTime.Now;
            Lead.UserConvertId = AbpSession.UserId;
            Repository.Update(Lead);

            return new PostOutput {FinalStatues="success" , Reason= "تم التحويل بنجاح" };
        }

        public async Task<Select2PagedResult> GetLeadsNameSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
            => await _crmLeadsPersonsManager.GetLeadsNameSelect2(searchTerm, pageSize, pageNumber, lang);
        #region Contacts

        #endregion



    }
}
