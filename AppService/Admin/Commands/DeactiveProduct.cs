using System;
using AppCore.AppServices.Admin_.Command;
using Repositories.Repository.ProductRepository;

namespace AppService.Admin.Commands
{
	public class DeactiveProduct: IDeactiveProduct
    {
        #region field
        private readonly IProductRepository _productRepository;
        #endregion

        #region ctor
        public DeactiveProduct(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        #endregion

        #region Implementation
        public async Task<bool> Execute(int id, CancellationToken cancellation)
        {
            return await _productRepository.RemoveProduct(id, cancellation);
        }
        #endregion

    }
}

