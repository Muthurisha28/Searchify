using Searchify.Core.Model;

namespace Searchify.Core.Interfaces
{
    public interface IAuthenticateService
    {
        Task<string> AuthenticateUser(User user);
    }
}
