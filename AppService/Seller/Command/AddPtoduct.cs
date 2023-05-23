using System;
using AppCore.AppServices.Seller.Command;
using AppCore.DtoModels.Product;
using Repositories.Repository.ProductRepository;

namespace AppService.Seller.Command
{
	public class AddPtoduct: IAddProduct
    {
		private readonly IProductRepository _productRepository;
		public AddPtoduct(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}
		public async Task Execute(AddProductDto productDto,CancellationToken cancellation)
		{
			_productRepository.AddProduct(productDto, cancellation);
		}

	}
}

