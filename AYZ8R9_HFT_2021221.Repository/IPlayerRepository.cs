using AYZ8R9_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYZ8R9_HFT_2021221.Repository
{
    public interface IPlayerRepository:IRepository<Player>
    {
        void ChangeName(int id, string newName);//change the name of the player
        void ChangeJerseyNumber(int id, int number);//change the jersey number
        void Change(Player player);//change by object
    }
}
