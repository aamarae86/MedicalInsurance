using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Repositories;
using Abp.Linq;
using Abp.UI;
using ERP._System._Counters.ProcDto;
using ERP._System._Counters.Procs;
using ERP.Helpers.Core.__PostAudited;
using ERP.ModificationsValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System
{
    public abstract class EditBaseAsyncCrudAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput>
        : EditBaseAsyncCrudAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, EntityDto<TPrimaryKey>>
        where TEntity : class, IEntity<TPrimaryKey>, IHasModificationTime, IPostAudited
        where TEntityDto : IEntityDto<TPrimaryKey>
        where TUpdateInput : IEntityDto<TPrimaryKey>, IHasModificationTimeValidation
    {
        protected EditBaseAsyncCrudAppService(
            IRepository<TEntity, TPrimaryKey> repository
            )
            : base(repository)
        {
        }
    }

    public abstract class EditBaseAsyncCrudAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, TGetInput>
    : EditBaseAsyncCrudAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, TGetInput, EntityDto<TPrimaryKey>>
        where TEntity : class, IEntity<TPrimaryKey>, IHasModificationTime, IPostAudited
        where TEntityDto : IEntityDto<TPrimaryKey>
        where TUpdateInput : IEntityDto<TPrimaryKey>, IHasModificationTimeValidation
        where TGetInput : IEntityDto<TPrimaryKey>
    {
        protected EditBaseAsyncCrudAppService(
            IRepository<TEntity, TPrimaryKey> repository
            )
            : base(repository)
        {

        }
    }

    public abstract class EditBaseAsyncCrudAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, TGetInput, TDeleteInput>
       : AsyncCrudAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, TGetInput, TDeleteInput>,
        IAsyncCrudAppService<TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, TGetInput, TDeleteInput>
           where TEntity : class, IEntity<TPrimaryKey>, IHasModificationTime, IPostAudited
           where TEntityDto : IEntityDto<TPrimaryKey>
           where TUpdateInput : IEntityDto<TPrimaryKey>, IHasModificationTimeValidation
           where TGetInput : IEntityDto<TPrimaryKey>
           where TDeleteInput : IEntityDto<TPrimaryKey>
    {
        protected EditBaseAsyncCrudAppService(
            IRepository<TEntity, TPrimaryKey> repository
            )
            : base(repository)
        {
            AsyncQueryableExecuter = NullAsyncQueryableExecuter.Instance;
        }

        internal abstract Task EntityCreatePreExecute(TCreateInput input);
        internal abstract Task EntityCreatePostExecute(TCreateInput input, TPrimaryKey EntityId);
        internal abstract Task EntityUpdatePreExecute(TUpdateInput input);
        internal abstract Task EntityDeletePreExecute(TDeleteInput input);

        public async override Task<TEntityDto> Create(TCreateInput input)
        {
            CheckCreatePermission();

            await EntityCreatePreExecute(input);

            var entity = await base.Create(input);

            await EntityCreatePostExecute(input, entity.Id);

            return entity;
        }

        public async override Task<TEntityDto> Update(TUpdateInput input)
        {
            CheckUpdatePermission();

            await CheckIsPosted(input);

            await CheckIsModified(input);

            await EntityUpdatePreExecute(input);

            return await base.Update(input);
        }

        public override async Task Delete(TDeleteInput input)
        {
            await CheckIsPosted(input);
            await EntityDeletePreExecute(input);
            await base.Delete(input);
        }

        private async Task CheckIsModified(TUpdateInput input)
        {
                var current = await Repository.GetAsync(input.Id);
                var modifyTimeStr = current.LastModificationTime.HasValue ? current.LastModificationTime.Value.ToString("dd/MM/yyyy hh:mm:ss tt").Replace("م", "PM").Replace("ص", "AM") : null;
                if (!current.LastModificationTime.HasValue || modifyTimeStr == input.LastModificationTimeStr.Replace("م", "PM").Replace("ص", "AM"))
                    return;

                throw new UserFriendlyException("Modified version!");
        }

        private async Task CheckIsPosted(IEntityDto<TPrimaryKey> input)
        {
            if (await Repository.CountAsync(c => c.Id.Equals(input.Id) && c.PostTime.HasValue) < 1)
                return;
            throw new UserFriendlyException("Posted!");
        }
    }
}
