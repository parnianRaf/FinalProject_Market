using System;
using AppCore;
using AppService.Admin_;
using FinalProject_Market.Cache;
using Hangfire;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Service;

namespace AppService.BackGroundJobs
{
	public class BackgroundTask
    {
        private readonly CronsAuction cron;
        private readonly IAuctionCacheAppService auctionApp;
        //private readonly IServiceProvider provider;

        public BackgroundTask(CronsAuction cron, IAuctionCacheAppService auctionApp, IServiceProvider provider)
        {
            this.cron = cron;
            this.auctionApp = auctionApp;
            //this.provider = provider;
        }

        public async Task OnGet(CancellationToken cancellation)
        {
            //using(IServiceScope service = provider.CreateScope())
            //{
                RecurringJob.AddOrUpdate<IAuctionCacheAppService>("1", s => s.SetCache(cancellation), cron.At12);
                List<Auction> auctions = await auctionApp.GetCache(cancellation);
                auctions.Where(a => a.IsActive == null).ToList().ForEach(a =>
                {
                    BackgroundJob.Schedule<IAuctionAppService>(s => s.UpdateAuctions(a, cancellation), a.StartTime - DateTime.Now);
                });
                auctions.Where(a => a.IsActive == true).ToList().ForEach(a =>
                {
                    BackgroundJob.Schedule<IAuctionAppService>(s => s.UpdateAuctions(a, cancellation), a.EndTime + TimeSpan.FromMilliseconds(1000) - DateTime.Now);
                });

            //}
  
        }

    }
}

