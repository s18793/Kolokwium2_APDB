using Kolokwium2_apdb.DTOs;
using Kolokwium2_apdb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium2_apdb.Services
{
    public interface IFootballServices
    {

        public IEnumerable<ChampionshipTeam> getTeams(int id);
        public void addPlayer(PlayerReq p, int tId);
    }
}
