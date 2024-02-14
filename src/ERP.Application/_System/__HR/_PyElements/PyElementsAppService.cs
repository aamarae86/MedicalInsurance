using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System.__HR._PyElements.Dto;
using ERP._System.__Warehouses._PyElements;
using ERP._System._GlCodeComDetails;
using ERP.Authorization;
using ERP.Core.Helpers.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__HR._PyElements
{
    [AbpAuthorize]
    public class PyElementsAppService : AsyncCrudAppService<PyElements, PyElementsDto, long, PyElementsPagedDto, PyElementsCreateDto, PyElementsEditDto>,
        IPyElementsAppService
    {
        private readonly IGlCodeComDetailsManager _glCodeComDetailsManager;

        public PyElementsAppService(IRepository<PyElements, long> repository, IGlCodeComDetailsManager glCodeComDetailsManager
              ) : base(repository)
        {
            _glCodeComDetailsManager = glCodeComDetailsManager;

            CreatePermissionName = PermissionNames.Pages_PyElements_Insert;
            UpdatePermissionName = PermissionNames.Pages_PyElements_Update;
            DeletePermissionName = PermissionNames.Pages_PyElements_Delete;
            GetAllPermissionName = PermissionNames.Pages_PyElements;
        }

        protected override IQueryable<PyElements> CreateFilteredQuery(PyElementsPagedDto input)
        {
            var iqueryable = Repository.GetAllIncluding(z => z.CrGlCodeComDetailsDebitAccount, z => z.FndLookupValuesElementTypeLkp);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.ElementName))
                iqueryable = iqueryable.Where(z => z.ElementName.Contains(input.Params.ElementName));

            if (input.Params != null && input.Params.ElementSerial != null && input.Params.ElementSerial != 0)
                iqueryable = iqueryable.Where(z => z.ElementSerial == input.Params.ElementSerial);

            return iqueryable;
        }

        public async override Task<PyElementsDto> Create(PyElementsCreateDto input)
        {
            CheckCreatePermission();

            input.DebitAccountId = await _glCodeComDetailsManager.CreateAndRetrieveCodeComOneId(input.codeComUtilityIds);

            var current = ObjectMapper.Map<PyElements>(input);

            await Repository.InsertAsync(current);

            return new PyElementsDto();
        }

        public async Task<PyElementsDto> GetDetailAsync(EntityDto<long> input)
        {
            var current = await Repository.GetAllIncluding(z => z.CrGlCodeComDetailsDebitAccount, z => z.FndLookupValuesElementTypeLkp)
                                          .Where(z => z.Id == input.Id).FirstOrDefaultAsync();

            (string ids, string texts) = await _glCodeComDetailsManager.GetCodeComTextsIds(current.CrGlCodeComDetailsDebitAccount, _app.Reqlanguage);

            var ReturnObj = ObjectMapper.Map<PyElementsDto>(current);

            ReturnObj.codeComUtilityIds = ids;
            ReturnObj.codeComUtilityTexts = texts;

            return ReturnObj;
        }

        public async override Task<PyElementsDto> Update(PyElementsEditDto input)
        {
            CheckUpdatePermission();

            var current = await Repository.GetAsync(input.Id);

            var DebitAccountId = await _glCodeComDetailsManager.CreateAndRetrieveCodeComOneId(input.codeComUtilityIds);

            input.DebitAccountId = DebitAccountId;

            ObjectMapper.Map(input, current);

            _ = await Repository.UpdateAsync(current);

            return new PyElementsDto();
        }

        public async Task<bool> GetExistElementNameAsync(string input, string Id)
        {
            var current = await Repository.GetAll()
                .Where(x => x.ElementName.ToLower() == input.ToLower() && x.Id.ToString() != Id).FirstOrDefaultAsync();

            return current != null;
        }

        public async Task<bool> GetExistElementSerialAsync(string input, string Id)
        {
            var current = await Repository.GetAll()
                .Where(x => x.ElementSerial.ToString().ToLower() == input.ToLower() && x.Id.ToString() != Id).FirstOrDefaultAsync();

            return current != null;
        }
    }
}
