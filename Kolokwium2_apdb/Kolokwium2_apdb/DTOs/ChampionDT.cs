using Kolokwium2_apdb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium2_apdb.DTOs
{
    public class ChampionDT
    {

        public string officialName { get; set; }
        public List<Team> TeamList { get; set; }

    }
}
