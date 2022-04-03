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
    public class TeamLogic : ITeamLogic
    {
        ITeamRepository teamRepo;
        public TeamLogic(ITeamRepository teamRepo)
        {
            this.teamRepo = teamRepo;
        }
        public void ChangeCoach(int id, string newCoach)
        {
            if (!TheSame(id))
            {
                throw new WrongIdException("[Err] The id is not correct...");
            }
            else if (newCoach == "")
            {
                throw new NameIsEmptyException("[Err] The name is empty....");
            }
            else
            {
                teamRepo.Changecoach(id, newCoach);
            }
        }

        public void ChangeTeamName(int id, string newName)
        {
            if (!TheSame(id))
            {
                throw new WrongIdException("[Err] The id is not correct...");
            }
            else if (newName == "")
            {
                throw new NameIsEmptyException("[Err] The name is empty....");
            }
            else
            {
                teamRepo.ChangeName(id, newName);
            }
        }

        public void Change(Team stat)
        {
            teamRepo.Change(stat);
        }

        public void CreateTeam(Team NewTeam)
        {
            if (TheSame(NewTeam))
            {
                throw new AlreadyExistException("[Err] The team is already exist...");
            }
            teamRepo.Create(NewTeam);
        }
        bool TheSame(Team team)
        {
            bool theSame = false;
            foreach (var item in teamRepo.GetAll())
            {
                if (item.City == team.City && item.Division == team.Division && item.Stadium == team.Stadium && item.HeadCoach == team.HeadCoach)
                {
                    theSame = true;
                }
            }
            return theSame;
        }

        public void DeleteTeam(int id)
        {
            if (!TheSame(id))
            {
                throw new ItDoesNotExistException("[Err] The team is not exist...");
            }
            teamRepo.Delete(id);
        }

        bool TheSame(int id)
        {
            bool theSame = false;
            foreach (var item in teamRepo.GetAll())
            {
                if (item.TeamId == id)
                {
                    theSame = true;
                }
            }
            return theSame;
        }

        public IEnumerable<Team> GetAllTeams()
        {
            return teamRepo.GetAll();
        }

        public Team GetTeam(int id)
        {
            if (!TheSame(id))
            {
                throw new WrongIdException("[Err] The id is not correct...");
            }
            return teamRepo.GetOne(id);
        }
    }
}
