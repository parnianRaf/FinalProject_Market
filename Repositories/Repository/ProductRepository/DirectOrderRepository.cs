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
        public async Task<DirectOrder> AddDirectOrder(int orderId, User customer, Product product, CancellationToken cancellation)
        {
            DirectOrder order = new()
            {
                Id = orderId,
                SellerId = product.UserId,
                UserId = customer.Id,
                User = customer,
                TotalPrice = (decimal)product.Price,
                CreatedBy = customer.Id,
                CreatedAt=DateTime.UtcNow
            };

            product.IsActive = false;
            product.DirectOrderId = orderId;
            product.DirectOrder = order;
            order.Products.Add(product);
            _context.DirectOrders.Add(order);
            _context.Products.Update(product);
            await _context.SaveChangesAsync(cancellation);
            return order;

        }

        //baraye buissiness =>inke sefareshesho taghir bede baraye list productha aval befahmim az hamin foroshande mitone bekhare ya foroshande dg
        public async Task<T> GetOrer<T>(int id, CancellationToken cancellation)
        {
            return _mapper.Map<T>( await _context.DirectOrders.Where(p => p.Id == id).FirstOrDefaultAsync(cancellation));
        }

        public async Task AddProductToOrderList(User user, Product product,DirectOrder order,decimal productPrice,CancellationToken cancellation)
        {
            //DirectOrder directOrder =await _context.DirectOrders.FirstOrDefaultAsync(o=>o.Id== order.Id) ?? new DirectOrder();
            //Product product1 = await _context.Products.FirstOrDefaultAsync(p => p.Id == product.Id) ?? new Product();
            order.Products.Add(product);
            order.TotalPrice = productPrice;
            product.IsActive = false;
            product.DirectOrder = order;
            product.DirectOrderId = order.Id;
            _context.Products.Update(product);
            _context.DirectOrders.Update(order);
            await _context.SaveChangesAsync(cancellation);
        }

        public async Task UpdateSubmitOrder(DirectOrder order,CancellationToken cancellation)
        {
            order.ModifiedAt = DateTime.Now;
            _context.Update(order);
            await _context.SaveChangesAsync(cancellation);
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
                order.ModifiedAt = DateTime.Now;
                _context.DirectOrders.Update(order);
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
                order.ModifiedAt = DateTime.Now;
                order.IsCommentDeleted = true;
                _context.DirectOrders.Update(order);
                //product.ModifiedBy
                await _context.SaveChangesAsync();
                return !result;
            }
            return result;
        }

        public async Task<DirectOrder> GetCurrentCustomerDirectOrders(int customerId, CancellationToken cancellation)
        {
            DirectOrder order= await _context.DirectOrders.Include(o=>o.User).Include(o=>o.Products).Where(o => !o.IsPaid).Where(o => o.UserId == customerId).FirstOrDefaultAsync(cancellation) ?? new DirectOrder();
            return order;
        }

        public async Task<DirectOrderCartDto> GetCart(int orderId,CancellationToken cancellation)
        {
            return await _context.DirectOrders.Where(o => o.Id == orderId).Select(o => new DirectOrderCartDto()
            {
                Id=o.Id,
                CustomerFullName = o.User.FullNameToString(),
                FactorDate = DateTime.UtcNow,
                FactorExpireDate = DateTime.UtcNow + TimeSpan.FromDays(20),
                SellerName = o.Products.FirstOrDefault().User.FullNameToString(),
                TotalPrice = o.TotalPrice,
                ProductDtos = o.Products.Select(p => new DetailedProductDto()
                {
                    Id = p.Id,
                    ProductName = p.ProductName,
                    Price = p.Price,
                    filePathSource =p.filePathSource

                }).ToList()

            }).FirstOrDefaultAsync(cancellation) ?? new DirectOrderCartDto();
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
                ComissionPaidByOrder=((d.Products.FirstOrDefault().User.HasMedal) &&(d.Products.FirstOrDefault().User.MedalAchievedAt<d.PaidAt)) ? "0" : Convert.ToString(d.TotalPrice*7/10),
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
            var result = dirctOrderDtos;
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

