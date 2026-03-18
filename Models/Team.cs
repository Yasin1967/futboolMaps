namespace FOOTBALMAPSV2.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FoundationYear { get; set; }
        public string LogoUrl { get; set; }
        
        public int CityId { get; set; }
        public City City { get; set; }
    }
}
