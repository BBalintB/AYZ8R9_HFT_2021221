using AYZ8R9_HFT_2021221.Endpoint.Services;
using AYZ8R9_HFT_2021221.Logic;
using AYZ8R9_HFT_2021221.Logic.Exceptions;
using AYZ8R9_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
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
        IHubContext<SignalRHub> hub;

        public PlayerController(IPlayerLogic playerLogic, IHubContext<SignalRHub> hub)
        {
            this.PlayerLogic = playerLogic;
            this.hub = hub;
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
            try
            {
                return PlayerLogic.GetPlayer(id);
            }
            catch (WrongIdException)
            {
                return null;
            }
            
        }

        // POST /player
        [HttpPost]
        public void Post([FromBody] Player value)
        {
            try
            {
                PlayerLogic.CreatePlayer(value);
                hub.Clients.All.SendAsync("PlayerCreated", value);
            }
            catch (AlreadyExistException)
            {/*******/}

        }

        // PUT /player/5/update
        [HttpPut("{id}/{update}")]
        public void Put(int id,string update, [FromBody] string value)
        {
            try
            {
                if (update == "name")
                {
                    PlayerLogic.ChangeName(id, value);
                }
                else if (update == "jersey")
                {
                    PlayerLogic.ChangeJerseyNumber(id, int.Parse(value));
                }
            }
            catch (WrongIdException) {/*******/}
            catch (NameIsEmptyException) {/*******/}
            catch (JerseyNumberIsNotGoodException) {/*******/}
            
            
        }

        [HttpPut]
        public void Put([FromBody] Player value)
        {
            PlayerLogic.ChangePlayer(value);
            hub.Clients.All.SendAsync("PlayerUpdated", value);

        }



        // DELETE /player/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                var deletedPlayer = PlayerLogic.GetPlayer(id);
                PlayerLogic.Delete(id);
                hub.Clients.All.SendAsync("PlayerDeleted", deletedPlayer);
            }
            catch (ItDoesNotExistException)
            {
                /*******/
            }

        }
    }
}
