using Microsoft.AspNetCore.Http;

namespace Service
{
    public interface IImageService
    {
        string GetFilePath(string name, List<IFormFile>? photos);
    }
}