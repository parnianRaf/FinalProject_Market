using System;
using System.Collections.Generic;
using AppCore;
using AppCore.DtoModels;
using AppCore.DtoModels.DirectOrder;
using AppCore.DtoModels.Product;
using AppSqlDataBase;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ExtensionMethods;
using Microsoft.AspNetCore.Identity;

namespace Repositories.Repository.ProductRepository
{
    public class DirectOrderRepository : IDirectOrderRepository
    {
        #region field
        private readonly MarketContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        #endregion

        #region ctor
        public DirectOrderRepository(MarketContext context
            , IMapper mapper, UserManager<User> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }
        #endregion

        #region Implementation
        //baraye list productha aval foroshandaro azash miprsim, list sefareshha tanha az yek maghaqze mitavanad bashad
        public async Task AddDirectOrder(AddDirectDto oredrDto, CancellationToken cancellation)
        {
            DirectOrder order = _mapper.Map<DirectOrder>(oredrDto);
            order.CreatedAt = DateTime.Now;
            //product.CreatedBy= .
            _context.DirectOrders.Add(order);
            await _context.SaveChangesAsync(cancellation);

        }

        //baraye buissiness =>inke sefareshesho taghir bede baraye list productha aval befahmim az hamin foroshande mitone bekhare ya foroshande dg
        public async Task<EditDirectOrderDto> GetOrer(int id, CancellationToken cancellation)
        {
            DirectOrder? order = await _context.DirectOrders.Where(p => p.Id == id).FirstOrDefaultAsync(cancellation);
            if (order != null)
            {
                return _mapper.Map<EditDirectOrderDto>(order);
            }
            return new EditDirectOrderDto();
        }

        public async Task<bool> EditAuction(EditDirectOrderDto orderDto, CancellationToken cancellation)
        {
            bool result = false;
            DirectOrder? order = await _context.DirectOrders.Where(p => p.Id == orderDto.Id).FirstOrDefaultAsync(cancellation);
            if (order != null)
            {
                _context.DirectOrders.Update(order);
                order.ModifiedAt = DateTime.Now;
                //auction.ModifiedBy
                await _context.SaveChangesAsync();
                return !result;
            }
            return result;
        }

        public async Task<bool> RemoveAuction(int id, CancellationToken cancellation)
        {
            DirectOrder? order = await _context.DirectOrders.Where(p => p.Id == id).FirstOrDefaultAsync(cancellation);
            if (order != null)
            {
                try
                {
                    order.IsDeleted = true;
                    order.DeletedAt = DateTime.Now;
                    //auction.DeletedBy
                    var res = _context.DirectOrders.Update(order);
                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;

                }


            }
            return false;


        }

        public async Task<bool> AddCommentByCustomer(int orderId, int customerId, string comment, CancellationToken cancellation)
        {
            bool result = false;
            DirectOrder? order = await _context.DirectOrders.Where(o => o.Id == orderId && o.UserId == customerId).FirstOrDefaultAsync(cancellation);
            if (order != null)
            {
                order.CommentByCostumer = comment;
                _context.DirectOrders.Update(order);
                await _context.SaveChangesAsync();
                return true;
            }
            return result;

        }

        public async Task<bool> AcceptComment(int orderId, CancellationToken cancellation)
        {
            bool result = false;
            DirectOrder? order = await _context.DirectOrders.Where(p => p.Id == orderId).FirstOrDefaultAsync(cancellation);
            if (order != null)
            {
                order.IsCommentAcceptedByAdmin = true;
                _context.DirectOrders.Update(order);
                order.ModifiedAt = DateTime.Now;
                //product.ModifiedBy
                await _context.SaveChangesAsync();
                return !result;
            }
            return result;
        }

        public async Task<bool> RejectComment(int orderId, CancellationToken cancellation)
        {
            bool result = false;
            DirectOrder? order = await _context.DirectOrders.Where(p => p.Id == orderId).FirstOrDefaultAsync(cancellation);
            if (order != null)
            {
                order.IsCommentAcceptedByAdmin = false;
                _context.DirectOrders.Update(order);
                order.ModifiedAt = DateTime.Now;
                //product.ModifiedBy
                await _context.SaveChangesAsync();
                return !result;
            }
            return result;
        }

        public async Task<List<DetailedDirctOrderDto>> GetAllPaidOrders(CancellationToken cancellation)
        {
            List<DetailedDirctOrderDto> dirctOrderDtos = await _context.DirectOrders.Where(d => d.IsPaid).Select(d => new DetailedDirctOrderDto()
            {
                Id = d.Id,
                IsPaid = d.IsPaid,
                TotalPrice = d.TotalPrice,
                SellerName = d.Products.FirstOrDefault().User.FullNameToString(),
                CustomerName = d.User.FullNameToString(),
                CommentByCostumer = d.CommentByCostumer,
                IsCommentAcceptedByAdmin = d.IsCommentAcceptedByAdmin,
                IsCommentDeleted = d.IsCommentDeleted,
                ProductDtos = d.Products.Select(o => new DetailedProductDto()
                {
                    Id = o.Id,
                    ProductName = o.ProductName,
                    Price = o.Price,
                    SellerFullName = o.User.FullNameToString(),
                    CategoryName = o.Category.Title,
                    PavilionName = o.User.Pavilions.FirstOrDefault(p => p.Id == o.PavilionId).Title,
                    filePathSource = o.filePathSource
                }).ToList()

            }).ToListAsync(cancellation);
            return dirctOrderDtos;
        }

        public async Task<decimal> CommisionPaidBySellerDirectOredr(int sellerId,CancellationToken cancellation)
        {
            User? seller =await _userManager.FindByIdAsync(sellerId.ToString());
            if (seller!=null)
            {
                if(seller.HasMedal)
                {
                    return await _context.DirectOrders.Where(o => o.PaidAt < seller.MedalAchievedAt).Select(o => o.TotalPrice).SumAsync(cancellation);
                }
                return await _context.DirectOrders.Select(o => o.TotalPrice).SumAsync(cancellation);

            }
            return 0;

        }

        #endregion

    }
}

