using ShowcaseRVHub.Domain.Model;

namespace ShowcaseRVHub.Domain.Commands
{
    public interface ICreateShowcaseUserCommand
    {
        Task ExecuteCreateAsync(ShowcaseUser user);
    }
}
