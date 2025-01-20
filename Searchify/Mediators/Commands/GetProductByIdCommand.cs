using MediatR;
using Searchify.Core.Model;

namespace Searchify.Mediators.Commands
{
    public class GetProductByIdCommand :IRequest<Product>
    {
        public int ProductId {  get; set; }

        public GetProductByIdCommand(int productId)
        {
            ProductId = productId;
        }
    }
}
