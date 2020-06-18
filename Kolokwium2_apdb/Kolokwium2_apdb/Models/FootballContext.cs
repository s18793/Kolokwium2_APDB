using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium2_apdb.Models
{
    public class FootballContext : DbContext
    {

        public virtual DbSet<Championship> Championships { get; set; }
        public virtual DbSet<ChampionshipTeam> ChampionshipTeams { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<PlayerTeam> PlayerTeams { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
    }


}
