using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System.__HR._HrPersons._HrPersonIdentityCard;
using ERP._System.__HR._HrPersons._HrPersonPassportDetails;
using ERP._System.__HR._HrPersons._HrPersonSalaryElements;
using ERP._System.__HR._HrPersons._HrPersonVisaDetails;
using ERP._System.__HR._HrPersons.Dto;
using ERP._System.__HR._PyElements;
using ERP._System._Counters.ProcDto;
using ERP._System._Counters.Procs;
using ERP.Authorization;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Org.BouncyCastle.Math.EC.Rfc7748;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__HR._HrPersons
{
    [AbpAuthorize]
    public class HrPersonsAppService : AttachBaseAsyncCrudAppService<HrPersons, HrPersonsDto, long, HrPersonsPagedDto, HrPersonsCreateDto, HrPersonsEditDto, AttachAuditedEntity>, IHrPersonsAppService
    {
        private readonly IHrPersonsManager _hrPersonsManager;
        private readonly IGetCounterRepository _repoProcCounter;
        private readonly IPyElementsManager _pyElementsManager;
        private readonly IRepository<HrPersonVisaDetails, long> _repoHrPersonVisaDetails;
        private readonly IRepository<HrPersonPassportDetails, long> _repoHrPersonPassportDetails;
        private readonly IRepository<HrPersonIdentityCard, long> _repoHrPersonIdentityCard;
        private readonly IRepository<HrPersonSalaryElements, long> _repoHrPersonSalaryElements;
        private readonly IRepository<HrPersonAttachments, long> _repoHrPersonAttachments;

        public HrPersonsAppService(IRepository<HrPersons, long> repository,
            IRepository<HrPersonVisaDetails, long> repoHrPersonVisaDetails,
            IRepository<HrPersonPassportDetails, long> repoHrPersonPassportDetails,
            IRepository<HrPersonIdentityCard, long> repoHrPersonIdentityCard,
            IRepository<HrPersonSalaryElements, long> repoHrPersonSalaryElements,
            IHrPersonsManager hrPersonsManager, IPyElementsManager pyElementsManager,
            IConfiguration config, IRepository<HrPersonAttachments, long> repoHrPersonAttachments,
            IGetCounterRepository getCounterRepository) : base(repository, config)
        {
            _repoProcCounter = getCounterRepository;
            _hrPersonsManager = hrPersonsManager;
            _pyElementsManager = pyElementsManager;
            _repoHrPersonAttachments = repoHrPersonAttachments;
            _repoHrPersonVisaDetails = repoHrPersonVisaDetails;
            _repoHrPersonIdentityCard = repoHrPersonIdentityCard;
            _repoHrPersonSalaryElements = repoHrPersonSalaryElements;
            _repoHrPersonPassportDetails = repoHrPersonPassportDetails;

            CreatePermissionName = PermissionNames.Pages_HrPersons_Insert;
            UpdatePermissionName = PermissionNames.Pages_HrPersons_Update;
            DeletePermissionName = PermissionNames.Pages_HrPersons_Delete;
            GetAllPermissionName = PermissionNames.Pages_HrPersons;

            PreFileName = "HrPerson-Profile";
            ServiceFolder = "HrPerson-Profile";
        }

        protected override IQueryable<HrPersons> CreateFilteredQuery(HrPersonsPagedDto input)
        {
            var iqueryable = Repository.GetAllIncluding(x => x.FndStatusLkp, x => x.FndNationalityLkp);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.FirstName))
                iqueryable = iqueryable.Where(z => z.GetFullName().Contains(input.Params.FirstName));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.EmployeeNumber))
                iqueryable = iqueryable.Where(z => z.EmployeeNumber.Contains(input.Params.EmployeeNumber));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.AccountNumber))
                iqueryable = iqueryable.Where(z => z.EmployeeNumber.Contains(input.Params.AccountNumber));

            if (input.Params != null && input.Params.NationalityLkpId != null)
                iqueryable = iqueryable.Where(z => z.NationalityLkpId == input.Params.NationalityLkpId);

            if (input.Params != null && input.Params.StatusLkpId != null)
                iqueryable = iqueryable.Where(z => z.StatusLkpId == input.Params.StatusLkpId);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.HireDate))
            {
                var dt = DateTimeController.ConvertToDateTime(input.Params.HireDate);

                iqueryable = iqueryable.Where(z => z.HireDate == dt);
            }

            return iqueryable;
        }

        public async override Task<HrPersonsDto> Create(HrPersonsCreateDto input)
        {
            CheckCreatePermission();

            input.EmployeeNumber = await GetPersonNumber();

            var hrPersons = await base.Create(input);

            if (input.VisaDetails != null && input.VisaDetails.Count > 0)
                foreach (var item in input.VisaDetails)
                    await InsertHrPersonVisaData(item, hrPersons.Id);

            if (input.PassportDetails != null && input.PassportDetails.Count > 0)
                foreach (var item in input.PassportDetails)
                    await InsertHrPersonPassportData(item, hrPersons.Id);

            if (input.IdentityCards != null && input.IdentityCards.Count > 0)
                foreach (var item in input.IdentityCards)
                    await InsertPersonIdentityCardData(item, hrPersons.Id);

            if (input.SalaryElements != null && input.SalaryElements.Count > 0)
                foreach (var item in input.SalaryElements)
                    await InsertHrPersonSalaryElementsData(item, hrPersons.Id);

            if (input.Attachments?.Count > 0)
                foreach (var item in input.Attachments)
                    await InsertHrPersonAttachmentsData(item, hrPersons.Id);

            return new HrPersonsDto { };
        }

        public async override Task<HrPersonsDto> Update(HrPersonsEditDto input)
        {
            CheckUpdatePermission();

            _ = await base.Update(input);

            await CRUD_HrPersonVisa(input.VisaDetails, input.Id);
            await CRUD_HrPersonPassport(input.PassportDetails, input.Id);
            await CRUD_HrPersonIdentityCard(input.IdentityCards, input.Id);
            await CRUD_HrPersonSalaryElements(input.SalaryElements, input.Id);
            await CRUD_HrPersonAttachments(input.Attachments, input.Id);

            return new HrPersonsDto { };
        }

        public async Task<HrPersonsDto> GetDetailAsync(EntityDto<long> input)
        {
            var mapped = ObjectMapper.Map<HrPersonsDto>(await Repository
                           .GetAllIncluding(x => x.FndBankLkp, x => x.FndCountryOfBrithLkp, x => x.FndDestinationCountryLkp,
                                  x => x.FndNoticeUnitLkp, x => x.FndPaymentTypeLkp, x => x.FndPersonCategoryLkp,
                                  x => x.FndPersonTypeLkp, x => x.FndProbationUnitLkp, x => x.FndSponserLkp, x => x.FndFirstTitleLkp,
                                  x => x.FndJobGradeLkp, x => x.FndGenderLkp, x => x.PyPayrollTypes, x => x.FndJobLkp,
                                  x => x.FndTicketClassLkp, x => x.HrOrganizationsBranch, x => x.HrOrganizationsDept,
                                  x => x.HrPersonSupervisor, x => x.FndStatusLkp, x => x.FndMaritalStatusLkp, x => x.FndNationalityLkp)
                           .Where(z => z.Id == input.Id).FirstOrDefaultAsync());

            //mapped.base64Str = string.IsNullOrEmpty(mapped.PersonPhoto) ? string.Empty : _imageConfig.ConvertToBase64String(mapped.PersonPhoto, Path.GetExtension(mapped.PersonPhoto), "AppAttachments/HrPerson-Profile");
            //mapped.fileExt = Path.GetExtension(mapped.PersonPhoto);

            return mapped;
        }
        public async Task<HrPersonsDto> LoginHrPerson(HrPersonsDto input)
        {
            var mapped = ObjectMapper.Map<HrPersonsDto>(await Repository.GetAll()
                            .Where(z => z.EmailAddress == input.EmailAddress && z.PhoneNumber == input.PhoneNumber).FirstOrDefaultAsync());
            return mapped;
        }
        public async override Task<HrPersonsDto> Get(EntityDto<long> input)
        {
            return ObjectMapper.Map<HrPersonsDto>(await Repository.GetAllIncluding(x=>x.FndGenderLkp , x=>x.FndNationalityLkp).Where(x=>x.Id == input.Id).FirstOrDefaultAsync());
        }

        public async Task<List<HrPersonVisaDetailsDto>> GetAllPersonVisaData(EntityDto<long> input)
        {
            var listData = await _repoHrPersonVisaDetails
                               .GetAllIncluding(x => x.FndIssuedByLkp, x => x.FndPlaceOfIssueLkp, x => x.FndVisaTypeLkp)
                               .Where(d => d.HrPersonId == input.Id).ToListAsync();

            return ObjectMapper.Map<List<HrPersonVisaDetailsDto>>(listData);
        }

        public async Task<List<HrPersonPassportDetailsDto>> GetAllPersonPassportData(EntityDto<long> input)
        {
            var listData = await _repoHrPersonPassportDetails.GetAllIncluding(
                                             x => x.FndCountryOfIssueLkp, x => x.FndPassportTypeLkp
                                    ).Where(d => d.HrPersonId == input.Id).ToListAsync();

            return ObjectMapper.Map<List<HrPersonPassportDetailsDto>>(listData);
        }

        public async Task<List<HrPersonIdentityCardDto>> GetAllPersonIdentityCardData(EntityDto<long> input)
        {
            var listData = await _repoHrPersonIdentityCard.GetAll().Where(d => d.HrPersonId == input.Id).ToListAsync();

            return ObjectMapper.Map<List<HrPersonIdentityCardDto>>(listData);
        }

        public async Task<List<HrPersonSalaryElementsDto>> GetAllPersonSalaryElementsData(EntityDto<long> input)
        {
            var listData = await _repoHrPersonSalaryElements.GetAllIncluding(x => x.PyElements, x => x.StartPeriods, x => x.EndPeriods)
                                 .Where(d => d.HrPersonId == input.Id).ToListAsync();

            return ObjectMapper.Map<List<HrPersonSalaryElementsDto>>(listData);
        }

        public async Task<List<HrPersonAttachmentsDto>> GetAllAttachments(EntityDto<long> input)
        {
            var listData = await _repoHrPersonAttachments.GetAllListAsync(d => d.HrPersonId == input.Id);

            return ObjectMapper.Map<List<HrPersonAttachmentsDto>>(listData);
        }

        public async Task<Select2PagedResult> GetPersonSupervisorSelect2(long id, string searchTerm, int pageSize, int pageNumber, string lang)
            => await _hrPersonsManager.GetPersonSupervisorSelect2(id, searchTerm, pageSize, pageNumber, lang);

        public async Task<Select2PagedResult> GetPersonsSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
            => await _hrPersonsManager.GetPersonsSelect2(searchTerm, pageSize, pageNumber, lang);

        public async Task<Select2PagedResult> GetPyElementsSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
            => await _pyElementsManager.GetPyElementsSelect2(searchTerm, pageSize, pageNumber, lang);

        public async Task<Select2PagedResult> GetPersonsNumbersSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
            => await _hrPersonsManager.GetPersonsNumbersSelect2(searchTerm, pageSize, pageNumber, lang);
        public async Task<Select2PagedResult> GetPersonsNumbersForEngineersSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
          => await _hrPersonsManager.GetPersonsNumbersForEngineersSelect2(searchTerm, pageSize, pageNumber, lang);

        #region Assets Methods

        private async Task InsertHrPersonVisaData(HrPersonVisaDetailsDto hrPersonVisaDto, long personId)
        {
            hrPersonVisaDto.HrPersonId = personId;

            var hrPersonVisa = ObjectMapper.Map<HrPersonVisaDetails>(hrPersonVisaDto);

            _ = await _repoHrPersonVisaDetails.InsertAsync(hrPersonVisa);
        }

        private async Task InsertHrPersonPassportData(HrPersonPassportDetailsDto hrPersonPassportDto, long personId)
        {
            hrPersonPassportDto.HrPersonId = personId;

            var hrPersonPassport = ObjectMapper.Map<HrPersonPassportDetails>(hrPersonPassportDto);

            _ = await _repoHrPersonPassportDetails.InsertAsync(hrPersonPassport);
        }

        private async Task InsertPersonIdentityCardData(HrPersonIdentityCardDto personIdentityCardDto, long personId)
        {
            personIdentityCardDto.HrPersonId = personId;

            var personIdentityCard = ObjectMapper.Map<HrPersonIdentityCard>(personIdentityCardDto);

            _ = await _repoHrPersonIdentityCard.InsertAsync(personIdentityCard);
        }

        private async Task InsertHrPersonSalaryElementsData(HrPersonSalaryElementsDto personSalaryElementsDto, long personId)
        {
            personSalaryElementsDto.HrPersonId = personId;

            var personSalaryElements = ObjectMapper.Map<HrPersonSalaryElements>(personSalaryElementsDto);

            _ = await _repoHrPersonSalaryElements.InsertAsync(personSalaryElements);
        }

        private async Task InsertHrPersonAttachmentsData(HrPersonAttachmentsDto attachmentsDto, long personId)
        {
            attachmentsDto.HrPersonId = personId;

            var attachments = ObjectMapper.Map<HrPersonAttachments>(attachmentsDto);

            _ = await _repoHrPersonAttachments.InsertAsync(attachments);
        }

        private async Task CRUD_HrPersonVisa(ICollection<HrPersonVisaDetailsDto> hrPersonVisaDetailsDtos, long personId)
        {
            if (hrPersonVisaDetailsDtos != null && hrPersonVisaDetailsDtos.Count > 0)
            {
                foreach (var item in hrPersonVisaDetailsDtos)
                {
                    if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                    {
                        var hrPersonVisa = await _repoHrPersonVisaDetails.GetAsync((long)item.Id);

                        item.HrPersonId = personId;

                        ObjectMapper.Map(item, hrPersonVisa);

                        _ = await _repoHrPersonVisaDetails.UpdateAsync(hrPersonVisa);
                    }
                    else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                    {
                        await InsertHrPersonVisaData(item, personId);
                    }
                    else if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                    {
                        await _repoHrPersonVisaDetails.DeleteAsync((long)item.Id);
                    }
                }
            }
        }

        private async Task CRUD_HrPersonPassport(ICollection<HrPersonPassportDetailsDto> passportDetailsDtos, long personId)
        {
            if (passportDetailsDtos != null && passportDetailsDtos.Count > 0)
            {
                foreach (var item in passportDetailsDtos)
                {
                    if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                    {
                        var passportDetails = await _repoHrPersonPassportDetails.GetAsync((long)item.Id);

                        item.HrPersonId = personId;

                        ObjectMapper.Map(item, passportDetails);

                        _ = await _repoHrPersonPassportDetails.UpdateAsync(passportDetails);
                    }
                    else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                    {
                        await InsertHrPersonPassportData(item, personId);
                    }
                    else if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                    {
                        await _repoHrPersonPassportDetails.DeleteAsync((long)item.Id);
                    }
                }
            }
        }

        private async Task CRUD_HrPersonIdentityCard(ICollection<HrPersonIdentityCardDto> personIdentityCardDtos, long personId)
        {
            if (personIdentityCardDtos != null && personIdentityCardDtos.Count > 0)
            {
                foreach (var item in personIdentityCardDtos)
                {
                    if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                    {
                        var personIdentityCard = await _repoHrPersonIdentityCard.GetAsync((long)item.Id);

                        item.HrPersonId = personId;

                        ObjectMapper.Map(item, personIdentityCard);

                        _ = await _repoHrPersonIdentityCard.UpdateAsync(personIdentityCard);
                    }
                    else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                    {
                        await InsertPersonIdentityCardData(item, personId);
                    }
                    else if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                    {
                        await _repoHrPersonIdentityCard.DeleteAsync((long)item.Id);
                    }
                }
            }
        }

        private async Task CRUD_HrPersonSalaryElements(ICollection<HrPersonSalaryElementsDto> personSalaryElementsDtos, long personId)
        {
            if (personSalaryElementsDtos != null && personSalaryElementsDtos.Count > 0)
            {
                foreach (var item in personSalaryElementsDtos)
                {
                    if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                    {
                        var personSalaryElements = await _repoHrPersonSalaryElements.GetAsync((long)item.Id);

                        item.HrPersonId = personId;
                        item.Amount = personSalaryElements.Amount;
                        item.StartPeriodId = personSalaryElements.StartPeriodId;
                        item.PyElementId = personSalaryElements.PyElementId;
                        item.EndPeriodId = personSalaryElements.EndPeriodId ?? item.EndPeriodId;

                        ObjectMapper.Map(item, personSalaryElements);

                        _ = await _repoHrPersonSalaryElements.UpdateAsync(personSalaryElements);
                    }
                    else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                    {
                        await InsertHrPersonSalaryElementsData(item, personId);
                    }
                    else if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                    {
                        await _repoHrPersonSalaryElements.DeleteAsync((long)item.Id);
                    }
                }
            }
        }

        private async Task CRUD_HrPersonAttachments(ICollection<HrPersonAttachmentsDto> attachmentsDtos, long personId)
        {
            if (attachmentsDtos?.Count > 0)
            {
                foreach (var item in attachmentsDtos)
                {
                    if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                    {
                        var attachments = await _repoHrPersonAttachments.GetAsync((long)item.Id);

                        item.HrPersonId = personId;

                        ObjectMapper.Map(item, attachments);

                        _ = await _repoHrPersonAttachments.UpdateAsync(attachments);
                    }
                    else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                    {
                        await InsertHrPersonAttachmentsData(item, personId);
                    }
                    else if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                    {
                        await _repoHrPersonAttachments.DeleteAsync((long)item.Id);
                    }
                }
            }
        }

        private async Task<string> GetPersonNumber()
        {
            var counterInput = new GetCounterInputDto { CounterName = "HrPersons", TenantId = (int)AbpSession.TenantId, Lang = "ar-EG", year = 0 };

            var result = await _repoProcCounter.Execute(counterInput, "GetCounter");

            return result?.FirstOrDefault()?.OutputStr ?? string.Empty;
        }

        #endregion
    }
}
