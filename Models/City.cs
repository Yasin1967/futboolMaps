using System.Collections.Generic;

namespace FOOTBALMAPSV2.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        
        // Added properties from Week 2
        public string History { get; set; } = default!;
        public string Culture { get; set; } = default!;
        public string NaturalResources { get; set; } = default!;
        public string LocalFood { get; set; } = default!;
        
        // Added properties from Week 9
        public int SupportCount { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
        
        public int CountryId { get; set; }
        public Country Country { get; set; } = default!;

        public ICollection<Team> Teams { get; set; }

        public City()
        {
            Teams = new HashSet<Team>();
        }
    }
}
