using Microsoft.AspNetCore.Http;

namespace ECom.Application.Abstractions.Storage;

public interface IBaseStorage
{
    Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string pathOrContainerName, IFormFileCollection files);
    Task DeleteAsync(string pathOrContainerName, string fileName);
    List<string> GetFiles(string pathOrContainerName);
    bool HasFile(string pathOrContainerName, string fileName);
}
