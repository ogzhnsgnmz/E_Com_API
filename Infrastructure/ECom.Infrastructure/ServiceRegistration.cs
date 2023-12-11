using ECom.Infrastructure.Services.Storage.Azure;
using ECom.Infrastructure.Services.Storage.Local;
using ECom.Infrastructure.Services.Storage;
using ECom.Infrastructure.Services.Token;
using Microsoft.Extensions.DependencyInjection;
using ECom.Application.Abstractions.Storage;
using ECom.Application.Abstractions.Token;
using ECom.Infrastructure.Helper.Enums;

namespace ECom.Infrastructure;

public static class ServiceRegistration
{
    public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
    {
        //serviceCollection.AddScoped<IFileService, FileService>();
        serviceCollection.AddScoped<IStorageService, StorageService>();
        serviceCollection.AddScoped<ITokenHandler, TokenHandler>();
    }
    public static void AddStorage<T>(this IServiceCollection serviceCollection) where T : BaseStorage, IBaseStorage
    {
        serviceCollection.AddScoped<IBaseStorage, T>();
    }
    public static void AddStorage(this IServiceCollection serviceCollection, StorageType storageType)
    {
        switch (storageType)
        {
            case StorageType.Local:
                //serviceCollection.AddScoped<IStorage, LocalStorage>();
                break;
            case StorageType.Azure:
                serviceCollection.AddScoped<IBaseStorage, AzureStorage>();
                break;
            default:
                //serviceCollection.AddScoped<IStorage, LocalStorage>();
                break;
        }
    }
}
