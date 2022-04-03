using AYZ8R9_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYZ8R9_HFT_2021221.Logic
{
    public interface IStatisticLogic
    {
        Statistic GetStastic(int id);
        void CreateStatistic(Statistic NewStatistic);
        void DeleteStatistic(int id);
        void ChangePassingyard(int id, int newPYards);
        void ChangeRecievingyard(int id, int newReYards);
        void ChangeRushingyard(int id, int newRuYards);
        void ChangeTouchdowns(int id, int newScore);
        void Change(Statistic stat);
        IEnumerable<Statistic> GetAllStatistic();
    }
}
