using System;
using AppCore.DtoModels.Auction;
using AppCore.DtoModels.Category;
using AppCore.DtoModels.DirectOrder;
using AppCore.DtoModels.Product;
using AutoMapper;

namespace AppCore.Contracts.AppServices
{
    public class MapServices : IMapServices
    {
        #region field
        private readonly IMapper _mapper;
        #endregion

        #region ctor
        public MapServices(IMapper mapper)
        {
            _mapper = mapper;
        }
        #endregion

        public User MapUser<T>(T userDto)
        {
            return _mapper.Map<User>(userDto);
        }

        public T MapUser<T>(User user)
        {
            return _mapper.Map<T>(user);
        }

        public List<T> MapUser<T>(List<User> users)
        {
            return _mapper.Map<List<T>>(users);
        }

        public List<CategoryDtoModel> MapCategory(List<Category> categories)
        {
            return _mapper.Map<List<CategoryDtoModel>>(categories);
        }

        public Category MapCategory(CategoryDtoModel categories)
        {
            return _mapper.Map<Category>(categories);
        }

        public Product MapProduct(AddProductDto productDto)
        {
            return _mapper.Map<Product>(productDto);
        }

        public Auction MapAuction(AddAuctionDto auctionDto)
        {
            return _mapper.Map<Auction>(auctionDto);
        }

        public EditDirectOrderDto MapOrder(DirectOrder order)
        {
            return _mapper.Map<EditDirectOrderDto>(order);
        }

    }
}

