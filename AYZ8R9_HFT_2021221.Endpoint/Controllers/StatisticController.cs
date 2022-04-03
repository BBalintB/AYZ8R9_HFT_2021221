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
    public class StatisticController : ControllerBase
    {
        

        IStatisticLogic statisticLogic;
        IHubContext<SignalRHub> hub;
        public StatisticController(IStatisticLogic statisticLogic, IHubContext<SignalRHub> hub)
        {
            this.statisticLogic = statisticLogic;
            this.hub = hub;
        }
        // GET: /Statistic
        [HttpGet]
        public IEnumerable<Statistic> Get()
        {
            return statisticLogic.GetAllStatistic();
        }

        // GET /Statistic/5
        [HttpGet("{id}")]
        public Statistic Get(int id)
        {
            try
            {
                return statisticLogic.GetStastic(id);
            }
            catch (WrongIdException)
            {

                return null;
            }
            
        }

        // POST /Statistic
        [HttpPost]
        public void Post([FromBody] Statistic value)
        {
            try
            {
                statisticLogic.CreateStatistic(value);
                hub.Clients.All.SendAsync("StatisticCreated", value);
            }
            catch (AlreadyExistException)
            {
                /*******/
            }

        }

        // PUT /Statistic
        [HttpPut("{id}/{choose}")]
        public void Put(int id, string choose, [FromBody] int stat)
        {
            try
            {
                if (choose == "Passing")
                {
                    statisticLogic.ChangePassingyard(id, stat);
                }
                else if (choose == "Rushing")
                {
                    statisticLogic.ChangeRushingyard(id, stat);
                }
                else if (choose == "Receiving")
                {
                    statisticLogic.ChangeRecievingyard(id, stat);
                }
                else if (choose == "Touchdowns")
                {
                    statisticLogic.ChangeTouchdowns(id, stat);
                }
                var staT = statisticLogic.GetStastic(id);
                hub.Clients.All.SendAsync("StatisticDeleted", stat);
            }
            catch (WrongIdException) { /*******/}
            catch (YardsCantBeMinusException) { /*******/}

        }

        [HttpPut]
        public void Put([FromBody] Statistic value)
        {
            statisticLogic.Change(value);
            hub.Clients.All.SendAsync("StatisticUpdated", value);

        }

        // DELETE /Statistic/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                var stat = statisticLogic.GetStastic(id);
                statisticLogic.DeleteStatistic(id);
                hub.Clients.All.SendAsync("StatisticDeleted", stat);
            }
            catch (WrongIdException)
            {
                /*******/
            }

        }
    }
}
