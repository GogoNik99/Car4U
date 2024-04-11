using Microsoft.AspNetCore.Http;

namespace Car4U.Core.Contracts
{
    public interface IImageService
    {
        Task<string> UploadAsync(IFormFile img);

        void DeleteImg(string fileName);

    }
}
