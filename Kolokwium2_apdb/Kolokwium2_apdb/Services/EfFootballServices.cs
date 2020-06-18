using Kolokwium2_apdb.DTOs;
using Kolokwium2_apdb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium2_apdb.Services
{
    public class EfFootballServices : IFootballServices
    {

        private FootballContext _context;

        public EfFootballServices(FootballContext context)
        {
            _context = context;
        }

        public IEnumerable<ChampionshipTeam> getTeams(int id)
        {
            var teams = _context.Championships
                .Any(x => x.IdChampionship.Equals(id));

            if (teams == null)
            {
                //moj bład ale zabrakło czasu..
            }

            var t = _context.ChampionshipTeams
               .Where(x => x.IdChampionship.Equals(id)).ToList();

            return t;
        }

        public void addPlayer(PlayerReq p, int tId)
        {
            var team = _context.Teams.Where(a => a.IdTeam == tId).FirstOrDefault();

            var man = _context.Players.Where(e => e.FirstName.Equals(p.firstName) && e.LastName.Equals(p.lastName) && e.DateOfBirth == p.birthdate).FirstOrDefault();
            if (team == null)
            {
                throw new Exception();//nie zrobilem swojego
            }

            if (man == null)
            {
                throw new Exception();//nie zrobilem swojego
            }

            var player = _context.PlayerTeams.Where(t => t.IdPlayer == man.IdPlayer).FirstOrDefault();

            PlayerTeaM nowyGracz = new PlayerTeaM()
            {
                IdPlayer = player.IdPlayer

            };

            _context.PlayerTeams.Add(nowyGracz);
            _context.SaveChanges();
        }
        }
}
