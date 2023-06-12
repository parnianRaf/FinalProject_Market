﻿using AppCore.DtoModels.Category;
using AppCore.DtoModels.Product;

namespace AppCore.Contracts.AppServices.Account
{
    public interface IMapServices
    {
        User MapUser<T>(T userDto);
        List<T> MapUser<T>(List<User> users);
        T MapUser<T>(User user);
        List<CategoryDtoModel> MapCategory(List<Category> categories);
        Product MapProduct(AddProductDto productDto);
        Category MapCategory(CategoryDtoModel categories);
    }
}