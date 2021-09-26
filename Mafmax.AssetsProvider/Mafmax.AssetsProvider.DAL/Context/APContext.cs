using Mafmax.AssetsProvider.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mafmax.AssetsProvider.DAL.Context
{
    /// <summary>
    /// Database context for Assets Provider application
    /// </summary>
    public class APContext : DbContext
    {
        /// <summary>
        /// Create APContext
        /// </summary>
        /// <param name="options">Context creating options</param>
        public APContext(DbContextOptions<APContext> options) : base(options)
        {

        }

        /// <summary>
        /// All assets
        /// </summary>
        public DbSet<Asset> Assets { get; set; }

        /// <summary>
        /// Shares (stocks). Specific assets.
        /// </summary>
        public DbSet<Share> Shares { get; set; }

        /// <summary>
        /// Bonds. Specific assets.
        /// </summary>
        public DbSet<Bond> Bonds { get; set; }

        /// <summary>
        /// Countries e.g. USA or Russia
        /// </summary>
        public DbSet<Country> Countries { get; set; }


        /// <summary>
        /// Companies which issue assets
        /// </summary>
        public DbSet<Issuer> Issuers { get; set; }

        /// <summary>
        /// Industries of business
        /// </summary>

        public DbSet<Industry> Industries { get; set; }

        /// <summary>
        /// Overrides base.OnModelCreating
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var countries = new List<Country>
            {
                new(){Id = 1, Name="Россия"},
                new(){Id = 2, Name="США"},
            };
            modelBuilder.Entity<Country>().HasData(countries);

            var stockExchanges = new List<StockExchange>
            {
                new(){Id=1,Key="MOEX",Name = "Московская биржа"}
            };
            modelBuilder.Entity<StockExchange>().HasData(stockExchanges);
            var industries = new List<Industry>
            {
                new(){Id=1,Name="Технологии"},
                new(){Id=2,Name="Финансы"},
                new(){Id=3,Name="Добыча ископаемых"},
                new(){Id=4,Name="Нефть и газ"},
                new(){Id=5,Name="Телекоммуникации"},
                new(){Id=6,Name="IT"},
            };
            modelBuilder.Entity<Industry>().HasData(industries);
            var issuers = new List<Issuer>
            {
                new() {Id=1,CountryId=1,IndustryId=5,Name="МТС" },
                new() {Id=2,CountryId=1,IndustryId=4,Name="Сургутнефтегаз" },
                new() {Id=3,CountryId=1,IndustryId=3,Name="Алроса" },
                new() {Id=4,CountryId=2,IndustryId=1,Name="Apple" },
                new() {Id=5,CountryId=1,IndustryId=6,Name="Яндекс" },
                new() {Id=6,CountryId=1,IndustryId=2,Name="Сбербанк России" },
            };
            modelBuilder.Entity<Issuer>().HasData(issuers);
            var shares = new List<Share>
            {
                new() {Id=1, IssuerId=6,Ticker="SBERP",      ISIN="RU0009029557", Name="Сбербанк России, акция привелегированная",   IsPreffered=true,   LotSize=10, Currency="RUB",StockId= 1},
                new() {Id=2, IssuerId=1,Ticker="MTSS",       ISIN="RU0007775219", Name="МТС, акция обыкновенная",                    IsPreffered=false,  LotSize=10, Currency="RUB",StockId= 1},
                new() {Id=3, IssuerId=2,Ticker="SNGS",       ISIN="RU0008926258", Name="Сургутнефтегаз, акция обыкновенная",         IsPreffered=false,  LotSize=100,Currency="RUB",StockId= 1},
                new() {Id=4, IssuerId=3,Ticker="ALRS",       ISIN="RU0007252813", Name="Алроса, акция обыкновенная",                 IsPreffered=false,  LotSize=10, Currency="RUB",StockId= 1},
                new() {Id=5, IssuerId=4,Ticker="AAPL-RM",    ISIN="US0378331005", Name="Apple, акция обыкновенная",                  IsPreffered=false,  LotSize=1,  Currency="USD",StockId= 1},
                new() {Id=6, IssuerId=5,Ticker="YNDX",       ISIN="NL0009805522", Name="ЯНДЕКС Н.В., акция обыкновенная",            IsPreffered=false,  LotSize=1,  Currency="EUR",StockId= 1},
                new() {Id=7, IssuerId=6,Ticker="SBER",       ISIN="RU0009029540", Name="Сбербанк России, акция обыкновенная",        IsPreffered=false,  LotSize=10, Currency="RUB",StockId= 1},
            };
            modelBuilder.Entity<Share>().HasData(shares);

            var bonds = new List<Bond>
            {
                new() {Id=8, IssuerId=6,Ticker="RU000A101C89", ISIN="RU000A101C89", Name="Сбербанк ПАО 001Р-SBER15",     LotSize=1,   Currency="RUB",StockId= 1, Type=BondType.Corporate},
                new() {Id=9, IssuerId=6,Ticker="RU000A1013J4", ISIN="RU000A1013J4", Name="СберИОС 001Р-177R GMKN 100",   LotSize=1,   Currency="RUB",StockId= 1, Type=BondType.Corporate},
            };
            modelBuilder.Entity<Bond>().HasData(bonds);

            modelBuilder.Entity<Asset>().OwnsOne(e => e.Circulation).HasData(
                    new { AssetId = 1, Start = new DateTime(2016, 7, 16) },
                    new { AssetId = 2, Start = new DateTime(2004, 2, 11) },
                    new { AssetId = 3, Start = new DateTime(2005, 1, 11) },
                    new { AssetId = 4, Start = new DateTime(2011, 11, 29) },
                    new { AssetId = 5, Start = new DateTime(2020, 9, 8) },
                    new { AssetId = 6, Start = new DateTime(2014, 6, 4) },
                    new { AssetId = 7, Start = new DateTime(2007, 7, 20) },
                    new { AssetId = 8, Start = new DateTime(2020, 1, 20) },
                    new { AssetId = 9, Start = new DateTime(2019, 6, 19) }
                    );
            base.OnModelCreating(modelBuilder);
        }

    }
}
