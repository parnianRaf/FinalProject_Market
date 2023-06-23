using System;
using AppCore.DtoModels.DirectOrder;
using System.Reflection.Emit;
using Repositories.Repository.ProductRepository;
using AppCore;

namespace Service
{
    public class DirectOrderService : IDirectOrderService
    {
        private readonly IDirectOrderRepository _directOrderRepository;

        public DirectOrderService(IDirectOrderRepository directOrderRepository)
        {
            _directOrderRepository = directOrderRepository;
        }

        public async Task AddOrder(int orderId,User customer,Product product,CancellationToken cancellation)
        {
            await _directOrderRepository.AddDirectOrder(orderId, customer, product, cancellation);
        }

        public async Task AddProductToOrderList(Product product, DirectOrder order, CancellationToken cancellation)
        {
            decimal totalPrice = (decimal)(order.TotalPrice +product.Price);
            await _directOrderRepository.AddProductToOrderList(product, order, totalPrice, cancellation);
        }

        public bool IsExistCurrentUnPaidOrder(User user)
        {
            var x = user.DirectOrders.Where(d => !d.IsPaid).Any();
            return x;
        }

        public bool IsAllowed(Product product, DirectOrder order)
        {
            if(product.IsActive)
            {
                 return (product.UserId == order.SellerId);
            }
            return false;
        }

        public async Task<List<DetailedDirctOrderDto>> GetAllDirectOrder(CancellationToken cancellation)
        {
            return await _directOrderRepository.GetAllPaidOrders(cancellation);
        }

        public DirectOrder GetUnPaidDirectOrder(User customer)
        {
            return customer.DirectOrders.Where(o => !o.IsPaid).FirstOrDefault() ?? new DirectOrder();
        }

        public async Task<DirectOrder> GetEntityDirectOrder(int id, CancellationToken cancellation)
        {
            return await _directOrderRepository.GetOrer<DirectOrder>(id, cancellation);
        }

        public async Task<EditDirectOrderDto> GetDirectOrder(int id, CancellationToken cancellation)
        {
            return await _directOrderRepository.GetOrer<EditDirectOrderDto>(id, cancellation);
        }

        public async Task<bool> AcceptComment(int orderId, CancellationToken cancellation)
        {
            return await _directOrderRepository.AcceptComment(orderId, cancellation);
        }

        public async Task<bool> RejectComment(int orderId, CancellationToken cancellation)
        {
            return await _directOrderRepository.RejectComment(orderId, cancellation);
        }
    }
}

