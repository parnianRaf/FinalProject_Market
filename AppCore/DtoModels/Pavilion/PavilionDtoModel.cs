using System;
namespace AppCore.DtoModels
{
	public class PavilionDtoModel
	{
        public int Id { get; set; }

        public string? Title { get; set; }

        public string SellerName { get; set; }

        public bool IsAccepted { get; set; }

        public DateTime AcceptedAt { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedAt { get; set; }
    }
}

