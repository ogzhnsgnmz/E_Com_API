namespace ECom.Application.Abstractions.Storage;

public interface IStorageService : IBaseStorage
{
    public string StorageName { get; }
}
