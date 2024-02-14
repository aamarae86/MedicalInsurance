using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__HR._HrPersons.Dto;
using ERP.Helpers.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP._System.__HR._HrPersons
{
    public interface IHrPersonsAppService : IAsyncCrudAppService<HrPersonsDto, long, HrPersonsPagedDto, HrPersonsCreateDto, HrPersonsEditDto>
    {
        Task<HrPersonsDto> LoginHrPerson(HrPersonsDto input);
        Task<HrPersonsDto> GetDetailAsync(EntityDto<long> input);

        Task<List<HrPersonVisaDetailsDto>> GetAllPersonVisaData(EntityDto<long> input);

        Task<List<HrPersonPassportDetailsDto>> GetAllPersonPassportData(EntityDto<long> input);

        Task<List<HrPersonIdentityCardDto>> GetAllPersonIdentityCardData(EntityDto<long> input);

        Task<Select2PagedResult> GetPersonSupervisorSelect2(long id, string searchTerm, int pageSize, int pageNumber, string lang);

        Task<Select2PagedResult> GetPersonsSelect2(string searchTerm, int pageSize, int pageNumber, string lang);

        Task<Select2PagedResult> GetPersonsNumbersSelect2(string searchTerm, int pageSize, int pageNumber, string lang);

        Task<Select2PagedResult> GetPyElementsSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
