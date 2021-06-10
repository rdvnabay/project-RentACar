using Microsoft.AspNetCore.Http;

namespace Business.Adapters
{
   public interface IImageUploadService
    {
        public string Upload(IFormFile file);
    }
}
