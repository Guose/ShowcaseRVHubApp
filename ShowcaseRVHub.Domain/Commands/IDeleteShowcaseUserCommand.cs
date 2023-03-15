using ShowcaseRVHub.Domain.Model;

namespace ShowcaseRVHub.Domain.Commands
{
    public interface IDeleteShowcaseUserCommand
    {
        Task ExecuteDeleteAsync(Guid id);
    }
}
