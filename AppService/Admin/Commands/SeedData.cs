using System;
using AppCore.AppServices.Admin_.Command;
using Repositories.UserRepository;

namespace AppService.Admin
{
    public class SeedData : ISeedData
    {
        #region field
        private readonly IAdminRepository _repository;
        #endregion
        #region ctor
        public SeedData(IAdminRepository repository)
        {
            _repository = repository;
        }
        #endregion
        #region Implementation
        public async Task<bool> Execute()
        {
            return await _repository.SeedAdminData();
        }
        #endregion
    }
}

