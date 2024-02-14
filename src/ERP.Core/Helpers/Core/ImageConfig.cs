using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Text;

namespace ERP.Helpers.Core
{
    public class ImageConfig : IImageConfig
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public ImageConfig(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public string SaveImage(string imgBase64, string ImgName, string ImgExtension, string folderName)
        {
            String path = $"{_hostingEnvironment.ContentRootPath}/{folderName}"; //Path

            //Check if directory exist
            if (!Directory.Exists(path)) Directory.CreateDirectory(path); //Create directory if it doesn't exist

            string imageName2 = $"{ImgName}{"T"}{ImgExtension}";

            //set the image path
            string imgPath2 = Path.Combine(path, imageName2);

            byte[] imageBytes = Convert.FromBase64String(imgBase64);

            File.WriteAllBytes(imgPath2, imageBytes);

            if (ImgExtension.ToLower().Contains("jbg") ||
                ImgExtension.ToLower().Contains("jbeg") ||
                ImgExtension.ToLower().Contains("png") ||
                ImgExtension.ToLower().Contains("tiff") ||
                ImgExtension.ToLower().Contains("bmp") ||
                ImgExtension.ToLower().Contains("gif")
                )
            {
                Image bmp = new Bitmap(imgPath2);

                Image img = ResizeImage(bmp, 1200, 628);

                string imageName = $"{ImgName}{ImgExtension}";

                //set the image path
                string imgPath = Path.Combine(path, imageName);

                img.Save(imgPath, System.Drawing.Imaging.ImageFormat.Jpeg);

                return imageName;
            }
            else
            {
                return imageName2;
            }

        }
        public string ConvertToBase64String(string fileName, string extension, string folderName)
        {
            try
            {
                string path = $"{_hostingEnvironment.ContentRootPath}/{folderName}/{fileName}";

                byte[] fileByte = File.ReadAllBytes(path);

                if (extension.ToLower().Contains("jpg") ||
                    extension.ToLower().Contains("jpeg") ||
                    extension.ToLower().Contains("png") ||
                    extension.ToLower().Contains("tiff") ||
                    extension.ToLower().Contains("bmp") ||
                    extension.ToLower().Contains("gif"))
                    return $"data:image/{extension.Replace('.', ' ').Trim()};base64,{Convert.ToBase64String(fileByte)}";
                else if (extension.ToLower().Contains("txt"))
                    return $"data:text/plain;base64,{Convert.ToBase64String(fileByte)}";
                else
                    return $"data:application/{extension.Replace('.', ' ').Trim()};base64,{Convert.ToBase64String(fileByte)}";
            }
            catch (Exception x)
            {
                return x.InnerException?.Message ?? x.Message;
            }
        }
        public string ConvertToBase64StringOnly(string fileName, string folderName)
        {
            string path = $"{_hostingEnvironment.ContentRootPath}/{folderName}/{fileName}";
            byte[] fileByte = File.ReadAllBytes(path);
            return Convert.ToBase64String(fileByte);
        }
        public void RemoveImage(string fileName, string folderName)
        {
            var fullPath = $"{_hostingEnvironment.ContentRootPath}/{folderName}/{fileName}";
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
        }

        public static Image ResizeImage(Image img, int maxWidth, int maxHeight)
        {
            if (img.Height < maxHeight && img.Width < maxWidth)
            {
                return img;
            }
            else
            {
                using (img)
                {
                    Double xRatio = (double)img.Width / maxWidth;
                    Double yRatio = (double)img.Height / maxHeight;
                    Double ratio = Math.Max(xRatio, yRatio);
                    int nnx = (int)Math.Floor(img.Width / ratio);
                    int nny = (int)Math.Floor(img.Height / ratio);
                    Bitmap cpy = new Bitmap(nnx, nny, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
                    using (Graphics gr = Graphics.FromImage(cpy))
                    {
                        gr.Clear(Color.Transparent);

                        // This is said to give best quality when resizing images
                        gr.InterpolationMode = InterpolationMode.HighQualityBicubic;

                        gr.DrawImage(img,
                            new Rectangle(0, 0, nnx, nny),
                            new Rectangle(0, 0, img.Width, img.Height),
                            GraphicsUnit.Pixel);
                    }

                    return cpy;
                }
            }

        }

    }
}
