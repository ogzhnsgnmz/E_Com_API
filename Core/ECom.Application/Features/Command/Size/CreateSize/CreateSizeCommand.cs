using ECom.Application.Repositories.Size;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Application.Features.Command.Size.CreateSize
{
    public class CreateSizeCommandHandler : IRequestHandler<CreateSizeCommandRequest, CreateSizeCommandResponse>
    {
        private readonly ISizeWriteRepository _sizeWriteRepository;

        public CreateSizeCommandHandler(ISizeWriteRepository sizeWriteRepository)
        {
            _sizeWriteRepository = sizeWriteRepository;
        }

        public async Task<CreateSizeCommandResponse> Handle(CreateSizeCommandRequest request, CancellationToken cancellationToken)
        {
            await _sizeWriteRepository.AddAsync(new()
            {
                Name = request.Name
            });

            await _sizeWriteRepository.SaveAsync();

            return new();
        }
    }

    public class CreateSizeCommandRequest : IRequest<CreateSizeCommandResponse>
    {
        public string Name { get; set; }
    }

    public class CreateSizeCommandResponse
    {

    }
}