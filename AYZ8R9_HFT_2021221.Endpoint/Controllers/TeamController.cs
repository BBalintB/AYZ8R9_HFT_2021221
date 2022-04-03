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
    public class TeamController : ControllerBase
    {
        ITeamLogic teamLogic;
        IHubContext<SignalRHub> hub;
        public TeamController(ITeamLogic teamLogic, IHubContext<SignalRHub> hub)
        {
            this.teamLogic = teamLogic;
            this.hub = hub;
        }
        // GET: /team
        [HttpGet]
        public IEnumerable<Team> Get()
        {
            return teamLogic.GetAllTeams();
        }

        // GET /team/5
        [HttpGet("{id}")]
        public Team Get(int id)
        {
            try
            {
                return teamLogic.GetTeam(id);
            }
            catch (WrongIdException)
            {
                return null;
            }
            
        }

        // POST /team
        [HttpPost]
        public void Post([FromBody] Team value)
        {
            try
            {
                teamLogic.CreateTeam(value);
                hub.Clients.All.SendAsync("TeamCreated", value);
            }
            catch (AlreadyExistException)
            {
                /*******/
            }

        }

        // PUT /team/5
        [HttpPut("{id}/{choose}")]
        public void Put(int id,string choose, [FromBody] string value)
        {
            try
            {
                if (choose == "team")
                {
                    teamLogic.ChangeTeamName(id, value);
                }
                else if (choose == "coach")
                {
                    teamLogic.ChangeCoach(id, value);
                }
            }
            catch (WrongIdException) {/*******/}
            catch (NameIsEmptyException) { /*******/}

        }

        [HttpPut]
        public void Put([FromBody] Team value)
        {
            teamLogic.Change(value);
            hub.Clients.All.SendAsync("TeamUpdated", value);

        }

        // DELETE /team/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                var deleedteam = teamLogic.GetTeam(id);
                teamLogic.DeleteTeam(id);
                hub.Clients.All.SendAsync("TeamDeleted", deleedteam);
            }
            catch (WrongIdException)
            {
                /*******/
            }

        }
    }
}
