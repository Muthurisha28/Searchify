using MediatR;
using Searchify.Core.Interfaces;
using Searchify.Core.Model;
using Searchify.Mediators.Commands;

namespace Searchify.Mediators.CommandHandlers
{
    public class GetAllProductsCommandHandler : IRequestHandler<GetAllProductsCommand, IEnumerable<Product>>
    {

        private readonly IProductService _productService;

        public GetAllProductsCommandHandler(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IEnumerable<Product>> Handle(GetAllProductsCommand request, CancellationToken cancellationToken)
        {
            return await _productService.GetAllProducts();
        }
    }
}
