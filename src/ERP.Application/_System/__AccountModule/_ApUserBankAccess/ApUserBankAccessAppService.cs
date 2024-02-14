using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System.__SalesModule._IvSaleHd;
using ERP._System._ApBankAccounts;
using ERP._System._ApBanks;
using ERP._System._ApBanks.Dto;
using ERP._System._ApUserBankAccess.Dto;
using ERP.Authorization;
using ERP.Authorization.Users;
using ERP.Core.Helpers.Extensions;
using ERP.Users.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System._ApUserBankAccess
{
    [AbpAuthorize]
    public class ApUserBankAccessAppService : AsyncCrudAppService<ApUserBankAccess, ApUserBankAccessDto, long, PagedApUserBankAccessResultRequestDto, CreateApUserBankAccessDto, ApUserBankAccessEditDto>, IApUserBankAccessAppService
    {
        private readonly IRepository<ApBanks, long> _banksrepository;
        private readonly IRepository<ApBankAccounts, long> _BankAccountsrepository;

        private readonly IRepository<IvSaleHd, long> _ivSaleRepository;

        public ApUserBankAccessAppService(IRepository<ApUserBankAccess, long> repository,
                  IRepository<ApBanks, long> banksrepository,
                  IRepository<ApBankAccounts, long> BankAccountsrepository, IRepository<IvSaleHd, long> ivSaleRepository) : base(repository)
        {
            _banksrepository = banksrepository;
            _BankAccountsrepository = BankAccountsrepository;
            _ivSaleRepository= ivSaleRepository;
            CreatePermissionName = PermissionNames.Pages_ApUserBankAccess_Insert;
            UpdatePermissionName = PermissionNames.Pages_ApUserBankAccess_Update;
            DeletePermissionName = PermissionNames.Pages_ApUserBankAccess_Delete;
            GetAllPermissionName = PermissionNames.Pages_ApUserBankAccess;
        }

        public async override Task<PagedResultDto<ApUserBankAccessDto>> GetAll(PagedApUserBankAccessResultRequestDto input)
        {
            CheckGetAllPermission();

            var queryable = Repository.GetAllIncluding(z => z.ApBankAccounts, z => z.User);

            if (input.Params != null && input.Params.UserId != 0)
            {
                queryable = queryable.Where(q => q.UserId == input.Params.UserId);
            }

            var count = await queryable.CountAsync();
            var listOrder = new List<SortModel> { new SortModel { Sort = input.OrderByValue.Sort, ColId = input.OrderByValue.ColId } };
            queryable = queryable.DynamicOrderBy(listOrder);
            queryable = queryable.Skip(input.SkipCount);
            var data = await queryable.Take(input.MaxResultCount).ToListAsync();

            var data2 = ObjectMapper.Map(data, new List<ApUserBankAccessDto>());
            foreach (var item in data2)
            {
                if (item.ApBankAccounts != null)
                {
                    var Bank = _banksrepository.GetAll().FirstOrDefault(x => x.Id == item.ApBankAccounts.BankId);
                    item.ApBanksDto = ObjectMapper.Map<ApBanksDto>(Bank);
                }
                //var user = _userrepository.GetAll().FirstOrDefault(x => x.Id == item.UserId);
                //item.User= ObjectMapper.Map<UserDto>(user);
            }
            var PagedResultDto = new PagedResultDto<ApUserBankAccessDto>()
            {
                Items = data2 as IReadOnlyList<ApUserBankAccessDto>,
                TotalCount = count
            };

            return PagedResultDto;
        }

        public async Task<ApUserBankAccessDto> GetDetailAsync(EntityDto<long> input)
        {
            var current = await Repository.GetAllIncluding(z => z.ApBankAccounts, z => z.User)
                .Where(z => z.Id == input.Id).FirstOrDefaultAsync();

            var mapped = ObjectMapper.Map<ApUserBankAccessDto>(current);
            var Bank = _banksrepository.GetAll().FirstOrDefault(x => x.Id == mapped.ApBankAccounts.BankId);
            mapped.ApBanksDto = ObjectMapper.Map<ApBanksDto>(Bank);
            return mapped;
        }

        public async Task<ApUserBankAccessDto> GetMainAccountAsync()
        {
            var current = await Repository.GetAllIncluding(z => z.ApBankAccounts, z => z.User)
                .Where(z => z.UserId == AbpSession.UserId && z.IsPrimaryCash==true).FirstOrDefaultAsync();

            var mapped = ObjectMapper.Map<ApUserBankAccessDto>(current);
            var Bank = _banksrepository.GetAll().FirstOrDefault(x => x.Id == mapped.ApBankAccounts.BankId);
            mapped.ApBanksDto = ObjectMapper.Map<ApBanksDto>(Bank);
            return mapped;
        }

        public async override Task<ApUserBankAccessDto> Create(CreateApUserBankAccessDto input)
        {
            CheckCreatePermission();

            if (!await Repository.GetAll().AnyAsync(z => z.UserId == input.UserId && z.BankAccountId == input.BankAccountId))
                return await base.Create(input);

            return new ApUserBankAccessDto();
        }

        public async override Task<ApUserBankAccessDto> Update(ApUserBankAccessEditDto input)
        {
            CheckUpdatePermission();

            if (!await Repository.GetAll().AnyAsync(z => z.Id != input.Id && z.UserId == input.UserId && z.BankAccountId == input.BankAccountId))
                return await base.Update(input);

            return new ApUserBankAccessDto();
        }

        public async Task<bool> AddAllBanks(long UserId)
        {
            var AllAccounts = _BankAccountsrepository.GetAll();
            foreach (var item in AllAccounts)
            {
                if (!await Repository.GetAll().AnyAsync(z => z.UserId == UserId && z.BankAccountId == item.Id))
                {
                    var EntityToAdd = ApUserBankAccess.Create(item.Id, false, UserId);
                    await Repository.InsertAsync(EntityToAdd);
                }
            }
            return true;
        }

        public async Task<ApUserBankAccessDto> GetBankAccessName(long saleid)
        {
            var sale = await _ivSaleRepository.FirstOrDefaultAsync(x => x.Id == saleid);

            var current = await Repository.GetAllIncluding(z => z.ApBankAccounts, z => z.User)
                .Where(z=>z.BankAccountId == sale.BankAccountId).FirstOrDefaultAsync();

            var mapped = ObjectMapper.Map<ApUserBankAccessDto>(current);
            var Bank = _banksrepository.GetAll().FirstOrDefault(x => x.Id == mapped.ApBankAccounts.BankId);
            mapped.ApBanksDto = ObjectMapper.Map<ApBanksDto>(Bank);
            return mapped;
        }
    }
}
