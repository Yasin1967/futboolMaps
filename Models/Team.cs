namespace FOOTBALMAPSV2.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public int FoundationYear { get; set; }
        public string LogoUrl { get; set; } = default!;
        
        public string? History { get; set; }
        public string? Achievements { get; set; }
        
        public int CityId { get; set; }
        public City City { get; set; } = default!;

        public int? LeagueId { get; set; }
        public League? League { get; set; }
    }
}
