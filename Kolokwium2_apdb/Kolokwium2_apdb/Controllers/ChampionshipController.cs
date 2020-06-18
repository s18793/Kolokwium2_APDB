using Kolokwium2_apdb.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium2_apdb.Controllers
{

    [Route("api/championships")]
    [ApiController]
    public class ChampionshipController : ControllerBase
    {
        
           IFootballServices _db;
        public ChampionshipController(IFootballServices db)
        {
            _db = db;
        }


        [HttpGet("{id}/teams")]
        public IActionResult getTeamsInChampionship(int id)
        {
            
                var res = _db.getTeams(id);
            return Ok(res);


        }
            
            
    }
}