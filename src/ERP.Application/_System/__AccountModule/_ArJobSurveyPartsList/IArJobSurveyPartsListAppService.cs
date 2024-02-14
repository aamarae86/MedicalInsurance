using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ERP._System.__CharityBoxes._ArJobSurveyPartsList.Dto;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__CharityBoxes._ArJobSurveyPartsList
{
    public interface IArJobSurveyPartsListAppService : IAsyncCrudAppService<ArJobSurveyPartsListDto, long, PagedArJobSurveyPartsListResultRequestDto, CreateArJobSurveyPartsListDto, ArJobSurveyPartsListEditDto>
    {
        Task<ArJobSurveyPartsListDto> GetDetailAsync(EntityDto<long> input);

        Task<Select2PagedResult> GetArJobSurveyPartsListSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
    }
}
