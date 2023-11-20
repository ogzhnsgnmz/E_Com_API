using Microsoft.AspNetCore.Http;

namespace ECom.Application.Services;

public interface IFileService
{
    Task<List<(string fileName, string path)>> uploadAsync(string path, IFormFileCollection files);
    Task<bool> copyFileAsync(string path, IFormFile file);
}
