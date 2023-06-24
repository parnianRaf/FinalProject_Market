using System;
using AppCore;
using AppService.Admin_;

namespace FinalProject_Market.BackGroundServices
{
    public class AuctionBackGroundService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public AuctionBackGroundService( IServiceProvider serviceProvider)
        {

            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using(IServiceScope service = _serviceProvider.CreateScope())
                {
                    var _auction= service.ServiceProvider.GetRequiredService<IAuctionAppService>();
                    List<Auction> auctions = await _auction.GetAllEntityAuction(stoppingToken);
                    auctions.ForEach(a =>
                    {
                        a.IsActive = (a.StartTime < DateTime.Now && DateTime.Now < a.EndTime);
                        _auction.UpdateAuction(a, stoppingToken);
                    });
                }

            }
        }
    }
}

