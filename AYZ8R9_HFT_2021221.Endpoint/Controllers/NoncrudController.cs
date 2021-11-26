using AYZ8R9_HFT_2021221.Logic;
using AYZ8R9_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AYZ8R9_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class NoncrudController : ControllerBase
    {
        IPlayerLogic playerLogic;
        public NoncrudController(IPlayerLogic playerLogic)
        {
            this.playerLogic = playerLogic;
        }
        // GET: /Noncrud/MostPassingYards
        [HttpGet]
        public IEnumerable<Player> MostPassingYards()
        {
            return playerLogic.MostPassingYards();
        }

        // GET: /Noncrud/MostRushingYards
        [HttpGet]
        public IEnumerable<Player> MostRushingYards()
        {
            return playerLogic.MostRushingYards();
        }
        // GET: /Noncrud/MostReceivingYards
        [HttpGet]
        public IEnumerable<Player> MostReceivingYards()
        {
            return playerLogic.MostReceivingYards();
        }
        // GET: /Noncrud/MostTouchdowns
        [HttpGet]
        public IEnumerable<Player> MostTouchdowns()
        {
            return playerLogic.MostTouchdowns();
        }

        // GET: /Noncrud/PlayersByTeam/Team
        [HttpGet("{Team}")]
        public IEnumerable<Player> PlayersByTeam(string team)
        {
            return playerLogic.PlayersByTeam(team);
        }
    }
}
