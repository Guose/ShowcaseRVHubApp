using ShowcaseRVHub.Domain.Model;

namespace ShowcaseRVHub.Domain.Commands
{
    public interface IUpdateShowcaseUserCommand
    {
        Task ExecuteUpdateAsync(ShowcaseUser user);
    }
}
