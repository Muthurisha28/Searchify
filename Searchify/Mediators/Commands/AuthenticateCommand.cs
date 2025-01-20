using MediatR;
using Searchify.Core.Model;

namespace Searchify.Mediators.Commands
{
    public class AuthenticateCommand : IRequest<string>
    {
        public User User { get; set;}

        public AuthenticateCommand(User user)
        {
            User = user;
        }
    }
}
