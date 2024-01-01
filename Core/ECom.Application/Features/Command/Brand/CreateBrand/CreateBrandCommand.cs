using ECom.Application.Features.Command.Category.CreateCategory;
using ECom.Application.Repositories.Brand;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Application.Features.Command.Brand.CreateBrand
{
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommandRequest, CreateBrandCommandResponse>
    {
        private readonly IBrandWriteRepository _brandWriteRepository;

        public CreateBrandCommandHandler(IBrandWriteRepository brandWriteRepository)
        {
            _brandWriteRepository = brandWriteRepository;
        }

        public async Task<CreateBrandCommandResponse> Handle(CreateBrandCommandRequest request, CancellationToken cancellationToken)
        {
            await _brandWriteRepository.AddAsync(new()
            {
                Name = request.Name
            });

            await _brandWriteRepository.SaveAsync();

            return new();
        }
    }

    public class CreateBrandCommandRequest : IRequest<CreateBrandCommandResponse>
    {
        public string Name { get; set; }
    }

    public class CreateBrandCommandResponse
    {

    }
}
