using AYZ8R9_HFT_2021221.Logic.Exceptions;
using AYZ8R9_HFT_2021221.Models;
using AYZ8R9_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYZ8R9_HFT_2021221.Logic
{
    public class StatisticLogic : IStatisticLogic
    {
        IStatisticRepository statRepo;
        public StatisticLogic(IStatisticRepository statRepo)
        {
            this.statRepo = statRepo;
        }

        public void ChangePassingyard(int id, int newPYards)
        {
            if (!TheSame(id))
            {
                throw new WrongIdException("[Err] The id is not correct...");
            }
            else if (newPYards < 0)
            {
                throw new YardsCantBeMinusException("[Err] Passing yards can't be minus");
            }
            else
            {
                statRepo.ChangePassingyard(id, newPYards);
            }
        }

        public void ChangeRecievingyard(int id, int newReYards)
        {
            if (!TheSame(id))
            {
                throw new WrongIdException("[Err] The id is not correct...");
            }
            else if (newReYards < 0)
            {
                throw new YardsCantBeMinusException("[Err] Receiving yards can't be minus");
            }
            else
            {
                statRepo.ChangeRecievingyard(id, newReYards);
            }
        }

        public void ChangeRushingyard(int id, int newRuYards)
        {
            if (!TheSame(id))
            {
                throw new WrongIdException("[Err] The id is not correct...");
            }
            else if (newRuYards < 0)
            {
                throw new YardsCantBeMinusException("[Err] Rushing yards can't be minus");
            }
            else
            {
                statRepo.ChangeRushingyard(id, newRuYards);
            }
        }

        public void ChangeTouchdowns(int id, int newScore)
        {
            if (!TheSame(id))
            {
                throw new WrongIdException("[Err] The id is not correct...");
            }
            else if (newScore < 0)
            {
                throw new YardsCantBeMinusException("[Err] Touchdowns score can't be minus");
            }
            else
            {
                statRepo.ChangeTouchdowns(id, newScore);
            }
        }

        public void Change(Statistic stat) {
            statRepo.Change(stat);
        }

        public void CreateStatistic(Statistic NewStatistic)
        {
            statRepo.Create(NewStatistic);
        }
       

        public void DeleteStatistic(int id)
        {
            if (!TheSame(id))
            {
                throw new ItDoesNotExistException("[Err] The statistic is not exist...");
            }
            statRepo.Delete(id);
        }
        bool TheSame(int id)
        {
            bool theSame = false;
            foreach (var item in statRepo.GetAll())
            {
                if (item.StatId == id)
                {
                    theSame = true;
                }
            }
            return theSame;
        }

        public IEnumerable<Statistic> GetAllStatistic()
        {
            return statRepo.GetAll();
        }

        public Statistic GetStastic(int id)
        {
            if (!TheSame(id))
            {
                throw new WrongIdException("[Err] The id is not correct...");
            }
            return statRepo.GetOne(id);
        }
    }
}
