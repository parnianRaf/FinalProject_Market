using AppCore.DtoModels.Product;

namespace Service
{
    public interface IProductService
    {
        List<string> GetProductNames(List<DetailedProductDto> productDtos);
    }
}