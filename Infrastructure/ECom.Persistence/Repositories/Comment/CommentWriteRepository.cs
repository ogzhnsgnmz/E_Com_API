using ECom.Application.Repositories.Comment;

namespace ECom.Persistence.Repositories.Comment;

public class CommentWriteRepository : WriteRepository<Domain.Entities.Comment>, ICommentWriteRepository
{
    public CommentWriteRepository(EComDbContext context) : base(context)
    {
    }
}
