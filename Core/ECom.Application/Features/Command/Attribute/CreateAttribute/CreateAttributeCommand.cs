using ECom.Application.Repositories.Attribute;
using MediatR;

namespace ECom.Application.Features.Command.Attribute.CreateAttribute;

public class CreateAttributeCommandHandler : IRequestHandler<CreateAttributeCommandRequest, CreateAttributeCommandResponse>
{
    private readonly IAttributeWriteRepository _AttributeWriteRepository;

    public CreateAttributeCommandHandler(IAttributeWriteRepository AttributeWriteRepository)
    {
        _AttributeWriteRepository = AttributeWriteRepository;
    }

    public async Task<CreateAttributeCommandResponse> Handle(CreateAttributeCommandRequest request, CancellationToken cancellationToken)
    {
        await _AttributeWriteRepository.AddAsync(new()
        {
            Name = request.Name
        });

        await _AttributeWriteRepository.SaveAsync();

        return new();
    }
}

public class CreateAttributeCommandRequest : IRequest<CreateAttributeCommandResponse>
{
    public string Name { get; set; }
}

public class CreateAttributeCommandResponse
{

}
