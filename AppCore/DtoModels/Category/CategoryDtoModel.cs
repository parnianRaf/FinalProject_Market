using System;
using AppCore.DtoModels.Product;

namespace AppCore.DtoModels.Category
{
	public class CategoryDtoModel
	{
        public int Id { get; set; }

        public string Title { get; set; }

        public string ImageFile { get; set; }

        public List<DetailedProductDto>? productDtos { get; set; }
    }
}

