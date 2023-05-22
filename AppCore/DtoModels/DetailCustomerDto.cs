using System;
namespace AppCore.DtoModels
{
	public class DetailCustomerDto
	{
        public int Id { get; set; }

        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string UserName { get; set; }

        public string PasswordHash { get; set; }

        public string NationalityCode { get; set; }

        public bool IsMainAddress { get; set; }
    }
}

