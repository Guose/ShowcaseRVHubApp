using ShowcaseRVHub.Domain.Commands;
using ShowcaseRVHub.Domain.Model;

namespace ShowcaseRVHub.EntityFramework.Commands
{
    public class UpdateShowcaseUserCommand : IUpdateShowcaseUserCommand
    {
        public Task ExecuteUpdateAsync(ShowcaseUser user)
        {
            throw new NotImplementedException();
        }
    }
}
