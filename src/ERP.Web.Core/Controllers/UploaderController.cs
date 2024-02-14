//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Abp.MultiTenancy;
//using Abp.UI;
//using ERP.Authentication.External;
//using ERP.Authentication.JwtBearer;
//using ERP.Authorization;
//using ERP.Authorization.Users;
//using ERP.Models.TokenAuth;
//using ERP.MultiTenancy;
//using Microsoft.AspNetCore.Http;
//using ERP.FileUploader;
//using Microsoft.AspNetCore.WebUtilities;
//using Microsoft.Net.Http.Headers;
//using Microsoft.AspNetCore.Http.Features;
//using System.Net;
//using System.IO;
//using Microsoft.Extensions.Configuration;
//using System;

//namespace ERP.Controllers
//{
//    //[Route("api/[controller]/[action]")]
//    //public class UploaderController : ERPControllerBase
//    //{
//    //    public UploaderController(
//    //        IConfiguration config
//    //        )
//    //    {
//    //        // To save physical files to a path provided by configuration:
//    //        _targetFilePath = config.GetValue<string>("StoredFilesPath");
//    //    }

//    //    //private readonly long _fileSizeLimit;
//    //    private readonly string[] _permittedExtensions = { ".txt", ".png" };
//    //    private readonly string _targetFilePath;

//    //    // Get the default form options so that we can use them to set the default 
//    //    // limits for request body data.
//    //    private static readonly FormOptions _defaultFormOptions = new FormOptions();

//    //    [HttpPost]
//    //    [RequestFormLimits(MultipartBodyLengthLimit = 268435456)]
//    //    public async Task<string> Upload(IFormFile file, long parentId=0, long Id =0)
//    //    {
//    //        try
//    //        {
//    //            string ftpFilePath = "http://localhost/";
//    //            var uploads = Path.Combine(_targetFilePath, "uploads");
//    //            if (file.Length > 0)
//    //            {
//    //                //var trustedFileNameForDisplay = WebUtility.HtmlEncode(file.FileName);
//    //                var trustedFileNameForFileStorage = $"{Guid.NewGuid().ToString()}.{file.ContentType.Remove(0,file.ContentType.IndexOf("/")+1)}";
//    //                //var filePath = Path.Combine(uploads, file.FileName);
//    //                var filePath = Path.Combine(uploads, trustedFileNameForFileStorage);
//    //                using (var fileStream = new FileStream(filePath, FileMode.Create))
//    //                {
//    //                    await file.CopyToAsync(fileStream);
//    //                }
//    //                //ftpFilePath = $"{ftpFilePath}{file.FileName}";
//    //                ftpFilePath = $"{ftpFilePath}{trustedFileNameForFileStorage}";
//    //            }
//    //            return ftpFilePath;

//    //        }
//    //        catch (Exception ex)
//    //        {
//    //            throw new UserFriendlyException(ex.Message);
//    //        }        
//    //    }
//    //}
//}
