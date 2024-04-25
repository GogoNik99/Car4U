using Car4U.Core.Contracts;
using Microsoft.AspNetCore.Http;
using static Car4U.Infrastructure.Constants.DataConstants;

namespace Car4U.Core.Services
{
    public class ImageService : IImageService
    {
        public void DeleteImg(string fileName)
        {
            if (fileName != null)
            {
                File.Delete($"{ImagePath}/{fileName}");
            }
        }
        public async Task<string> UploadAsync(IFormFile img)
        {
            string fileName = "Something went Wrong!";

            if (img != null)
            {
                string uploadDir = ImagePath;
                fileName = img.FileName;
                string path = Path.Combine(uploadDir, fileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await img.CopyToAsync(fileStream);
                }
            }

            return fileName;
        }
    }
}
