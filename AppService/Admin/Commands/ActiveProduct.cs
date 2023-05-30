using System;
using AppCore.AppServices.Admin_.Command;
using AppCore.DtoModels.Product;
using Repositories.Repository.ProductRepository;

namespace AppService.Admin.Commands
{
	public class ActiveProduct:IActiveProduct
	{
        #region field
        private readonly IProductRepository _productRepository;
        #endregion

        #region ctor
        public ActiveProduct(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        #endregion

        #region Implementation

        public async Task Execute(int id, CancellationToken cancellation)
        {
            await _productRepository.AcceptProduct(id, cancellation);
        }
        #endregion
    }
}

