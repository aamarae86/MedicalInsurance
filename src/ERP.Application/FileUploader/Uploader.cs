using Abp.UI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;


namespace ERP.FileUploader
{
    public class Uploader : ERPAppServiceBase, IUploader
    {
        private readonly string[] _permittedExtensions = { ".txt", ".png" };
        private readonly string _targetFilePath;
        private string _httpFilePath;

        public Uploader(IConfiguration config)
        {
            // To save physical files to a path provided by configuration:
            _targetFilePath = config.GetValue<string>("StoredFilesPath");
            _httpFilePath = config.GetValue<string>("HttpFilePath");
        }

        #region snippet_UploadPhysical
        [HttpPost]
        [RequestFormLimits(MultipartBodyLengthLimit = 268435456)]
        public async Task<string> UploadPhysical(IFormFile file, long parentId = 0, long Id = 0, string oldFile = null)
        {
            if (parentId != 0)
                if (!string.IsNullOrEmpty(oldFile))
                {
                    string oldFilePath = oldFile.Replace(_httpFilePath, $"{_targetFilePath}\\");
                    File.Delete(oldFilePath);
                }
            return await SaveFile(file);
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            try
            {
                //var uploads = Path.Combine(_targetFilePath, "uploads");
                if (file.Length > 0)
                {
                    var fileExt = file.ContentType.Remove(0, file.ContentType.IndexOf("/") + 1);
                    //var trustedFileNameForDisplay = WebUtility.HtmlEncode(file.FileName);
                    var trustedFileNameForFileStorage = $"{Guid.NewGuid().ToString()}.{fileExt}";
                    //var filePath = Path.Combine(uploads, file.FileName);
                    var filePath = Path.Combine(_targetFilePath, trustedFileNameForFileStorage);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                    //ftpFilePath = $"{ftpFilePath}{file.FileName}";
                    _httpFilePath = $"{_httpFilePath}{trustedFileNameForFileStorage}";
                }
                return _httpFilePath;

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(ex.Message);
            }
        }
        #endregion
    }
}
