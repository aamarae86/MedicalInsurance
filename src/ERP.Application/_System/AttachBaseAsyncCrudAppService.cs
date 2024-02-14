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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ERP._System
{
    public abstract class AttachBaseAsyncCrudAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, TAttachEntity>
        : AttachBaseAsyncCrudAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, EntityDto<TPrimaryKey>, TAttachEntity>
        where TEntity : class, IEntity<TPrimaryKey>//, IHasModificationTime, IPostAudited
        where TEntityDto : IEntityDto<TPrimaryKey>
        where TUpdateInput : IEntityDto<TPrimaryKey>//, IHasModificationTimeValidation
        where TAttachEntity : class, IAttachEntity
    {
        protected AttachBaseAsyncCrudAppService(
            IRepository<TEntity, TPrimaryKey> repository
            , IConfiguration config
            )
            : base(repository, config)
        {
        }
    }

    public abstract class AttachBaseAsyncCrudAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, TGetInput, TAttachEntity>
    : AttachBaseAsyncCrudAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, TGetInput, EntityDto<TPrimaryKey>, TAttachEntity>
        where TEntity : class, IEntity<TPrimaryKey>//, IHasModificationTime, IPostAudited
        where TEntityDto : IEntityDto<TPrimaryKey>
        where TUpdateInput : IEntityDto<TPrimaryKey>//, IHasModificationTimeValidation
        where TGetInput : IEntityDto<TPrimaryKey>
        where TAttachEntity : class, IAttachEntity
    {
        protected AttachBaseAsyncCrudAppService(
            IRepository<TEntity, TPrimaryKey> repository
            , IConfiguration config
            )
            : base(repository, config)
        {

        }
    }

    public abstract class AttachBaseAsyncCrudAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, TGetInput, TDeleteInput, TAttachEntity>
       : AsyncCrudAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, TGetInput, TDeleteInput>,
       //: EditBaseAsyncCrudAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, TGetInput, TDeleteInput>,
        IAttachBaseAsyncCrudAppService<TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, TGetInput, TDeleteInput>
        where TEntity : class, IEntity<TPrimaryKey>//, IHasModificationTime, IPostAudited
        where TEntityDto : IEntityDto<TPrimaryKey>
        where TUpdateInput : IEntityDto<TPrimaryKey>//, IHasModificationTimeValidation
           where TGetInput : IEntityDto<TPrimaryKey>
           where TDeleteInput : IEntityDto<TPrimaryKey>
           where TAttachEntity : class, IAttachEntity
    {
        public IConfiguration _config;

        protected AttachBaseAsyncCrudAppService(
            IRepository<TEntity, TPrimaryKey> repository
            , IConfiguration config
            )
            : base(repository)
        {
            AsyncQueryableExecuter = NullAsyncQueryableExecuter.Instance;

            _config = config;
            _targetFilePath = _config.GetValue<string>("StoredFilesPath");
            _httpFilePath = _config.GetValue<string>("HttpFilePath");
        }

        #region snippet_UploadPhysical
        private readonly string _targetFilePath;
        private string _httpFilePath;



        [HttpPost]
        [RequestFormLimits(MultipartBodyLengthLimit = 268435456)]
        public async Task<string> UploadAttach(IFormFile file, IFormCollection keys)
        {
            long ParentId = string.IsNullOrEmpty(keys["ParentId"]) ? 0 : Convert.ToInt64(keys["ParentId"]);
            long Id = string.IsNullOrEmpty(keys["Id"]) ? 0 : Convert.ToInt64(keys["Id"]);
            string filePath = string.IsNullOrEmpty(keys["filePath"]) ? string.Empty : keys["filePath"].ToString();

            await DeleteExistingFile(ParentId, Id, filePath);

            return await SaveFile(file);
        }

        [HttpPost]
        [RequestFormLimits(MultipartBodyLengthLimit = 268435456)]
        public async Task<IEnumerable<object>> UploadMultiAttach(List<IFormFile> files, IFormCollection keys)
        {
            List<object> result = new List<object>();

            foreach (var file in files)
            {
                var status = await SaveMultiFile(file);
                result.Add(status);
            }

            return result;
        }

        protected virtual Task<TAttachEntity> GetAttachmentEntityAsync(long ParentId, long Id, string filePath)
        {
            return null;
        }

        TAttachEntity attach = null;

        public string ServiceFolder;
        public string PreFileName;

        private async Task DeleteExistingFile(long ParentId, long Id, string filePath)
        {
            if (ParentId != 0 && Id != 0 && !string.IsNullOrEmpty(filePath))
            {
                attach = await GetAttachmentEntityAsync(ParentId, Id, filePath);
                if (attach != null)
                {
                    string oldFilePath = filePath.Replace(_httpFilePath, $"{_targetFilePath}\\");
                    try
                    {
                        File.Delete(oldFilePath);
                    }
                    catch (Exception)
                    {
                        throw new UserFriendlyException("File Delete Exception");
                    }
                }
                else
                {
                    throw new UserFriendlyException("Invalid data");
                }
            }
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            try
            {
                if (file.Length > 0)
                {
                    var fileExt = file.FileName.Remove(0, file.FileName.LastIndexOf(".") + 1);
                    var trustedFileNameForFileStorage = GetRandomFileName(fileExt);
                    var filePath = GetFilePath(trustedFileNameForFileStorage);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                    _httpFilePath = filePath.Replace(_targetFilePath, _httpFilePath).Replace("/\\", "/").Replace("\\", "/"); // $"{_httpFilePath}{trustedFileNameForFileStorage}";
                }
                return _httpFilePath;

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(ex.Message);
            }
        }

        private async Task<object> SaveMultiFile(IFormFile file)
        {
            try
            {
                var httpPath = _httpFilePath;

                if (file.Length > 0)
                {
                    var fileExt = file.FileName.Remove(0, file.FileName.LastIndexOf(".") + 1);
                    var trustedFileNameForFileStorage = GetRandomFileName(fileExt);
                    var filePath = GetFilePath(trustedFileNameForFileStorage);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }

                    httpPath = filePath.Replace(_targetFilePath, httpPath).Replace("/\\", "/").Replace("\\", "/"); // $"{_httpFilePath}{trustedFileNameForFileStorage}";
                }

                var result = new  { FilePath = httpPath, AttachmentName = Path.GetFileNameWithoutExtension(file.FileName) };
                
                return result;

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(ex.Message);
            }
        }

        private string GetFilePath(string fileName)
        {
            string path = Path.Combine(_targetFilePath, $"AppAttachments/{ServiceFolder}");
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            path = Path.Combine(path, fileName);
            return path;
        }
        private string GetRandomFileName(string fileExt)
        {
            return $"{PreFileName}-{Guid.NewGuid().ToString()}.{fileExt}";
        }
        #endregion
    }    
}
