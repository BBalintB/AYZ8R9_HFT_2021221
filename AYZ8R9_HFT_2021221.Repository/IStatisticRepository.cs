using AYZ8R9_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYZ8R9_HFT_2021221.Repository
{
    public interface IStatisticRepository:IRepository<Statistic>
    {
        void ChangeTouchdowns(int id, int newScore);//change the touchdowns
        void ChangePassingyard(int id, int newPYards);// change the passing yards
        void ChangeRushingyard(int id, int newRuYards);//change the rushing yards
        void ChangeRecievingyard(int id, int newReYards);//change the recieving yards
        void Change(Statistic other);
    }
}
