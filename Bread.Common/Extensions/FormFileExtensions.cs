using Microsoft.AspNetCore.Http;

using System;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bread.Common.Extensions
{
    public static class FormFileExtensions
    {
        public const int ImageMinimumBytes = 512;

        public static async Task<byte[]> GetBytesAsync(this IFormFile formFile)
        {
            using var memoryStream = new MemoryStream();
            await formFile.CopyToAsync(memoryStream);

            return memoryStream.ToArray();
        }

        public static bool IsImage(this IFormFile formFile)
        {            
            if (
                formFile.ContentType.ToLower() != "image/jpg" 
                && formFile.ContentType.ToLower() != "image/jpeg"
                && formFile.ContentType.ToLower() != "image/pjpeg"                
                && formFile.ContentType.ToLower() != "image/x-png"
                && formFile.ContentType.ToLower() != "image/png"
            )
            {
                return false;
            }

            if (
                Path.GetExtension(formFile.FileName).ToLower() != ".jpg"
                && Path.GetExtension(formFile.FileName).ToLower() != ".png"                
                && Path.GetExtension(formFile.FileName).ToLower() != ".jpeg")
            {
                return false;
            }

            //-------------------------------------------
            //  Attempt to read the file and check the first bytes
            //-------------------------------------------
            try
            {
                if (!formFile.OpenReadStream().CanRead)
                {
                    return false;
                }
                //------------------------------------------
                //check whether the image size exceeding the limit or not
                //------------------------------------------ 
                if (formFile.Length < ImageMinimumBytes)
                {
                    return false;
                }

                byte[] buffer = new byte[ImageMinimumBytes];
                formFile.OpenReadStream().Read(buffer, 0, ImageMinimumBytes);
                string content = System.Text.Encoding.UTF8.GetString(buffer);
                if (Regex.IsMatch(content, @"<script|<html|<head|<title|<body|<pre|<table|<a\s+href|<img|<plaintext|<cross\-domain\-policy",
                    RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Multiline))
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
            
            try
            {
                using var bitmap = new Bitmap(formFile.OpenReadStream());
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                formFile.OpenReadStream().Position = 0;
            }

            return true;
        }
    }
}
