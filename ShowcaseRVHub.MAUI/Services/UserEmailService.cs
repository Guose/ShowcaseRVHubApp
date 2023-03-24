using ShowcaseRVHub.MAUI.Model;
using ShowcaseRVHub.MAUI.Services.Interfaces;

namespace ShowcaseRVHub.MAUI.Services
{
    public class UserEmailService : IUserEmailService
    {
        private readonly IUserRepository _userRepository;
        public UserEmailService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> ResetPasswordAsync(string email)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);

            if (user != null)
            {
                // Simulate sending a password reset email
                // In a real implementation, you would send an email with a unique link for resetting the password
                return true;
            }
            return false;
        }

        public async Task<bool> RetrieveUsernameAsync(string email)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);

            if (user != null)
            {
                // Simulate returning the user's username
                return true;
            }

            return false;
        }
    }
}
