using AYZ8R9_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYZ8R9_HFT_2021221.Repository
{
    public interface ITeamRepository:IRepository<Team>
    {
        void ChangeName(int id, string newName);//change the team name
        void Changecoach(int id, string newCoach);//change the coach name
    }
}
