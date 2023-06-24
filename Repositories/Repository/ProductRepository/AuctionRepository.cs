﻿using System;
using System.Collections.Generic;
using AppCore;
using AppCore.DtoModels;
using AppCore.DtoModels.Auction;
using AppCore.DtoModels.Offer;
using AppCore.DtoModels.Product;
using AppSqlDataBase;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ExtensionMethods;
using Microsoft.AspNetCore.Identity;

namespace Repositories.Repository.ProductRepository
{
    public class AuctionRepository : IAuctionRepository
    {
        #region field
        private readonly MarketContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        #endregion

        #region ctor
        public AuctionRepository(MarketContext context
            , IMapper mapper, UserManager<User> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }
        #endregion

        #region Implementation
        public async Task AddAuction(int id, int sellerId,List<Product> products,Auction auction, CancellationToken cancellation)
        {
            auction.Id = id;
            auction.SellerId = sellerId;
            auction.CreateAt = DateTime.Now;
            auction.CreateBy = sellerId;
            auction.Products = products;
            products.ForEach(p => { p.Auction = auction; p.AuctionId = id; });
            _context.Auctions.Add(auction);
            auction.Products.ForEach((p => _context.Products.Update(p)));
            await _context.SaveChangesAsync(cancellation);
        }

        //moghe buissiness hatman baiad havasemon bashe ke datetime now o start auction moghayese shavad

        public async Task<EditAuctionDto> EditGetAuction(int id, CancellationToken cancellation)
        {
            Auction? auction = await _context.Auctions.Where(p => p.Id == id).FirstOrDefaultAsync(cancellation);
            if (auction != null)
            {
                return _mapper.Map<EditAuctionDto>(auction);
            }
            return new EditAuctionDto();
        }

        public async Task UpdateAuction(Auction auction,CancellationToken cancellation)
        {
            _context.Update(auction);
            await _context.SaveChangesAsync(cancellation);
        }

        public async Task<bool> EditAuction(EditAuctionDto auctionDto, CancellationToken cancellation)
        {
            bool result = false;
            Auction? auction = await _context.Auctions.Where(p => p.Id == auctionDto.Id).FirstOrDefaultAsync(cancellation);
            if (auction != null)
            {
                _context.Auctions.Update(auction);
                auction.ModeifiedAt = DateTime.Now;
                //auction.ModifiedBy
                await _context.SaveChangesAsync();
                return !result;
            }
            return result;
        }

        public async Task<bool> RemoveAuction(int id, CancellationToken cancellation)
        {
            Auction? auction = await _context.Auctions.Where(p => p.Id == id).FirstOrDefaultAsync(cancellation);
            if (auction != null)
            {
                try
                {
                    auction.IsDeleted = true;
                    auction.DeleteAt = DateTime.Now;
                    //auction.DeletedBy
                    var res = _context.Auctions.Update(auction);
                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;

                }


            }
            return false;


        }

        //selerId baiad hamon htttpContext.User.Id????????????????????????!!!!!!!!!!!
        public async Task<List<DetailedAuctionDto>> GetAllSellerAuctions(CancellationToken cancellation, int SellerId)
        {
            List<Auction> auctions = await _context.Auctions.Where(p => p.SellerId == SellerId).ToListAsync(cancellation);
            return _mapper.Map<List<DetailedAuctionDto>>(auctions);
        }

        //selerId baiad hamon htttpContext.User.Id????????????????????????!!!!!!!!!!!
        public async Task<List<DetailedAuctionDto>> GetAllCustomersAuctions(CancellationToken cancellation, int CustomerId)
        {
            List<Auction> auctions = await _context.Auctions.Where(p => p.AcceptedCustomerId == CustomerId).ToListAsync(cancellation);
            return _mapper.Map<List<DetailedAuctionDto>>(auctions);
        }

        //public async Task<List<DetailedProductDto>> GetProductsInSpecificAuction(int sellerId, int auctionId, CancellationToken cancellation)
        //{
        //    List<Product> products = await _context.Products.Where(p => p.SellerId == sellerId && p.AuctionId == auctionId).ToListAsync();
        //    return _mapper.Map<List<DetailedProductDto>>(products);
        //}

        public async Task<List<DetailedOfferDto>> GetOffersInSpecificSellerAuction(int sellerId, int auctionId, CancellationToken cancellation)
        {
            List<Offer> offers = await _context.Offers.Where(o => o.Auction.Id == auctionId && o.Auction.SellerId == sellerId).ToListAsync();
            return _mapper.Map<List<DetailedOfferDto>>(offers);
        }

