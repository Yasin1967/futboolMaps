using System.Collections.Generic;

namespace FOOTBALMAPSV2.Models
{
    public class League
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Tier { get; set; } = default!; // e.g., "Süper Lig", "1. Lig"

        public ICollection<Team> Teams { get; set; }

        public League()
        {
            Teams = new HashSet<Team>();
        }
    }
}
