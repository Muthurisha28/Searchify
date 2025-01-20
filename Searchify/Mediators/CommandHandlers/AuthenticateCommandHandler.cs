using MediatR;
using Searchify.Core.Interfaces;
using Searchify.Mediators.Commands;

namespace Searchify.Mediators.CommandHandlers
{
    public class AuthenticateCommandHandler : IRequestHandler<AuthenticateCommand, string>
    {
        private readonly IAuthenticateService _authenticateService;

        public AuthenticateCommandHandler(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }

        public async Task<string> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
        {
            return await _authenticateService.AuthenticateUser(request.User);
        }
    }
}
