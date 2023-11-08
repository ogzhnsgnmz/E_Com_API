using ECom.Application.Repositories.Product;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Application.Features.Command.Product.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        readonly IProductReadRepository _ProductReadRepository;
        readonly IProductWriteRepository _ProductWriteRepository;
        readonly ILogger<UpdateProductCommandHandler> _logger;

        public UpdateProductCommandHandler(IProductReadRepository ProductReadRepository, IProductWriteRepository ProductWriteRepository = null, ILogger<UpdateProductCommandHandler> logger = null)
        {
            _ProductReadRepository = ProductReadRepository;
            _ProductWriteRepository = ProductWriteRepository;
            _logger = logger;
        }

        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Product Product = await _ProductReadRepository.GetByIdAsync(request.Id);
            Product.Name = request.Name;
            Product.Code = request.Code;
            Product.Practical = request.Practical;
            Product.Theoric = request.Theoric;
            Product.AKTS = Product.AKTS;
            await _ProductWriteRepository.SaveAsync();
            _logger.LogInformation("Ders güncellendi");
            return new();
        }
    }
    public class UpdateProductCommandRequest : IRequest<UpdateProductCommandResponse>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Theoric { get; set; }
        public string Practical { get; set; }
        public string AKTS { get; set; }
    }
    public class UpdateProductCommandResponse
    {
    }
}
