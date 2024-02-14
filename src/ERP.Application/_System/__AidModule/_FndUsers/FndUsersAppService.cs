using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System.__AidModule._FndUserRelatives;
using ERP._System.__AidModule._FndUserRelatives.Dto;
using ERP._System.__AidModule._FndUsers.Dto;
using ERP.Authorization;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__AidModule._FndUsers
{
    [AbpAuthorize]
    public class FndUsersAppService :
        AsyncCrudAppService<FndUsers, FndUsersDto, long, PagedFndUsersResultRequestDto, CreateFndUsersDto, FndUsersDto>,
        IFndUsersAppService
    {
        private readonly IRepository<FndUserRelatives, long> _repoFndUserRelatives;
        private readonly IFndUsersManager _fndUsersManager;

        public FndUsersAppService(
            IRepository<FndUsers, long> repository,
            IRepository<FndUserRelatives, long> repoFndUserRelatives,
            IFndUsersManager fndUsersManager) : base(repository)
        {
            _repoFndUserRelatives = repoFndUserRelatives;
            _fndUsersManager = fndUsersManager;

            CreatePermissionName = PermissionNames.Pages_FndUsers_Insert;
            UpdatePermissionName = PermissionNames.Pages_FndUsers_Update;
            DeletePermissionName = PermissionNames.Pages_FndUsers_Delete;
            GetAllPermissionName = PermissionNames.Pages_FndUsers;
        }


        public async override Task<PagedResultDto<FndUsersDto>> GetAll(PagedFndUsersResultRequestDto input)
        {
            var queryable = Repository.GetAllIncluding(
                                      x => x.GenderFndLookupValues,
                                      x => x.MaritalStatusFndLookupValues,
                                      x => x.NationalityFndLookupValues,
                                      x => x.QualificationFndLookupValues,
                                      x => x.CityFndLookupValues);

            var count = await queryable.CountAsync();


            if (input.Params != null && !string.IsNullOrEmpty(input.Params.Name))
                queryable = queryable.Where(q => q.Name.Contains(input.Params.Name));

            if (input.Params != null && input.Params.GenderLkpId != null)
                queryable = queryable.Where(q => q.GenderLkpId == input.Params.GenderLkpId);

            if (input.Params != null && input.Params.NationalityLkpId != null)
                queryable = queryable.Where(q => q.NationalityLkpId == input.Params.NationalityLkpId);

            if (input.Params != null && input.Params.CityLkpId != null)
                queryable = queryable.Where(q => q.CityLkpId == input.Params.CityLkpId);

            var listOrder = new List<SortModel> { new SortModel { Sort = input.OrderByValue.Sort, ColId = input.OrderByValue.ColId } };

            queryable = queryable.DynamicOrderBy(listOrder);
            queryable = queryable.Skip(input.SkipCount);

            var data = await queryable.Take(input.MaxResultCount).ToListAsync();

            var data2 = ObjectMapper.Map(data, new List<FndUsersDto>());

            var PagedResultDto = new PagedResultDto<FndUsersDto>()
            {
                Items = data2 as IReadOnlyList<FndUsersDto>,
                TotalCount = count
            };

            return PagedResultDto;
        }

        public override async Task<FndUsersDto> Create(CreateFndUsersDto input)
        {
            bool check = CheckIdNumbersRepeated(input.IdNumber, input.IdNumberWifeHusband1, input.IdNumberWife2, input.IdNumberWife3, input.IdNumberWife4);

            if (check) return new FndUsersDto { IdNumbersRepeated = true };

            var currentfndUsers =
                FndUsers.Create(input.Name, input.Region, input.JobDescription, input.Address,
                   input.WifeHusbandName1, input.WifeName2, input.WifeName3, input.WifeName4,
                   input.IdNumber, input.IdNumberWifeHusband1, input.IdNumberWife2, input.IdNumberWife4,
                   input.IdExpirationDate, input.BrithDate, input.PhoneNumber, input.MobileNumber1,
                   input.MobileNumber2, input.GenderLkpId, input.CityLkpId, input.NationalityLkpId, input.MaritalStatusLkpId, input.QualificationLkpId);

            _ = await Repository.InsertAsync(currentfndUsers);

            if (input.FndUserRelativesList.Count > 0)
            {
                foreach (var item in input.FndUserRelativesList)
                {
                    var current = FndUserRelatives.Create(item.name, item.idNumber, currentfndUsers.Id, item.genderLkpId, item.relativesTypeLkpId, item.nationalityLkpId, item.qualificationLkpId);

                    _ = await _repoFndUserRelatives.InsertAsync(current);
                }
            }

            return new FndUsersDto { IdNumbersRepeated = false };
        }

        public override async Task<FndUsersDto> Update(FndUsersDto input)
        {
            bool check = CheckIdNumbersRepeated(input.IdNumber, input.IdNumberWifeHusband1, input.IdNumberWife2, input.IdNumberWife3, input.IdNumberWife4);

            if (check) return new FndUsersDto { IdNumbersRepeated = true };

            FndUsers current = await Repository.GetAsync(input.Id);

            input.IdExpirationDate = Convert.ToDateTime(input.IdExpirationDateStr);
            input.BrithDate = Convert.ToDateTime(input.BrithDateStr);

            ObjectMapper.Map(input, current);

            _ = await Repository.UpdateAsync(current);

            if (input.FndUserRelativesList.Count > 0)
            {
                foreach (var item in input.FndUserRelativesList)
                {
                    if (item.id != null && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                    {
                        var fndUserRelatives = await _repoFndUserRelatives.GetAsync((long)item.id);

                        var mapped = ObjectMapper.Map(item, fndUserRelatives);

                        _ = await _repoFndUserRelatives.UpdateAsync(fndUserRelatives);
                    }
                    else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                    {
                        var currentRelative = FndUserRelatives.Create(item.name, item.idNumber, input.Id, item.genderLkpId, item.relativesTypeLkpId, item.nationalityLkpId, item.qualificationLkpId);

                        _ = await _repoFndUserRelatives.InsertAsync(currentRelative);
                    }
                    else if (item.id != null && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                    {
                        await _repoFndUserRelatives.DeleteAsync((long)item.id);
                    }
                }
            }

            return new FndUsersDto { IdNumbersRepeated = false };
        }

        public async Task<FndUsersDto> GetDetailAsync(EntityDto<long> input)
        {
            try
            {
                var current = await Repository
                              .GetAllIncluding(
                                      x => x.GenderFndLookupValues,
                                      x => x.MaritalStatusFndLookupValues,
                                      x => x.NationalityFndLookupValues,
                                      x => x.QualificationFndLookupValues,
                                      x => x.CityFndLookupValues)
                               .Where(z => z.Id == input.Id)
                               .FirstOrDefaultAsync();

                var currentDto = ObjectMapper.Map<FndUsersDto>(current);

                return currentDto;
            }
            catch (Exception x)
            {
                throw x;
            }
        }

        public async Task<List<FndUserRelativesDto>> GetAllDetails(long id)
        {
            var output = new List<FndUserRelativesDto>();

            var listData = await _repoFndUserRelatives
                .GetAllIncluding(z => z.GenderFndLookupValues, x => x.NationalityFndLookupValues, x => x.QualificationFndLookupValues, x => x.RelativesFndLookupValues)
                .Where(d => d.FndUsersId == id).ToListAsync();

            foreach (var item in listData)
            {
                var current = new FndUserRelativesDto
                {
                    id = item.Id,
                    name = item.Name,
                    idNumber = item.IdNumber,
                    genderLkp = item.GenderFndLookupValues.NameAr,
                    genderLkpId = item.GenderLkpId,
                    nationalityLkp = item.NationalityFndLookupValues.NameAr,
                    nationalityLkpId = item.NationalityLkpId,
                    qualificationLkp = item.QualificationFndLookupValues.NameAr,
                    qualificationLkpId = item.QualificationLkpId,
                    relativesTypeLkp = item.RelativesFndLookupValues.NameAr,
                    relativesTypeLkpId = item.RelativesTypeLkpId,
                    rowStatus = DetailRowStatus.RowStatus.NoAction.ToString()
                };

                output.Add(current);
            }

            return output;
        }

        public async override Task Delete(EntityDto<long> input)
        {
            var ids = await _repoFndUserRelatives.GetAll().Where(z => z.FndUsersId == input.Id).Select(z => z.Id).ToListAsync();

            foreach (var id in ids) await _repoFndUserRelatives.DeleteAsync(id);

            await Repository.DeleteAsync(input.Id);
        }

        public async Task<Select2PagedResult> GetFndUsersSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
                 => await _fndUsersManager.GetFndUsersSelect2(searchTerm, pageSize, pageNumber, lang);


        private bool CheckIdNumbersRepeated(string idNumber, string idWNumber1
          , string idWNumber2, string idWNumber3, string idWNumber4)
        {
            if (idNumber != null && (idNumber == idWNumber1 || idNumber == idWNumber2 || idNumber == idWNumber3 || idNumber == idWNumber4))
                return true;

            if (idWNumber1 != null && (idWNumber1 == idNumber || idWNumber1 == idWNumber2 || idWNumber1 == idWNumber3 || idWNumber1 == idWNumber4))
                return true;

            if (idWNumber2 != null && (idWNumber2 == idNumber || idWNumber2 == idWNumber1 || idWNumber2 == idWNumber3 || idWNumber2 == idWNumber4))
                return true;

            if (idWNumber3 != null && (idWNumber3 == idNumber || idWNumber3 == idWNumber1 || idWNumber3 == idWNumber2 || idWNumber3 == idWNumber4))
                return true;

            if (idWNumber4 != null && (idWNumber4 == idNumber || idWNumber4 == idWNumber1 || idWNumber4 == idWNumber2 || idWNumber4 == idWNumber3))
                return true;

            return false;
        }
    }
}
