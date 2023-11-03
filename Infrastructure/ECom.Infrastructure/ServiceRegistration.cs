using ECom.Infrastructure.Enums;
using ECom.Infrastructure.Services.Storage.Azure;
using ECom.Infrastructure.Services.Storage.Local;
using ECom.Infrastructure.Services.Storage;
using ECom.Infrastructure.Services.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ECom.Application.Abstractions.Storage;
using ECom.Application.Abstractions.Token;

namespace ECom.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {
            //serviceCollection.AddScoped<IFileService, FileService>();
            serviceCollection.AddScoped<IStorageService, StorageService>();
            serviceCollection.AddScoped<ITokenHandler, TokenHandler>();
        }
        public static void AddStorage<T>(this IServiceCollection serviceCollection) where T : Storage, IStorage
        {
            serviceCollection.AddScoped<IStorage, T>();
        }
        public static void AddStorage(this IServiceCollection serviceCollection, StorageType storageType)
        {
            switch (storageType)
            {
                case StorageType.Local:
                    //serviceCollection.AddScoped<IStorage, LocalStorage>();
                    break;
                case StorageType.Azure:
                    serviceCollection.AddScoped<IStorage, AzureStorage>();
                    break;
                case StorageType.AWS:
                    //serviceCollection.AddScoped<IStorage, Awsstorage>();
                    break;
                default:
                    //serviceCollection.AddScoped<IStorage, LocalStorage>();
                    break;
            }
        }
    }
}
