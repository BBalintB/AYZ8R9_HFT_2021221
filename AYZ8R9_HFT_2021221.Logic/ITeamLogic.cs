using AYZ8R9_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYZ8R9_HFT_2021221.Logic
{
    public interface ITeamLogic
    {
        Team GetTeam(int id);
        void ChangeTeamName(int id, string newName);
        void ChangeCoach(int id, string newCoach);
        void CreateTeam(Team NewTeam);
        void DeleteTeam(int id);
        IEnumerable<Team> GetAllTeams();
    }
}
