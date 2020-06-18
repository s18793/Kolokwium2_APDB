using System.Collections.Generic;

namespace Kolokwium2_apdb.Models
{
    public class Championship
    {

        public int IdChampionship { get; set; }
        public string OfficialName { get; set; }
        public int Year { get; set; }
        public  ICollection<ChampionshipTeam> ChampionshipTeam { get; set; }
    }
}