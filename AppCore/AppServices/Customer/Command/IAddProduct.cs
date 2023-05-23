using System;
using AppCore.DtoModels.Product;

namespace AppCore.AppServices.Seller.Command
{
    public interface IAddProduct
	{
		Task Execute(AddProductDto productDto,CancellationToken cancellation);
	}
    public interface ILogIn
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }
    public interface IRegister
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }
    public interface IEditProfile
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }
    public interface IGetProfile
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }
    public interface IDeleteAccount
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }
    public interface IAddAuction
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }
    public interface IEditAuction
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }
    public interface IGetAuction
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }
    public interface IGetAuctionList
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }
    public interface IDeleteAuction
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }
    public interface IDeleteAuction
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }
    public interface IDeleteAuction
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }
    public interface IDeleteAuction
    {
        Task Execute(AddProductDto productDto, CancellationToken cancellation);
    }




}

