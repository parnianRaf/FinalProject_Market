using System;
using AppCore;
using AppService.Admin_;
using FinalProject_Market.Cache;
using Hangfire;
using Microsoft.AspNetCore.Http;
using Service;

namespace AppService.BackGroundJobs
{
	public class BackgroundTask
    {
        private readonly CronsAuction cron;
        private readonly IAuctionCacheAppService auctionApp;

        public BackgroundTask(CronsAuction cron, IAuctionCacheAppService auctionApp)
        {
            this.cron = cron;
            this.auctionApp = auctionApp;
        }

        public async Task OnGet(CancellationToken cancellation)
        {
            RecurringJob.AddOrUpdate<IAuctionCacheAppService>("1",s=>s.SetCache(cancellation), cron.At12);
            List<Auction> auctions = await auctionApp.GetCache(cancellation);
            auctions.Where(a=>a.IsActive==null).ToList().ForEach( a =>
            {
               BackgroundJob.Schedule<IAuctionAppService>( s => s.UpdateAuctions(a, cancellation)  ,a.StartTime-DateTime.Now);
            });
            auctions.Where(a => a.IsActive == true).ToList().ForEach(a =>
            {
                BackgroundJob.Schedule<IAuctionAppService>(s => s.UpdateAuctions(a, cancellation), a.EndTime+TimeSpan.FromMilliseconds(1000) - DateTime.Now);
            });
        }

    }
}

