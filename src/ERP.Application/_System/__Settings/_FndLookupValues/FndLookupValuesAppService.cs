using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using ERP._System.__Settings._FndLookupValues.Dto;
using ERP._System._FndLookupValues.Dto;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System._FndLookupValues
{
    public class FndLookupValuesAppService : ERPAppServiceBase, IFndLookupValuesAppService
    {
        private readonly IRepository<FndLookupValues, long> _repoFndLookupValues;
        private readonly IFndLookupValuesManager _fndLookupValuesManager;

        public FndLookupValuesAppService(IRepository<FndLookupValues, long> repoFndLookupValues, IFndLookupValuesManager fndLookupValuesManager)
        {
            _repoFndLookupValues = repoFndLookupValues;
            _fndLookupValuesManager = fndLookupValuesManager;
        }

        public async Task<ListResultDto<FndLookupValuesDto>> GetAll()
        {
            var data = await _repoFndLookupValues.GetAll().ToListAsync();

            return new ListResultDto<FndLookupValuesDto>(ObjectMapper.Map<List<FndLookupValuesDto>>(data));
        }

        public async Task<IReadOnlyList<FndLookupValuesDto>> GetAllWithSearch(string nameAr, string nameEn, string lookupCode, string lookupType)
        {
            var query = _repoFndLookupValues.GetAll();

            if (!string.IsNullOrEmpty(nameAr)) query = query.Where(z => z.NameAr.Equals(nameAr));

            if (!string.IsNullOrEmpty(nameEn)) query = query.Where(z => z.NameEn.Equals(nameEn));

            if (!string.IsNullOrEmpty(lookupCode)) query = query.Where(z => z.LookupCode.Equals(lookupCode));

            if (!string.IsNullOrEmpty(lookupType)) query = query.Where(z => z.LookupType.Equals(lookupType));

            return ObjectMapper.Map<IReadOnlyList<FndLookupValuesDto>>(await query.ToListAsync());
        }

        public async Task<FndLookupValuesDto> Update(FndLookupValuesEditDto editDto)
        {
            var current = await _repoFndLookupValues.GetAsync(editDto.Id);

            ObjectMapper.Map(editDto, current);

            _ = await _repoFndLookupValues.UpdateAsync(current);

            return ObjectMapper.Map<FndLookupValuesDto>(current);
        }

        public async Task<FndLookupValuesDto> Get(EntityDto<long> input)
        {
            return ObjectMapper.Map<FndLookupValuesDto>(await _repoFndLookupValues.GetAsync(input.Id));
        }

        public async Task<Select2PagedResult> GetFndLookupValuesExcludingIdsSelect2(string type, string ids, string searchTerm, int pageSize, int pageNumber, string lang)
            => await _fndLookupValuesManager.GetFndLookupValuesExcludingIdsSelect2(type, ids, searchTerm, pageSize, pageNumber, lang);

        public async Task<Select2PagedResult> GetFndLookupValuesSelect2(string type, string searchTerm, int pageSize, int pageNumber, string lang)
            => await _fndLookupValuesManager.GetFndLookupValuesSelect2(type, searchTerm, pageSize, pageNumber, lang);
        public async Task<Select2PagedResult> GetFndLookupValuesCampainsDetailsSelect2(string type, string searchTerm, int pageSize, int pageNumber, string lang)
            => await _fndLookupValuesManager.GetFndLookupValuesCampainsDetailsSelect2(type, searchTerm, pageSize, pageNumber, lang);

        public async Task<Select2PagedResult> GetAttributesFndLookupValuesSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
            => await _fndLookupValuesManager.GetAttributesFndLookupValuesSelect2(searchTerm, pageSize, pageNumber, lang);

        public async Task<Select2PagedResult> GetFndLookupValuesWithParentIdSelect2(string parentId, string type, string searchTerm, int pageSize, int pageNumber, string lang)
            => await _fndLookupValuesManager.GetFndLookupValuesWithParentIdSelect2(parentId, type, searchTerm, pageSize, pageNumber, lang);
    }
}
