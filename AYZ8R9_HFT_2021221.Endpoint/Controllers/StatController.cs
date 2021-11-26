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
    [Route("[controller]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        

        IStatisticLogic statisticLogic;
        public StatController(IStatisticLogic statisticLogic)
        {
            this.statisticLogic = statisticLogic;
        }
        // GET: /stat
        [HttpGet]
        public IEnumerable<Statistic> Get()
        {
            return statisticLogic.GetAllStatistic();
        }

        // GET /stat/5
        [HttpGet("{id}")]
        public Statistic Get(int id)
        {
            return statisticLogic.GetStastic(id);
        }

        // POST /stat
        [HttpPost]
        public void Post([FromBody] Statistic value)
        {
            statisticLogic.CreateStatistic(value);
        }

        // PUT /stat
        [HttpPut("{id}/{choose}")]
        public void Put(int id,string choose,[FromBody] int stat)
        {
            if (choose == "Passing")
            {
                statisticLogic.ChangePassingyard(id, stat);
            }
            else if (choose == "Rushing") {
                statisticLogic.ChangeRushingyard(id, stat);
            }
            else if (choose == "Receiving") {
                statisticLogic.ChangeRecievingyard(id, stat);
            }
            else if (choose == "Touchdowns") {
                statisticLogic.ChangeTouchdowns(id, stat);
            }
        }

        // DELETE /stat/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            statisticLogic.DeleteStatistic(id);
        }
    }
}
