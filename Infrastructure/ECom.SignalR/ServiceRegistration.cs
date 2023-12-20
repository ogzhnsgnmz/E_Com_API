using ECom.SignalR.HubServices;
using Microsoft.Extensions.DependencyInjection;
using ECom.Application.Abstractions.Hubs;

namespace ECom.SignalR;

public static class ServiceRegistration
{
    public static void AddSignalRServices(this IServiceCollection collection)
    {
        collection.AddTransient<IProductHubService, ProductHubService>();
        collection.AddTransient<IOrderHubService, OrderHubService>();
        collection.AddSignalR();
    }
}