        //public async Task<List<DetailedOfferDto>> GetOffersInSpecificCustomerAuction(int customerId, int auctionId, CancellationToken cancellation)
        //{
        //    List<Offer> offers = await _context.Offers.Where(o => o.Auction.Id == auctionId && o.CustomerId == customerId).ToListAsync();
        //    return _mapper.Map<List<DetailedOfferDto>>(offers);
        //}

        public async Task<bool> AddCommentByCustomer(int auctionId, int customerId, string comment, CancellationToken cancellation)
        {
            bool result = false;
            Auction? auction = await _context.Auctions.Where(o => o.Id == auctionId && o.AcceptedCustomerId == customerId).FirstOrDefaultAsync(cancellation);
            if (auction != null)
            {
                _context.Auctions.Update(auction);
                await _context.SaveChangesAsync();
                return true;
            }
            return result;

        }

        public async Task<bool> AcceptComment(int auctionId, CancellationToken cancellation)
        {
            bool result = false;
            Auction? auction = await _context.Auctions.Where(p => p.Id == auctionId).FirstOrDefaultAsync(cancellation);
            if (auction != null)
            {
                auction.IsCommentAcceptedByAdmin = true;
                auction.ModeifiedAt = DateTime.Now;
                _context.Auctions.Update(auction);
                await _context.SaveChangesAsync();
                return !result;
            }
            return result;
        }

        public async Task<bool> RejectComment(int auctionId, CancellationToken cancellation)
        {
            bool result = false;
            Auction? auction = await _context.Auctions.Where(p => p.Id == auctionId).FirstOrDefaultAsync(cancellation);
            if (auction != null)
            {
                auction.IsCommentAcceptedByAdmin = false;
                auction.IsCommentDeleted = true;
                auction.ModeifiedAt = DateTime.Now;
                _context.Auctions.Update(auction);
                //product.ModifiedBy
                await _context.SaveChangesAsync();
                return !result;
            }
            return result;
        }

