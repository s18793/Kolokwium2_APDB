using System.Collections.Generic;

namespace Kolokwium2_apdb.Models
{
    public class Team
    {
        public int IdTeam { get; set; }
        public string TeamName { get; set; }
        public int MaxAge { get; set; }

        public  ICollection<ChampionshipTeam> ChampionshipTeam { get; set; }
        public  ICollection<PlayerTeaM> PlayerTeam { get; set; }
    }
}