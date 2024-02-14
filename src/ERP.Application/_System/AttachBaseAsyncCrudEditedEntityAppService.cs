using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Repositories;
using Abp.Linq;
using Abp.UI;
using ERP.Helpers.Core;
using ERP.Helpers.Core.__PostAudited;
using ERP.ModificationsValidation;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace ERP._System
{
    public abstract class AttachBaseAsyncCrudEditedEntityAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, TAttachEntity>
        : AttachBaseAsyncCrudEditedEntityAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, EntityDto<TPrimaryKey>, TAttachEntity>
        where TEntity : class, IEntity<TPrimaryKey>, IHasModificationTime, IPostAudited
        where TEntityDto : IEntityDto<TPrimaryKey>
        where TUpdateInput : IEntityDto<TPrimaryKey>, IHasModificationTimeValidation
        where TAttachEntity : class, IAttachEntity
    {
        protected AttachBaseAsyncCrudEditedEntityAppService(
            IRepository<TEntity, TPrimaryKey> repository
            , IConfiguration config
            )
            : base(repository, config)
        {
        }
    }

    public abstract class AttachBaseAsyncCrudEditedEntityAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, TGetInput, TAttachEntity>
    : AttachBaseAsyncCrudEditedEntityAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, TGetInput, EntityDto<TPrimaryKey>, TAttachEntity>
        where TEntity : class, IEntity<TPrimaryKey>, IHasModificationTime, IPostAudited
        where TEntityDto : IEntityDto<TPrimaryKey>
        where TUpdateInput : IEntityDto<TPrimaryKey>, IHasModificationTimeValidation
        where TGetInput : IEntityDto<TPrimaryKey>
        where TAttachEntity : class, IAttachEntity
    {
        protected AttachBaseAsyncCrudEditedEntityAppService(
            IRepository<TEntity, TPrimaryKey> repository
            , IConfiguration config
            )
            : base(repository, config)
        {

        }
    }

    public abstract class AttachBaseAsyncCrudEditedEntityAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, TGetInput, TDeleteInput, TAttachEntity>
       : AttachBaseAsyncCrudAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, TGetInput, TDeleteInput, TAttachEntity>,
        IAttachBaseAsyncCrudAppService<TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, TGetInput, TDeleteInput>
           where TEntity : class, IEntity<TPrimaryKey>, IHasModificationTime, IPostAudited
           where TEntityDto : IEntityDto<TPrimaryKey>
           where TUpdateInput : IEntityDto<TPrimaryKey>, IHasModificationTimeValidation
           where TGetInput : IEntityDto<TPrimaryKey>
           where TDeleteInput : IEntityDto<TPrimaryKey>
           where TAttachEntity : class, IAttachEntity
    {
        protected AttachBaseAsyncCrudEditedEntityAppService(
            IRepository<TEntity, TPrimaryKey> repository
            , IConfiguration config
            )
            : base(repository, config)
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

    public abstract class BaseAsyncCrudEditedEntityAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, TGetInput, TDeleteInput>
     : AsyncCrudAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, TGetInput, TDeleteInput>,
       IAsyncCrudAppService<TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, TGetInput, TDeleteInput>
       where TEntity : class, IEntity<TPrimaryKey>, IHasModificationTime, IPostAudited
       where TEntityDto : IEntityDto<TPrimaryKey>
       where TUpdateInput : IEntityDto<TPrimaryKey>, IHasModificationTimeValidation
       where TGetInput : IEntityDto<TPrimaryKey>
       where TDeleteInput : IEntityDto<TPrimaryKey>
    {
        protected BaseAsyncCrudEditedEntityAppService(
            IRepository<TEntity, TPrimaryKey> repository
            ) : base(repository)
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

    public abstract class BaseAsyncCrudEditedEntityAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, TGetInput>
 : AsyncCrudAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, TGetInput>,
   IAsyncCrudAppService<TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, TGetInput>
   where TEntity : class, IEntity<TPrimaryKey>, IHasModificationTime, IPostAudited
   where TEntityDto : IEntityDto<TPrimaryKey>
   where TUpdateInput : IEntityDto<TPrimaryKey>, IHasModificationTimeValidation
   where TGetInput : IEntityDto<TPrimaryKey>
    {
        protected BaseAsyncCrudEditedEntityAppService(
            IRepository<TEntity, TPrimaryKey> repository
            ) : base(repository)
        {
            AsyncQueryableExecuter = NullAsyncQueryableExecuter.Instance;
        }

        internal abstract Task EntityCreatePreExecute(TCreateInput input);
        internal abstract Task EntityCreatePostExecute(TCreateInput input, TPrimaryKey EntityId);
        internal abstract Task EntityUpdatePreExecute(TUpdateInput input);

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

    public abstract class BaseAsyncCrudEditedEntityAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput>
        : AsyncCrudAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput>,
        IAsyncCrudAppService<TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput>
        where TEntity : class, IEntity<TPrimaryKey>, IHasModificationTime, IPostAudited
        where TEntityDto : IEntityDto<TPrimaryKey>
        where TUpdateInput : IEntityDto<TPrimaryKey>, IHasModificationTimeValidation
    {
        protected BaseAsyncCrudEditedEntityAppService(
            IRepository<TEntity, TPrimaryKey> repository
            ) : base(repository)
        {
            AsyncQueryableExecuter = NullAsyncQueryableExecuter.Instance;
        }

        internal abstract Task EntityCreatePreExecute(TCreateInput input);
        internal abstract Task EntityCreatePostExecute(TCreateInput input, TPrimaryKey EntityId);
        internal abstract Task EntityUpdatePreExecute(TUpdateInput input);

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
