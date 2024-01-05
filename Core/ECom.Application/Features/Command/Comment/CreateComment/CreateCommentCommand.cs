using ECom.Application.Repositories.Comment;
using ECom.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Application.Features.Command.Comment.CreateComment
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommandRequest, CreateCommentCommandResponse>
    {
        private readonly ICommentWriteRepository _CommentWriteRepository;

        public CreateCommentCommandHandler(ICommentWriteRepository CommentWriteRepository)
        {
            _CommentWriteRepository = CommentWriteRepository;
        }

        public async Task<CreateCommentCommandResponse> Handle(CreateCommentCommandRequest request, CancellationToken cancellationToken)
        {
            await _CommentWriteRepository.AddAsync(new()
            {
                ProductId = Guid.Parse(request.ProductId),
                UserName = "admin",
                Content = request.Content,
                Ratings = request.Rating,
                Timestamp = DateTime.Now
            });

            await _CommentWriteRepository.SaveAsync();

            return new();
        }
    }

    public class CreateCommentCommandRequest : IRequest<CreateCommentCommandResponse>
    {
        public string Content { get; set; }
        public int Rating { get; set; }
        public string ProductId { get; set; }
    }

    public class CreateCommentCommandResponse
    {

    }
}