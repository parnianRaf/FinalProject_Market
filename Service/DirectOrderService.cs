using System;
using AppCore.DtoModels.DirectOrder;
using System.Reflection.Emit;
using Repositories.Repository.ProductRepository;
using AppCore;
using System.Collections.Generic;

namespace Service
{
    public class DirectOrderService : IDirectOrderService
    {
        private readonly IDirectOrderRepository _directOrderRepository;

        public DirectOrderService(IDirectOrderRepository directOrderRepository)
        {
            _directOrderRepository = directOrderRepository;
        }

        public async Task<DirectOrder> AddOrder(int orderId,User customer,Product product,CancellationToken cancellation)
        {
           return await _directOrderRepository.AddDirectOrder(orderId, customer, product, cancellation);
        }

        public async Task AddProductToOrderList(User user,Product product, DirectOrder order, CancellationToken cancellation)
        {
            decimal totalPrice = (decimal)(order.TotalPrice +product.Price);
            await _directOrderRepository.AddProductToOrderList(user,product, order, totalPrice, cancellation);
        }

        //public async Task<bool> IsExistCurrentUnPaidOrder(int  userId,CancellationToken cancellation)
        //{

        //}

        public bool IsAllowed(Product product, DirectOrder order)
        {
            return product.UserId == order.SellerId;
        }

        public async Task<List<DetailedDirctOrderDto>> GetAllDirectOrder(CancellationToken cancellation)
        {
            return await _directOrderRepository.GetAllPaidOrders(cancellation);
        }

        public async Task<DirectOrder> GetUnPaidDirectOrder(int customerId,CancellationToken cancellation)
        {
            DirectOrder order= await _directOrderRepository.GetCurrentCustomerDirectOrders(customerId, cancellation);
            return order;
        }

        public async Task<DirectOrderCartDto> GetDirectOrderCart(int orderId, CancellationToken cancellation)
        {
            return await _directOrderRepository.GetCart(orderId, cancellation);
        }

        public async Task<DirectOrder> GetEntityDirectOrder(int id, CancellationToken cancellation)
        {
            return await _directOrderRepository.GetOrer<DirectOrder>(id, cancellation);
        }

        public async Task<EditDirectOrderDto> GetDirectOrder(int id, CancellationToken cancellation)
        {
            return await _directOrderRepository.GetOrer<EditDirectOrderDto>(id, cancellation);
        }

        public async Task SubmitOrder(DirectOrder order,CancellationToken cancellation)
        {
            order.IsPaid = true;
            order.PaidAt = DateTime.UtcNow;
            await _directOrderRepository.UpdateSubmitOrder(order,cancellation);
        }

        public async Task SubmitComment(DirectOrder order,string comment,CancellationToken cancellation)
        {
            order.CommentByCostumer = comment;
            await _directOrderRepository.UpdateSubmitOrder(order, cancellation);
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

