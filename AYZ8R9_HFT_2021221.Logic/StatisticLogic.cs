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
    class StatisticLogic : IStatisticLogic
    {
        StatisticRepository statRepo;
        public StatisticLogic(StatisticRepository statRepo)
        {
            this.statRepo = statRepo;
        }

        public void ChangePassingyard(int id, int newPYards)
        {
            if (id > statRepo.GetAll().Count())
            {
                throw new WrongId("[Err] The id is too big...");
            }
            else if (newPYards < 0)
            {
                throw new YardsCantBeMinus("[Err] Passing yards can't be minus");
            }
            else
            {
                statRepo.ChangePassingyard(id,newPYards);
            }
        }

        public void ChangeRecievingyard(int id, int newReYards)
        {
            if (id > statRepo.GetAll().Count())
            {
                throw new WrongId("[Err] The id is too big...");
            }
            else if (newReYards < 0)
            {
                throw new YardsCantBeMinus("[Err] Receiving yards can't be minus");
            }
            else
            {
                statRepo.ChangeRecievingyard(id,newReYards);
            }
        }

        public void ChangeRushingyard(int id, int newRuYards)
        {
            if (id > statRepo.GetAll().Count())
            {
                throw new WrongId("[Err] The id is too big...");
            }
            else if (newRuYards < 0)
            {
                throw new YardsCantBeMinus("[Err] Rushing yards can't be minus");
            }
            else
            {
                statRepo.ChangeRushingyard(id, newRuYards);
            }
        }

        public void ChangeTouchdowns(int id, int newScore)
        {
            if (id > statRepo.GetAll().Count())
            {
                throw new WrongId("[Err] The id is too big...");
            }
            else if (newScore < 0)
            {
                throw new YardsCantBeMinus("[Err] Touchdowns score can't be minus");
            }
            else
            {
                statRepo.ChangeTouchdowns(id, newScore);
            }
        }

        public void CreateStatistic(Statistic NewStatistic)
        {
            if (TheSame(NewStatistic))
            {
                throw new AlreadyExist("[Err] The team is already exist...");
            }
            statRepo.Create(NewStatistic);
        }
        bool TheSame(Statistic stat)
        {
            bool theSame = false;
            foreach (var item in statRepo.GetAll())
            {
                if (item == stat)
                {
                    theSame = true;
                }
            }
            return theSame;
        }

        public void DeleteStatistic(int id)
        {
            if (!TheSame(id))
            {
                throw new ItDoesNotExist("[Err] The team is not exist...");
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
            if (id > statRepo.GetAll().Count())
            {
                throw new WrongId("[Err] The id is too big...");
            }
            return statRepo.GetOne(id);
        }
    }
}
