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
    public class PlayerLogic : IPlayerLogic
    {
        #region CRUD
        IPlayerRepository playerRepo;
        ITeamRepository teamRepository;
        IStatisticRepository statisticRepository;
        public PlayerLogic(IPlayerRepository playerRepos, ITeamRepository teamRepository, IStatisticRepository statisticRepository)
        {
            this.playerRepo = playerRepos;
            this.teamRepository = teamRepository;
            this.statisticRepository = statisticRepository;
        }
        public void ChangeJerseyNumber(int id, int number)
        {
            if (!TheSame(id))
            {
                throw new WrongIdException("[Err] The id is not correct...");
            }
            else if (number < 1 || number > 99)
            {
                throw new JerseyNumberIsNotGoodException("[Err] The jersey number is not good....");
            }
            else {
                playerRepo.ChangeJerseyNumber(id, number);
            }
            
        }

        public void ChangeName(int id, string newName)
        {
            if (!TheSame(id))
            {
                throw new WrongIdException("[Err] The id is not correct...");
            }
            else if (newName == "")
            {
                throw new NameIsEmptyException("[Err] The name is empty....");
            }
            else {
                playerRepo.ChangeName(id, newName);
            }
        }

        public void CreatePlayer(Player NewPlayer)
        {
            
            if (TheSame(NewPlayer))
            {
                throw new AlreadyExistException("[Err] The player is already exist...");
            }
            playerRepo.Create(NewPlayer);
        }

        bool TheSame(Player player) {
            bool theSame = false;
            foreach (var item in playerRepo.GetAll())
            {
                if (item.PlayerName == player.PlayerName && item.PlayerJerseyNumber == player.PlayerJerseyNumber && item.Position == player.Position && item.Age == player.Age)
                {
                    theSame = true;
                }
            }
            return theSame;
        }

        public void Delete(int id)
        {
            if (!TheSame(id))
            {
                throw new ItDoesNotExistException("[Err] The player is not exist...");
            }
            playerRepo.Delete(id);
        }
        bool TheSame(int id)
        {
            bool notTheSame = false;
            foreach (var item in playerRepo.GetAll())
            {
                if (item.PlayerId == id)
                {
                    notTheSame = true;
                }
            }
            return notTheSame;
        }

        public IEnumerable<Player> GetAllPlayers()
        {
            return playerRepo.GetAll();
        }

        public Player GetPlayer(int id)
        {
            if (!TheSame(id))
            {
                throw new WrongIdException("[Err] The id is not correct...");
            }
            return playerRepo.GetOne(id);
        }
        #endregion
        #region Non-CRUD
        public IEnumerable<Player> MostReceivingYards()
        {
            int yard = statisticRepository.GetAll().Max(yards => yards.ReceivingYards);
            var mostReYard = from x in playerRepo.GetAll()
                            where x.Stat.ReceivingYards.Equals(yard)
                            select x;
            ;
            return mostReYard;
        }

        public IEnumerable<Player> MostPassingYards()
        {
            var yard = statisticRepository.GetAll().Max(yards => yards.PassingYards);
            var mostPaYard = from x in playerRepo.GetAll()
                            where x.Stat.PassingYards == yard
                            select x;
            return mostPaYard;
        }

        public IEnumerable<Player> MostRushingYards()
        {
            var yard = statisticRepository.GetAll().Max(yards => yards.RushingYards);
            var mostRuYard = from x in playerRepo.GetAll()
                             where x.Stat.RushingYards == yard
                             select x;
            return mostRuYard;
        }

        public IEnumerable<Player> MostTouchdowns()
        {
            var TD = statisticRepository.GetAll().Max(touchdown => touchdown.Touchdowns);
            var mostTD = from x in playerRepo.GetAll()
                             where x.Stat.Touchdowns == TD
                             select x;
            return mostTD;
        }

        public IEnumerable<Player> PlayersByTeam(string name)
        {
            if (!TheSame(name))
            {
                throw new ItDoesNotExistException($"The team with the name: {name} does not exist..");
            }
            var team = from x in playerRepo.GetAll()
                        where x.Teams.TeamName == name
                        select x;
            return team;
        }
        bool TheSame(string name)
        {
            bool notTheSame = false;
            foreach (var item in teamRepository.GetAll())
            {
                if (item.TeamName == name)
                {
                    notTheSame = true;
                }
            }
            return notTheSame;
        }
        #endregion
    }
}
