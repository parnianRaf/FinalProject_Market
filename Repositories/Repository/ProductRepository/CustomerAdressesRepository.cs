using System;
using AppCore;
using AppCore.DtoModels;
using AppCore.DtoModels.Category;
using AppCore.DtoModels.Customer;
using AppCore.DtoModels.Product;
using AppSqlDataBase;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Repository.ProductRepository
{
    public class CustomerAdressesRepository 
    {
        #region field
        private readonly MarketContext _context;
        private readonly IMapper _mapper;
        #endregion

        #region ctor
        public CustomerAdressesRepository(MarketContext context
            , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #endregion

        #region Implementation
        public async Task AddAddress(DetailedCustomerAdddressDto adddressDto, CancellationToken cancellation)
        {
            CustomerAddress address = _mapper.Map<CustomerAddress>(adddressDto);
            address.CreatedAt = DateTime.Now;
            //address.CreatedBy= .

            _context.CustomerAddressess.Add(address);
            await _context.SaveChangesAsync(cancellation);
        }

        public async Task<DetailedCustomerAdddressDto> EditGetCustomerAddress(int id, CancellationToken cancellation)
        {
            CustomerAddress? address = await _context.CustomerAddressess.Where(p => p.Id == id).FirstOrDefaultAsync(cancellation);
            if (address != null)
            {
                return _mapper.Map<DetailedCustomerAdddressDto>(address);
            }
            return new DetailedCustomerAdddressDto();
        }

        public async Task<bool> EditCustomerAddress(DetailedCustomerAdddressDto adddressDto, CancellationToken cancellation)
        {
            bool result = false;
            CustomerAddress? address = await _context.CustomerAddressess.Where(p => p.Id == adddressDto.Id).FirstOrDefaultAsync(cancellation);
            if (address != null)
            {
                _context.CustomerAddressess.Update(address);
                address.ModifiedAt = DateTime.Now;
                //address.ModifiedBy
                await _context.SaveChangesAsync();
                return !result;
            }
            return result;
        }

        public async Task<bool> SetMainAddress(int id, CancellationToken cancellationToken)
        {
            bool result = false;
            CustomerAddress? address = await _context.CustomerAddressess.Where(a => a.Id == id).FirstOrDefaultAsync();
            CustomerAddress? mainAddress = await _context.CustomerAddressess.Where(a => a.IsMainAddress == true).FirstOrDefaultAsync();

            if (address != null)
            {
                address.IsMainAddress = true;
                if (mainAddress != null)
                {
                    mainAddress.IsMainAddress = false;
                }
                _context.CustomerAddressess.UpdateRange(address, mainAddress);
                await _context.SaveChangesAsync(cancellationToken);
                return !result;

            }
            return result;
        }

        public async Task<bool> RemovePavilion(int id, CancellationToken cancellation)
        {
            CustomerAddress? address = await _context.CustomerAddressess.Where(p => p.Id == id).FirstOrDefaultAsync(cancellation);
            if (address != null)
            {
                try
                {
                    address.IsDeleted = true;
                    address.DeleteAt = DateTime.Now;
                    //address.DeletedBy
                    var res = _context.CustomerAddressess.Update(address);
                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;

                }


            }
            return false;


        }

        //public async Task<List<CustomerAddress>> GetAddresses(int id, CancellationToken cancellation)
        //{
        //    return await _context.CustomerAddressess.Where(a => a.CustomerId == id).ToListAsync(cancellation);
        //}
        #endregion
    }
}

