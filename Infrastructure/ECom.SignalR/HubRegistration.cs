using ECom.SignalR.Hubs;
using Microsoft.AspNetCore.Builder;
using SignalR.Hubs;

namespace ECom.SignalR
{
    public static class HubRegistration
    {
        public static void MapHubs(this WebApplication webApplication)
        {
            webApplication.MapHub<ProductHub>("/product-hub");
            webApplication.MapHub<OrderHub>("/orders-hub");
        }
    }
}
