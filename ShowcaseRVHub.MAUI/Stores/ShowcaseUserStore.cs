using ShowcaseRVHub.Domain.Commands;
using ShowcaseRVHub.Domain.Model;
using ShowcaseRVHub.Domain.Queries;

namespace ShowcaseRVHub.MAUI.Stores
{
    public class ShowcaseUserStore
    {
        private readonly ICreateShowcaseUserCommand _createUserCommand;
        private readonly IUpdateShowcaseUserCommand _updateUserCommand;
        private readonly IDeleteShowcaseUserCommand _deleteUserCommand;
        private readonly IShowcaseUserQuery _showcaseUserQuery;
        private readonly List<ShowcaseUser> _showcaseUsersList;

        public IEnumerable<ShowcaseUser> ShowcaseUsersList => _showcaseUsersList;

        public event Action ShowcaseUsersLoaded;
        public event Action<ShowcaseUser> ShowcaseUserAdded;
        public event Action<ShowcaseUser> ShowcaseUserUpdated;
        public event Action<Guid> ShowcaseUserDeleted;

        public ShowcaseUserStore(
            ICreateShowcaseUserCommand createUserCommand,
            IUpdateShowcaseUserCommand updateUserCommand,
            IDeleteShowcaseUserCommand deleteUserCommand,
            IShowcaseUserQuery showcaseUserQuery)
        {
            _createUserCommand = createUserCommand;
            _updateUserCommand = updateUserCommand;
            _deleteUserCommand = deleteUserCommand;
            _showcaseUserQuery = showcaseUserQuery;

            _showcaseUsersList = new List<ShowcaseUser>();
        }

        public async Task LoadAsync()
        {
            IEnumerable<ShowcaseUser> showcaseUsers = await _showcaseUserQuery.GetAllShowcaseUsersAsync();

            _showcaseUsersList.Clear();
            _showcaseUsersList.AddRange(showcaseUsers);

            ShowcaseUsersLoaded?.Invoke();
        }

        public async Task CreateAsync(ShowcaseUser showcaseUser)
        {
            await _createUserCommand.ExecuteCreateAsync(showcaseUser);

            _showcaseUsersList.Add(showcaseUser);

            ShowcaseUserAdded?.Invoke(showcaseUser);
        }

        public async Task UpdateAsync(ShowcaseUser showcaseUser)
        {
            await _updateUserCommand.ExecuteUpdateAsync(showcaseUser);

            int currentUserIndex = _showcaseUsersList.FindIndex(u => u.Id == showcaseUser.Id);

            if (currentUserIndex != -1)
                _showcaseUsersList[currentUserIndex] = showcaseUser;
            else
                _showcaseUsersList.Add(showcaseUser);

            ShowcaseUserUpdated?.Invoke(showcaseUser);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _deleteUserCommand.ExecuteDeleteAsync(id);

            _showcaseUsersList.RemoveAll(u => u.Id != id);

            ShowcaseUserDeleted?.Invoke(id);
        }
    }
}
