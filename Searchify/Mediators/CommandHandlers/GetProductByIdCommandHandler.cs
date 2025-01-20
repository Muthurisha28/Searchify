using System.Reflection.Metadata.Ecma335;
using MediatR;
using Searchify.Core.Interfaces;
using Searchify.Core.Model;
using Searchify.Mediators.Commands;

namespace Searchify.Mediators.CommandHandlers
{
    public class GetProductByIdCommandHandler : IRequestHandler<GetProductByIdCommand, Product>
    {
        private readonly IProductService _productService;

        public GetProductByIdCommandHandler(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<Product> Handle(GetProductByIdCommand request, CancellationToken cancellationToken)
        {
            return await _productService.GetProductById(request.ProductId);
        }
    }
}
