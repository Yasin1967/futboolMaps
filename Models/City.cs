using System.Collections.Generic;

namespace FOOTBALMAPSV2.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        // Added properties from Week 2
        public string History { get; set; }
        public string Culture { get; set; }
        public string NaturalResources { get; set; }
        public string LocalFood { get; set; }
        
        // Added properties from Week 9
        public int SupportCount { get; set; }
        
        public int CountryId { get; set; }
        public Country Country { get; set; }

        public ICollection<Team> Teams { get; set; }

        public City()
        {
            Teams = new HashSet<Team>();
        }
    }
}
