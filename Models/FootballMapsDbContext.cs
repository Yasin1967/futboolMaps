using Microsoft.EntityFrameworkCore;

namespace FOOTBALMAPSV2.Models
{
    public class FootballMapsDbContext : DbContext
    {
        public FootballMapsDbContext(DbContextOptions<FootballMapsDbContext> options) : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // One-to-Many configurations
            modelBuilder.Entity<City>()
                .HasOne(c => c.Country)
                .WithMany(c => c.Cities)
                .HasForeignKey(c => c.CountryId);

            modelBuilder.Entity<Team>()
                .HasOne(t => t.City)
                .WithMany(c => c.Teams)
                .HasForeignKey(t => t.CityId);

            // Seed Data for Country
            modelBuilder.Entity<Country>().HasData(
                new Country { Id = 1, Name = "Türkiye" }
            );

            // Seed Data for Cities
            modelBuilder.Entity<City>().HasData(
                new City { Id = 34, Name = "İstanbul", CountryId = 1, History = "Tarihi Yarımada, Bizans ve Osmanlı başkenti.", Culture = "Kozmopolit yapı, müzeler", NaturalResources = "Boğaz, ormanlar", LocalFood = "Balık Ekmek, Kumpir, Sultanahmet Köftesi", SupportCount = 0 },
                new City { Id = 6, Name = "Ankara", CountryId = 1, History = "Cumhuriyetin başkenti, Frigya dönemi.", Culture = "Anıtkabir, Devlet Opera ve Balesi", NaturalResources = "Tuz Gölü havzası, ormanlar", LocalFood = "Ankara Döneri, Ankara Simidi, Beypazarı Kurusu", SupportCount = 0 },
                new City { Id = 35, Name = "İzmir", CountryId = 1, History = "Efes Antik Kenti, İyonya uygarlığı.", Culture = "Saat Kulesi, Boyoz kültürü", NaturalResources = "Ege Denizi, incir, zeytin ağaçları", LocalFood = "Boyoz, Kumru, Bomba, Gevrek", SupportCount = 0 },
                new City { Id = 16, Name = "Bursa", CountryId = 1, History = "Osmanlı Devleti'nin ilk başkenti.", Culture = "Ulu Cami, Koza Han", NaturalResources = "Uludağ, kaplıcalar", LocalFood = "İskender Kebap, Kestane Şekeri", SupportCount = 0 },
                new City { Id = 61, Name = "Trabzon", CountryId = 1, History = "Trabzon İmparatorluğu, Sümela Manastırı.", Culture = "Karadeniz kültürü, horon", NaturalResources = "Uzungöl, ormanlık alanlar", LocalFood = "Akçaabat Köftesi, Kuymak, Hamsi", SupportCount = 0 }
            );

            // Seed Data for Teams
            modelBuilder.Entity<Team>().HasData(
                new Team { Id = 1, Name = "Galatasaray", FoundationYear = 1905, CityId = 34, LogoUrl = "/images/teams/Galatasaray_Sports_Club_Logo.svg.png" },
                new Team { Id = 2, Name = "Fenerbahçe", FoundationYear = 1907, CityId = 34, LogoUrl = "/images/teams/Fenerbahçe_SK.png" },
                new Team { Id = 3, Name = "Beşiktaş", FoundationYear = 1903, CityId = 34, LogoUrl = "/images/teams/BesiktasJK-Logo.svg.png" },
                new Team { Id = 4, Name = "MKE Ankaragücü", FoundationYear = 1910, CityId = 6, LogoUrl = "/images/teams/MKE_Ankaragücü_logo.png" },
                new Team { Id = 5, Name = "Gençlerbirliği", FoundationYear = 1923, CityId = 6, LogoUrl = "/images/teams/Genclerbirligi.png" },
                new Team { Id = 6, Name = "Göztepe", FoundationYear = 1925, CityId = 35, LogoUrl = "https://upload.wikimedia.org/wikipedia/tr/b/bf/G%C3%B6ztepe_Armas%C4%B1.png" },
                new Team { Id = 7, Name = "Bursaspor", FoundationYear = 1963, CityId = 16, LogoUrl = "/images/teams/330px-Bursaspor-amblem.png" },
                new Team { Id = 8, Name = "Trabzonspor", FoundationYear = 1967, CityId = 61, LogoUrl = "/images/teams/TrabzonsporAmblemi.png" }
            );
        }
    }
}
