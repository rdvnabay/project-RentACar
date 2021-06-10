using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Core.Utilities.FileHelper
{
    public class ImageHelper
    {
        private static string imageUploadFolder = "wwwroot\\img";
        public static bool Remove(string fileName)
        {
            string fullPath = Path.Combine(fileName);
            if (File.Exists(imageUploadFolder + fullPath))
            {
                File.Delete(imageUploadFolder + fullPath);
                return true;
            }
            return false;
        }

        public static string Save(IFormFile file)
        {
            string extension = Path.GetExtension(file.FileName);
            string fileName = string.Format($"{Guid.NewGuid()}{extension}");
            string path = Path.Combine(Directory.GetCurrentDirectory(), imageUploadFolder, fileName);
            //if (!Directory.Exists(path))
            //    Directory.CreateDirectory(path);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                file.CopyToAsync(stream);
                //stream.Flush();
            }

            return fileName.ToString();
        }
        public static async Task<string> SaveAsync(IFormFile file)
        {
            string extension = Path.GetExtension(file.FileName);
            string fileName = string.Format($"{Guid.NewGuid()}{extension}");
            string path = Path.Combine(Directory.GetCurrentDirectory(), imageUploadFolder, fileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return fileName.ToString();
        }
    }
}
