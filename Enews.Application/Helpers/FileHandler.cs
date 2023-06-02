using Enews.Application.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Enews.Application.Helpers
{
    public class FileHandler : IFileHandler
    {
        public async Task CopyFileToFolder(IFormFile obj, string folderPath)
        {
            try
            {
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                using (FileStream fileStream = System.IO.File.Create(folderPath + @"\" + obj.FileName))
                {
                    obj.CopyTo(fileStream);
                    await fileStream.FlushAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteFileFromFolder(string filePath)
        {
            if(File.Exists(filePath))
            {
                try
                {
                    File.Delete(filePath);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
