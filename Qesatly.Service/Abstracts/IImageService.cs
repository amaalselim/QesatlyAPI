using Microsoft.AspNetCore.Http;

namespace Qesatly.Service.Abstracts
{
    public interface IImageService
    {
        Task<string> SaveFileAsync(IFormFile Img, string folderPath);
        Task DeleteFileAsync(string File);
    }
}
