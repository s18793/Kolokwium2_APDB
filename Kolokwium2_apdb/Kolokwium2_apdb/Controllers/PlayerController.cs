using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kolokwium2_apdb.DTOs;
using Kolokwium2_apdb.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium2_apdb.Controllers
{

    [Route("api/teams")]
    [ApiController]
    public class PlayerController : Controller
    {

        IFootballServices _db;
        public PlayerController(IFootballServices db)
        {
            _db = db;
        }
       [HttpPost("{id}/players")]
        public IActionResult addPlayer(PlayerReq p, int tId)
        {
            _db.addPlayer(p, tId);
            return Ok();
        }
    }
}