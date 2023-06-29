using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Seller.Command
{
    public interface IGetListOfActionsOffer
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }





}

