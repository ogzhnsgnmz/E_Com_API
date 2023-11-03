using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using MediatR;

namespace ECom.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection collection)
        {
            collection.AddMediatR(typeof(ServiceRegistration));
            collection.AddHttpClient();
        }
    }
}