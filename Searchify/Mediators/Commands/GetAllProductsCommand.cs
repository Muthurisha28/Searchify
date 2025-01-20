using MediatR;
using Searchify.Core.Model;

namespace Searchify.Mediators.Commands
{
    public class GetAllProductsCommand : IRequest<IEnumerable<Product>>
    {

    }
}
