using System;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace AppCore.Contracts.AppServices.Account
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
    }
}

