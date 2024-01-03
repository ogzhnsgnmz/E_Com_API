using ECom.Application.Repositories.Brand;
using ECom.Application.Repositories.Category;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Application.Features.Command.Category.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest, CreateCategoryCommandResponse>
    {
        private readonly ICategoryWriteRepository _categoryWriteRepository;

        public CreateCategoryCommandHandler(ICategoryWriteRepository categoryWriteRepository)
        {
            _categoryWriteRepository = categoryWriteRepository;
        }

        public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            await _categoryWriteRepository.AddAsync(new()
            {
                Name = request.Name,
                Slug = request.Slug
            });

            await _categoryWriteRepository.SaveAsync();

            return new();
        }
    }

    public class CreateCategoryCommandRequest : IRequest<CreateCategoryCommandResponse>
    {
        public string Name { get; set; }
        public string Slug { get; set; }
    }

    public class CreateCategoryCommandResponse
    {

    }
}