        public async Task<List<Auction>> GetAllEntityAuction(CancellationToken cancellation)
        {
            return await _context.Auctions.ToListAsync(cancellation);
        }
        //tamame auctionhaye tamam shode
        public async Task<List<DetailedAuctionDto>> GetAllAuctions(CancellationToken cancellation)
        {
            List<DetailedAuctionDto> auctionDtos =await _context.Auctions.Where(a=>a.IsFinished).Select(a => new DetailedAuctionDto()
            {
                Id = a.Id,
                StartTime = a.StartTime,
                EndTime = a.EndTime,
                AcceptedCustomerName = a.Offers.FirstOrDefault(o => o.AuctionId == a.Id && o.IsAccepted).User.FullNameToString(),
                FinalPrice = a.FinalPrice,
                // har auction tanha be yek seller taalogh darad
                SellerName = a.Products.FirstOrDefault().User.FullNameToString(),
                FinalCommentByCostumer = a.FinalCommentByCostumer,
                IsCommentAcceptedByAdmin = a.IsCommentAcceptedByAdmin,
                CommentAcceptedAt = a.CommentAcceptedAt,
                IsCommentDeleted = a.IsCommentDeleted,
                CommentDeletedAt = a.CommentDeletedAt,
                ComissionPaidByauction = ((a.Products.FirstOrDefault().User.HasMedal) && (a.Products.FirstOrDefault().User.MedalAchievedAt < DateTime.Now)) ? "0" : Convert.ToString(a.FinalPrice * 7 / 10),
                IsFinished = a.IsFinished,
                ProductDtos = a.Products.Select(o => new DetailedProductDto()
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
            return auctionDtos;
        }

        public async Task<List<DetailedAuctionDto>> GetAllAvailableAuctions(CancellationToken cancellation)
        {
            List<DetailedAuctionDto> auctionDtos = await _context.Auctions.Where(a => a.IsActive==true).Select(a => new DetailedAuctionDto()
            {
                Id = a.Id,
                StartTime = a.StartTime,
                EndTime = a.EndTime,
                AcceptedCustomerName = a.Offers.FirstOrDefault(o => o.AuctionId == a.Id && o.IsAccepted).User.FullNameToString(),
                FinalPrice = a.FinalPrice,
                // har auction tanha be yek seller taalogh darad
                SellerName = a.Products.FirstOrDefault().User.FullNameToString(),
                FinalCommentByCostumer = a.FinalCommentByCostumer,
                IsCommentAcceptedByAdmin = a.IsCommentAcceptedByAdmin,
                CommentAcceptedAt = a.CommentAcceptedAt,
                IsCommentDeleted = a.IsCommentDeleted,
                CommentDeletedAt = a.CommentDeletedAt,
                ComissionPaidByauction = ((a.Products.FirstOrDefault().User.HasMedal) && (a.Products.FirstOrDefault().User.MedalAchievedAt < DateTime.Now)) ? "0" : Convert.ToString(a.FinalPrice * 7 / 10),
                IsFinished = a.IsFinished,
                ProductDtos = a.Products.Select(o => new DetailedProductDto()
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
            return auctionDtos;
        }

        public async Task<List<DetailedAuctionDto>> GetAllPaidOrUnPaidAuctions(CancellationToken cancellation)
        {
            List<DetailedAuctionDto> auctionDtos = await _context.Auctions.Select(a => new DetailedAuctionDto()
            {
                Id = a.Id,
                StartTime = a.StartTime,
                EndTime = a.EndTime,
                AcceptedCustomerName = a.Offers.FirstOrDefault(o => o.AuctionId == a.Id && o.IsAccepted).User.FullNameToString(),
                FinalPrice = a.FinalPrice,
                // har auction tanha be yek seller taalogh darad
                SellerName = a.Products.FirstOrDefault().User.FullNameToString(),
                FinalCommentByCostumer = a.FinalCommentByCostumer,
                IsCommentAcceptedByAdmin = a.IsCommentAcceptedByAdmin,
                CommentAcceptedAt = a.CommentAcceptedAt,
                IsCommentDeleted = a.IsCommentDeleted,
                CommentDeletedAt = a.CommentDeletedAt,
                ComissionPaidByauction = ((a.Products.FirstOrDefault().User.HasMedal) && (a.Products.FirstOrDefault().User.MedalAchievedAt < DateTime.Now)) ? "0" : Convert.ToString(a.FinalPrice * 7 / 10),
                IsFinished = a.IsFinished,
                ProductDtos = a.Products.Select(o => new DetailedProductDto()
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
            return auctionDtos;
        }

        public async Task<Auction> GetAuction(int id, CancellationToken cancellation)
        {
            return await _context.Auctions.Where(p => p.Id == id).FirstOrDefaultAsync(cancellation) ?? new Auction();
        }

        public async Task<DetailedAuctionDto> GetDetailedAuction(int id, CancellationToken cancellation)
        {
            Auction? auction = await _context.Auctions.Where(p => p.Id == id).FirstOrDefaultAsync(cancellation);
            if (auction != null)
            {
                return new DetailedAuctionDto()
                {
                    Id = auction.Id,
                    StartTime = auction.StartTime,
                    EndTime = auction.EndTime,
                    AcceptedCustomerName = auction.Offers.FirstOrDefault(o => o.AuctionId == auction.Id).User.FullNameToString(),
                    FinalPrice = auction.FinalPrice,
                    // har auction tanha be yek seller taalogh darad
                    SellerName = auction.Products.FirstOrDefault().User.FullNameToString(),
                    FinalCommentByCostumer = auction.FinalCommentByCostumer,
                    IsCommentAcceptedByAdmin = auction.IsCommentAcceptedByAdmin,
                    CommentAcceptedAt = auction.CommentAcceptedAt,
                    IsCommentDeleted = auction.IsCommentDeleted,
                    CommentDeletedAt = auction.CommentDeletedAt,
                    IsFinished = auction.IsFinished,
                    ProductDtos = auction.Products.Select(o => new DetailedProductDto()
                    {
                        Id = o.Id,
                        ProductName = o.ProductName,
                        Price = o.Price,
                        SellerFullName = o.User.FullNameToString(),
                        CategoryName = o.Category.Title,
                        PavilionName = o.User.Pavilions.FirstOrDefault(p => p.Id == o.PavilionId).Title,
                        filePathSource = o.filePathSource
                    }).ToList()
                };
            }
            return new DetailedAuctionDto();
        }

        public Task<List<DetailedOfferDto>> GetOffersInSpecificAuction(int sellerId, int auctionId, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public async Task<decimal> CommisionPaidBySellerAuctions(int sellerId, CancellationToken cancellation)
        {
            User? seller = await _userManager.FindByIdAsync(sellerId.ToString());
            if (seller != null)
            {
                if (seller.HasMedal)
                {
                    return await _context.Auctions.Where(o => o.FinishedAt < seller.MedalAchievedAt).Select(o => o.FinalPrice).SumAsync(cancellation);
                }
               
                return await _context.Auctions.Select(o => o.FinalPrice).SumAsync(cancellation);

            }
            return 0;

        }




        #endregion

    }
}

