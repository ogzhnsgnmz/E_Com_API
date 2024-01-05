using ECom.Application.Repositories.Comment;

namespace ECom.Persistence.Repositories.Comment;

public class CommentReadRepository : ReadRepository<Domain.Entities.Comment>, ICommentReadRepository
{
    public CommentReadRepository(EComDbContext context) : base(context)
    {
    }
}
