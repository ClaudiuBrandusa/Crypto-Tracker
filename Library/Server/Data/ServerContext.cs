using Library.Server.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Server.Data
{
    public class ServerContext : DbContext
    {
        public ServerContext(DbContextOptions<ServerContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<Coin> Coins { get; set; }
        public DbSet<Credit> Credits { get; set; }
        public DbSet<CreditHistory> CreditHistories { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //User - Wallet (one to many)
            modelBuilder.Entity<User>()
                .HasKey(p => p.Id);
            modelBuilder.Entity<Wallet>()
                .HasKey(p => new { p.UserId, p.CoinId });

            modelBuilder.Entity<User>()
                .HasMany(x => x.Wallets)
                .WithOne(y => y.User);

            //User - Credit (one to one)
            //modelBuilder.Entity<Credit>()
                //.HasKey(p => p.UserId);

            modelBuilder.Entity<User>()
                .HasOne(x => x.Credit)
                .WithOne(y => y.User)
                .HasForeignKey<Credit>(y => y.UserId);

            //User - CreditHistory (one to one)
            //modelBuilder.Entity<CreditHistory>()
                //.HasKey(p => p.UserId);

            modelBuilder.Entity<User>()
                .HasOne(x => x.CreditHistory)
                .WithOne(y => y.User)
                .HasForeignKey<CreditHistory>(y => y.UserId);

            //User - Transaction (one to many)
            //modelBuilder.Entity<Transaction>()
                //.HasKey(p => p.Id);

            modelBuilder.Entity<User>()
                .HasMany(x => x.Transactions)
                .WithOne(y => y.User);

            //Wallet - Transaction (one to many)
            modelBuilder.Entity<Wallet>()
                .HasMany(x => x.Transactions)
                .WithOne(y => y.Wallet);

            //Coin - Wallet (one to many)
            //modelBuilder.Entity<Coin>()
                //.HasKey(p => p.Id);

            modelBuilder.Entity<Coin>()
                .HasMany(x => x.Wallets)
                .WithOne(y => y.Coin);
        }
    }
}
