using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FOOTBALMAPSV2.Models
{
    public class FootballMapsDbContext : IdentityDbContext<IdentityUser>
    {
        public FootballMapsDbContext(DbContextOptions<FootballMapsDbContext> options) : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<League> Leagues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuration for City Id (Plaka Code)
            modelBuilder.Entity<City>()
                .Property(c => c.Id)
                .ValueGeneratedNever();

            // One-to-Many configurations
            modelBuilder.Entity<City>()
                .HasOne(c => c.Country)
                .WithMany(c => c.Cities)
                .HasForeignKey(c => c.CountryId);

            modelBuilder.Entity<Team>()
                .HasOne(t => t.City)
                .WithMany(c => c.Teams)
                .HasForeignKey(t => t.CityId);

            modelBuilder.Entity<Team>()
                .HasOne(t => t.League)
                .WithMany(l => l.Teams)
                .HasForeignKey(t => t.LeagueId);

            // Seed Data for Country
            modelBuilder.Entity<Country>().HasData(
                new Country { Id = 1, Name = "Türkiye" }
            );

            // Seed Data for Leagues
            modelBuilder.Entity<League>().HasData(
                new League { Id = 1, Name = "Trendyol Süper Lig", Tier = "1. Kademe" },
                new League { Id = 2, Name = "Trendyol 1. Lig", Tier = "2. Kademe" },
                new League { Id = 3, Name = "TFF 2. Lig", Tier = "3. Kademe" }
            );

            // Seed Data for Cities
            modelBuilder.Entity<City>().HasData(
                new City { Id = 34, Name = "İstanbul", CountryId = 1, History = "Tarihi Yarımada, Bizans ve Osmanlı başkenti.", Culture = "Kozmopolit yapı, müzeler", NaturalResources = "Boğaz, ormanlar", LocalFood = "Balık Ekmek, Kumpir, Sultanahmet Köftesi", SupportCount = 0, Latitude = 41.0082, Longitude = 28.9784 },
                new City { Id = 6, Name = "Ankara", CountryId = 1, History = "Cumhuriyetin başkenti, Frigya dönemi.", Culture = "Anıtkabir, Devlet Opera ve Balesi", NaturalResources = "Tuz Gölü havzası, ormanlar", LocalFood = "Ankara Döneri, Ankara Simidi, Beypazarı Kurusu", SupportCount = 0, Latitude = 39.9334, Longitude = 32.8597 },
                new City { Id = 35, Name = "İzmir", CountryId = 1, History = "Efes Antik Kenti, İyonya uygarlığı.", Culture = "Saat Kulesi, Boyoz kültürü", NaturalResources = "Ege Denizi, incir, zeytin ağaçları", LocalFood = "Boyoz, Kumru, Bomba, Gevrek", SupportCount = 0, Latitude = 38.4192, Longitude = 27.1287 },
                new City { Id = 16, Name = "Bursa", CountryId = 1, History = "Osmanlı Devleti'nin ilk başkenti.", Culture = "Ulu Cami, Koza Han", NaturalResources = "Uludağ, kaplıcalar", LocalFood = "İskender Kebap, Kestane Şekeri", SupportCount = 0, Latitude = 40.1885, Longitude = 29.0610 },
                new City { Id = 61, Name = "Trabzon", CountryId = 1, History = "Trabzon İmparatorluğu, Sümela Manastırı.", Culture = "Karadeniz kültürü, horon", NaturalResources = "Uzungöl, ormanlık alanlar", LocalFood = "Akçaabat Köftesi, Kuymak, Hamsi", SupportCount = 0, Latitude = 41.0027, Longitude = 39.7168 },
                new City { Id = 55, Name = "Samsun", CountryId = 1, History = "Milli Mücadele'nin başladığı şehir.", Culture = "Gazi Müzesi, Bandırma Vapuru", NaturalResources = "Kızılırmak ve Yeşilırmak deltaları", LocalFood = "Samsun Pidesi, Bafra Pidesi", SupportCount = 0, Latitude = 41.2867, Longitude = 36.3300 },
                new City { Id = 31, Name = "Hatay", CountryId = 1, History = "Antik çağlardan günümüze medeniyetlerin kesişme noktası.", Culture = "Medeniyetler Korosu, Mozaik Müzesi", NaturalResources = "Asi Nehri, Titus Tüneli", LocalFood = "Künefe, Oruk, Tepsi Kebabı", SupportCount = 0, Latitude = 36.2066, Longitude = 36.1572 },
                new City { Id = 25, Name = "Erzurum", CountryId = 1, History = "Anadolu'nun en eski yerleşim merkezlerinden biri.", Culture = "Çifte Minareli Medrese, Yakutiye Medresesi", NaturalResources = "Palandöken Dağı, Tortum Şelalesi", LocalFood = "Cağ Kebabı, Kadayıf Dolması", SupportCount = 0, Latitude = 39.9043, Longitude = 41.2679 }
            );

            // Seed Data for Teams
            modelBuilder.Entity<Team>().HasData(
                new Team { Id = 1, Name = "Galatasaray", FoundationYear = 1905, CityId = 34, LogoUrl = "/images/teams/Galatasaray_Sports_Club_Logo.svg.png", LeagueId = 1 },
                new Team { Id = 2, Name = "Fenerbahçe", FoundationYear = 1907, CityId = 34, LogoUrl = "/images/teams/Fenerbahçe_SK.png", LeagueId = 1 },
                new Team { Id = 3, Name = "Beşiktaş", FoundationYear = 1903, CityId = 34, LogoUrl = "/images/teams/BesiktasJK-Logo.svg.png", LeagueId = 1 },
                new Team { Id = 4, Name = "MKE Ankaragücü", FoundationYear = 1910, CityId = 6, LogoUrl = "/images/teams/MKE_Ankaragücü_logo.png", LeagueId = 2 },
                new Team { Id = 5, Name = "Gençlerbirliği", FoundationYear = 1923, CityId = 6, LogoUrl = "/images/teams/Genclerbirligi.png", LeagueId = 2 },
                new Team { Id = 6, Name = "Göztepe", FoundationYear = 1925, CityId = 35, LogoUrl = "/images/teams/Göztepe.png", LeagueId = 1 },
                new Team { Id = 7, Name = "Bursaspor", FoundationYear = 1963, CityId = 16, LogoUrl = "/images/teams/330px-Bursaspor-amblem.png", LeagueId = 3 },
                new Team { Id = 8, Name = "Trabzonspor", FoundationYear = 1967, CityId = 61, LogoUrl = "/images/teams/TrabzonsporAmblemi.png", LeagueId = 1 },
                new Team { Id = 9, Name = "Samsunspor", FoundationYear = 1965, CityId = 55, LogoUrl = "/images/teams/Samsunspor_logo.png", LeagueId = 1 },
                new Team { Id = 10, Name = "Hatayspor", FoundationYear = 1967, CityId = 31, LogoUrl = "/images/teams/Hatayspor.png", LeagueId = 1 },
                new Team { Id = 11, Name = "Erzurumspor FK", FoundationYear = 2005, CityId = 25, LogoUrl = "/images/teams/Erzurumsporfk.png", LeagueId = 2 }
            );
        }
    }
}
