using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Core.Utilities.FileHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Business.Adapters
{
    public  class CloudinaryImageUploadManager:IImageUploadService
    {
        private Cloudinary _cloudinary;
        private IOptions<CloudinarySettings> _cloudinarySettings;
        public CloudinaryImageUploadManager(IOptions<CloudinarySettings> cloudinarySettings)
        {
            _cloudinarySettings = cloudinarySettings;
            Account account = new Account(_cloudinarySettings.Value.CloudName,
                                          _cloudinarySettings.Value.ApiKey,
                                          _cloudinarySettings.Value.ApiSecret);
            _cloudinary = new Cloudinary(account);
        }

        public string Upload(IFormFile file)
        {
            var uploadResult = new ImageUploadResult();
            if(file.Length > 0)
            {
                using (var stream=file.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams {
                        File = new FileDescription(file.FileName, stream)
                    };
                    uploadResult = _cloudinary.Upload(uploadParams);
                }
            }
            return uploadResult.Uri.ToString();
        }
    }
}
