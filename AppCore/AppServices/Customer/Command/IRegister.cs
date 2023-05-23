using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Customer.Command
{
    public interface IRegister
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }





}

