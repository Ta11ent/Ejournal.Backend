using Microsoft.AspNetCore.Http;

namespace Enews.Application.Interfaces
{
    public interface IFileHandler
    {
        Task CopyFileToFolder(IFormFile obj, string folderPath);
        void DeleteFileFromFolder(string filePath);
    }
}
