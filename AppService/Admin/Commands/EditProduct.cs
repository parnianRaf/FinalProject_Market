using System;
using AppCore.AppServices.Admin_.Command;
using AppCore.DtoModels.Product;
using Repositories.Repository.ProductRepository;

namespace AppService.Admin.Commands
{
	public class EditProduct:IEditProduct
    {
        #region field
        private readonly IProductRepository _productRepository;
        #endregion

        #region ctor
        public EditProduct(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        #endregion

        #region Implementation

        //public async Task<bool> Execute(EditProductDto productDto, CancellationToken cancellation)
        //{
        //    return await _productRepository.EditProduct(productDto, cancellation);
        //}

        public async Task<bool> Execute(DetailedProductDto productDto, CancellationToken cancellation)
        {
            return await _productRepository.EditProduct(productDto, cancellation);
        }

        #endregion
    }
}

