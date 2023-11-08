using ECom.Application.Repositories.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Application.Features.Command.Product.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        readonly IProductWriteRepository _ProductWriteRepository;

        public CreateProductCommandHandler(IProductWriteRepository ProductWriteRepository)
        {
            _ProductWriteRepository = ProductWriteRepository;
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            await _ProductWriteRepository.AddAsync(new()
            {
                Name = request.Name,
                Code = request.Code,
                Theoric = request.Theoric,
                Practical = request.Practical,
                AKTS = request.AKTS,
                SemesterId = Guid.Parse("1006FD27-7E4A-43A4-8CE9-1EF9D93E6847"),
                ArticleId = Guid.Parse("DA164FB9-F6A6-4DD1-87F8-44859BDAC21D")
            });

            await _ProductWriteRepository.SaveAsync();

            return new();
        }
    }
    public class CreateProductCommandRequest : IRequest<CreateProductCommandResponse>
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Theoric { get; set; }
        public string Practical { get; set; }
        public string AKTS { get; set; }
    }
    public class CreateProductCommandResponse
    {
    }
}
