using ShowcaseRVHub.Domain.Commands;

namespace ShowcaseRVHub.EntityFramework.Commands
{
    public class DeleteShowcaseUserCommand : IDeleteShowcaseUserCommand
    {
        public Task ExecuteDeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
