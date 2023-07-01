using System;
using System.Collections.Generic;
using AppCore;
using AppSqlDataBase.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AppSqlDataBase;
public class MarketContext : IdentityDbContext<User, IdentityRole<int>,int>
{
    #region ctor
    public MarketContext(DbContextOptions<MarketContext> options)
        : base(options)
    {
    }
    #endregion

    #region DbSet
    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Auction> Auctions { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<CustomerAddress> CustomerAddressess { get; set; }

    public virtual DbSet<DirectOrder> DirectOrders { get; set; }

    public virtual DbSet<Offer> Offers { get; set; }

    public virtual DbSet<Pavilion> Pavilions { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<SellerAddress> SellerAddressess { get; set; }

    public virtual DbSet<Wallet> Wallets { get; set; }
    #endregion

    #region OnModelCreating
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserEntityConfiguration).Assembly);
    }
    #endregion
}
