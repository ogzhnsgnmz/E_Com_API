using ECom.SignalR.HubServices;
using Microsoft.Extensions.DependencyInjection;

namespace ECom.SignalR
{
    public static class ServiceRegistration
    {
        public static void AddSignalRServices(this IServiceCollection collection)
        {
            collection.AddTransient<ProductHubService, ProductHubService>();
            collection.AddTransient<OrderHubService, OrderHubService>();
            collection.AddSignalR();
        }
    }
}
