using System;
using AppCore;
using AppCore.Entity.CacheEntity;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;

namespace Service
{
    public class AuctionCacheAppService : IAuctionCacheAppService
    {
        private readonly IMemoryCache memory;
        private readonly IAuctionService auction;

        public AuctionCacheAppService(IMemoryCache memory, IAuctionService auction)
        {
            this.memory = memory;
            this.auction = auction;
        }

        public async Task SetCache(CancellationToken cancellation)
        {
            List<Auction>? x = memory.Get<List<Auction>>(CacheEntity.AuctionList).ToList() ;
            List<Auction> auctions = await auction.GetAllEntityAuction(cancellation);
            if (x is not null)
            {
                memory.Remove(CacheEntity.AuctionList);
            }
            memory.Set(CacheEntity.AuctionList, auctions.Where(a => a.StartTime == DateTime.Today), new MemoryCacheEntryOptions { AbsoluteExpiration = DateTime.Now.AddDays(1) });
        }

        public async  Task<List<Auction>> GetCache(CancellationToken cancellation)
        {
            List<Auction>? auctions= memory.Get<List<Auction>>(CacheEntity.AuctionList).ToList() ;
            return auctions ?? new List<Auction>();
        }
    }
}

