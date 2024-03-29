﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
using ECom.Application.Repositories.ComletedOrder;
using ECom.Persistence.Repositories.CompletedOrder;
using ECom.Application.Repositories.Endpoint;
using ECom.Persistence.Repositories.Endpoint;
using ECom.Application.Repositories.Menu;
using ECom.Persistence.Repositories.Menu;
using ECom.Application.Repositories.File;
using ECom.Persistence.Repositories.File;
using Microsoft.AspNetCore.Identity;
using ETicaretAPI.Persistence.Services;
using ECom.Application.Repositories.Category;
using ECom.Application.Repositories.Size;
using ECom.Persistence.Repositories.Size;
using ECom.Application.Repositories.Brand;
using ECom.Persistence.Repositories.Brand;
using ECom.Persistence.Repositories.Category;
using ECom.Application.UnitOfWork;
using ECom.Application.Repositories.Attribute;
using ECom.Persistence.Repositories.Attribute;
using ECom.Application.Repositories.ProductAttribute;
using ECom.Persistence.Repositories.ProductAttribute;
using ECom.Application.Repositories.Comment;
using ECom.Persistence.Repositories.Comment;
using ECom.Persistence.Repositories.Address;
using ECom.Application.Repositories.Address;

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
        }).AddEntityFrameworkStores<EComDbContext>()
        .AddDefaultTokenProviders();

        services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
        services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
        services.AddScoped<IOrderReadRepository, OrderReadRepository>();
        services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
        services.AddScoped<IProductReadRepository, ProductReadRepository>();
        services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
        services.AddScoped<IFileReadRepository, FileReadRepository>();
        services.AddScoped<IFileWriteRepository, FileWriteRepository>();
        services.AddScoped<IProductImageFileReadRepository, ProductImageFileReadRepository>();
        services.AddScoped<IProductImageFileWriteRepository, ProductImageFileWriteRepository>();
        services.AddScoped<IInvoiceFileReadRepository, InvoiceFileReadRepository>();
        services.AddScoped<InvoiceFileWriteRepository, InvoiceFileWriteRepository>();
        services.AddScoped<IBasketItemReadRepository, BasketItemReadRepository>();
        services.AddScoped<IBasketItemWriteRepository, BasketItemWriteRepository>();
        services.AddScoped<IBasketReadRepository, BasketReadRepository>();
        services.AddScoped<IBasketWriteRepository, BasketWriteRepository>();
        services.AddScoped<ICompletedOrderReadRepository, CompletedOrderReadRepository>();
        services.AddScoped<ICompletedOrderWriteRepository, CompletedOrderWriteRepository>();
        services.AddScoped<IEndpointReadRepository, EndpointReadRepository>();
        services.AddScoped<IEndpointWriteRepository, EndpointWriteRepository>();
        services.AddScoped<IMenuReadRepository, MenuReadRepository>();
        services.AddScoped<IMenuWriteRepository, MenuWriteRepository>();
        services.AddScoped<ISizeReadRepository, SizeReadRepository>();
        services.AddScoped<ISizeWriteRepository, SizeWriteRepository>();
        services.AddScoped<IBrandReadRepository, BrandReadRepository>();
        services.AddScoped<IBrandWriteRepository, BrandWriteRepository>();
        services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
        services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();
        services.AddScoped<IAttributeReadRepository, AttributeReadRepository>();
        services.AddScoped<IAttributeWriteRepository, AttributeWriteRepository>();
        services.AddScoped<IProductAttributeReadRepository, ProductAttributeReadRepository>();
        services.AddScoped<IProductAttributeWriteRepository, ProductAttributeWriteRepository>();
        services.AddScoped<ICommentReadRepository, CommentReadRepository>();
        services.AddScoped<ICommentWriteRepository, CommentWriteRepository>();
        services.AddScoped<IAddressReadRepository, AddressReadRepository>();
        services.AddScoped<IAddressWriteRepository, AddressWriteRepository>();


        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IExternalAuthentication, AuthService>();
        services.AddScoped<IInternalAuthentication, AuthService>();
        services.AddScoped<IBasketService, BasketService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IAuthorizationEndpointService, AuthorizationEndpointService>();
        services.AddScoped<IProductService, ProductService>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
