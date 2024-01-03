﻿using ECom.Application.Repositories.ProductAttribute;
using ECom.Application.Repositories.Size;
using MediatR;

namespace ECom.Application.Features.Command.ProductAttribute.CreateProductAttribute;

public class CreateProductAttributeCommandHandler : IRequestHandler<CreateProductAttributeCommandRequest, CreateProductAttributeCommandResponse>
{

    readonly IProductAttributeWriteRepository _productAttributeWriteRepository;

    public CreateProductAttributeCommandHandler(IProductAttributeWriteRepository productAttributeWriteRepository)
    {
        _productAttributeWriteRepository = productAttributeWriteRepository;
    }

    public async Task<CreateProductAttributeCommandResponse> Handle(CreateProductAttributeCommandRequest request, CancellationToken cancellationToken)
    {
        await _productAttributeWriteRepository.AddAsync(new()
        {
            Value = request.Value,
            ProductId = Guid.Parse(request.ProductId),
            AttributeId = Guid.Parse("EF625341-AB8F-45B3-22EA-08DC0C6D24E5")
        });

        await _productAttributeWriteRepository.SaveAsync();

        return new();
    }
}
public class CreateProductAttributeCommandRequest : IRequest<CreateProductAttributeCommandResponse>
{
    public string Value { get; set; }
    public string ProductId { get; set; }
}
public class CreateProductAttributeCommandResponse
{
}
