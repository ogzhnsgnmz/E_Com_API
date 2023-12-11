﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ECom.Application.Repositories.File;
using ECom.Persistence.Repositories.File;
using ECom.Application.Repositories.Product;
using ECom.Persistence.Repositories.Product;
using ECom.Persistence.Repositories.Customer;
using ECom.Application.Repositories.Customer;
using ECom.Application.Repositories.InvoiceFile;
using ECom.Persistence.Repositories.InvoiceFile;
using ECom.Application.Repositories.Order;
using ECom.Persistence.Repositories.Order;
using ECom.Application.Repositories.ProductImageFile;
using ECom.Persistence.Repositories.ProductImageFile;
using ECom.Application.Abstractions.Services;
using ECom.Application.Abstractions.Services.Authentication;
using ECom.Persistence.Services;
using ECom.Domain.Entities.Identity;
using ECom.Persistence.Repositories.Basket;
using ECom.Application.Repositories.Basket;
using ECom.Persistence.Repositories.BasketItem;

namespace ECom.Persistence;

public static class ServiceRegistration
{
    public static void AddPersistenceServices(this IServiceCollection services)
    {
        services.AddDbContext<EComDbContext>(options => options.UseSqlServer(Configuration.ConnectionString));
        services.AddIdentity<AppUser, AppRole>(options =>
        {
            options.Password.RequiredLength = 3;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false; 
            options.Password.RequireUppercase = false;
        }).AddEntityFrameworkStores<EComDbContext>();
        services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
        services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
        services.AddScoped<IFileReadRepository, FileReadRepository>();
        services.AddScoped<IFileWriteRepository, FileWriteRepository>();
        services.AddScoped<IInvoiceFileReadRepository, InvoiceFileReadRepository>();
        services.AddScoped<IInvoiceFileWriteRepository, InvoiceFileWriteRepository>();
        services.AddScoped<IOrderReadRepository, OrderReadRepository>();
        services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
        services.AddScoped<IProductReadRepository, ProductReadRepository>();
        services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
        services.AddScoped<IProductImageFileReadRepository, ProductImageFileReadRepository>();
        services.AddScoped<IProductImageFileWriteRepository, ProductImageFileWriteRepository>();
        services.AddScoped<IBasketReadRepository, BasketReadRepository>();
        services.AddScoped<IBasketWriteRepository, BasketWriteRepository>();
        services.AddScoped<IBasketItemReadRepository, BasketItemReadRepository>();
        services.AddScoped<IBasketItemWriteRepository, BasketItemWriteRepository>();

        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IExternalAuthentication, AuthService>();
        services.AddScoped<IInternalAuthentication, AuthService>();
        services.AddScoped<IBasketService, BasketService>();
    }
}
