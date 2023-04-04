using SendGrid.Helpers.Mail;
using SendGrid;
using ShowcaseRVHub.MAUI.Model;
using ShowcaseRVHub.MAUI.Services.Interfaces;

namespace ShowcaseRVHub.MAUI.Services
{
    public class UserEmailService : IUserEmailService
    {
        private readonly IUserRepository _userRepository;
        private readonly ISendGridEmailService _sendGridEmailService;
        public UserEmailService(IUserRepository userRepository, ISendGridEmailService sendGridEmailService)
        {
            _userRepository = userRepository;
            _sendGridEmailService = sendGridEmailService;

        }

        public async Task<bool> ResetPasswordAsync(string email)
        {
            UserModel user = await _userRepository.GetUserByEmailAsync(email);

            if (user != null)
            {
                // Sending a password reset email
                await _sendGridEmailService.SendResetPasswordEmailAsync(email, user.FirstName, "first_name", user.FirstName);

                return true;
            }
            return false;
        }

        public async Task<bool> RetrieveUsernameAsync(string email)
        {
            UserModel user = await _userRepository.GetUserByEmailAsync(email);

            if (user != null)
            {
                // Simulate returning the user's username
                return true;
            }

            return false;
        }
    }
}
