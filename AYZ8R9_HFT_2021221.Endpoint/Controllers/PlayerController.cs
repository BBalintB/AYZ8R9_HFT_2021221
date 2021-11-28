using AYZ8R9_HFT_2021221.Logic;
using AYZ8R9_HFT_2021221.Logic.Exceptions;
using AYZ8R9_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AYZ8R9_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {

        IPlayerLogic PlayerLogic;

        public PlayerController(IPlayerLogic playerLogic)
        {
            this.PlayerLogic = playerLogic;
        }

        // GET: /player
        [HttpGet]
        public IEnumerable<Player> Get()
        {
            return PlayerLogic.GetAllPlayers();
        }

        // GET /player/5
        [HttpGet("{id}")]
        public Player Get(int id)
        {
            return PlayerLogic.GetPlayer(id);
        }

        // POST /player
        [HttpPost]
        public void Post([FromBody] Player value)
        {
            PlayerLogic.CreatePlayer(value);
        }

        // PUT /player/5/update
        [HttpPut("{id}/{update}")]
        public void Put(int id,string update, [FromBody] string value)
        {
            if (update == "name")
            {
                PlayerLogic.ChangeName(id, value);
            }
            else if(update == "jersey"){
                PlayerLogic.ChangeJerseyNumber(id, int.Parse(value));
            }
            
        }

        

        // DELETE /player/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            PlayerLogic.Delete(id);
        }
    }
}
