using System;
namespace AppCore.DtoModels.DirectOrder
{
	public class CommentOrderDto
	{
		public int Id { get; set; }

		public string Comment { get; set; }

		public string? CommentSubmitedAt { get; set; }

		public string CustomerImageFile { get; set; }
	}
}

