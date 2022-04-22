using Devfreela.Core.Entities;
using Devfreela.Infrastructure.Persistence;
using MediatR;

namespace Devfreela.Aplication.Commands.CreateComment
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, Unit>
    {
        private readonly DevFreelaDbContext _dbContext;
        public CreateCommentCommandHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = new ProjectComment(request.Content, request.IdProject, request.IdUser);

            _dbContext.ProjectComments.Add(comment);

            return Unit.Value;
        }
    }
}
